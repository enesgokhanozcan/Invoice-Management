using Management.Model.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Management.API.Infrastructure
{
    public class AuthFilter : Attribute, IActionFilter
    {
        private readonly IMemoryCache memoryCache;
        public AuthFilter(IMemoryCache _memoryCache)
        {
            memoryCache = _memoryCache;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            {
                if (!memoryCache.TryGetValue(key: $"AuthUser", out UserViewModel admin))
                {
                    context.Result = new BadRequestObjectResult("Lütfen admin olarak giriş yapınız.");
                }
                return;
            }
        }
    }
}
