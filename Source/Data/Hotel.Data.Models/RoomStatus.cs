namespace Hotel.Data.Models
{
    using Enumerations;
    using System.ComponentModel.DataAnnotations;

    public class RoomStatus
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Notes { get; set; }
    }
}
