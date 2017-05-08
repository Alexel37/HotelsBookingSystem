using HotelsBookingSystem.Models;
using HotelsBookingSystem.Models.CreditCardsModels;
using HotelsBookingSystem.Operations.CreditCardsOperations;
using Microsoft.AspNet.Identity.EntityFramework;
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
    [RoutePrefix("api/CreditCards")]
    public class CreditCardController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ICreditCardOperations operations;

        public CreditCardController()
        {
            operations = new CreditCardsOperations(context);
        }

        [HttpGet]
        [Route("cards")]
        //works
        public IHttpActionResult GetCards()
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();

            if(user==null)
            {
                return NotFound();
            }

            return Ok(operations.GetCreditCards(user[0]));
        }

        [HttpPost]
        [Route("cards")]
        //works
        public IHttpActionResult AddCards(CreditCardPostModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            if (user[0].Id != model.UserId)
            {
                return BadRequest(ModelState);
            }
            operations.AddCreditCard(model);
            return Ok();
        }

        [HttpPut]
        [Route("cards")]
        //works
        public IHttpActionResult UpdateCard(CreditCardPutModel card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            var acard = context.CreditCards.Find(card.Id);
            if(acard==null)
            {
                return BadRequest(ModelState);
            }

            if (user[0].Id != card.UserId || user[0].Id!=acard.ApplicationUserId)
            {
                return BadRequest(ModelState);
            }
            operations.UpdateCreditCard(card);
            return Ok(card);
        }

        [HttpDelete]
        [Route("cards/{id}")]
        //works
        public IHttpActionResult DeleteCard(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            var card = context.CreditCards.Find(id);
            if (user[0].Id != card.ApplicationUserId)
            {
                return BadRequest(ModelState);
            }
            operations.DeleteCreditCard(card);
            return Ok(operations.GetCreditCards(user[0]));
        }


        //admin

        [HttpGet]
        [Route("acards")]
        //works
        public IHttpActionResult GetACards()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            
            return Ok(operations.GetACreditCards(user[0]));
        }

        [HttpPost]
        [Route("acards")]
        //works
        public IHttpActionResult AddACards(CreditCardPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            var level = context.UserLevels.Find(user[0].UserLevelId);
            if (level.Name!="Administrator")
            {
                return BadRequest(ModelState);
            }
            operations.AddCreditCard(model);
            return Ok();
        }

        [HttpPut]
        [Route("acards")]
        //works
        public IHttpActionResult UpdateACard(CreditCardPutModel card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            var level = context.UserLevels.Find(user[0].UserLevelId);
            if (level.Name != "Administrator")
            {
                return BadRequest(ModelState);
            }
            operations.UpdateCreditCard(card);
            return Ok(card);
        }

        [HttpDelete]
        [Route("acards/{id}")]
        //must be working not cheked
        public IHttpActionResult DeleteACard(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = (ClaimsIdentity)User.Identity;
            var user = context.Users.Where(x => x.Email == identity.Name).ToList();
            var card = context.CreditCards.Find(id);
            var level = context.UserLevels.Find(user[0].UserLevelId);
            if (level.Name != "Administrator")
            {
                return BadRequest(ModelState);
            }
            operations.DeleteCreditCard(card);
            return Ok(operations.GetCreditCards(user[0]));
        }
    }
}
