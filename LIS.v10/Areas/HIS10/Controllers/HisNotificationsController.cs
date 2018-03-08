using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIS.v10.Areas.HIS10.Models;

namespace LIS.v10.Areas.HIS10.Controllers
{
    public class HisNotificationsController : Controller
    {
        private His10DBContainer db = new His10DBContainer();
        private Models.DBClasses db1 = new DBClasses();

        // GET: HIS10/HisNotifications
        public ActionResult Index()
        {
            return View(db.HisNotifications.ToList());
        }

        

        // GET: HIS10/HisNotifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisNotification hisNotification = db.HisNotifications.Find(id);
            if (hisNotification == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.getNotificationLogs = db1.getNotificationLogs(id);

            return View(hisNotification);
        }

        // GET: HIS10/HisNotifications/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
         
        public ActionResult Create(int? id)
        {
            int requestid = (int)id;
            ViewBag.RefId = requestid.ToString();
            HisProfileReq req = db.HisProfileReqs.Where(s => s.Id == requestid).FirstOrDefault();
            //Models.HisRequest req = db.HisRequests.Find((int)requestid);
            if (requestid != 0)
            {

                Models.HisNotification temp = new HisNotification();
                temp.DtSending = (DateTime)req.dtSchedule;
                temp.RefId = requestid;
                temp.RecType = "Client";
                temp.RefTable = "HisProfileReqs";
                temp.Message = db1.generateMessage((int)requestid);

                //create contact list
                
                return View(temp);

            }

            return View();
        }

        // POST: HIS10/HisNotifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecType,Recipient,Message,DtSending,RefId,RefTable")] HisNotification hisNotification)
        {
            if (ModelState.IsValid)
            {
                db.HisNotifications.Add(hisNotification);
                
                Models.HisProfileReq request = db.HisProfileReqs.Find(hisNotification.RefId);
                request.dtRequested = DateTime.Now;
                request.dtSchedule = hisNotification.DtSending;
                
                //create contact lists

                HisNotificationRecipient recipient = new HisNotificationRecipient();
                recipient.HisNotificationId = hisNotification.Id;

                //get contact number of physician
                HisPhysician physician = db.HisPhysicians.Where(s => s.Id == request.HisPhysicianId).FirstOrDefault();
                var notify_Physician = new HisNotificationRecipient //Make sure you have a table called test in DB
                {
                    HisNotificationId = hisNotification.Id,
                    ContactInfo = physician.ContactInfo
                };

                //get contact number of incharge
                HisIncharge incharge = db.HisIncharges.Where(s => s.Id == request.HisInchargeId).FirstOrDefault();
                HisNotificationRecipient notify_inchage = new HisNotificationRecipient
                {
                    HisNotificationId = hisNotification.Id,
                    ContactInfo = incharge.ContactInfo
                };

                //get contact info of client (hisprofile)
                HisProfile client = db.HisProfiles.Where(s => s.Id == request.HisProfileId).FirstOrDefault();
                HisNotificationRecipient notify_client = new HisNotificationRecipient
                {
                    HisNotificationId = hisNotification.Id,
                    ContactInfo = client.ContactInfo
                };

                //add to database
                db.HisNotificationRecipients.Add(notify_Physician);
                db.HisNotificationRecipients.Add(notify_inchage);
                db.HisNotificationRecipients.Add(notify_client);
                db.SaveChanges();

                //HIS10/HisProfileReqs?RptType=1&status=0
                // return RedirectToAction("Details", "HisNotifications", new { id = hisNotification.Id });

                View(hisNotification);
            }

            return View(hisNotification);
        }

        // GET: HIS10/HisNotifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisNotification hisNotification = db.HisNotifications.Find(id);
            if (hisNotification == null)
            {
                return HttpNotFound();
            }
            return View(hisNotification);
        }

        // POST: HIS10/HisNotifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecType,Recipient,Message,DtSending,RefId,RefTable")] HisNotification hisNotification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hisNotification).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hisNotification);
        }

        // GET: HIS10/HisNotifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HisNotification hisNotification = db.HisNotifications.Find(id);
            if (hisNotification == null)
            {
                return HttpNotFound();
            }
            return View(hisNotification);
        }

        // POST: HIS10/HisNotifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HisNotification hisNotification = db.HisNotifications.Find(id);
            db.HisNotifications.Remove(hisNotification);
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
