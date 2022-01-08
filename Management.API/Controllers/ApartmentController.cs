using Management.API.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : BaseController
    {
        public ApartmentController(IMemoryCache _memoryCache) : base(_memoryCache)
        {
        }
    }
}
