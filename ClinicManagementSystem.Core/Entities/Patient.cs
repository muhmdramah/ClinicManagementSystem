using ClinicManagementSystem.Core.Common;
using ClinicManagementSystem.Core.Enums;

namespace ClinicManagementSystem.Core.Entities
{
    public class Patient : BaseEntity
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }

        // Patient has many appointments
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}