using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelsBookingSystem.Models.TypeOfRoomsModels;
using HotelsBookingSystem.Models;
using System.Data.Entity;

namespace HotelsBookingSystem.Operations.TypeOfRoomOperations
{
    public class TypeOfRoomOperations : ITypeOfRoomOperations
    {
        private readonly ApplicationDbContext context;

        public TypeOfRoomOperations(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddTypeOfRoom(TypeOfRoomPostModel model)
        {
            context.TypeOfRooms.Add(new TypeOfRoom { Type = model.Type });
            context.SaveChanges();
        }

        public void DeleteTypeOfRoom(int id)
        {
            var typeofroom = context.TypeOfRooms.Find(id);
            if(typeofroom != null)
            {
                context.TypeOfRooms.Remove(typeofroom);
                context.SaveChanges();
            }
        }

        public TypeOfRoomGetModel GetTypeOfRoom(int id)
        {
            var typeofroom = context.TypeOfRooms.Find(id);
            if(typeofroom!=null)
            {
                return new TypeOfRoomGetModel { Id = typeofroom.Id, Type = typeofroom.Type };
            }
            return null;
        }

        public List<TypeOfRoomGetModel> GetTypeOfRooms()
        {
            return context.TypeOfRooms.Select(x => new TypeOfRoomGetModel { Id = x.Id, Type = x.Type }).ToList();
        }

        public void UpdateTypeOfRoom(TypeOfRoomPutModel model)
        {
            var typeofroom = context.TypeOfRooms.Find(model.Id);
            if(typeofroom==null)
            {
                return;
            }
            typeofroom.Type = model.Type;
            context.Entry(typeofroom).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}