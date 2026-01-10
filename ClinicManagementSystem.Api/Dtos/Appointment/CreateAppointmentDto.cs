using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Api.Dtos.Appointment
{
    public class CreateAppointmentDto
    {
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public string Note { get; set; }
    }
}