using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsBookingSystem.Models.OrderModels
{
    public class OrderGetModel
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public int RoomId { get; set; }
        public int CrediCardId { get; set; }
        public int HotelId { get; set; }
    }
}
