using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    public class Tunnel_xjbType
    {
        int _id;
        /// <summary>
        /// id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _typename;
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Typename
        {
            get { return _typename; }
            set { _typename = value; }
        }
        int _typeid;
        /// <summary>
        /// 所属类型ID
        /// </summary>
        public int Typeid
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        int parentid;
        /// <summary>
        /// 父类ID
        /// </summary>
        public int Parentid
        {
            get { return parentid; }
            set { parentid = value; }
        }
        string url;
        /// <summary>
        /// 连接地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        string isStop;
        /// <summary>
        /// 停用日期
        /// </summary>
        public string IsStop
        {
            get { return isStop; }
            set { isStop = value; }
        }
        int userID;
        /// <summary>
        /// 停用者
        /// </summary>
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}
