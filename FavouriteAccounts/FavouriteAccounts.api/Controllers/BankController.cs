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
using FavouriteAccounts.api.Repository;

namespace FavouriteAccounts.api.Controllers
{
    public class BankController : ApiController
    {
        private BankRepository  bankRepository;

        /// <summary>
        /// Constructor to initialize Context
        /// </summary>
        public BankController()
        {
            bankRepository = new BankRepository();
        }
        /// <summary>
        /// Action method to get bank list
        /// </summary>
        /// <returns></returns>
        // GET: api/Bank
        public IQueryable<Bank> GetBanks()
        {
            return bankRepository.GetBanks();
        }

        /// <summary>
        /// Method to get Bank detail based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Bank/5
        [ResponseType(typeof(Bank))]
        public IHttpActionResult GetBank(string Code)
        {
            Bank bank =  bankRepository.GetBank(Code);
            if (bank == null)
            {
                return NotFound();
            }

            return Ok(bank);
        }

        public bool BankExists(int id)
        {
            return bankRepository.BankExists(id);
        }
    }
}