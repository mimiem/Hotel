namespace Hotel.Data.Models
{
    using Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Image : IDeletableEntity
    {
        [Key]
        public int Id { get; set; }
        public byte[] ImageFile { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
