using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using FavouriteAccounts.ui.Models;
using System.Net.Http;
using FavouriteAccounts.ui.Helper;

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
        public ActionResult Validate(CustomerModel customer)
        {
            try
            {
                // TODO: Add insert logic here
                // call api with result ok for the login comparison

                // todo call proper method for validate
                //HttpResponseMessage response = FavouriteApiClient.webApiClient.PostAsync("Customer", customer.Id.ToString()).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
