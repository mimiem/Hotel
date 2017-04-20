﻿namespace Hotel.Data.Models
{
    using Enumerations;
    using System.Collections.Generic;

    public class MeetingHall
    {
        public MeetingHall()
        {
            this.Images = new HashSet<Image>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public HallType Type { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
