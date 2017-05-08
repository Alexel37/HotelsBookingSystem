using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelsBookingSystem.Models.RoomModels;
using HotelsBookingSystem.Models;
using System.Data.Entity;

namespace HotelsBookingSystem.Operations.RoomOperations
{
    public class RoomOperations : IRoomOperations
    {
        private readonly ApplicationDbContext context;

        public RoomOperations(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddRoom(RoomPostModel model)
        {
            var hotel = context.Hotels.Find(model.HotelId);
            var typeofroom = context.TypeOfRooms.Find(model.TypeOfRoomId);

            if(hotel==null || typeofroom==null)
            {
                return;
            }

            context.Rooms.Add(new Room { Hotel = hotel, Number = model.Number, EndDate = DateTime.Today, StartDate = DateTime.Today, TypeOfRoom = typeofroom });
            context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var room = context.Rooms.Find(id);
            context.Rooms.Remove(room);
            context.SaveChanges();
        }

        public List<RoomGetModel> GetFreeRooms()
        {
            return context.Rooms.Where(x => x.EndDate < DateTime.Today).Select(x => new RoomGetModel { HotelId = x.HotelId, Id = x.Id, IsFree = true, Number = x.Number, TypeOfRoomId = x.TypeOfRoomId }).ToList();
        }

        public List<RoomGetModel> GetFreeRooms(int HotelId)
        {
            return context.Rooms.Where(x => x.EndDate < DateTime.Today && x.HotelId==HotelId).Select(x => new RoomGetModel { HotelId = x.HotelId, Id = x.Id, IsFree = true, Number = x.Number, TypeOfRoomId = x.TypeOfRoomId }).ToList();
        }

        public RoomGetModel GetRoom(int id)
        {
            var room = context.Rooms.Find(id);
            if(room==null)
            {
                return null;
            }

            return new RoomGetModel { HotelId = room.HotelId, Id = room.Id, IsFree = (room.EndDate < DateTime.Today), Number = room.Number, TypeOfRoomId = room.TypeOfRoomId };

        }

        public List<RoomGetModel> GetRooms()
        {
            return context.Rooms.Select(x => new RoomGetModel { HotelId = x.HotelId, IsFree = (x.EndDate < DateTime.Today), Id = x.Id, Number = x.Number, TypeOfRoomId = x.TypeOfRoomId }).ToList();
        }

        public void UpdateRoom(RoomPutModel model)
        {
            var room = context.Rooms.Find(model.Id);
            room.Number = model.Number;
            var typeofroom = context.TypeOfRooms.Find(model.TypeOfRoomId);
            room.TypeOfRoom = typeofroom;
            context.Entry(room).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}