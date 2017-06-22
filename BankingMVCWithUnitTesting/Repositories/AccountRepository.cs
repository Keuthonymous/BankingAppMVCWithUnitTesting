using BankingMVCWithUnitTesting.DataAccess;
using BankingMVCWithUnitTesting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankingMVCWithUnitTesting.Repositories
{
    public class AccountRepository : IDisposable
    {
        private BankContext db = new BankContext();

        public IEnumerable<Account> GetAllAccounts()
        {
            return db.Accounts;
        }

        public void Add(Account account)
        {
            if (!db.Accounts.Contains(account))
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        public void Delete(Account account)
        {
            db.Accounts.Remove(account);
            db.SaveChanges();
        }

        public void Edit(Account account)
        {
            if (db.Accounts.Contains(account))
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Account GetById(int? id)
        {
            var query = (from a in db.Accounts
                         where a.ID == id
                         select a).FirstOrDefault();

            return query;
        }

        public IEnumerable<Account> GetByFName(string Fname)
        {
            var query = from a in db.Accounts
                        where a.AccountHolderFName == Fname
                        select a;
            return query;
        }

        public IEnumerable<Account> GetByLName(string Lname)
        {
            var query = from a in db.Accounts
                        where a.AccountHolderLName == Lname
                        select a;
            return query;
        }

        public Account GetBySSN(string ssn)
        {
            var query = (from a in db.Accounts
                         where a.SSN == ssn
                         select a).FirstOrDefault();
            return query;
        }

        public Account GetByEmail(string Email)
        {
            var query = (from a in db.Accounts
                         where a.Email == Email
                         select a).FirstOrDefault();
            return query;
        }

        public Account GetByPhoneNum(int PhoneNum)
        {
            var query = (from a in db.Accounts
                         where a.PhoneNumber == PhoneNum
                         select a).FirstOrDefault();
            return query;
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}