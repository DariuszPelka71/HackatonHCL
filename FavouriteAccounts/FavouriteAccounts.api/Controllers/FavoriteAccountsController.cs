`using System;
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
using FavouriteAccounts.api.Utility;
using log4net;

namespace FavouriteAccounts.api.Controllers
{
    [CustomExceptionFilter]
    public class FavoriteAccountsController : ApiController
    {
        //private readonly FavoritePayeeAccountsManagementEntities db;
        private readonly IFavoriteAccount _favoriteAccount;
        private static readonly ILog _log = LogManager.GetLogger(typeof(FavoriteAccount));


        //public FavoriteAccountsController()
        //{
        //    //db = new FavoritePayeeAccountsManagementEntities();
        //    _favoriteAccount = new FavoriteAccountRepo();
        //}
        public FavoriteAccountsController(IFavoriteAccount favoriteAccount)
        {
            //db = new FavoritePayeeAccountsManagementEntities();
            _favoriteAccount = favoriteAccount;
        }

        // GET: api/FavoriteAccounts
        [ResponseType(typeof(IEnumerable<FavoriteAccount>))]
        public IEnumerable<FavoriteAccount> GetFavoriteAccounts()
        {
            //var temp = db.FavoriteAccounts.ToList();
            return _favoriteAccount.Get();
            //return db.FavoriteAccounts.ToList();
        }

        // GET: api/FavoriteAccounts/5
        [ResponseType(typeof(FavoriteAccount))]
        public IHttpActionResult GetFavoriteAccount(int id)
        {
            FavoriteAccount favoriteAccount = _favoriteAccount.GetById(id);
            if (favoriteAccount == null)
            {
                return NotFound();
            }

            return Ok(favoriteAccount);
        }

        // PUT: api/FavoriteAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFavoriteAccount(int id, FavoriteAccount favoriteAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favoriteAccount.Id)
            {
                return BadRequest();
            }

            //db.Entry(favoriteAccount).State = EntityState.Modified;

            try
            {
                _favoriteAccount.Edit(favoriteAccount);
                //await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteAccountExists(id))
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

        // POST: api/FavoriteAccounts
        [ResponseType(typeof(FavoriteAccount))]
        public  IHttpActionResult PostFavoriteAccount(FavoriteAccount favoriteAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _favoriteAccount.Add(favoriteAccount);
            //db.FavoriteAccounts.Add(favoriteAccount);
            //await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = favoriteAccount.Id }, favoriteAccount);
        }

        // DELETE: api/FavoriteAccounts/5
        [ResponseType(typeof(FavoriteAccount))]
        public IHttpActionResult DeleteFavoriteAccount(int id)
        {
            //FavoriteAccount favoriteAccount = await db.FavoriteAccounts.FindAsync(id);
            //if (favoriteAccount == null)
            //{
            //    return NotFound();
            //}

            _favoriteAccount.Delete(id);
            //db.FavoriteAccounts.Remove(favoriteAccount);
            //await db.SaveChangesAsync();

            return Ok(_favoriteAccount);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool FavoriteAccountExists(int id)
        {
            return _favoriteAccount.Exists(id);
            //return db.FavoriteAccounts.Count(e => e.Id == id) > 0;
        }
    }
}