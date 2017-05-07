namespace Hotel.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryPictures
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Text can be only {1} symbols")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
