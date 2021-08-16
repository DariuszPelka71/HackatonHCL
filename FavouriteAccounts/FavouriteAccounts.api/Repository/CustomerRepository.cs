using FavouriteAccounts.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FavouriteAccounts.api.Repository
{
    public class CustomerRepository
    {
        private FavoritePayeeAccountsManagementEntities customerDB;

        public CustomerRepository()
        {
            customerDB = new FavoritePayeeAccountsManagementEntities();
        }

        public IQueryable<Customer> GetCustomers()
        {
            return customerDB.Customers.AsQueryable();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var bank = await customerDB.Customers.FindAsync(id);
            return bank;
        }

        public bool CustomerExists(int id)
        {
            return customerDB.Customers.Count(e => e.Id == id) > 0;
        }
    }
}