using DoctorClinic.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinic.PostgresDb
{
    public class DoctorClinicDbContext : DbContext
    {
        public DoctorClinicDbContext(DbContextOptions<DoctorClinicDbContext> options) : base(options) { }
        
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<PatientReservation> PatientReservations { get; set; }
    }
}
