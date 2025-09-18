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
    }
}
