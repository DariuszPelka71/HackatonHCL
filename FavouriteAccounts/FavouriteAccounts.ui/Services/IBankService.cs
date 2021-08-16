using FavouriteAccounts.ui.Models;

namespace FavouriteAccounts.ui.Services
{
    public interface IBankService
    {
        BankModel GetBank(string ibanCode);
    }
}