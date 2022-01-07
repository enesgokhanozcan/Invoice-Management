using AutoMapper;
using Management.Model;
using Management.Model.User;
using Management.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService,IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }
        [HttpPost]
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

    }
}
