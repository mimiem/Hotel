namespace Hotel.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    public class Room : AuditInfo, IDeletableEntity
    {

        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        [Key]
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public virtual RoomType RoomType{ get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
