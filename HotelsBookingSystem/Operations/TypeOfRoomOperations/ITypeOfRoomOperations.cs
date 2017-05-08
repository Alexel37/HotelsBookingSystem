using HotelsBookingSystem.Models.TypeOfRoomsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsBookingSystem.Operations.TypeOfRoomOperations
{
    interface ITypeOfRoomOperations
    {
        List<TypeOfRoomGetModel> GetTypeOfRooms();
        TypeOfRoomGetModel GetTypeOfRoom(int id);
        void AddTypeOfRoom(TypeOfRoomPostModel model);
        void UpdateTypeOfRoom(TypeOfRoomPutModel model);
        void DeleteTypeOfRoom(int id);
    }
}