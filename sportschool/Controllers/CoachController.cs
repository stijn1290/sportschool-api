using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportschool.Data;
using sportschool.Models;

namespace sportschool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        // GET: api/coach
        [HttpGet]
        public ActionResult<IEnumerable<Coach>> Get()
        {
            return Ok(DataSportschool.coaches);
        }
        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<Coach> Get(int id)
        {
            var coach = DataSportschool.coaches.FirstOrDefault(c => c.Id == id);
            if (coach == null) return NotFound();
            return Ok(coach);
        }
        public class AppointmentRequestDto
        {

            public int CoachId { get; set; }
            public int UserId { get; set; }
        }
        // POST api/makeappointmentwithpersonaltrainer
        [HttpPost("makeAppointment")]
        public IActionResult MakeAppointmentWithPersonalTrainer([FromBody] AppointmentRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            var coach = DataSportschool.coaches.FirstOrDefault(c => c.Id == request.CoachId);
            var user = DataSportschool.users.FirstOrDefault(u => u.Id == request.UserId);

            if (coach == null || user == null)
                return NotFound("One or both users not found");

            var appointment = new Appointment
            {
                Id = DataSportschool.appointments.Count + 1,
                Coach = coach,
                User = user,
            };

            DataSportschool.appointments.Add(appointment);

            return Ok(new
            {
                Message = "Appointment created",
                AppointmentId = appointment.Id,
                Coach = coach.Name,
                User = user.Name,
            });
        }
    }
}
