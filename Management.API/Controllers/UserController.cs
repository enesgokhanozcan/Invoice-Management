using AutoMapper;
using Management.API.Infrastructure;
using Management.Model;
using Management.Model.User;
using Management.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Security.Claims;

namespace Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService,IMapper _mapper, IMemoryCache _memoryCache)
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
        [HttpGet]
        //[Authorize(Roles ="True")]
        public General<UserViewModel> GetUsers()
        {
            var currentUser=GetCurrentUser();
            return userService.GetUsers();
        }
        [HttpGet("Admins")]
        [Authorize]
        public IActionResult AdminsEndpoints()
        {
            var currentUser=GetCurrentUser();
            return Ok($"Hi {currentUser.Entity.Email},{currentUser.Entity.Name}- {currentUser.Entity.Surname}-{currentUser.Entity.IsAdmin}");
        }
        private General<UserViewModel> GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var result = new General<UserViewModel>();
            if (identity != null)
            {
                var userClaims=identity.Claims;
                var user = new UserViewModel
                {
                    //Id=int.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.SerialNumber)?.Value),
                    //IsAdmin =bool.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value),
                    Email =userClaims.FirstOrDefault(o=>o.Type == ClaimTypes.Email)?.Value,
                    Name = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                };
                result.Entity = user;
                result.IsSucces = true;
            }
            return result;
        }

    }
}
