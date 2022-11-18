using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppTestGit;

namespace AppTestGit.Controllers
{
    public class CANDIDATsController : Controller
    {
        private DatabaseLocalEntities db = new DatabaseLocalEntities();

        // GET: CANDIDATs
        public ActionResult Index()
        {
            return View(db.CANDIDAT.ToList());
        }

        // GET: CANDIDATs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDAT cANDIDAT = db.CANDIDAT.Find(id);
            if (cANDIDAT == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDAT);
        }

        // GET: CANDIDATs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CANDIDATs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matricule,nom,prénom,mail,telephone,niveau,experience,dernier_employeur,cv_employeur")] CANDIDAT cANDIDAT)
        {
            if (ModelState.IsValid)
            {
                db.CANDIDAT.Add(cANDIDAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cANDIDAT);
        }

        // GET: CANDIDATs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDAT cANDIDAT = db.CANDIDAT.Find(id);
            if (cANDIDAT == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDAT);
        }

        // POST: CANDIDATs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matricule,nom,prénom,mail,telephone,niveau,experience,dernier_employeur,cv_employeur")] CANDIDAT cANDIDAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANDIDAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cANDIDAT);
        }

        // GET: CANDIDATs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDAT cANDIDAT = db.CANDIDAT.Find(id);
            if (cANDIDAT == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDAT);
        }

        // POST: CANDIDATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CANDIDAT cANDIDAT = db.CANDIDAT.Find(id);
            db.CANDIDAT.Remove(cANDIDAT);
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
        //public string PrintMessage()
        //{
        //    return 
        //}
    }
}
