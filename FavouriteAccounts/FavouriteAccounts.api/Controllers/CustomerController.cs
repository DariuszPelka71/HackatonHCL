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
    public class CustomerController : ApiController
    {
        private FavoritePayeeAccountsManagementEntities customerDB;

        public CustomerController()
        {
            customerDB = new FavoritePayeeAccountsManagementEntities();
        }
        /// <summary>
        /// Action to get the list of customers
        /// </summary>
        /// <returns></returns>
        // GET: api/Customer
        public IQueryable<Customer> GetCustomers()
        {
            return customerDB.Customers;
        }

        // GET: api/Customer/5
        /// <summary>
        /// Action to get the customer based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            Customer customer = await customerDB.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                customerDB.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return customerDB.Customers.Count(e => e.Id == id) > 0;
        }
    }
}