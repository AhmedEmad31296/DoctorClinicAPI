using DoctorClinic.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinic.Services.QueryHandlers
{
    //Query
    public class PatientReservationInfoQuery
    {
       
    }
    public class GetPatientReservationsOutput
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public string ReservationAppointment { get; set; }
    }
    public class GetPatientReservationsQuery : IRequest<List<GetPatientReservationsOutput>>
    {


    }
    //Handler
    public class GetPatientReservationsQueryHandler : IRequestHandler<GetPatientReservationsQuery , List<GetPatientReservationsOutput>>
    {
       
        private readonly IPatientReservationRepository _patientReservationRepository;

        public GetPatientReservationsQueryHandler(IPatientReservationRepository patientReservationRepository)
        {
            _patientReservationRepository = patientReservationRepository;
        }
        public async Task<List<GetPatientReservationsOutput>> Handle(GetPatientReservationsQuery request, CancellationToken cancellationToken)
        {
            var patientReservations = await _patientReservationRepository.GetAll()
                .Select(p => new GetPatientReservationsOutput
                {
                    Name = p.Name,
                    PhoneNumber = p.PhoneNumber,
                    Note = p.Note,
                    ReservationAppointment = p.Appointment.DayOfWeek.ToString() + " From " + p.Appointment.From.ToShortTimeString() + " TO " + p.Appointment.To.ToShortTimeString(),
                }).ToListAsync();
            return patientReservations;
        }


    }
}
