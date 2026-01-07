using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicManagementSystem.Core.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        // ممكن نضيف هنا CreatedAt, UpdatedAt لو حابب تتبع التواريخ
    }
}