using HotelsBookingSystem.Models;
using HotelsBookingSystem.Models.TypeOfRoomsModels;
using HotelsBookingSystem.Operations.TypeOfRoomOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace HotelsBookingSystem.Controllers
{
        //!!!!!!!!!!!!!
            //must be working only post cheked for adding some types
        //!!!!!!!!!!!!!

    [Authorize]
    [RoutePrefix("api/TypeOfRoom")]
    public class TypeOfRoomController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ITypeOfRoomOperations operations;

        public TypeOfRoomController()
        {
            operations = new TypeOfRoomOperations(context);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("typeofroom")]
        public IHttpActionResult GetTypeOfRooms()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(operations.GetTypeOfRooms());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("typeofroom/{id}")]
        public IHttpActionResult GetTypeOfRoom(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(operations.GetTypeOfRoom(id));
        }

        [HttpPost]
        [Route("typeofroom")]
        public IHttpActionResult AddTypeOfRoom(TypeOfRoomPostModel typeofroom)
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
            operations.AddTypeOfRoom(typeofroom);
            return Ok(typeofroom);
        }

        [HttpPut]
        [Route("typeofroom")]
        public IHttpActionResult UpdateTypeOfRoom(TypeOfRoomPutModel typeofroom)
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
            operations.UpdateTypeOfRoom(typeofroom);
            return Ok(typeofroom);
        }

        [HttpDelete]
        [Route("typeofroom/{id}")]
        public IHttpActionResult DeleteTypeOfRoom(int id)
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
            operations.DeleteTypeOfRoom(id);
            return Ok(operations.GetTypeOfRooms());
        }
    }
}
