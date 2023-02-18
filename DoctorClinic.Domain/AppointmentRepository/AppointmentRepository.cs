using DoctorClinic.Models;
using DoctorClinic.PostgresDb;
using DoctorClinic.Utilities.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinic.Domain
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {

        public AppointmentRepository(DoctorClinicDbContext context) : base(context)
        {

        }
       
    }
}
