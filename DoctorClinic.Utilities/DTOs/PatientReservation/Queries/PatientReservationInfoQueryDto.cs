using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinic.Utilities.DTOs.PatientReservation.Queries
{
    public class PatientReservationInfoQueryDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ReservationTime { get; set; }
        public string Note { get; set; }
        public string ReservationAppointment { get; set; }
    }
}
