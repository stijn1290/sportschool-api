using Microsoft.AspNetCore.Mvc;
using sportschool.Models;
using System.Collections.Generic;
using System.Linq;

namespace sportschool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<Subscription> subscriptions;
        private static List<User> users;

        // Static constructor om alles correct te initialiseren
        static UserController()
        {
            subscriptions = new List<Subscription>
            {
                new() { Id = 0, Name = "Unlimited", SubscriptionType = Subscription.Type.Unlimited },
                new() { Id = 1, Name = "1 keer in de week", SubscriptionType = Subscription.Type.One },
                new() { Id = 2, Name = "2 keer in de week", SubscriptionType = Subscription.Type.Two }
            };

            users = new List<User>
            {
                new() { Id = 0, Name = "John Doe", SubscriptionId = 1, Subscription = subscriptions[1] },
                new() { Id = 1, Name = "Jane Smith", SubscriptionId = 2, Subscription = subscriptions[2] },
                new() { Id = 2, Name = "Johanna Wilson", SubscriptionId = 0, Subscription = subscriptions[0] }
            };
        }

        // GET: api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(users);
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        // POST api/<ValuesController>
        [HttpPost]
        public void MakeAppointmentWithPersonalTrainer([FromBody] string value)
        {
        }
    }
}
