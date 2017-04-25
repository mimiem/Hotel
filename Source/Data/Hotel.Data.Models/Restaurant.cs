namespace Hotel.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
