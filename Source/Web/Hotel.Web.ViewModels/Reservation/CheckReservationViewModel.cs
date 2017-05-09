namespace Hotel.Web.ViewModels.Reservation
{
    using Infrastructure.Mapping;
    using System;
    using Data.Models;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CustomAttributes;
    public class CheckReservationViewModel : IMapFrom<Reservation>, IHaveCustomMappings
    {
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DateGreaterThan("EndDate")]
        [Display(Name = "Начална дата")]
        public DateTime? StartDate { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Крайна дата")]
        public DateTime? EndDate { get; set; }
        [Required]
        [Display(Name = "Вид стая")]
        public string RoomType { get; set; }
        public IEnumerable<SelectListItem> RoomTypes { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Reservation, CheckReservationViewModel>()
                .ForMember(expr => expr.RoomType, opts => opts.MapFrom(r => r.Room.RoomType.Type))
                .ForMember(expr => expr.RoomTypes, opts => opts.Ignore())
                .ReverseMap();
        }
    }
}
