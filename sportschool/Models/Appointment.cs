namespace sportschool.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public required Coach Coach { get; set; }
        public int CoachId { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
    }
}
