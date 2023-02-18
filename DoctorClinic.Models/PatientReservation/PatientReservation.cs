using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorClinic.Utilities.Enums;

namespace DoctorClinic.Models
{
    [Table(nameof(PatientReservation) + "s")]
    public class PatientReservation
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public string Note { get; set; }

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}
