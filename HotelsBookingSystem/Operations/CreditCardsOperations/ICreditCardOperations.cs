using HotelsBookingSystem.Models;
using HotelsBookingSystem.Models.CreditCardsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsBookingSystem.Operations.CreditCardsOperations
{
    interface ICreditCardOperations
    {
        //user
        List<CreditCardGetModel> GetCreditCards(ApplicationUser user);
        void AddCreditCard(CreditCardPostModel model);
        void UpdateCreditCard(CreditCardPutModel model);
        void DeleteCreditCard(CreditCard card);

        //admin
        List<CreditCardGetModel> GetACreditCards(ApplicationUser user);
    }
}
