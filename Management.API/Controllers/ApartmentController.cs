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
        public General<ApartmentInsertModel> Insert([FromBody] ApartmentInsertModel newApartment)
        {
            return apartmentService.Insert(newApartment);
        }
        [HttpPut("{id}")]
        public General<ApartmentUpdateModel> Update(int id, [FromBody] ApartmentUpdateModel apartmentUpdate)
        {
            return apartmentService.Update(id, apartmentUpdate);
        }
        [HttpDelete("{id}")]
        public General<ApartmentViewModel> Delete(int id)
        {
            return apartmentService.Delete(id);
        }
        [HttpGet]
        public General<ApartmentViewModel> ListApartment()
        {
            return apartmentService.ListApartment();
        }
    }
}
