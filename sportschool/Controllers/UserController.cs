using Microsoft.AspNetCore.Mvc;
using sportschool.Data;
using sportschool.Models;
using System.Collections.Generic;
using System.Linq;

namespace sportschool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Static constructor om alles correct te initialiseren

        // GET: api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(DataSportschool.users);
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = DataSportschool.users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        public class AppointmentRequestDto
        {

            public int User1Id { get; set; }
            public int User2Id { get; set; }
        }
        // POST api/makeappointmentwithpersonaltrainer
        [HttpPost("makeAppointment")]
        public IActionResult MakeAppointmentWithPersonalTrainer([FromBody] AppointmentRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            var user1 = DataSportschool.users.FirstOrDefault(u => u.Id == request.User1Id);
            var user2 = DataSportschool.users.FirstOrDefault(u => u.Id == request.User2Id);

            if (user1 == null || user2 == null)
                return NotFound("One or both users not found");

            var appointment = new Appointment
            {
                Id = DataSportschool.appointments.Count + 1,
                User1 = user1,
                User2 = user2,
            };
            if (user2.Role != Models.User.Roles.Personal_trainer)
            {
                return BadRequest("User is not a personal trainer");
            }

            DataSportschool.appointments.Add(appointment);

            return Ok(new
            {
                Message = "Appointment created",
                AppointmentId = appointment.Id,
                User1 = user1.Name,
                User2 = user2.Name,
            });
        }
    }
}
