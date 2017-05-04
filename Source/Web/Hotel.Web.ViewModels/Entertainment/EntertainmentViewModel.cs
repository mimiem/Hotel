namespace Hotel.Web.ViewModels.Entertainment
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    public class EntertainmentViewModel : IMapFrom<Entertainment>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}
