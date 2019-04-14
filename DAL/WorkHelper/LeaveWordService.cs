using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.WorkHelper;
using IDAL.Power;
using System.Data;
using System.Data.SqlClient;
using DAL.Power;
namespace DAL.WorkHelper
{
   public class LeaveWordService:ILeaveWordService
    {
        #region ILeaveWordService 成员
       IUserInfoService userInfo = new UserInfoService();
        public IList<LeaveWord> GetAllLeaveWord()
        {
            
            IMessageType messageType = new MessageTypeService();
            int msgType;
            int sender;
            int receiver;
            string sql = "usp_selectLeaveWord";
            IList<LeaveWord> list = new List<LeaveWord>();
            LeaveWord leaveword = null;
            DataTable table = DBHelper.GetDataTableProc(sql, null);
            {

                foreach (DataRow row in table.Rows)
                {
                    leaveword = new LeaveWord();
                    leaveword.Id = (int)row["ID"];
                    leaveword.MsgTitle = (string)row["MsgTitle"];
                    leaveword.MsgContent = (string)row["MsgContent"];
                    leaveword.MsgSendTime = (DateTime)row["MsgSendTime"];
                    leaveword.MsgState = (string)row["MsgState"];
                    leaveword.MeetingAddr = (string)row["MeetingAddr"];
                    leaveword.ChargeMan = (string)row["ChargeMan"];
                    leaveword.MeetingBeginTime = (DateTime)row["MeetingBeginTime"];
                    leaveword.MeetingType = (string)row["MeetingType"];
                    leaveword.IsAgree = (string)row["IsAgree"];
                    leaveword.Remark = (string)row["Remark"];
                    msgType = (int)row["MsgTypeId"];
                    leaveword.MsgTypeId = messageType.GetMessageTypeById(msgType);
                    sender = (int)row["SenderUser"];
                    leaveword.SenderUser = userInfo.GetAllUserById(sender);
                    receiver = (int)row["ReceiverUser"];
                    leaveword.ReceiverUser = userInfo.GetAllUserById(receiver);
                    list.Add(leaveword);
             
                }
                 return list;
            }
           
        }

        #endregion

        #region ILeaveWordService 成员


