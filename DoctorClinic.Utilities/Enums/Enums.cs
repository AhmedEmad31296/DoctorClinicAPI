using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinic.Utilities.Enums
{
    // حالة الحجز
    public enum ReservationStatus
    {
        [Description("الحجز معلق")]
        Pending = 0,
        [Description("تم الكشف")]
        Completed = 1,
        [Description("إلغاء الحجز")]
        Cancelled = 2
    }
}
