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
        public static Card currentCard;
        
        public ActionResult Index()
        {            
            return View();
        }

        [HttpGet]
        public ActionResult CheckPinCode(int pinCode)
        {                               
            currentCard = db.Cards.ToList().Find(item => item.PinCode == pinCode);
                                 
            if (currentCard==null)
            {               
               ViewBag.isError = true;
               ViewBag.pinCode = pinCode;

               return View("Index");
            }
            else
            {
                return View("Menu");
            }            
        }

        [HttpPost]
        public ActionResult ClientsCardInfo()
        {            
            return PartialView(currentCard);
        }

        [HttpGet]
        public ActionResult WithdrawCash()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Summa(string value)
        {            
            int summa = int.Parse(value);
            if(currentCard.Balance < summa)
            {
                var message = new { message = "У вас не достаточно средств для снятия"};
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                currentCard.Balance -= summa;
                db.SaveChanges();
                var message = new { message = "Снятие средств выполнено" };
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}