using HotelsBookingSystem.Models;
using HotelsBookingSystem.Models.RoomModels;
using HotelsBookingSystem.Operations.RoomOperations;
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
    //only post model checke to add some rooms ^^
    //!!!!!!!!!!!

    [Authorize]
    [RoutePrefix("api/Rooms")]
    public class RoomController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        IRoomOperations operations;

        public RoomController()
        {
            operations = new RoomOperations(context);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("rooms")]
        public IHttpActionResult GetRooms()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(operations.GetRooms());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("rooms/{id}")]
        public IHttpActionResult GetRoom(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(operations.GetRoom(id));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("freerooms")]
        public IHttpActionResult GetFreeRooms()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(operations.GetFreeRooms());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("freerooms/{id}")]
        public IHttpActionResult GetFreeRooms(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(operations.GetFreeRooms(id));
        }

        [HttpPost]
        [Route("rooms")]
        public IHttpActionResult AddRoom(RoomPostModel room)
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

            operations.AddRoom(room);
            return Ok(room);
        }

        [HttpPut]
        [Route("rooms")]
        public IHttpActionResult UpdateRoom(RoomPutModel room)
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
            operations.UpdateRoom(room);
            return Ok(room);
        }

        [HttpDelete]
        [Route("rooms/{id}")]
        public IHttpActionResult DeleteRoom(int id)
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
            operations.DeleteRoom(id);
            return Ok(operations.GetRooms());
        }
    }
}
