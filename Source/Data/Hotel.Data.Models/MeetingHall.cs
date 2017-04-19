namespace Hotel.Data.Models
{
    using Enumerations;
    public class MeetingHall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HallType Type { get; set; }
        public int Capacity { get; set; }
    }
}
