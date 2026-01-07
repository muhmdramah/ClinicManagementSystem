using ClinicManagementSystem.Core.Common;
using ClinicManagementSystem.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Core.Entities
{
    public class Doctor : BaseEntity
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } // Important for identity linking later

        public string Specialization { get; set; } // التخصص الدقيق
        public string Bio { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ConsultationFee { get; set; } // سعر الكشف

        // Foreign Key
        public int DepartmentId { get; set; }
        // Navigation Property
        public Department Department { get; set; }

        // Doctor has many appointments
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        // Doctor has schedules (مواعيد العمل)
        public ICollection<DoctorSchedule> Schedules { get; set; } = new List<DoctorSchedule>();
    }
}