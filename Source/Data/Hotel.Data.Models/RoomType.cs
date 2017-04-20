namespace Hotel.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RoomType
    {
        public RoomType()
        {
            this.Images = new HashSet<Image>();
        }
        [Key]
        public int Key { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
