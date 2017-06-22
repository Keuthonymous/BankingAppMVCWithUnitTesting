using BankingMVCWithUnitTesting.DataAccess;
using BankingMVCWithUnitTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingMVCWithUnitTesting.Repositories
{
    public class AccountBankRepository
    {
        private BankContext db = new BankContext();

        public void AddAccountToBank(int? AccID, int? BankID)
        {
            Account a = db.Accounts.Find(AccID);
            Bank b = db.Banks.Find(BankID);

            if (!b.Accounts.Contains(a))
            {
                b.Accounts.Add(a);
                db.SaveChanges();
            }
        }

        public void DeleteAccountFromBank(int? AccID, int? BankID)
        {
            Account a = db.Accounts.Find(AccID);
            Bank b = db.Banks.Find(BankID);

            if (b.Accounts.Contains(a))
            {
                b.Accounts.Remove(a);
                db.SaveChanges();
            }
        }

        public IEnumerable<Account> ViewAccountsInBank(int? bankID)
        {
            Bank b = db.Banks.Find(bankID);

            return b.Accounts;
        }

        public IEnumerable<Account> ViewAccountsInBankBySSN(int? bankID, string ssn)
        {
            Bank b = db.Banks.Find(bankID);

            var query = from a in b.Accounts
                        where a.SSN == ssn
                        select a;
            return query;
        }

        public IEnumerable<Account> ViewAccountsInBankByFname(int? bankID, string Fname)
        {
            Bank b = db.Banks.Find(bankID);

            var query = from a in b.Accounts
                        where a.AccountHolderFName == Fname
                        select a;
            return query;
        }

        public IEnumerable<Account> ViewAccountsInBankByLname(int? bankID, string Lname)
        {
            Bank b = db.Banks.Find(bankID);

            var query = from a in b.Accounts
                        where a.AccountHolderLName == Lname
                        select a;
            return query;
        }

        public IEnumerable<Account> ViewAccountsInBankPhoneNum(int? bankID, int? PhoneNum)
        {
            Bank b = db.Banks.Find(bankID);

            var query = from a in b.Accounts
                        where a.PhoneNumber == PhoneNum
                        select a;
            return query;
        }

        public IEnumerable<Account> ViewAccountsInBankByEmail(int? bankID, string Email)
        {
            Bank b = db.Banks.Find(bankID);

            var query = from a in b.Accounts
                        where a.Email == Email
                        select a;
            return query;
        }
    }
}