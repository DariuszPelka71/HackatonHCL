﻿using FavouriteAccounts.ui.Helper;
using FavouriteAccounts.ui.Models;
using FavouriteAccounts.ui.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace FavouriteAccounts.ui.Controllers
{
    public class FavouriteController : Controller
    {
        IFavouriteManagementService favouriteManagementService;
        IBankService bankService;

        public FavouriteController()
        {
            // This should be replaced by dependency injection! so object should come from parameter of the controller!
            favouriteManagementService = new FavouriteManagementService();
            bankService = new BankService();
        }

        // GET: Favourite/Index
        public ActionResult Index()
        {
            IEnumerable<FavouriteAccountModel> favouriteList;
            HttpResponseMessage response = FavouriteApiClient.webApiClient.GetAsync("FavoriteAccounts").Result;
            favouriteList = response.Content.ReadAsAsync<List<FavouriteAccountModel>>().Result;
            return View(favouriteList);

            //mocked data here
            //var favouriteList = new List<FavouriteAccountModel>() { new FavouriteAccountModel { Id = 1, AccountNumber = "123123", BankId = 1, BankName = "ING", CustomerId = 1, Name = "Mocked - Investment Account" },
            //                                                    new FavouriteAccountModel { Id = 2, AccountNumber = "1253123", BankId = 1, BankName = "Euroclear", CustomerId = 1, Name = "Mocked - Private Account" }};
            //return View(favouriteList);
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

                // Validate bank account number
                if (model.AccountNumber.Length != 20)
                {
                    throw new ArgumentException("Invalid length of account number.Account number should be 20 characters long.");
                }
                var ibanRetriever = new IBANRetriever();
                var ibanCode = ibanRetriever.RetrieveIBANCodeFromAcccountNumber(model.AccountNumber);
                var bank = this.bankService.GetBank(ibanCode);
                model.BankId = 2;//Should be bank.Id!
                var status = favouriteManagementService.AddFavouriteAccount(model);

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
            var favouriteModel = new FavouriteAccountModel();
            HttpResponseMessage response = FavouriteApiClient.webApiClient.GetAsync("FavoriteAccounts/" + id.ToString()).Result;
            favouriteModel = response.Content.ReadAsAsync<FavouriteAccountModel>().Result;

            return View(favouriteModel);
        }

        // POST: Favourite/Edit/5
        [HttpPost]
        public ActionResult Edit(FavouriteAccountModel model)
        {
            try
            {
                model.Name = model.Name;
                var ibanRetriever = new IBANRetriever();
                var ibanCode = ibanRetriever.RetrieveIBANCodeFromAcccountNumber(model.AccountNumber);
                var bank = this.bankService.GetBank(ibanCode);
                //model.BankId = 1;//Should be bank.Id!
                var status = favouriteManagementService.AmendFavouriteAccount(model);

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
