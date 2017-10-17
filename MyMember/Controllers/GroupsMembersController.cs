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
    public class GroupsMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GroupsMembers
        public async Task<ActionResult> Index()
        {
            return View(await db.GroupsMembers.ToListAsync());
        }

        // GET: GroupsMembers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupsMember groupsMember = await db.GroupsMembers.FindAsync(id);
            if (groupsMember == null)
            {
                return HttpNotFound();
            }
            return View(groupsMember);
        }

        // GET: GroupsMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupsMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CreateAt")] GroupsMember groupsMember)
        {
            if (ModelState.IsValid)
            {
                db.GroupsMembers.Add(groupsMember);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(groupsMember);
        }

        // GET: GroupsMembers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupsMember groupsMember = await db.GroupsMembers.FindAsync(id);
            if (groupsMember == null)
            {
                return HttpNotFound();
            }
            return View(groupsMember);
        }

        // POST: GroupsMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CreateAt")] GroupsMember groupsMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupsMember).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(groupsMember);
        }

        // GET: GroupsMembers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupsMember groupsMember = await db.GroupsMembers.FindAsync(id);
            if (groupsMember == null)
            {
                return HttpNotFound();
            }
            return View(groupsMember);
        }

        // POST: GroupsMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GroupsMember groupsMember = await db.GroupsMembers.FindAsync(id);
            db.GroupsMembers.Remove(groupsMember);
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
