using AutoMapper;
using IspProject.DTOs;
using IspProject.Models;

namespace IspProject.Settings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserCreationDTO, User>();
            
            
        }
    }
}
