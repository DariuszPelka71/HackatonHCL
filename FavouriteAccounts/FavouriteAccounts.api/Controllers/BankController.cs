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
using FavouriteAccounts.api.Data;
using FavouriteAccounts.api.Models;

namespace FavouriteAccounts.api.Controllers
{
    public class BankController : ApiController
    {
        private FavouriteAccountsapiContext bankDB;
        public BankController()
        {
            bankDB =  new FavouriteAccountsapiContext();
        }
        
        // GET: api/Bank
        public IQueryable<Bank> GetBanks()
        {
            return bankDB.Banks;
        }

        // GET: api/Bank/5
        [ResponseType(typeof(Bank))]
        public async Task<IHttpActionResult> GetBank(int id)
        {
            Bank bank = await bankDB.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }

            return Ok(bank);
        }

        // PUT: api/Bank/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBank(int id, Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank.Id)
            {
                return BadRequest();
            }

            bankDB.Entry(bank).State = EntityState.Modified;

            try
            {
                await bankDB.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(id))
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

        // POST: api/Bank
        [ResponseType(typeof(Bank))]
        public async Task<IHttpActionResult> PostBank(Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bankDB.Banks.Add(bank);
            await bankDB.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bank.Id }, bank);
        }

        // DELETE: api/Bank/5
        [ResponseType(typeof(Bank))]
        public async Task<IHttpActionResult> DeleteBank(int id)
        {
            Bank bank = await bankDB.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }

            bankDB.Banks.Remove(bank);
            await bankDB.SaveChangesAsync();

            return Ok(bank);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bankDB.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BankExists(int id)
        {
            return bankDB.Banks.Count(e => e.Id == id) > 0;
        }
    }
}