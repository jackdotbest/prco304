﻿using System;
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
    public class OrganisationsController : ApiController
    {
        private CE_DataEntities db = new CE_DataEntities();

        // GET: api/Organisations
        public IQueryable<Organisation> GetOrganisations()
        {
            return db.Organisations;
        }

        // GET: api/Organisations/5
        [ResponseType(typeof(Organisation))]
        public IHttpActionResult GetOrganisation(int id)
        {
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return NotFound();
            }

            return Ok(organisation);
        }

        // PUT: api/Organisations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganisation(int id, Organisation organisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organisation.Id)
            {
                return BadRequest();
            }

            db.Entry(organisation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganisationExists(id))
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

        // POST: api/Organisations
        [ResponseType(typeof(Organisation))]
        public IHttpActionResult PostOrganisation(Organisation organisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Organisations.Add(organisation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = organisation.Id }, organisation);
        }

        // DELETE: api/Organisations/5
        [ResponseType(typeof(Organisation))]
        public IHttpActionResult DeleteOrganisation(int id)
        {
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return NotFound();
            }

            db.Organisations.Remove(organisation);
            db.SaveChanges();

            return Ok(organisation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganisationExists(int id)
        {
            return db.Organisations.Count(e => e.Id == id) > 0;
        }
    }
}