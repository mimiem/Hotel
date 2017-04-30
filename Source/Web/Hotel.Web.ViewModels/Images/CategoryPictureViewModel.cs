namespace Hotel.Web.ViewModels.Images
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CategoryPictureViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public byte[] Picture { get; set; }
        public string Category { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, CategoryPictureViewModel>()
                .ForMember(expr => expr.Picture, opts => opts.MapFrom(p => p.Picture.Image))
                .ForMember(expr => expr.Category, opts => opts.MapFrom(p => p.Picture.Category.ToString()));
        }
    }
}
