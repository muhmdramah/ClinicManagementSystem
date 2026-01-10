using ClinicManagementSystem.Core.Enums;

namespace ClinicManagementSystem.Api.Dtos.Patient
{
    public class PatientDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
    }
}
