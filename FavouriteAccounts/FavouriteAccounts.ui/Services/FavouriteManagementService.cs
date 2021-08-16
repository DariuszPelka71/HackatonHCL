using FavouriteAccounts.ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FavouriteAccounts.ui.Services
{
    public class FavouriteManagementService : IFavouriteManagementService
    {
        public int AddFavouriteAccount(FavouriteAccountModel model)
        {
            return 0;
        }

        public int DeleteFavouriteAccount(int favouriteAccountId)
        {
            return 0;
        }

        public int AmendFavouriteAccount(FavouriteAccountModel model)
        {
            return 0;
        }

        public FavouriteAccountModel GetFavouriteAccount(int favouriteAccountId)
        {
            return new FavouriteAccountModel();
        }

        public IList<FavouriteAccountModel> GetFavouriteAccounts(int customerId, int pageNumber = 1, int pageSize = 5)
        {
            return new List<FavouriteAccountModel>();
        }
    }
}