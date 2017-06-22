using BankingMVCWithUnitTesting.DataAccess;
using BankingMVCWithUnitTesting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankingMVCWithUnitTesting.Repositories
{
    public class BanksRepository : IDisposable
    {
        BankContext db = new BankContext();

        public IEnumerable<Bank> GetAllBanks()
        {
            return db.Banks;
        }

        public Bank GetBankByID(int? id)
        {
            var query = (from b in db.Banks
                         where b.ID == id
                         select b).FirstOrDefault();
            return query;
        }

        public void Add(Bank bank)
        {
            if (!db.Banks.Contains(bank))
            {
                db.Banks.Add(bank);
                db.SaveChanges();
            }
        }

        public void Delete(Bank bank)
        {
            if (db.Banks.Contains(bank))
            {
                db.Banks.Remove(bank);
                db.SaveChanges();
            }
        }

        public void Edit(Bank bank)
        {
            if (db.Banks.Contains(bank))
            {
                db.Entry(bank).State = EntityState.Modified;
                db.SaveChanges();
            }
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