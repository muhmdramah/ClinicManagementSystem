using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicManagementSystem.Core.Enums
{
    public enum AppointmentStatus
    {
        Pending = 1,    // انتظار التأكيد
        Confirmed = 2,  // تم تأكيد الحجز
        Completed = 3,  // تم الكشف
        Cancelled = 4   // ملغي
    }
}