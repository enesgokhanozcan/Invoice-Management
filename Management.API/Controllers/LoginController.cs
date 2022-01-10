using Management.Model;
using Management.Model.User;
using Management.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IUserService userService;

        public LoginController(IUserService _userService,IMemoryCache _memoryCache)
        {
            memoryCache= _memoryCache;
            userService= _userService;
        }
        [HttpPost]
        public General<bool> Login([FromBody] UserLoginModel loginUser)
        {
            General<bool> response = new() { Entity = false };
            General<UserViewModel> _response = userService.Login(loginUser);
            if (_response.IsSucces)
            {
                if (!memoryCache.TryGetValue(key: $"LoginUser", out UserViewModel _loginuser))
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(value: 1),
                        Priority = CacheItemPriority.Normal,
                    };
                    memoryCache.Set(key: $"LoginUser", _response.Entity);
                }
                response.Entity = true;
                response.IsSucces = true;
                response.SuccesMessage = "Giriş işlemi başarıyla gerçekleştirilmiştir.";
            }
            return response;
        }

    }
}
