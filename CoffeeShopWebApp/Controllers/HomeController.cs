using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq.Expressions;
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

        public ActionResult ListItems()
        {
            CoffeShopDbEntities ORM = new CoffeShopDbEntities();
            List<Item> ProductList = ORM.Items.ToList();
            ViewBag.ProductList = ProductList;
            ViewBag.ProductDescription = ORM.Items.Select(x => x.Name).ToList();

            return View("NewUserRegistered");
        }

        public ActionResult NewUserRegistered(User NewUserRecord)
        {
            if (ModelState.IsValid)
            {
                CoffeShopDbEntities ORM = new CoffeShopDbEntities();
                try
                {
                    ORM.Users.Add(NewUserRecord);
                    ORM.SaveChanges(); //Validation failed for one or more entities. See 'EntityValidationErrors' property for more details.

                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",validationError.PropertyName,validationError.ErrorMessage);
                        }
                    }
                }



                ViewBag.FirstName = NewUserRecord.FirstName;
                return ListItems(); // View();
            }
            else
            {
                return View("Register");
            }
        }
        public ActionResult EditItem(string Name)
        {
            CoffeShopDbEntities ORM = new CoffeShopDbEntities();
            Item ItemToEdit = ORM.Items.Find(Name);
            if (ItemToEdit != null)
            {
                ViewBag.ItemToEdit = ItemToEdit;
                return View("EditItemForm");
            }
            else
            {
                return RedirectToAction("NewUserRegistered");
            }
        }

        public ActionResult DeleteItem(string ProductName)
        {
            CoffeShopDbEntities ORM = new CoffeShopDbEntities();

            Item ItemToBeDeleted = ORM.Items.Find(ProductName);

            if (ItemToBeDeleted != null)
            {
                ORM.Items.Remove(ItemToBeDeleted);
                ORM.SaveChanges();
            }
            return RedirectToAction("NewUserRegistered");
        }

        public ActionResult AddItemForm()
        {
            return View();
        }

        public ActionResult SaveAddedItem(Item AddItem)
        {
            if (ModelState.IsValid)
            {
                CoffeShopDbEntities ORM = new CoffeShopDbEntities();
                ORM.Items.Add(AddItem);
                ORM.SaveChanges();

                return RedirectToAction("NewUserRegistered");
            }
            else
            {
                return View("AddItemForm");
            }
        }


        public ActionResult SaveEditedItem(Item ItemToEdit)
        {
            CoffeShopDbEntities ORM = new CoffeShopDbEntities();
            Item temp = ORM.Items.Find(ItemToEdit.Name);

            temp.Description = ItemToEdit.Description;
            temp.Quantity = ItemToEdit.Quantity;
            temp.Price = ItemToEdit.Price;

            ORM.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();

            return RedirectToAction("NewUserRegistered");
        }
    }
}