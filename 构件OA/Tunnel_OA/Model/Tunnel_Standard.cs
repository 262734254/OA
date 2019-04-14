using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{

    /// <summary>
    /// 实体类Tunnel_Standard 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Tunnel_Standard
    {
        public Tunnel_Standard()
        { }
        #region Model
        private int _id;
        private string _s_file;
        private string _s_title;
        private string _s_name;
        private DateTime? _createdate;
        private int? _createuser;
        private int? _s_bum;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string S_File
        {
            set { _s_file = value; }
            get { return _s_file; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string S_Title
        {
            set { _s_title = value; }
            get { return _s_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string S_Name
        {
            set { _s_name = value; }
            get { return _s_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? S_bum
        {
            set { _s_bum = value; }
            get { return _s_bum; }
        }
        #endregion Model

    }
}

