using DoctorClinic.Domain;
using DoctorClinic.Models;
using DoctorClinic.Utilities.DTOs.PatientReservation.Commands;
using DoctorClinic.Utilities.DTOs.ResultViewModel;
using DoctorClinic.Utilities.Enums;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace DoctorClinic.Services.CommandHandlers
{
    public class CreatePatientReservationCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public int AppointmentId { get; set; }

    }

    public class CreatePatientReservationCommandHandler : IRequestHandler<CreatePatientReservationCommand, bool>
    {
        private readonly IPatientReservationRepository patientReservationRepository;

        public CreatePatientReservationCommandHandler(
            IPatientReservationRepository patientReservationRepository
            )
        {
            this.patientReservationRepository = patientReservationRepository;
        }

        public async Task<bool> Handle(CreatePatientReservationCommand patientReservation, CancellationToken cancellationToken)
        {

            //The doctor can have only 2 overlapping appointments at any time 
            var patientReservationAtSameTimeCount = await patientReservationRepository.GetAll().AsNoTracking()
                .CountAsync(x => x.ReservationStatus == ReservationStatus.Pending && x.AppointmentId == patientReservation.AppointmentId);
            if (patientReservationAtSameTimeCount >= 2)
                return false;
            var newPatientReservation = new PatientReservation
            {
                AppointmentId = patientReservation.AppointmentId,
                Name = patientReservation.Name,
                PhoneNumber = patientReservation.PhoneNumber,
                ReservationStatus = ReservationStatus.Pending,
                Note = patientReservation.Note,
            };
            return await patientReservationRepository.InsertAsync(newPatientReservation);

        }
    }
}
