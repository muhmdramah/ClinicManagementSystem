using ClinicManagementSystem.Core.Common;
using ClinicManagementSystem.Core.Enums;

namespace ClinicManagementSystem.Core.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTime AppointmentDate { get; set; } // تاريخ ووقت الحجز
        public string Note { get; set; } // شكوى المريض المبدئية
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        // Foreign Keys
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}