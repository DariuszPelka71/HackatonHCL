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
                HttpResponseMessage response = FavouriteApiClient.webApiClient.GetAsync("Customer/" + customer.Id.ToString()).Result;

                if (response.IsSuccessStatusCode)
                {
                    //todo go to the list page

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

    }
}
