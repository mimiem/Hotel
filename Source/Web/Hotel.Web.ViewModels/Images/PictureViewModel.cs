namespace Hotel.Web.Hotel.Web.ViewModels.Images
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class PictureViewModel : IMapFrom<Picture>
    {
        public byte[] Image { get; set; }
    }
}
