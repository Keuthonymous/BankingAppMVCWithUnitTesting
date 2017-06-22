using BankingMVCWithUnitTesting.Models;
using BankingMVCWithUnitTesting.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BankingMVCWithUnitTesting.Controllers
{
    public class AccountBankController : Controller
    {
        AccountBankRepository ab = new AccountBankRepository();
        BanksRepository br = new BanksRepository();
        AccountRepository ar = new AccountRepository();

        // GET: AccountBank
        public ActionResult Index()
        {
            return View(br.GetAllBanks().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = br.GetBankByID(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        public ActionResult ViewAccounts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = br.GetBankByID(id);
            IEnumerable<Account> acc = bank.Accounts;
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(acc);
        }

        public ActionResult ViewTransHistory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = ar.GetById(id);
            IEnumerable<Trans> trans = account.Transactions;
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(trans);
        }

        public ActionResult Deposit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = ar.GetById(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(Account account, double amount)
        {
            if (ModelState.IsValid)
            {
                ab.Deposit(account, amount);
                return RedirectToAction("Index");
            }
            return View(account);
        }
    }
}