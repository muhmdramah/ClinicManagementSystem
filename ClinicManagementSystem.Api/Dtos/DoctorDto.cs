namespace ClinicManagementSystem.Api.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public decimal ConsultationFee { get; set; }
        public string Phone { get; set; }

        public string DepartmentName { get; set; }
    }
}