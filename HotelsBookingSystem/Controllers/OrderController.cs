using HotelsBookingSystem.Models;
using HotelsBookingSystem.Models.OrderModels;
using HotelsBookingSystem.Operations.OrderOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace HotelsBookingSystem.Controllers
{
    [Authorize]
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        IOrderOperations operations;

        public OrderController()
        {
            operations = new OrderOperations(context);
        }

        [HttpPost]
        [Route("order")]
        public IHttpActionResult MakeOrder(MakeOrderModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();

            if(user[0].Id!=order.UserId)
            {
                return BadRequest(ModelState);
            }

            return Ok(operations.MakeOrder(order));
        }
    }
}
