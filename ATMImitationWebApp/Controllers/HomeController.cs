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
        
        public ActionResult Index()
        {            
            return View();
        }

        [HttpGet]
        public ActionResult CheckPinCode(int pinCode)
        {                   
            bool isError = false;

            Card findCard = db.Cards.ToList().Find(item => item.PinCode == pinCode);
                                 
            if (findCard==null)
            {
               isError = true;
            }

            ViewBag.isError = isError;
            ViewBag.pinCode = pinCode;

            return View("Index");
        }
    }
}