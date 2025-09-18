using sportschool.Models;

namespace sportschool.Data
{

    public static class DataSportschool
    {
        public static List<Subscription> subscriptions = new List<Subscription>
            {
                new () { Id = 0, Name = "Unlimited", SubscriptionType = Subscription.Type.Unlimited
            },
                new () { Id = 1, Name = "1 keer in de week", SubscriptionType = Subscription.Type.One
},
                new() { Id = 2, Name = "2 keer in de week", SubscriptionType = Subscription.Type.Two }
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
            new() { Id = 0, Name = "Yoga", Description = "Een rustgevende cursus waar ontspanning centraal staat", Users = new List<User>() },
            new() {  Id = 1, Name = "Pilates", Description = "Een cursus gericht op kracht, flexibiliteit en lichaamshouding", Users = new List<User>()},
            new() { Id = 2, Name = "Paaldansen",Description = "Een uitdagende cursus die kracht en elegantie combineert", Users = new List<User> { users[0] } }
        };
        public static List<Coach> coaches = new List<Coach>
        {
            new(){ Id= 0, Name = "Bert"},
            new(){ Id= 1, Name = "Jan"},
        };
    }
}
