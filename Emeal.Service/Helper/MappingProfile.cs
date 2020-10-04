using AutoMapper;
using Emeal.EFCore.Models;
using Emeal.Model;

namespace Emeal.Service.Startup
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}