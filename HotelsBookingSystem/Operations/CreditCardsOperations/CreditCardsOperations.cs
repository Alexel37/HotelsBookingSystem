using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelsBookingSystem.Models.CreditCardsModels;
using HotelsBookingSystem.Models;
using System.Data.Entity;

namespace HotelsBookingSystem.Operations.CreditCardsOperations
{
    public class CreditCardsOperations : ICreditCardOperations
    {
        private readonly ApplicationDbContext context;

        public CreditCardsOperations(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddCreditCard(CreditCardPostModel model)
        {
            var user = context.Users.Find(model.UserId);
            context.CreditCards.Add(new CreditCard { ApplicationUser = user, Cash = model.Cash, Code = model.Code });
            context.SaveChanges();
        }

        public void DeleteCreditCard(CreditCard card)
        {
            context.CreditCards.Remove(card);
            context.SaveChanges();
        }

        public List<CreditCardGetModel> GetCreditCards(ApplicationUser user)
        {
            return context.CreditCards.Where(x => x.ApplicationUserId == user.Id).Select(t => new CreditCardGetModel { Cash = t.Cash, Code = t.Code, Id = t.Id, UserId = t.ApplicationUserId }).ToList();
        }

        public void UpdateCreditCard(CreditCardPutModel model)
        {
            
            CreditCard card = context.CreditCards.Find(model.Id);
            card.Cash = model.Cash;
            card.Code = model.Code;
            //context.CreditCards.Attach(card);
            context.Entry(card).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<CreditCardGetModel> GetACreditCards(ApplicationUser user)
        {
            var level = context.UserLevels.Find(user.UserLevelId);
            if (level.Name == "Administrator")
            {
                return context.CreditCards.Select(t => new CreditCardGetModel { Cash = t.Cash, Code = t.Code, Id = t.Id, UserId = t.ApplicationUserId }).ToList();
            }
            return null;
        }
    }
}