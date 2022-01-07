using AutoMapper;
using Management.DB.Entities.DataContext;
using Management.Model;
using Management.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public General<UserViewModel> Insert(UserViewModel newUser)
        {
            var result = new General<UserViewModel>() { IsSucces = false };
            var model = mapper.Map<Management.DB.Entities.User>(newUser);
            using (var srv = new ManagementContext())
            {
                model.Idatetime = DateTime.Now;
                srv.User.Add(model);
                srv.SaveChanges();
                result.Entity = mapper.Map<UserViewModel>(model);
                result.IsSucces = true;
            }
            return result;
        }

        public General<UserViewModel> Login(UserLoginModel loginUser)
        {
            General<UserViewModel> result = new();

            using (var srv = new ManagementContext())
            {
                var data = srv.User.FirstOrDefault(x =>x.Email == loginUser.Email && x.Password == loginUser.Password);
                if (data is not null)
                {
                    result.IsSucces = true;
                    result.Entity = mapper.Map<UserViewModel>(data);
                    result.SuccesMessage = "Giriş işlemi başarıyla gerçekleşmiştir.";
                }
            }

            return result;
        }

        public General<UserViewModel> Update(int id, UserViewModel userUpdate)
        {
            var result = new General<UserViewModel>();
            using (var srv = new ManagementContext())
            {
                var data = srv.User.SingleOrDefault(i => i.Id == id);
                if (data is not null)
                {
                    data.Name = userUpdate.Name;
                    data.Surname = userUpdate.Surname;
                    data.Tcno = userUpdate.Tcno;
                    data.Email = userUpdate.Email;
                    data.Password = userUpdate.Password;
                    data.PlateCode = userUpdate.PlateCode;
                    data.PhoneNumber = userUpdate.PhoneNumber;
                    data.Idatetime = DateTime.Now;
                    srv.SaveChanges();
                    result.Entity = mapper.Map<UserViewModel>(userUpdate);
                    result.IsSucces = true;
                }
                else
                {
                    result.BadMessage = "Kullanıcı güncellenemedi.";
                }
            }
            return result;

        }

        public General<UserViewModel> Delete(int id)
        {
            var result = new General<UserViewModel>();
            using (var srv = new ManagementContext())
            {
                var data = srv.User.SingleOrDefault(i => i.Id == id);
                if (data is not null)
                {
                    srv.User.Remove(data);
                    srv.SaveChanges();
                    result.Entity = mapper.Map<UserViewModel>(data);
                    result.IsSucces = true;
                }
                else
                {
                    result.BadMessage = "Kullanıcı silinemedi.";
                }
            }
            return result;
        }

        public General<UserViewModel> GetUsers()
        {
            var result = new General<UserViewModel>();
            using (var srv = new ManagementContext())
            {
                var data=srv.User.OrderBy(i => i.Id);
                if (data.Any())
                {
                    result.List = mapper.Map<List<UserViewModel>>(data);
                    result.IsSucces = true;
                }
                else
                {
                    result.BadMessage = "Kullanıcı bulunamadı.";
                }
            }
            return result;
        }
    }
}
