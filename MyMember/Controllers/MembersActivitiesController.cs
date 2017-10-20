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
    public class MembersActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MembersActivities
        public async Task<ActionResult> Index()
        {
            var membersActivities = db.MembersActivities.Include(m => m.Members);
            return View(await membersActivities.ToListAsync());
        }

        // GET: MembersActivities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersActivity membersActivity = await db.MembersActivities.FindAsync(id);
            if (membersActivity == null)
            {
                return HttpNotFound();
            }
            return View(membersActivity);
        }

        // GET: MembersActivities/Create
        public ActionResult Create(int id)
        {
            //ViewBag.MemberId = id; //new SelectList(db.Members, "Id", "FirstName");

            var member = db.Members.Find(id);
            if(member ==null)
            {
                return HttpNotFound();
            }
            var memberActivity = new MembersActivity
            {
                MemberId = member.Id
            };

            return View(memberActivity);
        }

        // POST: MembersActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Amount,Text,CreatedAt,MemberId")] MembersActivity membersActivity)
        {
            membersActivity.CreatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                
                db.MembersActivities.Add(membersActivity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", membersActivity.MemberId);
            return View(membersActivity);
        }

        // GET: MembersActivities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersActivity membersActivity = await db.MembersActivities.FindAsync(id);
            if (membersActivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", membersActivity.MemberId);
            return View(membersActivity);
        }

        // POST: MembersActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Amount,Text,CreatedAt,MemberId")] MembersActivity membersActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membersActivity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", membersActivity.MemberId);
            return View(membersActivity);
        }

        // GET: MembersActivities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersActivity membersActivity = await db.MembersActivities.FindAsync(id);
            if (membersActivity == null)
            {
                return HttpNotFound();
            }
            return View(membersActivity);
        }

        // POST: MembersActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MembersActivity membersActivity = await db.MembersActivities.FindAsync(id);
            db.MembersActivities.Remove(membersActivity);
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
