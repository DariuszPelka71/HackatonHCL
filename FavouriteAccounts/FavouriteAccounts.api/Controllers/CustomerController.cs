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
    public class CustomerController : ApiController
    {
        private CustomerRepository customerRepository;

        public CustomerController()
        {
            customerRepository = new CustomerRepository();
        }
        /// <summary>
        /// Action to get the list of customers
        /// </summary>
        /// <returns></returns>
        // GET: api/Customer
        public IQueryable<Customer> GetCustomers()
        {
            return customerRepository.GetCustomers();
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
            Customer customer = await customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Method to check if the customer exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CustomerExists(int id)
        {
            return customerRepository.CustomerExists(id);
        }
    }
}