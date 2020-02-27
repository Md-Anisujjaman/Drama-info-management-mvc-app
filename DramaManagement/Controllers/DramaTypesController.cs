using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DramaManagement.Models;

namespace DramaManagement.Controllers
{
    public class DramaTypesController : Controller
    {
        private DramaBDEntities db = new DramaBDEntities();

        // GET: DramaTypes
        public ActionResult Index()
        {
            return View(db.DramaTypes.ToList());
        }

        // GET: DramaTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DramaType dramaType = db.DramaTypes.Find(id);
            if (dramaType == null)
            {
                return HttpNotFound();
            }
            return View(dramaType);
        }

        // GET: DramaTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DramaTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DramaTypeID,TypeName")] DramaType dramaType)
        {
            if (ModelState.IsValid)
            {
                db.DramaTypes.Add(dramaType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dramaType);
        }

        // GET: DramaTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DramaType dramaType = db.DramaTypes.Find(id);
            if (dramaType == null)
            {
                return HttpNotFound();
            }
            return View(dramaType);
        }

        // POST: DramaTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DramaTypeID,TypeName")] DramaType dramaType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dramaType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dramaType);
        }

        // GET: DramaTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DramaType dramaType = db.DramaTypes.Find(id);
            if (dramaType == null)
            {
                return HttpNotFound();
            }
            return View(dramaType);
        }

        // POST: DramaTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DramaType dramaType = db.DramaTypes.Find(id);
            db.DramaTypes.Remove(dramaType);
            db.SaveChanges();
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
