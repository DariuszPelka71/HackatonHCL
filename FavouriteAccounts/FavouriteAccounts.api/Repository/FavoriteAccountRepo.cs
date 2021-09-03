using FavouriteAccounts.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FavouriteAccounts.api.Repository
{
    public class FavoriteAccountRepo :IFavoriteAccount
    {
        private readonly FavoritePayeeAccountsManagementEntities _db;

        public FavoriteAccountRepo()
        {
            _db = new FavoritePayeeAccountsManagementEntities();
        }

        /// <summary>
        /// Get List of Favorite Account.
        /// </summary>
        /// <returns></returns>
        public IQueryable<FavoriteAccount> Get()
        {
            return _db.FavoriteAccounts;
        }

        /// <summary>
        /// Get List of Favorite Account.
        /// </summary>
        /// <returns></returns>
        public FavoriteAccount GetById(int id)
        {
            return _db.FavoriteAccounts.FirstOrDefault(x => x.Id == id); 
        }



        /// <summary>
        /// Add new Favorite Account.
        /// </summary>
        /// <param name="favoriteAccount"></param>
        public void Add(FavoriteAccount favoriteAccount)
        {
            _db.FavoriteAccounts.Add(favoriteAccount);
            _db.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Favorite Account.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var account = _db.FavoriteAccounts.FirstOrDefault(x => x.Id == id);
            _db.FavoriteAccounts.Remove(account);
            _db.SaveChangesAsync();
        }
        /// <summary>
        /// Edit Favorite Account.
        /// </summary>
        /// <param name="favoriteAccount"></param>
        public void Edit(FavoriteAccount favoriteAccount)
        {
            _db.Entry(favoriteAccount).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChangesAsync();
        }
        /// <summary>
        /// Check Favorite Account is exists 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            var account = _db.FavoriteAccounts.FirstOrDefault(x => x.Id == id);
            return account != null;
        }
    }
}