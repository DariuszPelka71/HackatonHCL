namespace FavouriteAccounts.ui.Models
{
    public class FavouriteAccountModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AccountNumber { get; set; }

        public int CustomerId { get; set; }

        public int BankId { get; set; }

        public BankModel Bank { get; set; }
        public CustomerModel Customer { get; set; }
    }
}