namespace ClinicManagementSystem.Api.Dtos.Schedule
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}