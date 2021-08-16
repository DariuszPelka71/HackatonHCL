using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FavouriteAccounts.ui.Helper
{
    public class IBANRetriever
    {
        public string RetrieveIBANCodeFromAcccountNumber(string accountNumber)
        {
            if (accountNumber.Length != 20)
            {
                throw new ArgumentException("Invalid length of account number. Account number should be 20 characters long.");
            }

            return accountNumber.Substring(4, 4);
        }
    }
}