using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportschool.Data;
using sportschool.Models;
using System.Collections.Generic;

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

            if (DataSportschool.appointments.Any(a => a.Coach.Id == request.CoachId && a.User.Id == request.UserId))
                return BadRequest("User has already booked this coach.");

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
        // GET api/coach/{id}/appointments
        [HttpGet("{id}/appointments")]
        public ActionResult<IEnumerable<object>> GetCoachAppointments(int id)
        {
            var coach = DataSportschool.coaches.FirstOrDefault(c => c.Id == id);
            if (coach == null) return NotFound();

            var bookedUsers = DataSportschool.appointments
                .Where(a => a.Coach.Id == id)
                .Select(a => new { a.User.Id, a.User.Name })
                .ToList();

            return Ok(bookedUsers);
        }


    }
}
