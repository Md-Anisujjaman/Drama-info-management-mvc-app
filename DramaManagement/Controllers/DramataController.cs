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
    public class DramataController : Controller
    {
        private DramaBDEntities db = new DramaBDEntities();

        // GET: Dramata
        public async Task<ActionResult> Index()
        {
            var dramas = db.Dramas.Include(d => d.Director).Include(d => d.DramaType).Include(d => d.ScriptWriter);
            return View(await dramas.ToListAsync());
        }

        // GET: Dramata/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drama drama = await db.Dramas.FindAsync(id);
            if (drama == null)
            {
                return HttpNotFound();
            }
            return View(drama);
        }

        // GET: Dramata/Create
        public ActionResult Create()
        {
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "FirstName");
            ViewBag.DramaTypeID = new SelectList(db.DramaTypes, "DramaTypeID", "TypeName");
            ViewBag.SWID = new SelectList(db.ScriptWriters, "SWID", "FirstName");
            return View();
        }

        // POST: Dramata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DramaID,DirectorID,SWID,DramaTypeID,Title,ReleaseYear")] Drama drama)
        {
            if (ModelState.IsValid)
            {
                db.Dramas.Add(drama);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "FirstName", drama.DirectorID);
            ViewBag.DramaTypeID = new SelectList(db.DramaTypes, "DramaTypeID", "TypeName", drama.DramaTypeID);
            ViewBag.SWID = new SelectList(db.ScriptWriters, "SWID", "FirstName", drama.SWID);
            return View(drama);
        }

        // GET: Dramata/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drama drama = await db.Dramas.FindAsync(id);
            if (drama == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "FirstName", drama.DirectorID);
            ViewBag.DramaTypeID = new SelectList(db.DramaTypes, "DramaTypeID", "TypeName", drama.DramaTypeID);
            ViewBag.SWID = new SelectList(db.ScriptWriters, "SWID", "FirstName", drama.SWID);
            return View(drama);
        }

        // POST: Dramata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DramaID,DirectorID,SWID,DramaTypeID,Title,ReleaseYear")] Drama drama)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drama).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "FirstName", drama.DirectorID);
            ViewBag.DramaTypeID = new SelectList(db.DramaTypes, "DramaTypeID", "TypeName", drama.DramaTypeID);
            ViewBag.SWID = new SelectList(db.ScriptWriters, "SWID", "FirstName", drama.SWID);
            return View(drama);
        }

        // GET: Dramata/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drama drama = await db.Dramas.FindAsync(id);
            if (drama == null)
            {
                return HttpNotFound();
            }
            return View(drama);
        }

        // POST: Dramata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Drama drama = await db.Dramas.FindAsync(id);
            db.Dramas.Remove(drama);
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
