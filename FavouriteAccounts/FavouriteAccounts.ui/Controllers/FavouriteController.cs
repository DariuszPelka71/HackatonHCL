using FavouriteAccounts.ui.Helper;
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
            IList<FavouriteAccountModel> favouriteList;
            HttpResponseMessage response = FavouriteApiClient.webApiClient.GetAsync("FavoriteAccounts").Result;

            var customerData = response.Content.ReadAsStringAsync();
            var jsonString = customerData.Result;

            // this below lists return not valid list because of the 1st element fine and next elements null
            favouriteList = response.Content.ReadAsAsync<List<FavouriteAccountModel>>().Result;
            var temp = JsonConvert.DeserializeObject<List<FavouriteAccountModel>>(jsonString).Where(i => i != null);

            return View(temp);

            //mocked data here
            //var favouriteList = new List<FavouriteAccountModel>() { new FavouriteAccountModel { Id = 4, AccountNumber = "123123", BankId = 1, BankName = "ing", CustomerId = 1, Name = "investment account" },
            //                                                    new FavouriteAccountModel { Id = 2, AccountNumber = "1253123", BankId = 1, BankName = "euroclear", CustomerId = 1, Name = "private account" }};
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
            return View(id);
        }

        // POST: Favourite/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpResponseMessage result;

                var deleteEmployeeTask = FavouriteApiClient.webApiClient.DeleteAsync("FavoriteAccounts/" + id.ToString()).Result;
                //deleteEmployeeTask.Wait();
                //result = deleteEmployeeTask.Result;

                if (deleteEmployeeTask.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
