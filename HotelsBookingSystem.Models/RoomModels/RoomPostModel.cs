using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsBookingSystem.Models.RoomModels
{
    public class RoomPostModel
    {
        public int HotelId { get; set; }
        public int Number { get; set; }
        public int TypeOfRoomId { get; set; }
    }
}
