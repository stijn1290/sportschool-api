namespace sportschool.Models
{
    public class Subscription
    {
        public enum Type
        {
            Unlimited = 0,
            One = 1,
            Two = 2
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Type SubscriptionType { get; set; }
        
    }
}
