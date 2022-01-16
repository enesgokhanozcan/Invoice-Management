using AutoMapper;
using Management.API.Infrastructure;
using Management.Model;
using Management.Model.Apartment;
using Management.Service.Apartment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : BaseController
    {
        private readonly IApartmentService apartmentService;
        private readonly IMapper mapper;
        public ApartmentController(IApartmentService _apartmentService, IMapper _mapper, IMemoryCache _memoryCache) : base(_memoryCache)
        {
            apartmentService = _apartmentService;
            mapper = _mapper;
        }
        [HttpPost]
        [ServiceFilter(typeof(LoginFilter))]
        public General<ApartmentInsertModel> Insert([FromBody] ApartmentInsertModel newApartment)
        {
            newApartment.Iuser = CurrentUser.Id;
            return apartmentService.Insert(newApartment);
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(LoginFilter))]
        public General<ApartmentUpdateModel> Update(int id, [FromBody] ApartmentUpdateModel apartmentUpdate)
        {
            return apartmentService.Update(id, apartmentUpdate);
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(LoginFilter))]
        public General<ApartmentViewModel> Delete(int id)
        {
            return apartmentService.Delete(id);
        }
        [HttpGet]
        public General<ApartmentViewModel> ListApartment()
        {
            return apartmentService.ListApartment();
        }
        [HttpGet("{id}")]
        public General<ApartmentViewModel> GetById(int id)
        {
            return apartmentService.GetById(id);
        }
    }
}
