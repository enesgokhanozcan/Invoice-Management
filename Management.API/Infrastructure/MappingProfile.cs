using AutoMapper;
using Management.Model.Apartment;
using Management.Model.User;

namespace Management.API.Infrastructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, Management.DB.Entities.User>();
            CreateMap<Management.DB.Entities.User,UserViewModel >();
            CreateMap<ApartmentViewModel, Management.DB.Entities.Apartment>();
            CreateMap<Management.DB.Entities.Apartment, ApartmentViewModel>();
        }   
    }
}
