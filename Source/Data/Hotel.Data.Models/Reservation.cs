namespace Hotel.Data.Models
{
    using Common.Models;
    using Hotel.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Reservation : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
