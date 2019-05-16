using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cesmvc.Models;

namespace cesmvc.Controllers
{
    [Authorize(Roles = "Admin, Exam")]
    public class OrganisationsController : Controller
    {
        private CE_DataEntities db = new CE_DataEntities();

        // GET: Organisations
        public ActionResult Index()
        {
            var organisations = db.Organisations.Include(o => o.Person).Include(o => o.Person1);
            return View(organisations.ToList());
        }

        // GET: Organisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // GET: Organisations/Create
        public ActionResult Create()
        {
            ViewBag.CONTACTID = new SelectList(db.People, "Id", "FORENAME");
            ViewBag.INVOICEID = new SelectList(db.People, "Id", "FORENAME");
            return View();
        }

        // POST: Organisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NAME,SECTOR,EMPLOYEES,CONTACTID,INVOICEID,WEBADDRESS,INCLUDEREGISTER,INCLUDEMARKETING")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                db.Organisations.Add(organisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CONTACTID = new SelectList(db.People, "Id", "FORENAME", organisation.CONTACTID);
            ViewBag.INVOICEID = new SelectList(db.People, "Id", "FORENAME", organisation.INVOICEID);
            return View(organisation);
        }

        // GET: Organisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONTACTID = new SelectList(db.People, "Id", "FORENAME", organisation.CONTACTID);
            ViewBag.INVOICEID = new SelectList(db.People, "Id", "FORENAME", organisation.INVOICEID);
            return View(organisation);
        }

        // POST: Organisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NAME,SECTOR,EMPLOYEES,CONTACTID,INVOICEID,WEBADDRESS,INCLUDEREGISTER,INCLUDEMARKETING")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CONTACTID = new SelectList(db.People, "Id", "FORENAME", organisation.CONTACTID);
            ViewBag.INVOICEID = new SelectList(db.People, "Id", "FORENAME", organisation.INVOICEID);
            return View(organisation);
        }

        // GET: Organisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // POST: Organisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organisation organisation = db.Organisations.Find(id);
            db.Organisations.Remove(organisation);
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
