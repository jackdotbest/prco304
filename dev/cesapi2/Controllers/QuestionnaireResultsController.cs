using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using cesapi2.Models;

namespace cesapi2.Controllers
{
    public class QuestionnaireResultsController : ApiController
    {
        private CE_DataEntities db = new CE_DataEntities();

        // GET: api/QuestionnaireResults
        public IQueryable<QuestionnaireResult> GetQuestionnaireResults()
        {
            return db.QuestionnaireResults;
        }

        // GET: api/QuestionnaireResults/5
        [ResponseType(typeof(QuestionnaireResult))]
        public IHttpActionResult GetQuestionnaireResult(int id)
        {
            QuestionnaireResult questionnaireResult = db.QuestionnaireResults.Find(id);
            if (questionnaireResult == null)
            {
                return NotFound();
            }

            return Ok(questionnaireResult);
        }

        // PUT: api/QuestionnaireResults/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaireResult(int id, QuestionnaireResult questionnaireResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaireResult.id)
            {
                return BadRequest();
            }

            db.Entry(questionnaireResult).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/QuestionnaireResults
        [ResponseType(typeof(QuestionnaireResult))]
        public IHttpActionResult PostQuestionnaireResult(QuestionnaireResult questionnaireResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionnaireResults.Add(questionnaireResult);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questionnaireResult.id }, questionnaireResult);
        }

        // DELETE: api/QuestionnaireResults/5
        [ResponseType(typeof(QuestionnaireResult))]
        public IHttpActionResult DeleteQuestionnaireResult(int id)
        {
            QuestionnaireResult questionnaireResult = db.QuestionnaireResults.Find(id);
            if (questionnaireResult == null)
            {
                return NotFound();
            }

            db.QuestionnaireResults.Remove(questionnaireResult);
            db.SaveChanges();

            return Ok(questionnaireResult);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireResultExists(int id)
        {
            return db.QuestionnaireResults.Count(e => e.id == id) > 0;
        }
    }
}