using HotelsBookingSystem.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsBookingSystem.Operations.HotelOperations
{
    interface IHotelOperations
    {
        List<HotelGetModel> GetHotels();
        HotelGetModel GetHotel(int id);
        void AddHotel(HotelPostModel model);
        void UpdateHotel(HotelPutModel model);
        void DeleteHotel(int id);
    }
}
