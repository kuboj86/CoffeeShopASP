using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShopWebApp.Models;

namespace CoffeeShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View(); 
        }

        public ActionResult NewUserRegistered(UserInput NewCustomer)
        {
            ViewBag.FirstName = NewCustomer.FirstName;
            return View();
        }
    
    }
}