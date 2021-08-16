﻿using System;
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
using FavouriteAccounts.api.Data;
using FavouriteAccounts.api.Models;

namespace FavouriteAccounts.api.Controllers
{
    public class CustomerController : ApiController
    {
        private FavouriteAccountsapiContext customerDB;
        public CustomerController()
        {
            customerDB = new FavouriteAccountsapiContext();
        }

        // GET: api/Customer
        public IQueryable<Customer> GetCustomers()
        {
            return customerDB.Customers;
        }

        // GET: api/Customer/5
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

        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            customerDB.Entry(customer).State = EntityState.Modified;

            try
            {
                await customerDB.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customer
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customerDB.Customers.Add(customer);
            await customerDB.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customer/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            Customer customer = await customerDB.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customerDB.Customers.Remove(customer);
            await customerDB.SaveChangesAsync();

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