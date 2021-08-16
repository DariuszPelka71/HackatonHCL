using FavouriteAccounts.ui.Helper;
using FavouriteAccounts.ui.Models;
using FavouriteAccounts.ui.Services;
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
        IFavouriteManagementService favouriteManagementService;
        IBankService bankService;

        public FavouriteController()
        {
            // This should be replaced by dependency injection! so object should come from parameter of the controller!
            favouriteManagementService = new FavouriteManagementService();
            bankService = new BankService();
        }

        // GET: Favourite
        public ActionResult Index()
        {
            IEnumerable<FavouriteAccountModel> favouriteList;
            HttpResponseMessage response = FavouriteApiClient.webApiClient.GetAsync("FavoriteAccounts").Result;

            // todo manage data logic from response to list

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
            return View();
        }

        // POST: Favourite/Edit/5
        [HttpPost]
        public ActionResult Edit(FavouriteAccountModel model)
        {
            try
            {
                model.CustomerId = 1; //To be replaced by the value from Session variable from login page
                var ibanRetriever = new IBANRetriever();
                var ibanCode = ibanRetriever.RetrieveIBANCodeFromAcccountNumber(model.AccountNumber);
                var bank = this.bankService.GetBank(ibanCode);
                model.BankId = 2;//Should be bank.Id!
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
