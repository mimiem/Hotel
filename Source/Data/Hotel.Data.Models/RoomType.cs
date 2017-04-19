namespace Hotel.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RoomType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

    }
}
