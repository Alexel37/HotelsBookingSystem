using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelsBookingSystem.Models.OrderModels;
using HotelsBookingSystem.Models;
using System.Data.Entity;

namespace HotelsBookingSystem.Operations.OrderOperations
{
    public class OrderOperations : IOrderOperations
    {
        private readonly ApplicationDbContext context;

        public OrderOperations(ApplicationDbContext context)
        {
            this.context = context;
        }
              
        public OrderGetModel MakeOrder(MakeOrderModel model)
        {
            var room = context.Rooms.Find(model.RoomId);
            var card = context.CreditCards.Find(model.CreditCardId);
            var user = context.Users.Find(model.UserId);

            if (room == null || card == null || user==null || model.StartDate>model.EndDate)
            {
                return null;
            }

            double RPrice = room.TypeOfRoomId * 250 * (model.EndDate - model.StartDate).Days;

            if(card.Cash<RPrice || room.EndDate>model.StartDate || card.ApplicationUserId!=user.Id)
            {
                return null;
            }

            card.Cash -= RPrice;
           context.Entry(card).State = EntityState.Modified;

            room.EndDate = model.EndDate;
            context.Entry(room).State = EntityState.Modified;


            context.BookingHistories.Add(new BookingHistory { ApplicationUser = user, CreditCardId = model.CreditCardId, EndDate = model.EndDate, Price = RPrice, Room = room, StartDate = model.StartDate });
            context.SaveChanges();

            return new OrderGetModel { CrediCardId = model.CreditCardId, EndDate = model.EndDate, Price = RPrice, RoomId = model.RoomId, StartDate = model.StartDate, UserId = model.UserId, HotelId = room.HotelId };
        }      

    }
}