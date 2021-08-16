using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FavouriteAccounts.api.Models;

namespace FavouriteAccounts.api.Repository
{
    public class BankRepository
    {
        private FavoritePayeeAccountsManagementEntities bankDB;

        public BankRepository()
        {
            bankDB = new FavoritePayeeAccountsManagementEntities();
        }

        public IQueryable<Bank> GetBanks()
        {
            return bankDB.Banks.AsQueryable();
        }

        public Bank GetBank(string Code)
        {
            var bank = bankDB.Banks.Where(e=> e.Code == Code);
            return bank.FirstOrDefault();
        }

        public bool BankExists(int id)
        {
            return bankDB.Banks.Count(e => e.Id == id) > 0;
        }

    }
}