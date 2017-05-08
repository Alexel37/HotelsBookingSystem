using HotelsBookingSystem.Models.RoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsBookingSystem.Operations.RoomOperations
{
    interface IRoomOperations
    {
        List<RoomGetModel> GetRooms();
        RoomGetModel GetRoom(int id);
        void AddRoom(RoomPostModel model);
        void UpdateRoom(RoomPutModel model);
        void DeleteRoom(int id);
        List<RoomGetModel> GetFreeRooms();
        List<RoomGetModel> GetFreeRooms(int HotelId);
    }
}
