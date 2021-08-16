using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FavouriteAccounts.api.Models;

namespace FavouriteAccounts.api.Controllers
{
    public class BankController : ApiController
    {
        private FavoritePayeeAccountsManagementEntities bankDB;
        public BankController()
        {
            bankDB = new FavoritePayeeAccountsManagementEntities();
        }


        // GET: api/Bank
        /// <summary>
        /// Method to get Banks list
        /// </summary>
        /// <returns></returns>
        public IQueryable<Bank> GetBanks()
        {
            return bankDB.Banks;
        }

        // GET: api/Bank/5
        /// <summary>
        /// Method to get Bank Detail based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Bank))]
        public async Task<IHttpActionResult> GetBank(int id)
        {
            Bank bank = await bankDB.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }

            return Ok(bank);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bankDB.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BankExists(int id)
        {
            return bankDB.Banks.Count(e => e.Id == id) > 0;
        }
    }
}