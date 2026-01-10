using AutoMapper;
using ClinicManagementSystem.Api.Dtos.Doctor;
using ClinicManagementSystem.Api.Dtos.Patient;
using ClinicManagementSystem.Core.Entities;

namespace ClinicManagementSystem.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateDoctorDto, Doctor>();

            CreateMap<Doctor, CreateDoctorDto>();

            CreateMap<Doctor, DoctorDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));

            CreateMap<CreatePatientDto, Patient>();

            CreateMap<Patient, CreatePatientDto>();

            CreateMap<PatientDto, Patient>();

            CreateMap<Patient, PatientDto>();
        }
    }
}