using DoctorClinic.Models;
using DoctorClinic.PostgresDb;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinic.Domain
{
    public class PatientReservationRepository : BaseRepository<PatientReservation>, IPatientReservationRepository
    {
        public PatientReservationRepository(DoctorClinicDbContext context) : base(context)
        {

        }
    }
}
