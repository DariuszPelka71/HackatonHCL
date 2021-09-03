using FavouriteAccounts.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavouriteAccounts.api.Repository
{
    public interface IBankRepository
    {
        IQueryable<Bank> GetBanks();
        Bank GetBank(string bankCode);
        bool BankExists(int id);
    }
}
