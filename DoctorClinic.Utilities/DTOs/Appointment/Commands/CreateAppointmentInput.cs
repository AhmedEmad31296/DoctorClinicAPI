using DoctorClinic.Utilities.Helpers;
using System.Text.Json.Serialization;

namespace DoctorClinic.Utilities.DTOs.Appointment.Command
{
    public class CreateAppointmentInput
    {
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
