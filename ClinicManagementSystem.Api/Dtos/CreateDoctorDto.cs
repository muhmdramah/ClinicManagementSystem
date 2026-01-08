namespace ClinicManagementSystem.Api.Dtos
{
    public class CreateDoctorDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        public decimal ConsultationFee { get; set; }
        public int DepartmentId { get; set; } 
    }
}