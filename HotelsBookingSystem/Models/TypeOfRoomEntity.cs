using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsBookingSystem.Models
{
    public class TypeOfRoom
    {
        public TypeOfRoom()
        {
            this.Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual HashSet<Room> Rooms { get; set; }
    }
}