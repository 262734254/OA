using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    public class Tunnel_FilesManage
    {
        #region 构造
        public Tunnel_FilesManage()
        {
            f_ID = 0;
            f_Type = "";
            f_Title = string.Empty;
            f_Content = string.Empty;
            f_Name = string.Empty;
            f_URL = string.Empty;
            f_CreateUser = 0;
            f_CreateDate = Convert.ToDateTime("1800-01-01");
            f_ModiUser = 0;
            f_ModiDate = Convert.ToDateTime("1800-01-01");
            f_DelUser = 0;
            f_DelDate = Convert.ToDateTime("1800-01-01");
        }
        #endregion
        #region 变量
        private int f_ID;
        private string f_Type;
        private string f_Title;
        private string f_Content;
        private string f_Name;
        private string f_URL;
        private int f_CreateUser;
        private DateTime f_CreateDate;
        private int f_ModiUser;
        private DateTime f_ModiDate;
        private int f_DelUser;
        private DateTime f_DelDate;
        #endregion
        #region Model
        public int F_ID
        {
            get { return f_ID; }
            set { f_ID = value; }
        }
        public string F_Type
        {
            get { return f_Type; }
            set { f_Type = value; }
        }
        public string F_Title
        {
            get { return f_Title; }
            set { f_Title = value; }
        }
        public string F_Content
        {
            get { return f_Content; }
            set { f_Content = value; }
        }
        public string F_Name
        {
            get { return f_Name; }
            set { f_Name = value; }
        }
        public string F_URL
        {
            get { return f_URL; }
            set { f_URL = value; }
        }
        public int F_CreateUser
        {
            get { return f_CreateUser; }
            set { f_CreateUser = value; }
        }
        public DateTime F_CreateDate
        {
            get { return f_CreateDate; }
            set { f_CreateDate = value; }
        }
        public int F_ModiUser
        {
            get { return f_ModiUser; }
            set { f_ModiUser = value; }
        }
        public DateTime F_ModiDate
        {
            get { return f_ModiDate; }
            set { f_ModiDate = value; }
        }
        public int F_DelUser
        {
            get { return f_DelUser; }
            set { f_DelUser = value; }
        }
        public DateTime F_DelDate
        {
            get { return f_DelDate; }
            set { f_DelDate = value; }
        }
        #endregion
    }
}
