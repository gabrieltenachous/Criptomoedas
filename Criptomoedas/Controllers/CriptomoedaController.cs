using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Criptomoedas.Models;

namespace Criptomoedas.Controllers
{
    public class CriptomoedaController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Criptomoeda
        public ActionResult Index()
        {
            return View(db.Criptomoedas.ToList());
        }

        // GET: Criptomoeda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criptomoeda criptomoeda = db.Criptomoedas.Find(id);
            if (criptomoeda == null)
            {
                return HttpNotFound();
            }
            return View(criptomoeda);
        }

        // GET: Criptomoeda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Criptomoeda/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Quantidade,CheckBox")] Criptomoeda criptomoeda)
        {
            if (ModelState.IsValid)
            {
                db.Criptomoedas.Add(criptomoeda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(criptomoeda);
        }

        // GET: Criptomoeda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criptomoeda criptomoeda = db.Criptomoedas.Find(id);
            if (criptomoeda == null)
            {
                return HttpNotFound();
            }
            return View(criptomoeda);
        }

        // POST: Criptomoeda/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Quantidade,CheckBox")] Criptomoeda criptomoeda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criptomoeda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(criptomoeda);
        }

        // GET: Criptomoeda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criptomoeda criptomoeda = db.Criptomoedas.Find(id);
            if (criptomoeda == null)
            {
                return HttpNotFound();
            }
            return View(criptomoeda);
        }

        // POST: Criptomoeda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Criptomoeda criptomoeda = db.Criptomoedas.Find(id);
            db.Criptomoedas.Remove(criptomoeda);
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
