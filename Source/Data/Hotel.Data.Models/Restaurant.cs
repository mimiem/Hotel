namespace Hotel.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Restaurant
    {
        public Restaurant()
        {
            this.Images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
