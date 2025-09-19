using Microsoft.AspNetCore.Mvc;
using sportschool.Data;
using sportschool.Models;
using System.Globalization;

namespace sportschool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        // GET api/Subscription/5
        [HttpGet("{userId}")]
        public IActionResult GetSubscriptionByUserId(int userId)
        {
            var user = DataSportschool.users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();

            var sub = DataSportschool.subscriptions.FirstOrDefault(s => s.Id == user.SubscriptionId);
            if (sub == null) return NotFound();

            return Ok(sub);
        }

        // POST api/Subscription/checkin/5
        [HttpPost("checkin/{userId}")]
        public IActionResult CheckIn(int userId)
        {
            var user = DataSportschool.users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound("User not found");
            if (user.Subscription == null) return BadRequest("User has no subscription");

            int currentWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                DateTime.Now,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday
            );

            if (user.CheckInWeek != currentWeek)
            {
                user.WeeklyCheckInCount = 0;
                user.CheckInWeek = currentWeek;
            }

            int? maxCheckIns = user.Subscription.SubscriptionType switch
            {
                Subscription.Type.One => 1,
                Subscription.Type.Two => 2,
                Subscription.Type.Unlimited => null,
                _ => 0
            };

            if (maxCheckIns.HasValue && user.WeeklyCheckInCount >= maxCheckIns.Value)
                return BadRequest("Check-in limit reached for your subscription");

            if (maxCheckIns.HasValue)
                user.WeeklyCheckInCount++;

            string remainingMessage = maxCheckIns.HasValue
                ? $"Check-in gelukt! Je hebt {maxCheckIns.Value - user.WeeklyCheckInCount} check-ins over deze week."
                : "Check-in gelukt! Je hebt unlimited check-ins deze week.";

            return Ok(new { message = remainingMessage });
        }

        // POST api/Subscription/change
        [HttpPost("change")]
        public ActionResult ChangeSubscription([FromBody] ChangeSubscriptionRequest request)
        {
            var user = DataSportschool.users.FirstOrDefault(u => u.Id == request.UserId);
            var subscription = DataSportschool.subscriptions.FirstOrDefault(s => s.Id == request.SubscriptionId);

            if (user == null || subscription == null)
            {
                return BadRequest(new { message = "Ongeldige gebruiker of subscriptie." });
            }

            user.SubscriptionId = subscription.Id;
            user.Subscription = subscription;

            return Ok(new
            {
                message = $"Subsciptie veranderd naar {subscription.Name}.",
                user
            });
        }

        // POST api/Subscription/cancel
        [HttpPost("cancel")]
        public IActionResult CancelSubscription([FromBody] CancelSubscriptionRequest request)
        {
            var user = DataSportschool.users.FirstOrDefault(u => u.Id == request.UserId);
            if (user == null) return NotFound("User not found");

            user.SubscriptionId = -1;  // remove subscription
            user.Subscription = null;

            return Ok(new { message = "Subscriptie is geanuleerd." });
        }


        // GET all subscriptions
        [HttpGet("all")]
        public IActionResult GetAllSubscriptions()
        {
            return Ok(DataSportschool.subscriptions);
        }

        public class ChangeSubscriptionRequest
        {
            public int UserId { get; set; }
            public int SubscriptionId { get; set; }
        }

        public class CancelSubscriptionRequest
        {
            public int UserId { get; set; }
        }

        // DTO class (not used here but kept for reference)
        public class SubscriptionChangeRequest
        {
            public int UserId { get; set; }
            public int SubscriptionId { get; set; }
        }
    }
}
