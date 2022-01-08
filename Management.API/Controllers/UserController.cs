using AutoMapper;
using Management.API.Infrastructure;
using Management.Model;
using Management.Model.User;
using Management.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService,IMapper _mapper, IMemoryCache _memoryCache) : base(_memoryCache)
        {
            userService = _userService;
            mapper = _mapper;
        }
        [HttpPost]
        [ServiceFilter(typeof(LoginFilter))]
        public General<UserViewModel>Insert([FromBody] UserViewModel newUser)
        {
            return userService.Insert(newUser);
        }
        [HttpPut("{id}")]
        public General<UserViewModel> Update(int id, [FromBody] UserViewModel userUpdate)
        {
            return userService.Update(id, userUpdate);
        }
        [HttpDelete("{id}")]
        public General<UserViewModel> Delete(int id)
        {
            return userService.Delete(id);
        }
        [HttpGet]
        public General<UserViewModel> GetUsers()
        {
            return userService.GetUsers();
        }

    }
}
