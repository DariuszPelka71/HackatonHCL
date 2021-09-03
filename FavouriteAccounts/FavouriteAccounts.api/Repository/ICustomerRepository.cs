using FavouriteAccounts.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavouriteAccounts.api.Repository
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();
        Task<Customer> GetCustomer(int id);

        bool CustomerExists(int id);
    }
}
