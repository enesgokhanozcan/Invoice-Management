using AutoMapper;
using Management.Model.User;

namespace Management.API.Infrastructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, Management.DB.Entities.User>();
            CreateMap<Management.DB.Entities.User,UserViewModel >();
        }   
    }
}
