using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsBookingSystem.Models.RoomModels
{
    public class RoomGetModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int Number {  get; set; }
        public int TypeOfRoomId { get; set; }
        public bool IsFree { get; set; }
    }
}
