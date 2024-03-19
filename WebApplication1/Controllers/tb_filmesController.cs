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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class tb_filmesController : ApiController
    {
        private p_etec_2024Entities1 db = new p_etec_2024Entities1();

        // GET: api/tb_filmes
        public IQueryable<tb_filmes> Gettb_filmes()
        {
            return db.tb_filmes;
        }

        // GET: api/tb_filmes/5
        [ResponseType(typeof(tb_filmes))]
        public IHttpActionResult Gettb_filmes(int id)
        {
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            if (tb_filmes == null)
            {
                return NotFound();
            }

            return Ok(tb_filmes);
        }

        // PUT: api/tb_filmes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_filmes(int id, tb_filmes tb_filmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_filmes.id_filme)
            {
                return BadRequest();
            }

            db.Entry(tb_filmes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_filmesExists(id))
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

        // POST: api/tb_filmes
        [ResponseType(typeof(tb_filmes))]
        public IHttpActionResult Posttb_filmes(tb_filmes tb_filmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_filmes.Add(tb_filmes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_filmes.id_filme }, tb_filmes);
        }

        // DELETE: api/tb_filmes/5
        [ResponseType(typeof(tb_filmes))]
        public IHttpActionResult Deletetb_filmes(int id)
        {
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            if (tb_filmes == null)
            {
                return NotFound();
            }

            db.tb_filmes.Remove(tb_filmes);
            db.SaveChanges();

            return Ok(tb_filmes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_filmesExists(int id)
        {
            return db.tb_filmes.Count(e => e.id_filme == id) > 0;
        }
    }
}