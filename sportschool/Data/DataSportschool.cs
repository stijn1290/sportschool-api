using sportschool.Models;

namespace sportschool.Data
{

    public static class DataSportschool
    {
        public static List<Subscription> subscriptions = new List<Subscription>
{
    new () {
        Id = 0,
        Name = "Unlimited",
        SubscriptionType = Subscription.Type.Unlimited,
        Description = "Best for professionals who want unlimited access",
        Price = 29.99m,
        Features = new List<string>
        {
            "Onbeperkt Gym toegang",
            "Gratis coach",
            "Gratis cursus"
        }
    },
    new () {
        Id = 1,
        Name = "Starter",
        SubscriptionType = Subscription.Type.One,
        Description = "Best for all beginners",
        Price = 9.99m,
        Features = new List<string>
        {
            "Gym toegang 1x",
            "Betaalde coach",
            "Betaalde cursus"
        }
    },
    new () {
        Id = 2,
        Name = "Basic",
        SubscriptionType = Subscription.Type.Two,
        Description = "For regulars who want a bit more",
        Price = 19.99m,
        Features = new List<string>
        {
            "Gym toegang 2x",
            "Betaalde coach",
            "Betaalde cursus"
        }
    }
};

        public static List<User> users = new List<User>
            {
                new() { Id = 0, Name = "John Doe", SubscriptionId = 1, Subscription = subscriptions[1] },
                new() { Id = 1, Name = "Jane Smith", SubscriptionId = 2, Subscription = subscriptions[2] },
                new() { Id = 2, Name = "Johanna Wilson", SubscriptionId = 0, Subscription = subscriptions[0] }
            };
        public static List<Appointment> appointments = new List<Appointment>();
        public static List<Cursus> cursussen = new List<Cursus>
        {
            new() { Id = 0, Name = "Yoga", Description = "Een rustgevende cursus", Users = new List<User>() },
            new() { Id = 1, Name = "Pilates", Description = "Een kracht cursus", Users = new List<User>() },
            new() { Id = 2, Name = "Paaldansen",Description = "Een uitdagende cursus", Users = new List<User>() },
            new() { Id = 3, Name = "Hit workout", Description = "Een rustgevende cursus", Users = new List<User>() },
        };
        public static List<Coach> coaches = new List<Coach>
        {
            new(){ Id= 0, Name = "Bert"},
            new(){ Id= 1, Name = "Jan"},
            new(){ Id= 2, Name = "Harrie"},
            new(){ Id= 3, Name = "Bas"},
        };
    }
}
