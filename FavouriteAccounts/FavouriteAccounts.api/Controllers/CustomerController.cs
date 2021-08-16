using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FavouriteAccounts.api.Models;

namespace FavouriteAccounts.api.Controllers
{
    public class CustomerController : Controller
    {
        private FavoritePayeeAccountsManagementEntities customerDB;

        //Constructor
        public CustomerController()
        {
            customerDB  = new FavoritePayeeAccountsManagementEntities();
        }

        // GET: Customers
        /// <summary>
        /// Action to Get Customers
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var customers = customerDB.Customers;
            return View(await customers.ToListAsync());
        }

        // GET: Customers/Details/5
        /// <summary>
        /// Action to get Details of customer based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await customerDB.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
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