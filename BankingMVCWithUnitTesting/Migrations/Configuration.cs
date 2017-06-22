namespace BankingMVCWithUnitTesting.Migrations
{
    using BankingMVCWithUnitTesting.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BankingMVCWithUnitTesting.DataAccess.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BankingMVCWithUnitTesting.DataAccess.BankContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Accounts.AddOrUpdate(
                a => a.ID,
                new Account { AccountHolderFName = "Mike", AccountHolderLName = "Daughtrey", Address = "A Place", SSN = "123-12-1234", Email = "Something@something.com", PhoneNumber = 0705550127 },
                new Account { AccountHolderFName = "Liam", AccountHolderLName = "Something", Address = "Another Place", SSN = "124-12-1234", Email = "Something@somethingelse.com", PhoneNumber = 0705550128 },
                new Account { AccountHolderFName = "Tarek", AccountHolderLName = "Bouzo", Address = "A Place Somewhere else", SSN = "125-12-1234", Email = "Something@anotherthing.com", PhoneNumber = 0705550129 }
                );

        }
    }
}
