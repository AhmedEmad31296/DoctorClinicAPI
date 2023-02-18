using DoctorClinic.Utilities.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinic.Utilities.DTOs.PatientReservation.Commands
{
    public class CreatePatientReservationDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReservationTime { get; set; }
        public string Note { get; set; }
        public int AppointmentId { get; set; }
    }
}
