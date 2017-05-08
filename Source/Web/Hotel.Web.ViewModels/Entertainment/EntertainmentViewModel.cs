namespace Hotel.Web.ViewModels.Entertainment
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.Linq;

    public class EntertainmentViewModel : IMapFrom<Entertainment>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<string> Facilities { get; set; }
        public ICollection<int> PictureIds { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Entertainment, EntertainmentViewModel>()
                .ForMember(expr => expr.Facilities, opts => opts.MapFrom(e=>e.Facilities.Split('|')))
                .ForMember(expr => expr.PictureIds, opts => opts.MapFrom(e => e.Pictures.Select(p=>p.Id)))
                .ReverseMap();
        }
    }
}
