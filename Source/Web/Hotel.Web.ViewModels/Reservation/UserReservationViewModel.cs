namespace Hotel.Web.Hotel.Web.ViewModels.Reservation
{
    using Infrastructure.Mapping;
    using AutoMapper;
    using System;
    using global::Hotel.Web.ViewModels.Reservation;

    public class UserReservationViewModel : IMapFrom<CheckReservationViewModel>, IHaveCustomMappings
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string RoomType { get; set; }
        public int Days
        {
            get
            {
                TimeSpan? diff = this.EndDate.Value - this.StartDate.Value;
                return diff.Value.Days;
            }
        }
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
            configuration.CreateMap<CheckReservationViewModel, UserReservationViewModel>()
                .ForMember(expr => expr.PricePerNight, opts => opts.Ignore())
                .ForMember(expr => expr.Days, opts => opts.Ignore())
                .ForMember(expr => expr.PriceTotal, opts => opts.Ignore())
                .ReverseMap();

            
        }
    }
}
