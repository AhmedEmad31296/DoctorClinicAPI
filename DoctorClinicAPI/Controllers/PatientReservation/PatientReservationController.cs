using MediatR;
using Microsoft.AspNetCore.Mvc;
using DoctorClinic.Services.CommandHandlers;
using DoctorClinic.Utilities.DTOs.ResultViewModel;
using DoctorClinic.Services.QueryHandlers;

namespace DoctorClinicAPI.Controllers.PatientReservation
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PatientReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Create Patient Reservation
        /// </summary>
        // POST api/PatientReservation/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientReservationCommand patientReservation)
        {
            ResultViewModel _resultViewModel = new();
            var response = await _mediator.Send(patientReservation);
            if (!response)
            {
                _resultViewModel.Message = "لا يمكن حجز اكثر من حالتين في نفس الميعاد";
            }
            else
            {
                _resultViewModel.Message = "تم الحجز بنجاح";
                _resultViewModel.ResultView = ResultViewEnum.Success;
            }
            return response ? Ok(_resultViewModel) : BadRequest(_resultViewModel);
        }
        /// <summary>
        /// Create Patient Reservation
        /// </summary>
        // POST api/PatientReservation/GetReservations
        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            ResultViewModel _resultViewModel = new();
            var response = await _mediator.Send(new GetPatientReservationsQuery());
            if (response is not null)
            {
                _resultViewModel.ResultView = ResultViewEnum.Success;
                _resultViewModel.Data = response;
            }
            else
            {
                _resultViewModel.ResultView = ResultViewEnum.Success;
                _resultViewModel.Message = "لا يوجد حجوزات متاحة";
                _resultViewModel.Data = new List<GetAppointmentsOutput>();
            }
            return response is not null ? Ok(_resultViewModel) : NotFound(_resultViewModel);
        }
    }
}
