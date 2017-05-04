namespace Hotel.Web.ViewModels.Images
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CategoryPictureViewModel : IMapFrom<CategoryPictures>, IHaveCustomMappings
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int PictureId { get; set; }
        public string Category { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CategoryPictures, CategoryPictureViewModel>()
                .ForMember(expr => expr.PictureId, opts => opts.MapFrom(p => p.Picture.Id))
                .ForMember(expr => expr.Category, opts => opts.MapFrom(p => p.Picture.Category.ToString()));
        }
    }
}
