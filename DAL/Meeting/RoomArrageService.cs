using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL.Meeting;
using IDAL.Power;
using Model;
using DAL.Power;
using System.Data;
using System.Data.SqlClient;
namespace DAL.Meeting
{
    public class RoomArrageService:IRoomArrageService
    {
        IUserInfoService userService = new UserInfoService();
        #region IRoomArrageService 成员
        /// <summary>
        /// 根据会场名称查询会场安排信息
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public IList<RoomArrage> SearchRoomArrageStateByRoomName(string roomName)
        {
            IList<RoomArrage> list=new List<RoomArrage>();
            string sql = "usp_SearchRoomArrageStateByRoomName";
            using (DataTable dt = DBHelper.GetDataTableProc(sql, new SqlParameter("@RoomName", (roomName==null)?"":roomName)))
            {
                foreach (DataRow  row in dt.Rows)
                {
                    RoomArrage roomArrage = new RoomArrage();
                    roomArrage.Id = Convert.ToInt32(row["RID"]);
                    roomArrage.RoomName = row["RoomName"].ToString();
                    roomArrage.RomeState = row["RomeState"].ToString();
                    roomArrage.Remark = row["Remark"].ToString();
                    roomArrage.InstancyDegree = row["InstancyDegree"].ToString();
                    roomArrage.ChargeMan = row["ChargeMan"].ToString();// userService.GetAllUserById(Convert.ToInt32(row["ChargeMan"]));
                    roomArrage.MeetingType = row["MeetingType"].ToString();
                    roomArrage.BeginTime = Convert.ToDateTime(row["BeginTime"]);
                    roomArrage.EndTime = Convert.ToDateTime(row["EndTime"]);

                    list.Add(roomArrage);
                }
            }
            return list;
        }

        #endregion

        #region IRoomArrageService 成员

        /// <summary>
        /// 添加会场安排信息
        /// </summary>
        /// <param name="roomArrage"></param>
        public void AddRoomArrage(RoomArrage roomArrage)
        {
            string sql = "usp_addRoomArrage";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BeginTime",roomArrage.BeginTime),
                new SqlParameter("@EndTime",roomArrage.EndTime),
                new SqlParameter("@RoomName",roomArrage.RoomName),
                new SqlParameter("@MeetingType",roomArrage.MeetingType),
                new SqlParameter("@RomeState",roomArrage.RomeState),
                new SqlParameter("@ChargeMan",roomArrage.ChargeMan),
                new SqlParameter("@InstancyDegree",roomArrage.InstancyDegree),
                new SqlParameter("@Remark",roomArrage.Remark)
            };
            DBHelper.ExecuteNonQueryProc(sql,para);
        }

        #endregion
    }
}
