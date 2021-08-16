using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FavouriteAccounts.api.Models;

namespace FavouriteAccounts.api.Controllers
{
    public class FavoriteAccountsController : Controller
    {
        private FavoritePayeeAccountsManagementEntities db = new FavoritePayeeAccountsManagementEntities();

        // GET: FavoriteAccounts
        public async Task<ActionResult> Index()
        {
            var favoriteAccounts = db.FavoriteAccounts.Include(f => f.Bank).Include(f => f.Customer);
            return View(await favoriteAccounts.ToListAsync());
        }

        // GET: FavoriteAccounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteAccount favoriteAccount = await db.FavoriteAccounts.FindAsync(id);
            if (favoriteAccount == null)
            {
                return HttpNotFound();
            }
            return View(favoriteAccount);
        }

        // GET: FavoriteAccounts/Create
        public ActionResult Create()
        {
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Code");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            return View();
        }

        // POST: FavoriteAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,AccountNumber,CustomerId,BankId")] FavoriteAccount favoriteAccount)
        {
            if (ModelState.IsValid)
            {
                db.FavoriteAccounts.Add(favoriteAccount);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BankId = new SelectList(db.Banks, "Id", "Code", favoriteAccount.BankId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", favoriteAccount.CustomerId);
            return View(favoriteAccount);
        }

        // GET: FavoriteAccounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteAccount favoriteAccount = await db.FavoriteAccounts.FindAsync(id);
            if (favoriteAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Code", favoriteAccount.BankId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", favoriteAccount.CustomerId);
            return View(favoriteAccount);
        }

        // POST: FavoriteAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,AccountNumber,CustomerId,BankId")] FavoriteAccount favoriteAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favoriteAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Code", favoriteAccount.BankId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", favoriteAccount.CustomerId);
            return View(favoriteAccount);
        }

        // GET: FavoriteAccounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteAccount favoriteAccount = await db.FavoriteAccounts.FindAsync(id);
            if (favoriteAccount == null)
            {
                return HttpNotFound();
            }
            return View(favoriteAccount);
        }

        // POST: FavoriteAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FavoriteAccount favoriteAccount = await db.FavoriteAccounts.FindAsync(id);
            db.FavoriteAccounts.Remove(favoriteAccount);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
