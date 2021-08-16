using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace FavouriteAccounts.ui.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // POST: Customer/Validate
        [HttpPost]
        public ActionResult Validate(int CustomerId)
        {
            try
            {
                // TODO: Add insert logic here
                // call api with result ok for the login comparison

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
