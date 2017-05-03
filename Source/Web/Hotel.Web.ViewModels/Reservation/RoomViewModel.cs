namespace Hotel.Web.ViewModels.Reservation
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class RoomViewModel : IMapFrom<Room>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int RoomId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Room, RoomViewModel>()
                .ForMember(expr => expr.RoomId, opts => opts.MapFrom(r=>r.Id))
                .ForMember(expr => expr.RoomType, opts => opts.MapFrom(r => r.RoomType.Type));
        }
    }
}
