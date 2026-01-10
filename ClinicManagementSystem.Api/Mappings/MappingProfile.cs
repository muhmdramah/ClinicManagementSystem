using AutoMapper;
using ClinicManagementSystem.Api.Dtos;
using ClinicManagementSystem.Api.Dtos.Appointment;
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


            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName));
        }
    }
}