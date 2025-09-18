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
        public string Name { get; set; } = string.Empty;

        // Keeps your enum type
        public Type SubscriptionType { get; set; }

        // New fields for frontend
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Store features as a serialized string (JSON or ; separated)
        public List<string> Features { get; set; } = new List<string>();
    }
}
