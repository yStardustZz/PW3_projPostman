using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class tb_filmes1Controller : Controller
    {
        private p_etec_2024Entities2 db = new p_etec_2024Entities2();

        // GET: tb_filmes1
        public ActionResult Index()
        {
            return View(db.tb_filmes.ToList());
        }

        // GET: tb_filmes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            if (tb_filmes == null)
            {
                return HttpNotFound();
            }
            return View(tb_filmes);
        }

        // GET: tb_filmes1/Create
        public ActionResult Create()
        {
            return View();
        }

        //GET: tb_filmes1/Api
        public ActionResult Api()
        {
            return View();
        }

        // POST: tb_filmes1/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_filme,nome_filme,genero_filme,prod_filme,ano_filme")] tb_filmes tb_filmes)
        {
            if (ModelState.IsValid)
            {
                db.tb_filmes.Add(tb_filmes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_filmes);
        }

        // GET: tb_filmes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            if (tb_filmes == null)
            {
                return HttpNotFound();
            }
            return View(tb_filmes);
        }

        // POST: tb_filmes1/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_filme,nome_filme,genero_filme,prod_filme,ano_filme")] tb_filmes tb_filmes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_filmes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_filmes);
        }

        // GET: tb_filmes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            if (tb_filmes == null)
            {
                return HttpNotFound();
            }
            return View(tb_filmes);
        }

        // POST: tb_filmes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            db.tb_filmes.Remove(tb_filmes);
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
