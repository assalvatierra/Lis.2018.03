using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIS.v10.Areas.Rpi.Models;

namespace LIS.v10.Areas.Rpi.Controllers
{
    public class RpiControlsController : Controller
    {
        private RpiDBContainer1 db = new RpiDBContainer1();

        // GET: Rpi/RpiControls
        public ActionResult Index(int? id)
        {
            var rpiControls = db.RpiControls.Include(r => r.RpiDevice);
            return View(rpiControls.Where(r=>r.RpiDeviceId == id).ToList());
        }

        // GET: Rpi/RpiControls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RpiControl rpiControl = db.RpiControls.Find(id);
            if (rpiControl == null)
            {
                return HttpNotFound();
            }
            return View(rpiControl);
        }

        // GET: Rpi/RpiControls/Create
        public ActionResult Create()
        {
            ViewBag.RpiDeviceId = new SelectList(db.RpiDevices, "Id", "Description");
            return View();
        }

        // POST: Rpi/RpiControls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DtSchedule,Data,RpiDeviceId")] RpiControl rpiControl)
        {
            if (ModelState.IsValid)
            {
                db.RpiControls.Add(rpiControl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RpiDeviceId = new SelectList(db.RpiDevices, "Id", "Description", rpiControl.RpiDeviceId);
            return View(rpiControl);
        }

        // GET: Rpi/RpiControls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RpiControl rpiControl = db.RpiControls.Find(id);
            if (rpiControl == null)
            {
                return HttpNotFound();
            }
            ViewBag.RpiDeviceId = new SelectList(db.RpiDevices, "Id", "Description", rpiControl.RpiDeviceId);
            return View(rpiControl);
        }

        // POST: Rpi/RpiControls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DtSchedule,Data,RpiDeviceId")] RpiControl rpiControl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rpiControl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RpiDeviceId = new SelectList(db.RpiDevices, "Id", "Description", rpiControl.RpiDeviceId);
            return View(rpiControl);
        }

        // GET: Rpi/RpiControls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RpiControl rpiControl = db.RpiControls.Find(id);
            if (rpiControl == null)
            {
                return HttpNotFound();
            }
            return View(rpiControl);
        }

        // POST: Rpi/RpiControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RpiControl rpiControl = db.RpiControls.Find(id);
            db.RpiControls.Remove(rpiControl);
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
