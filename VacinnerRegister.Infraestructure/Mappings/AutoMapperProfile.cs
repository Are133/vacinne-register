using AutoMapper;
using VacinneRegister.Core.DTOs;
using VacinneRegister.Core.Entities;

namespace VacinnerRegister.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTo>();
            CreateMap<UserDTo, User>();
        }
    }
}
