using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.WorkHelper;
using IDAL.Power;
using System.Data;
using System.Data.SqlClient;
namespace DAL.WorkHelper
{
    public class MessageTypeService:IMessageType
    {
        #region IMessageType 成员

        public MessageType GetMessageTypeById(int typeId)
        {
            string sql = "usp_selectMessageTypeID";
            MessageType messageType =null;
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@TypeID", typeId)))
            {
                while (reader.Read())
                {
                    messageType = new MessageType();
                    messageType.Id = (int)reader["TypeID"];
                    messageType.MsgType = (string)reader["MsgType"];
                }
            }
            return messageType;
        }

        public IList<MessageType> GetMessageType()
        {
            string sql = "usp_selectMessageType";
            IList<MessageType> list = new List<MessageType>();
            
            DataTable table = DBHelper.GetDataTableProc(sql);
            MessageType messageType = null;
                foreach (DataRow row in table.Rows)
                {
                    messageType = new MessageType();
                    messageType.Id = (int)row["TypeID"];
                    messageType.MsgType = (string)row["MsgType"];
                    list.Add(messageType);
                }
                return list;
            
        }

        #endregion
    }
}
