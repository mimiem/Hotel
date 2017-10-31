namespace Hotel.Web.Hotel.Web.ViewModels.Reservation
{
    using System;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Data.Models;

    public class UserReservationAllViewModel : IMapFrom<Reservation>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Days
        {
            get
            {
                TimeSpan? diff = this.EndDate.Value - this.StartDate.Value;
                return diff.Value.Days;
            }
        }
        public int RoomId { get; set; }

        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public double PriceTotal
        {
            get
            {
                return this.Days * this.PricePerNight;
            }
        }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Reservation, UserReservationAllViewModel>()
                .ForMember(expr => expr.RoomType, opts => opts.MapFrom(r => r.Room.RoomType.Type))
                .ForMember(expr => expr.PricePerNight, opts => opts.MapFrom(r => r.Room.RoomType.Price))
                .ForMember(expr => expr.Days, opts => opts.Ignore())
                .ReverseMap();
        }
    }
}
