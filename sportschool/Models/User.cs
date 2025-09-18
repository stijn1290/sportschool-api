namespace sportschool.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription? Subscription { get; set; }

        public int WeeklyCheckInCount { get; set; } = 0;

        public int CheckInWeek { get; set; } = -1;
    }
}
