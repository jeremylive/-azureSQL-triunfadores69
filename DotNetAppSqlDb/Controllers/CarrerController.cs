using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Models;using System.Diagnostics;

namespace DotNetAppSqlDb.Controllers
{
    public class TodosController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Carrer
        public ActionResult Index()
        {            
            Trace.WriteLine("GET /Carrer/Index");
            return View(db.CarrerM.ToList());
        }

        // GET: Carrer/Details/5
        public ActionResult Details(int? id)
        {
            Trace.WriteLine("GET /Carrer/Details/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrer carrer = db.CarrerM.Find(id);
            if (carrer == null)
            {
                return HttpNotFound();
            }
            return View(carrer);
        }

        // GET: Carrer/Create
        public ActionResult Create()
        {
            Trace.WriteLine("GET /Carrer/Create");
            return View(new Carrer {});
        }

        // POST: Carrer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,CreatedDate")] Carrer carrer)
        {
            Trace.WriteLine("POST /Carrer/Create");
            if (ModelState.IsValid)
            {
                db.CarrerM.Add(carrer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carrer);
        }

        // GET: Carrer/Edit/5
        public ActionResult Edit(int? id)
        {
            Trace.WriteLine("GET /Carrer/Edit/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrer carrer = db.CarrerM.Find(id);
            if (carrer == null)
            {
                return HttpNotFound();
            }
            return View(carrer);
        }

        // POST: Carrer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Description,CreatedDate")] Carrer carrer)
        {
            Trace.WriteLine("POST /Carrer/Edit/" + carrer.id);
            if (ModelState.IsValid)
            {
                db.Entry(carrer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrer);
        }

        // GET: Carrer/Delete/5
        public ActionResult Delete(int? id)
        {
            Trace.WriteLine("GET /Carrer/Delete/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrer carrer = db.CarrerM.Find(id);
            if (carrer == null)
            {
                return HttpNotFound();
            }
            return View(carrer);
        }

        // POST: Carrer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trace.WriteLine("POST /Carrer/Delete/" + id);
            Carrer carrer = db.CarrerM.Find(id);
            db.CarrerM.Remove(carrer);
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