        public LeaveWord GetLeaveWordMsgTypeId(int msgTypeId)
        {
            IUserInfoService userInfo = new UserInfoService();
            IMessageType messageType = new MessageTypeService();
            int msgType;
            int sender;
            int receiver;
            string sql = "usp_SelectLeaveWordMsgTypeId";
            LeaveWord leaveword = null;
            using (SqlDataReader row = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@MsgTypeId", msgTypeId)))
            {

                while (row.Read())
                {
                    leaveword = new LeaveWord();
                    leaveword.Id = (int)row["ID"];
                    leaveword.MsgTitle = (string)row["MsgTitle"];
                    leaveword.MsgContent = (string)row["MsgContent"];
                    leaveword.MsgSendTime = (DateTime)row["MsgSendTime"];
                    leaveword.MsgState = (string)row["MsgState"];
                    leaveword.MeetingAddr = (string)row["MeetingAddr"];
                    leaveword.ChargeMan = (string)row["ChargeMan"];
                    leaveword.MeetingBeginTime = (DateTime)row["MeetingBeginTime"];
                    leaveword.MeetingType = (string)row["MeetingType"];
                    leaveword.IsAgree = (string)row["IsAgree"];
                    leaveword.Remark = (string)row["Remark"];
                    msgType = (int)row["MsgTypeId"];
                    leaveword.MsgTypeId = messageType.GetMessageTypeById(msgType);
                    sender = (int)row["SenderUser"];
                    leaveword.SenderUser = userInfo.GetAllUserById(sender);
                    receiver = (int)row["ReceiverUser"];
                    leaveword.ReceiverUser = userInfo.GetAllUserById(receiver);
                    
                }

            }
            return leaveword;
        }

        #endregion

        #region ILeaveWordService 成员


        public int AddLeaveWord(LeaveWord leave)
        {
            string sql = "usp_InsertLeaveWordMessage";
            SqlParameter[] para = new SqlParameter[]
           {
               new SqlParameter("@MsgTitle",leave.MsgTitle),
               new SqlParameter("@MsgContent",leave.MsgContent),
               new SqlParameter("@MsgTypeId",leave.MsgTypeId.Id),
               new SqlParameter("@SenderUser",leave.SenderUser.UID),
               new SqlParameter("@ReceiverUser",leave.ReceiverUser.UID),
               new SqlParameter("@MsgSendTime",leave.MsgSendTime),
               new SqlParameter("@MsgState",(leave.MsgState)==null?"":leave.MsgState),
               new SqlParameter("@MeetingAddr",(leave.MeetingAddr)==null?"":leave.MeetingAddr),
               new SqlParameter("@ChargeMan",(leave.ChargeMan)==null?"":leave.ChargeMan),
               new SqlParameter("@MeetingBeginTime",leave.MeetingBeginTime),
               new SqlParameter("@MeetingType",(leave.MeetingType)==null?"":leave.MeetingType),
               new SqlParameter("@IsAgree",(leave.IsAgree)==null?"":leave.IsAgree),
               new SqlParameter("@Remark",(leave.Remark)==null?"":leave.Remark)
           };
            return DBHelper.ExecuteNonQueryProc(sql, para);
        }

        #endregion

        #region ILeaveWordService 成员


        public LeaveWord GetLeaveWordById(int id)
        {
            IUserInfoService userInfo = new UserInfoService();
            IMessageType messageType = new MessageTypeService();
            int msgType;
            int sender;
            int receiver;
            string sql = "usp_selectAllLeaveWordID";
            LeaveWord leaveword = null;
            using (SqlDataReader row = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@Id", id)))
            {

                while (row.Read())
                {
                    leaveword = new LeaveWord();
                    leaveword.Id = (int)row["ID"];
                    leaveword.MsgTitle = (string)row["MsgTitle"];
                    leaveword.MsgContent = (string)row["MsgContent"];
                    leaveword.MsgSendTime = (DateTime)row["MsgSendTime"];
                    leaveword.MsgState = (string)row["MsgState"];
                    leaveword.MeetingAddr = (string)row["MeetingAddr"];
                    leaveword.ChargeMan = (string)row["ChargeMan"];
                    leaveword.MeetingBeginTime = (DateTime)row["MeetingBeginTime"];
                    leaveword.MeetingType = (string)row["MeetingType"];
                    leaveword.IsAgree = (string)row["IsAgree"];
                    leaveword.Remark = (string)row["Remark"];
                    msgType = (int)row["MsgTypeId"];
                    leaveword.MsgTypeId = messageType.GetMessageTypeById(msgType);
                    sender = (int)row["SenderUser"];
                    leaveword.SenderUser = userInfo.GetAllUserById(sender);
                    receiver = (int)row["ReceiverUser"];
                    leaveword.ReceiverUser = userInfo.GetAllUserById(receiver);

                }

            }
            return leaveword;
        }

        #endregion

        #region ILeaveWordService 成员


        public IList<LeaveWord> SelectLeaveWordByAll(string msgTypeId, string msgState, string meetingBeginTime)
        {
            IMessageType messageType = new MessageTypeService();
            int msgType;
            int sender;
            int receiver;
            string sql = "usp_GetAllLeaveWordMessage";
            SqlParameter[] para = new SqlParameter[]
            {
             new SqlParameter("@MsgType",msgTypeId==null?"":msgTypeId),
             new SqlParameter("@MsgState",msgState==null?"":msgState),
             new SqlParameter("@day",meetingBeginTime==null?"":meetingBeginTime)
             
            };
            IList<LeaveWord> list = new List<LeaveWord>();
            LeaveWord leaveword = null;
            using(DataTable table = DBHelper.GetDataTableProc(sql, para))
            {

                foreach (DataRow row in table.Rows)
                {
                    leaveword = new LeaveWord();
                    leaveword.Id = (int)row["ID"];
                    leaveword.MsgTitle = (string)row["MsgTitle"];
                    leaveword.MsgContent = (string)row["MsgContent"];
                    leaveword.MsgSendTime = (DateTime)row["MsgSendTime"];
                    leaveword.MsgState = (string)row["MsgState"];
                    leaveword.MeetingAddr = (string)row["MeetingAddr"];
                    leaveword.ChargeMan = (string)row["ChargeMan"];
                    leaveword.MeetingBeginTime = (DateTime)row["MeetingBeginTime"];
                    leaveword.MeetingType = (string)row["MeetingType"];
                    leaveword.IsAgree = (string)row["IsAgree"];
                    leaveword.Remark = (string)row["Remark"];
                    msgType = (int)row["MsgTypeId"];
                    leaveword.MsgTypeId = messageType.GetMessageTypeById(msgType);
                    sender = (int)row["SenderUser"];
                    leaveword.SenderUser = userInfo.GetAllUserById(sender);
                    receiver = (int)row["ReceiverUser"];
                    leaveword.ReceiverUser = userInfo.GetAllUserById(receiver);
                    list.Add(leaveword);

                }
                return list;
            }
        }

        #endregion

        #region ILeaveWordService 成员


        public void DeleteLeaveWordById(int id)
        {
            string sql = "usp_DeleteLeaveWordID";

            DBHelper.ExecuteNonQueryProc(sql, new SqlParameter("@Id",id));
        }

        #endregion



        #region ILeaveWordService 成员


        public IList<LeaveWord> GetAllLeaveWordTitle(string msgState)
        {
            IMessageType messageType = new MessageTypeService();
            int msgType;
            int sender;
            int receiver;
            string sql = "usp_selectLeaveWordMsgType";
            IList<LeaveWord> list = new List<LeaveWord>();
            LeaveWord leaveword = null;
            DataTable table = DBHelper.GetDataTableProc(sql, new SqlParameter("@MsgState",msgState));
            {

                foreach (DataRow row in table.Rows)
                {
                    leaveword = new LeaveWord();
                    leaveword.Id = (int)row["ID"];
                    leaveword.MsgTitle = (string)row["MsgTitle"];
                    leaveword.MsgContent = (string)row["MsgContent"];
                    leaveword.MsgSendTime = (DateTime)row["MsgSendTime"];
                    leaveword.MsgState = (string)row["MsgState"];
                    leaveword.MeetingAddr = (string)row["MeetingAddr"];
                    leaveword.ChargeMan = (string)row["ChargeMan"];
                    leaveword.MeetingBeginTime = (DateTime)row["MeetingBeginTime"];
                    leaveword.MeetingType = (string)row["MeetingType"];
                    leaveword.IsAgree = (string)row["IsAgree"];
                    leaveword.Remark = (string)row["Remark"];
                    msgType = (int)row["MsgTypeId"];
                    leaveword.MsgTypeId = messageType.GetMessageTypeById(msgType);
                    sender = (int)row["SenderUser"];
                    leaveword.SenderUser = userInfo.GetAllUserById(sender);
                    receiver = (int)row["ReceiverUser"];
                    leaveword.ReceiverUser = userInfo.GetAllUserById(receiver);
                    list.Add(leaveword);

                }
                return list;
            }
        }

        #endregion
    }
}
