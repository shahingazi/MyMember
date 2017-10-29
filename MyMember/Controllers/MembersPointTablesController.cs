using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMember.Models;

namespace MyMember.Controllers
{
    public class MembersPointTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MembersPointTables
        public async Task<ActionResult> Index()
        {
            return View(await db.MembersPointTables.ToListAsync());
        }

        // GET: MembersPointTables/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersPointTable membersPointTable = await db.MembersPointTables.FindAsync(id);
            if (membersPointTable == null)
            {
                return HttpNotFound();
            }
            return View(membersPointTable);
        }

        // GET: MembersPointTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersPointTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Amount,Point,PointValue,MinimumPayoutPoint")] MembersPointTable membersPointTable)
        {

            membersPointTable.UserName = User.Identity.Name;
            db.MembersPointTables.Add(membersPointTable);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");


            return View(membersPointTable);
        }

        // GET: MembersPointTables/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersPointTable membersPointTable = await db.MembersPointTables.FindAsync(id);
            if (membersPointTable == null)
            {
                return HttpNotFound();
            }
            return View(membersPointTable);
        }

        // POST: MembersPointTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,Amount,Point,PointValue,MinimumPayoutPoint")] MembersPointTable membersPointTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membersPointTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(membersPointTable);
        }

        // GET: MembersPointTables/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersPointTable membersPointTable = await db.MembersPointTables.FindAsync(id);
            if (membersPointTable == null)
            {
                return HttpNotFound();
            }
            return View(membersPointTable);
        }

        // POST: MembersPointTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MembersPointTable membersPointTable = await db.MembersPointTables.FindAsync(id);
            db.MembersPointTables.Remove(membersPointTable);
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
