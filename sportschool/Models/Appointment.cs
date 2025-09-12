namespace sportschool.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public required User User1 { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public required User User2 { get; set; }
    }
}
