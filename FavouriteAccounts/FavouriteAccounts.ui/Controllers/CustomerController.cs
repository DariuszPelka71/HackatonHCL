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
using Newtonsoft.Json;

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
                    var customerData = response.Content.ReadAsStringAsync();
                    var result = new JsonResult
                    {
                        Data = JsonConvert.DeserializeObject<CustomerModel>(customerData.Result)
                    };
                    Session["CustomerId"] = ((CustomerModel)result.Data).Id;
                    Session["CustomerName"] = ((CustomerModel)result.Data).Name;
                    return RedirectToAction("Index", "Favourite");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
