using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL.Meeting;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace DAL.Meeting
{
    public class MeetingSummaryService:IMeetingSummaryService
    {
        #region IMeetingSummaryService 成员
        /// <summary>
        /// //添加会议纪要信息
        /// </summary>
        /// <param name="meetingSummary"></param>
        public void AddMeetingSummary(MeetingSummary meetingSummary)
        {
            string sql = "usp_AddMeetingSummary";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MeetingTitle",meetingSummary.MeetingTitle),
                new SqlParameter("@MeetingContent",meetingSummary.MeetingContent),
                new SqlParameter("@BeginTime",meetingSummary.BeginTime.ToString()),
                new SqlParameter("@EndTime",meetingSummary.EndTime.ToString()),
                new SqlParameter("@MissingPeople",meetingSummary.MissingPeople),
                new SqlParameter("@ChargeMan",meetingSummary.ChargeMan),
                new SqlParameter("@Visitor",meetingSummary.Visitor),
                new SqlParameter("@Compere",meetingSummary.Compere)
            };
            DBHelper.ExecuteNonQueryProc(sql,para);
        }
        /// <summary>
        /// 更新会议纪要信息
        /// </summary>
        /// <param name="meetingSummary"></param>
        public void UpdateMeetingSummary(MeetingSummary meetingSummary)
        {
            string sql = "usp_ModifyMeetingSummary";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MeetingTitle",meetingSummary.MeetingTitle),
                new SqlParameter("@MeetingContent",meetingSummary.MeetingContent),
                new SqlParameter("@BeginTime",meetingSummary.BeginTime.ToString()),
                new SqlParameter("@EndTime",meetingSummary.EndTime.ToString()),
                new SqlParameter("@MissingPeople",meetingSummary.MissingPeople),
                new SqlParameter("@ChargeMan",meetingSummary.ChargeMan),
                new SqlParameter("@Visitor",meetingSummary.Visitor),
                new SqlParameter("@Compere",meetingSummary.Compere),
                new SqlParameter("@MSID",meetingSummary.MSID)
            };
            DBHelper.ExecuteNonQueryProc(sql, para);
        }
        /// <summary>
        /// 删除会议纪要信息
        /// </summary>
        /// <param name="strMSID"></param>
        public void DelMeetingSummary(string strMSID)
        {
            string sql = "usp_DeleteMeetingSummaryByMSID";
            DBHelper.ExecuteNonQueryProc(sql,new SqlParameter("@MSID",strMSID));
        }
        /// <summary>
        /// 根据会议纪要ID查询会议纪要详情信息
        /// </summary>
        /// <param name="MSID"></param>
        /// <returns></returns>
        public MeetingSummary GetMeetingSummaryById(int MSID)
        {
            string sql = "usp_GetMeetingSummaryById";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MSID",MSID),
               

            };
            MeetingSummary mSummary = null;
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, para))
            {
                if(reader.Read())
                {
                    mSummary = new MeetingSummary();
                    mSummary.MSID = Convert.ToInt32(reader["MSID"]);
                    mSummary.MeetingTitle = reader["MeetingTitle"].ToString();
                    mSummary.MeetingContent = reader["MeetingContent"].ToString();
                    mSummary.MissingPeople = reader["MissingPeople"].ToString();
                    mSummary.BeginTime = Convert.ToDateTime(reader["BeginTime"]);
                    mSummary.EndTime = Convert.ToDateTime(reader["EndTime"]);
                    mSummary.ChargeMan = reader["ChargeMan"].ToString();
                    mSummary.Compere = reader["Compere"].ToString();
                    mSummary.Visitor = reader["Visitor"].ToString();
                    reader.Close();
                    return mSummary;
                }
                else
                {
                    reader.Close();
                    return null;
                }
               
            }
            return mSummary;
        }
        /// <summary>
        /// 根据会议名称，开始时间和结束时间查询会议纪要信息
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public IList<MeetingSummary> SearchMeetingSummary(string roomName, string beginTime, string endTime)
        {
            string sql = "usp_SearchMeetingSummary";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoomName",(roomName==null)?"":roomName),
                new SqlParameter("@BeginTime",(beginTime==null)?"":beginTime),
                new SqlParameter("@EndTime",(endTime==null)?"":endTime)

            };
            IList<MeetingSummary> list=new List<MeetingSummary>();
            using (DataTable dt = DBHelper.GetDataTableProc(sql, para))
            {
                foreach (DataRow  row in dt.Rows)
                {
                    MeetingSummary mSummary = new MeetingSummary();
                    mSummary.MSID = Convert.ToInt32(row["MSID"]);
                    mSummary.MeetingTitle = row["MeetingTitle"].ToString();
                    mSummary.MeetingContent = row["MeetingContent"].ToString();
                    mSummary.MissingPeople = row["MissingPeople"].ToString();
                    mSummary.BeginTime = Convert.ToDateTime(row["BeginTime"]);
                    mSummary.EndTime = Convert.ToDateTime(row["EndTime"]);
                    mSummary.ChargeMan = row["ChargeMan"].ToString();
                    mSummary.Compere = row["Compere"].ToString();
                    mSummary.Visitor = row["Visitor"].ToString();
                    list.Add(mSummary);
                }
            }
            return list;
        }

        #endregion
    }
}
