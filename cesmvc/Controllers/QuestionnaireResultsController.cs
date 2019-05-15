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
    [Authorize(Roles = "Admin, Examm")]
    public class QuestionnaireResultsController : Controller
    {
        private CE_DataEntities db = new CE_DataEntities();

        // GET: QuestionnaireResults
        public ActionResult Index()
        {
            var questionnaireResults = db.QuestionnaireResults.Include(q => q.Organisation1);
            return View(questionnaireResults.ToList());
        }

        // GET: QuestionnaireResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireResult questionnaireResult = db.QuestionnaireResults.Find(id);
            if (questionnaireResult == null)
            {
                return HttpNotFound();
            }
            return View(questionnaireResult);
        }

        // GET: QuestionnaireResults/Create
        public ActionResult Create()
        {
            ViewBag.organisation = new SelectList(db.Organisations, "Id", "NAME");
            return View();
        }

        // POST: QuestionnaireResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,organisation,C2_1,C2_2,C2_3,C3_1,C3_2,C3_3,C3_4,C3_5,C3_6,C3_7,C4_1,C4_2,C4_3,C4_4,C4_5,C4_6,C5_1,C5_2,C5_3,C5_4,C5_5,C5_6,C5_7,C6_1,C6_1_1,C6_1_2,C6_1_3,C6_1_4,C6_2,C6_2_1,C6_2_2,C6_2_3,C6_2_4,C6_3,C7_1,C7_2,C7_3")] QuestionnaireResult questionnaireResult)
        {
            if (ModelState.IsValid)
            {
                db.QuestionnaireResults.Add(questionnaireResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.organisation = new SelectList(db.Organisations, "Id", "NAME", questionnaireResult.organisation);
            return View(questionnaireResult);
        }

        // GET: QuestionnaireResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireResult questionnaireResult = db.QuestionnaireResults.Find(id);
            if (questionnaireResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.organisation = new SelectList(db.Organisations, "Id", "NAME", questionnaireResult.organisation);
            return View(questionnaireResult);
        }

        // POST: QuestionnaireResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,organisation,C2_1,C2_2,C2_3,C3_1,C3_2,C3_3,C3_4,C3_5,C3_6,C3_7,C4_1,C4_2,C4_3,C4_4,C4_5,C4_6,C5_1,C5_2,C5_3,C5_4,C5_5,C5_6,C5_7,C6_1,C6_1_1,C6_1_2,C6_1_3,C6_1_4,C6_2,C6_2_1,C6_2_2,C6_2_3,C6_2_4,C6_3,C7_1,C7_2,C7_3")] QuestionnaireResult questionnaireResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionnaireResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.organisation = new SelectList(db.Organisations, "Id", "NAME", questionnaireResult.organisation);
            return View(questionnaireResult);
        }

        // GET: QuestionnaireResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireResult questionnaireResult = db.QuestionnaireResults.Find(id);
            if (questionnaireResult == null)
            {
                return HttpNotFound();
            }
            return View(questionnaireResult);
        }

        // POST: QuestionnaireResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionnaireResult questionnaireResult = db.QuestionnaireResults.Find(id);
            db.QuestionnaireResults.Remove(questionnaireResult);
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
