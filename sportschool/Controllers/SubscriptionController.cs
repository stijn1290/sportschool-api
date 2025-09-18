using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportschool.Data;
using sportschool.Models;

namespace sportschool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        [HttpGet]
        public ActionResult <User> Get(int id)
        {
            var user = DataSportschool.users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            if (user.Subscription == null) return BadRequest("");
            return Ok(user.Subscription.SubscriptionType);
        }
    }
}
