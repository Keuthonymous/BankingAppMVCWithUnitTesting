using BankingMVCWithUnitTesting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankingMVCWithUnitTesting.DataAccess
{
    public class BankContext : DbContext
    {
        public BankContext() : base("DefaultConnection") { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bank> Banks { get; set; }

        public System.Data.Entity.DbSet<BankingMVCWithUnitTesting.Models.Trans> Trans { get; set; }
    }
}