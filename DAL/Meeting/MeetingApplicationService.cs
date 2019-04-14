using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL.Meeting;
using IDAL.Power;
using DAL.Power;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace DAL.Meeting
{
    public class MeetingApplicationService:IMeetingApplicationService
    {
        RoomInfoService roomInfoService = new RoomInfoService();
        DepartmentService departService = new DepartmentService();
        #region  会议申请实现类   
        /// <summary>
        /// 添加会议申请单
        /// </summary>
        /// <param name="meetingApplication"></param>
        public void AddMeetingApplication(MeetingApplication meetingApplication)
        {
            string sql = "usp_addMeetingApplicaion";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MeetTitle",meetingApplication.MeetTitle),
                new SqlParameter("@MeetContent",meetingApplication.MeetContent),
                new SqlParameter("@ApplicationMan",meetingApplication.ApplicationMan),
                new SqlParameter("@DepartmentID",meetingApplication.DepartmentID.Id),
                new SqlParameter("@WithinEnlistMan",meetingApplication.WithinEnlistMan),
                new SqlParameter("@MeetType",meetingApplication.MeetType),
                new SqlParameter("@MeetNumber",meetingApplication.MeetNumber),
                new SqlParameter("@Compere",meetingApplication.Compere),
                new SqlParameter("@MeetingSummary",meetingApplication.MeetingSummary),
                new SqlParameter("@InstancyDegree",meetingApplication.InstancyDegree),
                new SqlParameter("@BeginTime",meetingApplication.BeginTime.ToString()),
                new SqlParameter("@EndTime",meetingApplication.EndTime.ToString()),
                new SqlParameter("@RoomID",meetingApplication.RoomInfo.RID)
                
            };
            DBHelper.ExecuteNonQueryProc(sql,para);
        }
        /// <summary>
        /// 根据会议名称和主办部门查询会议申请列表
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public IList<MeetingApplication> SearchMeetingApplication(string roomName, int departmentId)
        {
           
            IList<MeetingApplication> list=new List<MeetingApplication>();
            string sql = "usp_SearchMeetingApplication";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MeetTitle",roomName),
                new SqlParameter("@DepartmentID",departmentId)
            };
            using (DataTable dt=DBHelper.GetDataTableProc(sql,para))
            {
                foreach (DataRow row in dt.Rows)
                {
                    MeetingApplication application = new MeetingApplication();
                  

                    application.MID = Convert.ToInt32(row["MID"]);
                    application.MeetTitle = row["MeetTitle"].ToString();
                    application.MeetContent = row["MeetContent"].ToString();
                    application.MeetType = row["MeetType"].ToString();
                    application.State = row["State"].ToString();
                    application.WithinEnlistMan = row["WithinEnlistMan"].ToString();
                    application.MeetNumber = Convert.ToInt32(row["MeetNumber"]);
                    application.MeetingSummary =row["MeetingSummary"].ToString();
                    application.InstancyDegree = row["InstancyDegree"].ToString();
                    application.EndTime = DateTime.Parse(row["EndTime"].ToString());
                    application.BeginTime = DateTime.Parse(row["BeginTime"].ToString());
                    application.ApplicationTime = DateTime.Parse(row["ApplicationTime"].ToString());
                    application.ApplicationMan = row["ApplicationMan"].ToString();
                    application.Compere = row["Compere"].ToString();
                    application.DepartmentID = departService.GetAllDepartementById(Int32.Parse(row["DepartmentID"].ToString()));
                    application.RoomInfo = roomInfoService.SearchRoomInfoById(Convert.ToInt32(row["RoomID"]));
                    list.Add(application);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据会议申请单号查询一条会议申请信息
        /// </summary>
        /// <param name="MSID"></param>
        /// <returns></returns>
        public MeetingApplication GetMeetingApplicationById(int MSID)
        {
            

            MeetingApplication application = null;
            string sql = "usp_SearchMeetingApplicationById";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MID",MSID)
              
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, para))
            {
                if (reader.Read()) 
                {
                    application = new MeetingApplication();
                    application.MID = Convert.ToInt32(reader["MID"]);
                    application.MeetTitle = reader["MeetTitle"].ToString();
                    application.MeetContent = reader["MeetContent"].ToString();
                    application.MeetType = reader["MeetType"].ToString();
                    application.State = reader["State"].ToString();
                    application.WithinEnlistMan = reader["WithinEnlistMan"].ToString();
                    application.MeetNumber = Convert.ToInt32(reader["MeetNumber"]);
                    application.MeetingSummary = reader["MeetingSummary"].ToString();
                    application.InstancyDegree = reader["InstancyDegree"].ToString();
                    application.EndTime = DateTime.Parse(reader["EndTime"].ToString());
                    application.BeginTime = DateTime.Parse(reader["BeginTime"].ToString());
                    application.ApplicationTime = DateTime.Parse(reader["ApplicationTime"].ToString());
                    application.ApplicationMan = reader["ApplicationMan"].ToString();
                    application.Compere = reader["Compere"].ToString();
                    application.DepartmentID = departService.GetAllDepartementById(Int32.Parse(reader["DepartmentID"].ToString()));
                    application.RoomInfo = roomInfoService.SearchRoomInfoById(Convert.ToInt32(reader["RoomID"].ToString()));
                    reader.Close();
                    return application;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            return application;
        }
        /// <summary>
        /// 根据申请单号删除一条会议申请信息，但注意，只能删除未召开的会议
        /// </summary>
        /// <param name="MSID"></param>
        public void DelMeetingApplication(int MSID)
        {
            string sql = "usp_DelMeetingApplicationById";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MID",MSID)
            };
            DBHelper.ExecuteNonQueryProc(sql,para);
        }
        /// <summary>
        /// 修改会议申请信息
        /// </summary>
        /// <param name="meetingApplication"></param>
        public void UpdateMeetintApplication(MeetingApplication meetingApplication)
        {
            string sql = "usp_ModifyMeetingApplicaion";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MeetTitle",meetingApplication.MeetTitle),
                new SqlParameter("@MeetContent",meetingApplication.MeetContent),
                new SqlParameter("@ApplicationMan",meetingApplication.ApplicationMan),
                new SqlParameter("@DepartmentID",meetingApplication.DepartmentID.Id),
                new SqlParameter("@WithinEnlistMan",meetingApplication.WithinEnlistMan),
                new SqlParameter("@MeetType",meetingApplication.MeetType),
                new SqlParameter("@MeetNumber",meetingApplication.MeetNumber),
                new SqlParameter("@Compere",meetingApplication.Compere),
                new SqlParameter("@MeetingSummary",meetingApplication.MeetingSummary),
                new SqlParameter("@InstancyDegree",meetingApplication.InstancyDegree),
                new SqlParameter("@ApplicationTime",meetingApplication.ApplicationMan),
                new SqlParameter("@BeginTime",meetingApplication.BeginTime.ToString()),
                new SqlParameter("@EndTime",meetingApplication.EndTime.ToString()),
                new SqlParameter("@RoomID",meetingApplication.RoomInfo.RID),
                new SqlParameter("@MID",meetingApplication.MID)
                
            };
            DBHelper.ExecuteNonQueryProc(sql, para);
        }

        #endregion

        #region IMeetingApplicationService 成员

        /// <summary>
        /// 审批会议，更新状态
        /// </summary>
        /// <param name="id"></param>
        public void ModifyMeetingState(int id,string state)
        {
            string sql = "usp_ModifyMeetingState";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",id),
                new SqlParameter("@State",state)
            };
            DBHelper.ExecuteNonQueryProc(sql,para);
        }

        #endregion
    }
}
