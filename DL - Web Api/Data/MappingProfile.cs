using AutoMapper;
using SH.Data.ModelVM.Authentication;
using DL___Web_Api.Model.Models;
namespace DL___Web_Api.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Session, SessionVM>();
        }
    }
}
