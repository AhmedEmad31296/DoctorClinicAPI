using DoctorClinic.Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;
using DoctorClinic.Utilities.DTOs.ResultViewModel;

namespace DoctorClinic.Services.QueryHandlers
{
    //Query
    public class GetAppointmentsOutput
    {
        public int Id { get; set; }
        public string ReservationTime { get; set; }
        public string Day { get; set; }
    }
    public class GetAppointmentsQuery : IRequest<List<GetAppointmentsOutput>>
    {


    }
    //Handler
    public class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQuery, List<GetAppointmentsOutput>>
    {

        private readonly IAppointmentRepository _appointmentRepository;
        public GetAppointmentsQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<List<GetAppointmentsOutput>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
        {
            List<GetAppointmentsOutput> appointments = await _appointmentRepository.GetAll()
                .Select(a => new GetAppointmentsOutput
                {
                    Id = a.Id,
                    Day = a.DayOfWeek.ToString(),
                    ReservationTime = " From " + a.From.ToShortTimeString() + " TO " + a.To.ToShortTimeString(),
                }).ToListAsync();
            return appointments;
        }

    }
}
