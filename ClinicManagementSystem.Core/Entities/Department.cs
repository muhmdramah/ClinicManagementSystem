using ClinicManagementSystem.Core.Common;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClinicManagementSystem.Core.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } // e.g. Ophthalmology, Dentistry
        public string Description { get; set; }

        // Navigation Property: القسم فيه دكاترة كتير
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}