using FavouriteAccounts.ui.Helper;
using FavouriteAccounts.ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace FavouriteAccounts.ui.Services
{
    public class BankService : IBankService
    {
        public BankModel GetBank(string ibanCode)
        {
            return new BankModel();
        }
    }
}