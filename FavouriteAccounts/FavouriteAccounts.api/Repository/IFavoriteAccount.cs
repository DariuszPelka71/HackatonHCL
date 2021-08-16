using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavouriteAccounts.api.Models;

namespace FavouriteAccounts.api.Repository
{
    interface IFavoriteAccount
    {
        IQueryable<FavoriteAccount> Get();
        void Add(FavoriteAccount favoriteAccount);
        void Edit(FavoriteAccount favoriteAccount);
        void Delete(int id);
        bool Exists(int id);
    }
}
