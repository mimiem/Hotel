namespace Hotel.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Occupancy
    {
        [Key]
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual Room Room { get; set; }
    }
}
