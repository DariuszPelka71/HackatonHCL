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
    using System.Collections.Generic;
    
    public partial class FavoriteAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerId { get; set; }
        public int BankId { get; set; }
    
        //public virtual Bank Bank { get; set; }
        //public virtual Customer Customer { get; set; }
    }
}
