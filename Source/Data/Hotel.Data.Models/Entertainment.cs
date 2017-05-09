namespace Hotel.Data.Models
{
    using Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Entertainment : IAuditInfo, IDeletableEntity
    {
        public Entertainment()
        {
            this.CreatedOn = DateTime.Now;
            this.Pictures = new HashSet<Picture>();
        }
        [Key]
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Text can be bigger than {1} symbols")]
        [MaxLength(20, ErrorMessage = "Text can be only {1} symbols")]
        public string Name { get; set; }
        [MinLength(10, ErrorMessage = "Text can be only {1} symbols")]
        public string Description { get; set; }
        public string Facilities { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
