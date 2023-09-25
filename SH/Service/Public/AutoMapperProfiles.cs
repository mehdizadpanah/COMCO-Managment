using AutoMapper;
using SH.Data.ModelVM;

namespace SH.Service.Public;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ProgramUserVm, ProgramUserVm>(); // Replace 'Model' with your actual model class
    }
}