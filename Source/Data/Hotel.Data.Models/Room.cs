namespace Hotel.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Room : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomType Type { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
