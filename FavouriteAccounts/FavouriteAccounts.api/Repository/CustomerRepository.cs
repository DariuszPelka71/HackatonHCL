using FavouriteAccounts.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FavouriteAccounts.api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private FavoritePayeeAccountsManagementEntities customerDB;

        public CustomerRepository()
        {
            customerDB = new FavoritePayeeAccountsManagementEntities();
        }

        /// <summary>
        /// Method to get the list of customers
        /// </summary>
        /// <returns></returns>
        public IQueryable<Customer> GetCustomers()
        {
            return customerDB.Customers.AsQueryable();
        }

        /// <summary>
        /// Get customer detail based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomer(int id)
        {
            var bank = await customerDB.Customers.FindAsync(id);
            return bank;
        }

        /// <summary>
        /// To check if Customer exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CustomerExists(int id)
        {
            return customerDB.Customers.Count(e => e.Id == id) > 0;
        }
    }
}