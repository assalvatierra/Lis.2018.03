using Newtonsoft.Json;
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

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        // -- GET METHODS --//        
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

            //string sql = "SELECT TOP 1000  HisNotificationRecipients.Id, HisNotifications.DtSending," +
            //    " HisNotificationRecipients.ContactInfo, HisNotifications.Message "+
            //    " FROM [HisNotificationLogs]"+
            //    " INNER JOIN [HisNotificationRecipients] ON [HisNotificationLogs].HisNotificationRecipientId = [HisNotificationRecipients].Id"+
            //    " INNER JOIN [HisNotifications] ON [HisNotificationRecipients].HisNotificationId = [HisNotifications].Id"+
            //    " WHERE HisNotificationRecipients.Id NOT IN (SELECT HisNotificationLogs.HisNotificationRecipientId FROM HisNotificationLogs)"+
            //    " OR [HisNotificationLogs].Status = 'Failed'";
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
    }
}
