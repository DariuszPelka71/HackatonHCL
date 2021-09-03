using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FavouriteAccounts.api.Models;

namespace FavouriteAccounts.api.Repository
{
    public class BankRepository : IBankRepository
    {
        private FavoritePayeeAccountsManagementEntities bankDB;

        public BankRepository()
        {
            bankDB = new FavoritePayeeAccountsManagementEntities();
        }

        /// <summary>
        /// Get the Bank list
        /// </summary>
        /// <returns></returns>
        public IQueryable<Bank> GetBanks()
        {
            return bankDB.Banks.AsQueryable();
        }

        /// <summary>
        /// Get bank details based on Bank code
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        public Bank GetBank(string bankCode)
        {
            var bank = bankDB.Banks.Where(e=> e.Code == bankCode);
            return bank.FirstOrDefault();
        }

        /// <summary>
        /// Check if bank exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool BankExists(int id)
        {
            return bankDB.Banks.Count(e => e.Id == id) > 0;
        }

    }
}