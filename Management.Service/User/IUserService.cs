using Management.Model;
using Management.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service.User
{
    public interface IUserService
    {
        public General<UserViewModel> Login(UserLoginModel loginUser);
        public General<UserViewModel> Insert(UserViewModel newUser);
        public General<UserViewModel> Update(int id, UserViewModel userUpdate);
        public General<UserViewModel> Delete(int id);
    }
}
