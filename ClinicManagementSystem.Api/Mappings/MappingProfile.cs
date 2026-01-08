using AutoMapper;
using ClinicManagementSystem.Api.Dtos;
using ClinicManagementSystem.Core.Entities;

namespace ClinicManagementSystem.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateDoctorDto, Doctor>();

            CreateMap<Doctor, CreateDoctorDto>();
        }
    }
}