using Microsoft.AspNetCore.Mvc;
using sportschool.Data;
using sportschool.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sportschool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursusController : ControllerBase
    {
        // GET: api/<CursusController>
        [HttpGet]
        public ActionResult<IEnumerable<Cursus>> Get()
        {
            return Ok(DataSportschool.cursussen);
        }

        // GET api/<CursusController>/5
        [HttpGet("{id}")]
        public ActionResult<Cursus> Get(int id)
        {
            var cursus = DataSportschool.cursussen.FirstOrDefault(u => u.Id == id);
            if (cursus == null) return NotFound();
            return Ok(cursus);
        }
        public class CursusBound
        {
            public int userId { get; set; }
            public string cursusName { get; set; }
        }
        // POST api/inschrijvencursus
        [HttpPost("inschrijvencursus")]
        public IActionResult InschrijvenCursus([FromBody] CursusBound cursus)
        {
            var user = DataSportschool.users.FirstOrDefault(u => u.Id == cursus.userId);
            var gevondenCursus = DataSportschool.cursussen.FirstOrDefault(c => c.Name == cursus.cursusName);
            if(gevondenCursus == null) return NotFound();
            if(user == null) return NotFound();

            if (gevondenCursus.Users.Any(u => u.Id == cursus.userId))
                return BadRequest("User is already enrolled in this course.");

            gevondenCursus.Users.Add(user);

            return Ok(new
            {
                message = $"{user.Name} je hebt je ingeschreven voor cursus: {cursus.cursusName}"
            });
        }
        // POST api/uitschrijvencursus
        [HttpPost("uitschrijvencursus")]
        public IActionResult UitschrijvenCursus([FromBody] CursusBound cursus)
        {
            var user = DataSportschool.users.FirstOrDefault(u => u.Id == cursus.userId);
            var gevondenCursus = DataSportschool.cursussen.FirstOrDefault(c => c.Name == cursus.cursusName);
            if (gevondenCursus == null) return NotFound();
            if (user == null) return NotFound();
            gevondenCursus.Users.Remove(user);

            return Ok($"{user.Name} je hebt je uitgeschreven voor cursus: {cursus.cursusName}");
        }
    }
}
