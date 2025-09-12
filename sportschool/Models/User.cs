namespace sportschool.Models
{
    public class User
    {
        public enum Roles
        {
            Normal,
            Personal_trainer
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubscriptionId { get; set; }
        public required Subscription Subscription { get; set; }
        public Roles Role { get; set; }
    }
}
