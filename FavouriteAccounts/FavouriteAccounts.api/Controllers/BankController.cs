using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FavouriteAccounts.api.Models;

namespace FavouriteAccounts.api.Controllers
{
    public class BankController : Controller
    {
        private FavoritePayeeAccountsManagementEntities bankDB;

        //Constructor
        public BankController()
        {
            bankDB = new FavoritePayeeAccountsManagementEntities();
        }

        // GET: Banks
        /// <summary>
        /// Action to Get Banks list
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var banks = bankDB.Banks;
            return View(await banks.ToListAsync());
        }

        // GET: Banks/Details/5
        /// <summary>
        /// Action to get Details of bank based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = await bankDB.Banks.FindAsync(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bankDB.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// method to check if banks exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CustomerExists(int id)
        {
            return bankDB.Banks.Count(e => e.Id == id) > 0;
        }
    }
}