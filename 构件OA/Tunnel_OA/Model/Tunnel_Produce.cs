using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    /// <summary>
    /// 实体类 Tunnel_Produce 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Tunnel_Produce
    {
        public Tunnel_Produce()
        {
            _proID = 0;
            _proType = string.Empty;
            _proTitle = string.Empty;
            _proName = string.Empty;
            _proSrc = string.Empty;
            _createDate = Convert.ToDateTime("1800-01-01");
            _createUser = 0;
            _modiDate = Convert.ToDateTime("1800-01-01");
            _modiUser = 0;
            _deleteDate = Convert.ToDateTime("1800-01-01");
            _deleteUser = 0;
            _proState = "N";
        }

        #region Model
        private int _proID;
        private string _proType;
        private string _proTitle;
        private string _proName;
        private string _proSrc;
        private DateTime _createDate;
        private int _createUser;
        private DateTime _modiDate;
        private int _modiUser;
        private DateTime _deleteDate;
        private int _deleteUser;
        private string _proState;

        public int ProID
        {
            get
            {
                return _proID;
            }
            set
            {
                _proID = value;
            }
        }
        public string ProType
        {
            get
            {
                return _proType;
            }
            set
            {
                _proType = value;
            }
        }
        public string ProTitle
        {
            get
            {
                return _proTitle;
            }
            set
            {
                _proTitle = value;
            }
        }
        public string ProName
        {
            get
            {
                return _proName;
            }
            set
            {
                _proName = value;
            }
        }
        public string ProSrc
        {
            get
            {
                return _proSrc;
            }
            set
            {
                _proSrc = value;
            }
        }
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }
        public int CreateUser
        {
            get
            {
                return _createUser;
            }
            set
            {
                _createUser = value;
            }
        }
        public DateTime ModiDate
        {
            get
            {
                return _modiDate;
            }
            set
            {
                _modiDate = value;
            }
        }
        public int ModiUser
        {
            get
            {
                return _modiUser;
            }
            set
            {
                _modiUser = value;
            }
        }
        public DateTime DeleteDate
        {
            get
            {
                return _deleteDate;
            }
            set
            {
                _deleteDate = value;
            }
        }
        public int DeleteUser
        {
            get
            {
                return _deleteUser;
            }
            set
            {
                _deleteUser = value;
            }
        }
        public string ProState
        {
            get
            {
                return _proState;
            }
            set
            {
                _proState = value;
            }
        }
        #endregion
    }
}
