namespace Hotel.Data.Models
{
    using Common.Models;
    using Enumerations;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Picture : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageCategory Category { get; set; }
        public byte[] Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual Entertainment EntertainmentPicture { get; set; }

    }
}
