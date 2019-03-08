using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATMImitationWebApp.Models;
using System.Diagnostics;

namespace ATMImitationWebApp.Controllers
{
    public class HomeController : Controller
    {
        ClientContext db = new ClientContext();
        public static int currentPinCode;
        
        public ActionResult Index()
        {            
            return View();
        }

        [HttpGet]
        public ActionResult CheckPinCode(int pinCode)
        {                               
            Card currentCard = db.Cards.ToList().Find(item => item.PinCode == pinCode);
                                 
            if (currentCard==null)
            {               
               ViewBag.isError = true;
               ViewBag.pinCode = pinCode;

               return View("Index");
            }
            else
            {
                currentPinCode = pinCode;
                return View("Menu");
            }            
        }

        [HttpPost]
        public ActionResult ClientsCardInfo()
        {          
            Card currentCard = db.Cards.ToList().Find(item => item.PinCode == currentPinCode);
            return PartialView(currentCard);
        }

        [HttpGet]
        public ActionResult WithdrawCash()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Transaction()
        {
            Card currentCard = db.Cards.ToList().Find(item => item.PinCode == currentPinCode);
            return PartialView(currentCard.Client.Transactions);
        }

        [HttpGet]
        public ActionResult Summa(string value)
        {
            Card currentCard = db.Cards.ToList().Find(item => item.PinCode == currentPinCode);

            int summa = int.Parse(value);

            if(currentCard.Balance < summa)
            {
                var message = new { message = "У вас не достаточно средств для снятия"};
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                currentCard.Balance -= summa;
                currentCard.Client.Transactions.Add(new Transaction { Date=DateTime.Now, Summa=summa});
                db.SaveChanges();
                var message = new { message = "Снятие средств выполнено" };
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}