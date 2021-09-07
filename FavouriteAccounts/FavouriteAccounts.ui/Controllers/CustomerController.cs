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
using System.Web.Security;
using System.Security.Principal;

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
        // login method
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
                    SignInRemember(((CustomerModel)result.Data).Id, true);
                    return RedirectToAction("Index", "Favourite");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //POST: Logout    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();

                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                return View(); // local page - login
            }
            catch
            {
                throw;
            }
        }

        private void EnsureLoggedOut()
        {
            if (Request.IsAuthenticated)
                Logout();
        }

        private void SignInRemember(int userId, bool isPersistent = false)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.SetAuthCookie(userId.ToString(), isPersistent);
        }


    }
}
