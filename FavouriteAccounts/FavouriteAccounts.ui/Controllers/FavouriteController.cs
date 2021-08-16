using FavouriteAccounts.ui.Helper;
using FavouriteAccounts.ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FavouriteAccounts.ui.Controllers
{
    public class FavouriteController : Controller
    {
        // GET: Favourite
        public ActionResult Index()
        {
            return View();
        }

        // GET: Favourite/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Favourite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Favourite/Create
        [HttpPost]
        public ActionResult Create(FavouriteAccountModel model)
        {
            try
            {
                model.CustomerId = 1; //To be replaced by the value from Session variable from login page
                model.BankId = 2;
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = FavouriteApiClient.webApiClient.PostAsync("FavoriteAccounts", data).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Favourite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Favourite/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Favourite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Favourite/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
