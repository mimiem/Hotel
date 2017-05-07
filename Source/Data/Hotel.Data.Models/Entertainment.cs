﻿namespace Hotel.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Entertainment
    {
        public Entertainment()
        {
            this.Pictures = new HashSet<Picture>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Text can be only {1} symbols")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Facilities { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}