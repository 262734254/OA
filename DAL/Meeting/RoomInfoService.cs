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
    public class RoomInfoService:IRoomInfoService
    {


        #region IRoomInfoService 成员
        /// <summary>
        /// 获取根据会场名称查询所有会场信息，会场名称为空，则查询所有
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public IList<RoomInfo> GetAllRoomInfo(string roomName)
        {
           IList<RoomInfo> list=new List<RoomInfo>();
           string sql = "usp_Meet_AllRoomInfo";
           SqlParameter[] para = new SqlParameter[]
           {
               new SqlParameter("@RoomName",roomName)
           };
           using (DataTable dt = DBHelper.GetDataTableProc(sql, para))
           {
               foreach (DataRow row in dt.Rows)
               {
                   RoomInfo room = new RoomInfo();
                   room.RID = Convert.ToInt32(row["RID"]);
                   room.RoomName = row["RoomName"].ToString();
                   room.RomeCondition = row["RomeCondition"].ToString();
                   room.RomeAddr = row["RomeAddr"].ToString();
                   room.ContainNum = Convert.ToInt32(row["ContainNum"]);
                   room.Equip = row["Equip"].ToString();
                   list.Add(room);
               }
           }
           return list;

        }
        /// <summary>
        /// 新增会场
        /// </summary>
        /// <param name="roomInfo"></param>
        public void AddRoomInfo(RoomInfo roomInfo)
        {
            string sql = "usp_Meet_AddRoomInfo";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoomName",roomInfo.RoomName),
                new SqlParameter("@ContainNum",roomInfo.ContainNum),
                new SqlParameter("@Equip",roomInfo.Equip),
                new SqlParameter("@RomeAddr",roomInfo.RomeAddr),
                new SqlParameter("@RomeCondition",roomInfo.RomeCondition),
               
            };
            DBHelper.ExecuteNonQueryProc(sql,para);

        }
        /// <summary>
        /// 修改会场信息
        /// </summary>
        /// <param name="roomInfo"></param>
        public void ModifyRoomInfo(RoomInfo roomInfo)
        {
            string sql = "usp_Meet_ModifyRoomInfo";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoomName",roomInfo.RoomName),
                new SqlParameter("@ContainNum",roomInfo.ContainNum),
                new SqlParameter("@Equip",roomInfo.Equip),
                new SqlParameter("@RomeAddr",roomInfo.RomeAddr),
                new SqlParameter("@RomeCondition",roomInfo.RomeCondition),
                new SqlParameter("@RID",roomInfo.RID)
            };
            DBHelper.ExecuteNonQueryProc(sql, para);

        }
        /// <summary>
        /// 删除会场信息
        /// </summary>
        /// <param name="roomId"></param>
        public void DeleteRoomInfo(string roomIds)
        {
            string sql = "usp_DelRoomInfoById";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoomIds",roomIds)
            };
            DBHelper.ExecuteNonQueryProc(sql,para);
        }
        /// <summary>
        /// 根据会场ID查询一条会场信息
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public RoomInfo SearchRoomInfoById(int roomId)
        {
            RoomInfo room = new RoomInfo();
            string sql = "usp_Meet_SearchRoomInfoById";
            SqlParameter[] para = new SqlParameter[]
           {
               new SqlParameter("@RoomId",roomId)
           };
            using (SqlDataReader reader=DBHelper.ExecuteReaderProc(sql,para))
            {
                if (reader.Read())
                {
                    room.RID = Convert.ToInt32(reader["RID"]);
                    room.RoomName = reader["RoomName"].ToString();
                    room.RomeCondition = reader["RomeCondition"].ToString();
                    room.RomeAddr = reader["RomeAddr"].ToString();
                    room.ContainNum = Convert.ToInt32(reader["ContainNum"]);
                    room.Equip = reader["Equip"].ToString();
                }
               
            }
            return room;
        }
        #endregion








        #region IRoomInfoService 成员
        /// <summary>
        /// 获取所有会议室
        /// </summary>
        /// <returns></returns>
        public IList<RoomInfo> GetAllRoomInfo()
        {
            IList<RoomInfo> list = new List<RoomInfo>();
            string sql = "usp_Meet_AllRoom";
            
            using (DataTable dt = DBHelper.GetDataTableProc(sql,null))
            {
                foreach (DataRow row in dt.Rows)
                {
                    RoomInfo room = new RoomInfo();
                    room.RID = Convert.ToInt32(row["RID"]);
                    room.RoomName = row["RoomName"].ToString();
                    room.RomeCondition = row["RomeCondition"].ToString();
                    room.RomeAddr = row["RomeAddr"].ToString();
                    room.ContainNum = Convert.ToInt32(row["ContainNum"]);
                    room.Equip = row["Equip"].ToString();
                    list.Add(room);
                }
            }
            return list;
        }

        #endregion
    }
}
