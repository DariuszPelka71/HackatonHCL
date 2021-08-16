using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FavouriteAccounts.ui.Helper
{
    public class FavouriteApiClient
    {
        public static HttpClient webApiClient = new HttpClient();

        static FavouriteApiClient()
        {
            webApiClient.BaseAddress = new Uri("https://localhost:44357/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}