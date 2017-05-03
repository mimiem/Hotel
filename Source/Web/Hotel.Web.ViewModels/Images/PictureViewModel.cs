namespace Hotel.Web.Hotel.Web.ViewModels.Images
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class PictureViewModel : IMapFrom<Picture>
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
}
