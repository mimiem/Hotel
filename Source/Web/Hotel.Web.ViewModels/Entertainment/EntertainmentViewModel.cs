namespace Hotel.Web.ViewModels.Entertainment
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class EntertainmentViewModel : IMapFrom<Entertainment>, IHaveCustomMappings
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Text can be bigger than {1} symbols")]
        [MaxLength(20, ErrorMessage = "Text can be only {1} symbols")]
        public string Name { get; set; }
        [MinLength(10, ErrorMessage = "Text can be only {1} symbols")]
        public string Description { get; set; }
        public string Facilities { get; set; }
        public ICollection<int> PictureIds { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Entertainment, EntertainmentViewModel>()
                .ForMember(expr => expr.PictureIds, evm => evm.MapFrom(e => e.Pictures.Select(p => p.Id)))
                .ReverseMap();
        }
    }
}
