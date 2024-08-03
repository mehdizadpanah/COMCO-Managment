using AutoMapper;
using DL.Models.DataModels;
using SH.Data.ModelVM.Authentication;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserSessionVM, UserSession>();
    }
}