using FavouriteAccounts.ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FavouriteAccounts.ui.Services
{
    public interface IFavouriteManagementService
    {
        int AddFavouriteAccount(FavouriteAccountModel model);

        int DeleteFavouriteAccount(int favouriteAccountId);

        int AmendFavouriteAccount(FavouriteAccountModel model);

        FavouriteAccountModel GetFavouriteAccount(int favouriteAccountId);

        IList<FavouriteAccountModel> GetFavouriteAccounts(int customerId, int pageNumber = 1, int pageSize = 5);
    }
}