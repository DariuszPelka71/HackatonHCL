//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FavouriteAccounts.api.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FavoritePayeeAccountsManagementEntities : DbContext
    {
        public FavoritePayeeAccountsManagementEntities()
            : base("name=FavoritePayeeAccountsManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FavoriteAccount> FavoriteAccounts { get; set; }
    }
}
