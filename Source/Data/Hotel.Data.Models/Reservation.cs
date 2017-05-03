namespace Hotel.Data.Models
{
    using Hotel.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
