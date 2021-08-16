using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FavouriteAccounts.api.Data
{
    public class FavouriteAccountsapiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FavouriteAccountsapiContext() : base("name=FavouriteAccountsapiContext")
        {
        }

        public System.Data.Entity.DbSet<FavouriteAccounts.api.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<FavouriteAccounts.api.Models.Bank> Banks { get; set; }
    }
}
