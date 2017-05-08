using HotelsBookingSystem.Models;
using HotelsBookingSystem.Models.HotelModels;
using HotelsBookingSystem.Operations.HotelOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace HotelsBookingSystem.Controllers
{
        //!!!!!!!!!!!!
            //only post model checke to add some hotels ^^
        //!!!!!!!!!!!

    [Authorize]
    [RoutePrefix("api/Hotel")]
    public class HotelController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        IHotelOperations operations;

        public HotelController()
        {
            operations = new HotelOperations(context);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("hotels")]
        public IHttpActionResult GetHotels()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(operations.GetHotels());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("hotels/{id}")]
        public IHttpActionResult GetHotel(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(operations.GetHotel(id));
        }

        [HttpPost]
        [Route("hotels")]
        public IHttpActionResult AddHotel(HotelPostModel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            var level = context.UserLevels.Find(user[0].UserLevelId);

            if(level.Name!="Administrator" && level.Name!="Hotel Manager")
            {
                return BadRequest(ModelState);
            }
            operations.AddHotel(hotel);
            return Ok(hotel);
        }

        [HttpPut]
        [Route("hotels")]
        public IHttpActionResult UpdateHotel(HotelPutModel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            var level = context.UserLevels.Find(user[0].UserLevelId);

            if (level.Name != "Administrator" && level.Name != "Hotel Manager")
            {
                return BadRequest(ModelState);
            }
            operations.UpdateHotel(hotel);
            return Ok();
        }

        [HttpDelete]
        [Route("hotels/{id}")]
        public IHttpActionResult DeleteHotel(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            var level = context.UserLevels.Find(user[0].UserLevelId);

            if (level.Name != "Administrator" && level.Name != "Hotel Manager")
            {
                return BadRequest(ModelState);
            }

            operations.DeleteHotel(id);
            return Ok(operations.GetHotels());
        }
    }
}
