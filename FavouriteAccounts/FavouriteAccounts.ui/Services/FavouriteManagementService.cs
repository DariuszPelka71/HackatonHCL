using FavouriteAccounts.ui.Helper;
using FavouriteAccounts.ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace FavouriteAccounts.ui.Services
{
    public class FavouriteManagementService : IFavouriteManagementService
    {
        public int AddFavouriteAccount(FavouriteAccountModel model)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = FavouriteApiClient.webApiClient.PostAsync("FavoriteAccounts", data).Result;
            return 0;
        }

        public int DeleteFavouriteAccount(int favouriteAccountId)
        {
            return 0;
        }

        public int AmendFavouriteAccount(FavouriteAccountModel model)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = FavouriteApiClient.webApiClient.PutAsync("FavoriteAccounts/" + model.Id.ToString(), data).Result;
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