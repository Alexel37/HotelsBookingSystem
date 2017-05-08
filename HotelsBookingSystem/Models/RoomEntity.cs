using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsBookingSystem.Models
{
    public class Room
    {
        public Room()
        {
            this.BookingHistories = new HashSet<BookingHistory>();
        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        public int Number { get; set; }
        public int TypeOfRoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<BookingHistory> BookingHistories { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual TypeOfRoom TypeOfRoom { get; set; }
    }
}