using ClinicManagementSystem.Core.Common;

namespace ClinicManagementSystem.Core.Entities
{
    public class DoctorSchedule : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; set; } // Sunday, Monday...

        public TimeSpan StartTime { get; set; } // 09:00:00
        public TimeSpan EndTime { get; set; }   // 17:00:00
        public bool IsAvailable { get; set; } = true;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}