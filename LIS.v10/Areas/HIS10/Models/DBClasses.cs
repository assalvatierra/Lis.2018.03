using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIS.v10.Areas.HIS10.Models
{
    public class SmsNotificationItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class SmsNotificationMsg
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
    }

    public class NotificationLog
    {
        public int Id { get; set; }
        public String HisNotificationId { get; set; }
        public string DtSending { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }



    public class DBClasses
    {
        public Models.His10DBContainer db = new His10DBContainer();

        public List<SmsNotificationItem> getList()
        {
            List<SmsNotificationItem> hisrequests = db.HisRequests
                .Select(s => new SmsNotificationItem { Id = s.Id, Description = s.Description })
                .ToList();

            return hisrequests;
        }

        public SmsNotificationMsg getAdminMessage(int id)
        {
            HisRequest request = db.HisRequests.Find(id);

            SmsNotificationMsg msg = new SmsNotificationMsg
            {
                    Id = request.Id,
                    MessageBody = request.Title
                };

            return msg;
        }

        

        public SmsNotificationMsg getClientMessage(int id)
        {
            HisRequest request = db.HisRequests.Find(id);
            SmsNotificationMsg msg = new SmsNotificationMsg
            {
                Id = request.Id,
                MessageBody = request.Title
            };

            return msg;
        }

        public int updateItemStatus(int status)
        {
            return 1;
        }


        //added by jahdiel
        public HisNotificationLog getNotificationLogs(int? id)
        {
            return db.HisNotificationLogs.Find(id);
        }


        public List<HisNotificationLog> getNotificationLogs()
        {
            return db.HisNotificationLogs.ToList();
            
        }

        public List<HisNotification> getNotifList()
        {

            var data = db.HisNotifications.Select(s => new {
                s.Id,
                s.RecType,
                s.Recipient,
                s.Message,
                s.DtSending
            });

            return db.HisNotifications.ToList();
        }

        public List<HisNotification> getAdminNotif()
        {
            return db.HisNotifications.Where(d => d.RecType == "Admin").ToList();
        }

        public List<HisNotification> getClientNotif()
        {
            return db.HisNotifications.Where(d => d.RecType == "Client").ToList();
        }

        public void insertNewLog(HisNotificationLog newNotifLog)
        {
            db.HisNotificationLogs.Add(newNotifLog);
            db.SaveChanges();
        }


        //for hisnotificationController

        //make from message template
        //---------------------------------------------
        //NOTIFICATION
        //For: <HisProfile.Name>
        //Request: <HisRequest.Title> <HisProfile.Remarks>
        //Scheduled on: <HisProfileReq.DtSchedule>
        //By: <HisPhysician.Name>
        //Assisted by: <HisIncharge.Name>
        //---------------------------------------------

        public string generateMessage(int requestId)
        {

            string messageTemplate = "";
            string Formsg = " ", Requestmsg = " ", Scheduledmsg = " ", Physicianmsg = " ", Assistedmsg = " ";

            HisProfileReq profilereq = db.HisProfileReqs.Where(s => s.Id == requestId).FirstOrDefault();

            //get profilename
            HisProfile profile = db.HisProfiles.Where(s => s.Id == profilereq.HisProfileId).FirstOrDefault();
            Formsg = profile.Name;

            //get request title and remarks
            HisRequest request = db.HisRequests.Where(s => s.Id == profilereq.HisRequestId).FirstOrDefault();

            Requestmsg = request.Title + "  " + profilereq.Remarks;

            //get schedule
            Scheduledmsg = profilereq.dtSchedule.ToString();

            //get physician from hisPhysician
            HisPhysician physician = db.HisPhysicians.Where(s => s.Id == profilereq.HisPhysicianId).FirstOrDefault();
            Physicianmsg = physician.Name;

            //get hisincharge name
            HisIncharge incharge = db.HisIncharges.Where(s => s.Id == profilereq.HisInchargeId).FirstOrDefault();
            Assistedmsg = incharge.Name;

            messageTemplate = "NOTIFICATION"   + Environment.NewLine + Environment.NewLine +
                "For: "         + Formsg       + Environment.NewLine +
                "Request: "     + Requestmsg   + Environment.NewLine +
                "Scheduled: "   + Scheduledmsg + Environment.NewLine +
                "By: "          + Physicianmsg + Environment.NewLine +
                "Assisted By: " + Assistedmsg  + Environment.NewLine;

            return messageTemplate;
        }

        public string generateContactList(int notificationId)
        {

        

            return "";
        }

    }
}