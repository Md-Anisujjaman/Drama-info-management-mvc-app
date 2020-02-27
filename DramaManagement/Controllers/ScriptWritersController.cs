using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DramaManagement.Models;

namespace DramaManagement.Controllers
{
    public class ScriptWritersController : Controller
    {
        private DramaBDEntities db = new DramaBDEntities();

        // GET: ScriptWriters
        public async Task<ActionResult> Index()
        {
            return View(await db.ScriptWriters.ToListAsync());
        }

        // GET: ScriptWriters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptWriter scriptWriter = await db.ScriptWriters.FindAsync(id);
            if (scriptWriter == null)
            {
                return HttpNotFound();
            }
            return View(scriptWriter);
        }

        // GET: ScriptWriters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScriptWriters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SWID,FirstName,LastName,Gender")] ScriptWriter scriptWriter)
        {
            if (ModelState.IsValid)
            {
                db.ScriptWriters.Add(scriptWriter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(scriptWriter);
        }

        // GET: ScriptWriters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptWriter scriptWriter = await db.ScriptWriters.FindAsync(id);
            if (scriptWriter == null)
            {
                return HttpNotFound();
            }
            return View(scriptWriter);
        }

        // POST: ScriptWriters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SWID,FirstName,LastName,Gender")] ScriptWriter scriptWriter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scriptWriter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(scriptWriter);
        }

        // GET: ScriptWriters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptWriter scriptWriter = await db.ScriptWriters.FindAsync(id);
            if (scriptWriter == null)
            {
                return HttpNotFound();
            }
            return View(scriptWriter);
        }

        // POST: ScriptWriters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ScriptWriter scriptWriter = await db.ScriptWriters.FindAsync(id);
            db.ScriptWriters.Remove(scriptWriter);
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
