using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsBookingSystem.Models
{
    public class Hotel
    {
        public Hotel()
        {
            this.Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Star { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}