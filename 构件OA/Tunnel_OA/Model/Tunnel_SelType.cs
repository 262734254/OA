using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
   public class Tunnel_SelType
    {
        public Tunnel_SelType()
	    {
            _TypeID = 0;
            _TypeName = string.Empty;
            _BumID = "0";
            _BumName = string.Empty;
            url = string.Empty;
            _ParentID = 0;
            _IsDel = 0;
            _KSID = 0;
        }
        #region Model
        private int _TypeID;
        private string _TypeName;
        private string _BumID;
        private string _BumName;
        private string url;
        private int _ParentID;
        private int _IsDel;
        private int _KSID;
        /// <summary>
        /// 连接地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TypeID
        {
            set { _TypeID = value; }
            get { return _TypeID; }
        }
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string TypeName
        {
            set { _TypeName = value; }
            get { return _TypeName; }
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public string BumID
        {
            set { _BumID = value; }
            get { return _BumID; }
        }
        /// <summary>
        /// 所属部门名称
        /// </summary>
        public string BumName
        {
            set { _BumName = value; }
            get { return _BumName; }
        }
        /// <summary>
        /// 所属父类
        /// </summary>
        public int ParentID
        {
            set { _ParentID = value; }
            get { return _ParentID; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel
        {
            set { _IsDel = value; }
            get { return _IsDel; }
        }
        /// <summary>
        /// 科室编号
        /// </summary>
        public int KSID
        {
            set { _KSID = value; }
            get { return _KSID; }
        }
        #endregion Model
    }
}
