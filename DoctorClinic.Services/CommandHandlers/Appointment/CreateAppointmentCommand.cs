using DoctorClinic.Domain;
using DoctorClinic.Models;
using MediatR;

using Microsoft.EntityFrameworkCore;

namespace DoctorClinic.Services.CommandHandlers
{
    // Command
    public class CreateAppointmentCommand : IRequest<bool>
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; }
    }
    // Handler
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, bool>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<bool> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            
            bool isExistingAppointment = await _appointmentRepository.GetAll()
                .AnyAsync(x => x.IsActive && !x.IsDeleted && request.DayOfWeek == x.DayOfWeek && (request.From > x.From && request.To < x.To) || (request.To < x.To && request.To > x.From));
            
            if (isExistingAppointment)
                return false;

            var newAppointment = new Appointment
            {
                DayOfWeek = request.DayOfWeek,
                From = request.From,
                To = request.To,
            };
            return await _appointmentRepository.InsertAsync(newAppointment);


        }
    }

}
