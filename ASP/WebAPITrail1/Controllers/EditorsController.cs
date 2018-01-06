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
using WebAPITrail1.Models;

namespace WebAPITrail1.Controllers
{
    public class EditorsController : ApiController
    {
        private WebAPITrail1Context db = new WebAPITrail1Context();

        // GET: api/Editors
        public IQueryable<Editor> GetEditors()
        {
            return db.Editors;
        }

        // GET: api/Editors/5
        [ResponseType(typeof(Editor))]
        public IHttpActionResult GetEditor(int id)
        {
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return NotFound();
            }

            return Ok(editor);
        }

        // PUT: api/Editors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEditor(int id, Editor editor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editor.EditorId)
            {
                return BadRequest();
            }

            db.Entry(editor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorExists(id))
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

        // POST: api/Editors
        [ResponseType(typeof(Editor))]
        public IHttpActionResult PostEditor(Editor editor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Editors.Add(editor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = editor.EditorId }, editor);
        }

        // DELETE: api/Editors/5
        [ResponseType(typeof(Editor))]
        public IHttpActionResult DeleteEditor(int id)
        {
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return NotFound();
            }

            db.Editors.Remove(editor);
            db.SaveChanges();

            return Ok(editor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EditorExists(int id)
        {
            return db.Editors.Count(e => e.EditorId == id) > 0;
        }
    }
}