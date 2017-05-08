using HotelsBookingSystem.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsBookingSystem.Operations.OrderOperations
{
    interface IOrderOperations
    {
        OrderGetModel MakeOrder(MakeOrderModel model);
    }
}
