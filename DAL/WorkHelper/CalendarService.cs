using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using IDAL.WorkHelper;
using IDAL.Power;
using DAL.Power;
namespace DAL.WorkHelper
{
   public class CalendarService:ICalendarService
    {

        #region ICalendarService 成员

       public Calendar GetAllCalendarByID(int id)
        {
            IUserInfoService userInfo = new UserInfoService();
            int uId;
            string sql = "usp_selectCalendarById";
            Calendar calendar = null;
            using (SqlDataReader row = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@ID", id)))
            {

                while (row.Read())
                {
                    calendar = new Calendar();
                    calendar.Id = (int)row["ID"];
                    calendar.CalTheme = (string)row["CalTheme"];
                    calendar.CalContent = (string)row["CalContent"];
                    calendar.RemaindTime = (DateTime)row["RemaindTime"];
                    calendar.TransactTime = (DateTime)row["TransactTime"];
                    calendar.CalType = (string)row["CalType"];
                    uId = (int)row["UID"];
                    calendar.UId = userInfo.GetAllUserById(uId);
                    calendar.Repeat = (string)row["repeat"];

                }

            }
            return calendar;
        }

       public IList<Calendar> GetAllCalendar()
        {
            IUserInfoService userInfo = new UserInfoService();
            int uId;
            string sql = "usp_selectCalendar";
            IList<Calendar> list = new List<Calendar>();
            Calendar calendar = null;
            using (DataTable table = DBHelper.GetDataTableProc(sql, null))
            {

                foreach (DataRow row in table.Rows)
                {
                    calendar = new Calendar();
                    calendar.Id = (int)row["ID"];
                    calendar.CalTheme = (string)row["CalTheme"];
                    calendar.CalContent = (string)row["CalContent"];
                    calendar.RemaindTime = (DateTime)row["RemaindTime"];
                    calendar.TransactTime = (DateTime)row["TransactTime"];
                    calendar.CalType = (string)row["CalType"];
                    uId = (int)row["UID"];
                    calendar.UId = userInfo.GetAllUserById(uId);
                    calendar.Repeat = (string)row["repeat"];
                    list.Add(calendar);

                }
                return list;

            }
        }

        #endregion

        #region ICalendarService 成员


        public int AddCalendar(Calendar cal)
        {
            string sql = "usp_InsertCalendar";
            SqlParameter[] para = new SqlParameter[]
           {
               new SqlParameter("@UID", cal.UId.UID),
               new SqlParameter("@CalTheme",cal.CalTheme),
               new SqlParameter("@CalContent",cal.CalContent),
               new SqlParameter("@RemaindTime",cal.RemaindTime),
               new SqlParameter("@TransactTime",cal.TransactTime),
               new SqlParameter("@CalType",cal.CalType),
               new SqlParameter("@repeat",cal.Repeat)
           };
            return DBHelper.ExecuteNonQueryProc(sql, para);
        }

        #endregion



        #region ICalendarService 成员


        public void GetCalendarById(Calendar cal)
        {
            string sql = "usp_UpdateCalendar";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",cal.Id),
               new SqlParameter("@UID", cal.UId.UID),
               new SqlParameter("@CalTheme",cal.CalTheme),
               new SqlParameter("@CalContent",cal.CalContent),
               new SqlParameter("@RemaindTime",cal.RemaindTime),
               new SqlParameter("@TransactTime",cal.TransactTime),
               new SqlParameter("@CalType",cal.CalType),
               new SqlParameter("@repeat",cal.Repeat)
            };
             DBHelper.ExecuteNonQueryProc(sql, para);
        }

        #endregion

        #region ICalendarService 成员


        public IList<Calendar> SelectLeaveWord(string calTheme, string remaindTime)
        {
            IUserInfoService userInfo = new UserInfoService();
            int uid;
            string sql = "usp_selectCalendarByTime";
            SqlParameter[] para = new SqlParameter[]
            {
             new SqlParameter("@CalTheme",calTheme==null?"":calTheme),
             new SqlParameter("@day",remaindTime==null?"":remaindTime)
             
            };
            IList<Calendar> list = new List<Calendar>();
            Calendar calendar = null;
            using (DataTable table = DBHelper.GetDataTableProc(sql, para))
            {

                foreach (DataRow row in table.Rows)
                {
                    calendar = new Calendar();
                    calendar.Id = (int)row["ID"];
                    calendar.CalTheme = (string)row["CalTheme"];
                    calendar.CalContent = (string)row["CalContent"];
                    calendar.RemaindTime = (DateTime)row["RemaindTime"];
                    calendar.TransactTime = (DateTime)row["TransactTime"];
                    calendar.CalType = (string)row["CalType"];
                    uid = (int)row["UID"];
                    calendar.UId = userInfo.GetAllUserById(uid);
                    calendar.Repeat = (string)row["repeat"];
                    list.Add(calendar);

                }
                return list;
            }
        }

       
        #endregion

        #region ICalendarService 成员


        public int DeleteCalendar(int id)
        {
            string sql = "usp_DeleteCalendarID";
            return DBHelper.ExecuteNonQueryProc(sql, new SqlParameter("@Id", id));
        }

        #endregion

        #region ICalendarService 成员


        public int UpdateTime(int id)
        {
            string sql = "usp_UpdateTommor";
            return DBHelper.ExecuteNonQueryProc(sql, new SqlParameter("@id", id));
        }

        #endregion
    }
}
