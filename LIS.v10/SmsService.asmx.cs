﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using LIS.v10.Areas.HIS10.Models;
using LIS.v10.Areas.Rpi.Models;
namespace LIS.v10
{
    /// <summary>
    /// Summary description for SmsService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SmsService1 : System.Web.Services.WebService
    {

        public His10DBContainer db = new His10DBContainer();
        public DBClasses db1 = new DBClasses();
        public RpiDBContainer1 rpidb = new RpiDBContainer1();
       // public RpiModelContainer rpidb = new RpiModelContainer();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        // -- SMS NOTIFICATION METHODS --//        
        #region SMS Notification WebService
        //get all list of messages from 'HisNotifications' Table
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDetails()
        {
            string sql = "SELECT TOP 1000 [Id],[RecType],[Recipient],[Message],[DtSending]  FROM [aspnet-LIS.v10-20170509105835].[dbo].[HisNotifications]";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();

            da.Fill(ds);    //execute sqlAdapter

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        //get all list of contact list from 'HisNotificationsRecipients' Table using the Notification id 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getRecipientsLists(int notificationId)
        {
            string sql = "SELECT * [Id],[HisNotificationId],[ContactInfo]  FROM [aspnet-LIS.v10-20170509105835].[dbo].[HisNotificationRecipients] where HisNotificationRecipients.HisNotificationId = " + notificationId;
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();

            da.Fill(ds);    //execute sqlAdapter

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }


        //get notifications log
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLogsList()
        {

            string sql = "SELECT TOP 100  HisNotifications.Id, HisNotifications.DtSending, HisNotificationLogs.DTSending, HisNotificationLogs.Remarks," +
                "HisNotificationRecipients.ContactInfo, HisNotifications.RecType, HisNotifications.Message, HisNotificationLogs.Status " +
                "FROM [HisNotificationLogs] "+
                "INNER JOIN [HisNotificationRecipients] ON [HisNotificationLogs].HisNotificationRecipientId = [HisNotificationRecipients].Id "+
                "INNER JOIN [HisNotifications] ON [HisNotificationRecipients].HisNotificationId =  [HisNotifications].Id";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);    //execute sqlAdapter

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAdminMessage()
        {
            string sql = "SELECT [Id],[RecType],[Recipient],[Message],[DtSending] FROM dbo.HisNotifications WHERE [RecType]='admin'";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();
            da.Fill(ds);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getClientMessage()
        {
            string sql = "SELECT [Id],[RecType],[Recipient],[Message],[DtSending] FROM dbo.HisNotifications WHERE [RecType]='client'";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();
            da.Fill(ds);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        // --END OF GET METHODS --//        

        //update notificationlog for sent and failed to send messages
        [WebMethod]
        public void updateLog(int NotificationRecipientID, string DtSending, string Status, string Remarks)
        {
            string response = "success";
            try
            {

                string conString = ConfigurationManager.ConnectionStrings["SmsConnection"].ConnectionString;
                var con = new SqlConnection(conString);
                con.Open();

                var cmd = new SqlCommand("INSERT INTO [dbo].[HisNotificationLogs] ([HisNotificationRecipientId],[DtSending],[Status],[Remarks]) VALUES" +
                    " (" + NotificationRecipientID + ", '" + DtSending + "', '" + Status + "', '" + Remarks + "') ", con);

                int row = cmd.ExecuteNonQuery();
                con.Close();
                response = "success";
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                response = ex.ToString();
            }
            Context.Response.Write(response);
        }

        //update notifications for sent and failed to send messages
        [WebMethod]
        public void updateItemStatus(int NotificationID, string DtSending)
        {
            string response = NotificationID + " - " + DtSending;
            string sql = "UPDATE [dbo].[HisNotifications] SET [DtSending] = '" + DtSending + "' WHERE [HisNotifications].[Id] = " + NotificationID + "";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);    //execute sqlAdapter

            Context.Response.Clear();
            Context.Response.Write(response);

        }

       
        //get list of unsent items 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getUnsentItems()
        {

            string sql = "SELECT * FROM HisNotificationRecipients INNER JOIN HisNotifications " +
                  "ON HisNotifications.Id = HisNotificationRecipients.HisNotificationId " +
                  "WHERE HisNotificationRecipients.Id NOT IN (SELECT HisNotificationLogs.HisNotificationRecipientId FROM HisNotificationLogs) ";
            
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);    //execute sqlAdapter
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }


        //get list of unsent items 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFailedItems()
        {

            //string sql = "SELECT * FROM HisNotificationRecipients INNER JOIN HisNotifications " +
            //      "ON HisNotifications.Id = HisNotificationRecipients.HisNotificationId " +
            //      "WHERE HisNotificationRecipients.Id NOT IN (SELECT HisNotificationLogs.HisNotificationRecipientId FROM HisNotificationLogs) ";

            string sql = "SELECT * FROM HisNotificationRecipients INNER JOIN HisNotifications "+
                    "ON HisNotifications.Id = HisNotificationRecipients.HisNotificationId "+
                    "WHERE HisNotificationRecipients.Id IN "+
                    "(SELECT HisNotificationLogs.HisNotificationRecipientId FROM HisNotificationLogs "+
                    "WHERE HisNotificationLogs.Status = 'Failed')";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);    //execute sqlAdapter
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        ////get list of unsent items 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFailedItem2()
        {
            db1.getFailedNotification();
            string sql = "SELECT * FROM HisNotificationRecipients INNER JOIN HisNotifications " +
                    "ON HisNotifications.Id = HisNotificationRecipients.HisNotificationId " +
                    "WHERE HisNotificationRecipients.Id IN " +
                    "(SELECT HisNotificationLogs.HisNotificationRecipientId FROM HisNotificationLogs " +
                    "WHERE HisNotificationLogs.Status = 'Failed')";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);    //execute sqlAdapter

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getListsofFailed(string notificationRecipientID)
        {

            string sql = "SELECT * FROM HisNotificationLogs WHERE Status = 'Failed' AND HisNotificationRecipientID = " + notificationRecipientID;
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);    //execute sqlAdapter

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));

        }


        [WebMethod]
        public void addNotification(string recType, string recipient, string message, string dtSending)
        {
            string response = "success";

            string sql = "INSERT INTO [dbo].[HisNotifications] "+
                "([RecType],[Recipient],[Message],[DtSending],[RefId],[RefTable]) "+
                "VALUES('"+recType+"','"+recipient+"','"+message+"','"+ dtSending +"',0,'0') ";

            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);    //execute sqlAdapter

            Context.Response.Clear();
            Context.Response.Write(response);
        }
        #endregion


        //-- RasperryPi Methods --//
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
       public void rpi_getDevice(int deviceId)
        {
            //RpiDevice device = rpidb.RpiDevices.Where(r=>r.Id == id).FirstOrDefault();
            //RpiDevice device = rpidb.RpiDevices.Find(id);
            string sql = "SELECT * FROM [aspnet-LIS.v10-20170509105835].[dbo].[RpiDevices] WHERE [Id] = " + deviceId;
            // string sql = rpidb.RpiDevices.Find(id).ToString();
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();

            da.Fill(ds);    //execute sqlAdapter
            
            //da.Fill(ds);    //execute sqlAdapter
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void rpi_getAllDevice()
        {
            string sql = "SELECT * FROM [aspnet-LIS.v10-20170509105835].[dbo].[RpiDevices]";
           
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();

            da.Fill(ds);    //execute sqlAdapter
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void rpi_getControl(int deviceId)
        {
            string sql = "SELECT * FROM [aspnet-LIS.v10-20170509105835].[dbo].[RpiControls] WHERE [RpiDeviceId] = " + deviceId;
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();

            da.Fill(ds);    //execute sqlAdapter
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void rpi_getDataLog(int deviceId)
        {
            string sql = "SELECT * FROM [aspnet-LIS.v10-20170509105835].[dbo].[RpiDatalogs] WHERE [RpiDeviceId] = " + deviceId;

            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();

            da.Fill(ds);    //execute sqlAdapter
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }


        //POST METHODS
        [WebMethod]
        public void rpi_setDataLog(int deviceId, string Data, string DtLog)
        {
            string sql = "Insert into RpiDatalogs([DtRead],[DataRead],[RpiDeviceId]) "+
                "values ('"+ DtLog + "','"+ Data +"','"+ deviceId +"')";

            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();

            da.Fill(ds);    //execute sqlAdapter
            Context.Response.Clear();
            Context.Response.Write("200");
        }

    }
}
