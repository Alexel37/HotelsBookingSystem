using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsBookingSystem.Models
{
    public class BookingHistory
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public int CreditCardId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Room Room { get; set; }
    }
}