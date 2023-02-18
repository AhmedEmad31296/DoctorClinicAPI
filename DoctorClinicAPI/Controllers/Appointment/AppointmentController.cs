using MediatR;
using Microsoft.AspNetCore.Mvc;
using DoctorClinic.Services.CommandHandlers;
using DoctorClinic.Utilities.DTOs.ResultViewModel;
using DoctorClinic.Utilities.DTOs.Appointment.Command;
using DoctorClinic.Services.QueryHandlers;

namespace DoctorClinicAPI.Controllers.Appointment
{


    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Doctor Appointment
        /// </summary>
        // POST api/Appointment/CreateDoctorAppointment
        [HttpPost]
        public async Task<IActionResult> CreateDoctorAppointment(CreateAppointmentInput input)
        {
            ResultViewModel _resultViewModel = new();
            CreateAppointmentCommand appointment = new()
            {
                DayOfWeek = input.DayOfWeek,
                From = TimeOnly.FromDateTime(input.From),
                To = TimeOnly.FromDateTime(input.To)
            };

            var response = await _mediator.Send(appointment);
            if (response)
            {
                _resultViewModel.Message = "تم اضافة ميعاد جديد بنجاح";
                _resultViewModel.ResultView = ResultViewEnum.Success;
            }
            else
            {
                _resultViewModel.Message = "لا يمكن إجراء موعدين في نفس الوقت في هذا اليوم";
            }
            return response ? Ok(_resultViewModel) : BadRequest(_resultViewModel);
        }

        /// <summary>
        /// Create Doctor Appointment
        /// </summary>
        // POST api/Appointment/GetDoctorAppointments
        [HttpGet]
        public async Task<IActionResult> GetDoctorAppointments()
        {
            ResultViewModel _resultViewModel = new();
            List<GetAppointmentsOutput> response = await _mediator.Send(new GetAppointmentsQuery());
            if (response is not null)
            {
                _resultViewModel.ResultView = ResultViewEnum.Success;
                _resultViewModel.Data = response;
            }
            else
            {
                _resultViewModel.ResultView = ResultViewEnum.Success;
                _resultViewModel.Message = "لا يوجد مواعيد متاحة";
                _resultViewModel.Data = new List<GetAppointmentsOutput>();
            }
            return response is not null ? Ok(_resultViewModel) : NotFound(_resultViewModel);

        }
    }
}
