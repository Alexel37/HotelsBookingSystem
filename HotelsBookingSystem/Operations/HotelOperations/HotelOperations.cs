using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelsBookingSystem.Models.HotelModels;
using HotelsBookingSystem.Models;
using System.Data.Entity;

namespace HotelsBookingSystem.Operations.HotelOperations
{
    public class HotelOperations : IHotelOperations
    {
        private readonly ApplicationDbContext context;

        public HotelOperations(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddHotel(HotelPostModel model)
        {
            context.Hotels.Add(new Hotel { Name = model.Name, Star = model.Star });
            context.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            var hotel = context.Hotels.Find(id);
            if (hotel != null)
            {
                context.Hotels.Remove(hotel);
            }
            context.SaveChanges();
        }

        public HotelGetModel GetHotel(int id)
        {
            var a= context.Hotels.Find(id);
            if (a != null)
            {
                return new HotelGetModel { Id = a.Id, Name = a.Name, Star = a.Star };
            }
            return null;
        }

        public List<HotelGetModel> GetHotels()
        {
            return context.Hotels.Select(x => new HotelGetModel { Id = x.Id, Name = x.Name, Star = x.Star }).ToList();
        }

        public void UpdateHotel(HotelPutModel model)
        {
            var hotel = context.Hotels.Find(model.Id);
            hotel.Name = model.Name;
            hotel.Star = model.Star;
            context.Entry(hotel).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}