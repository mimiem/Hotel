namespace Hotel.Web.ViewModels.Reservation
{
    using Infrastructure.Mapping;
    using Data.Models;
    using AutoMapper;
    using System;

    public class UserReservationViewModel : IMapFrom<CheckReservationViewModel>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string RoomType { get; set; }
    }
}
