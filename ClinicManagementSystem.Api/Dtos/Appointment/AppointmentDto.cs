namespace ClinicManagementSystem.Api.Dtos
{
    public class AppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public string Note { get; set; }

        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}