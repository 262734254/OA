using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    /// <summary>
    /// 实体类 Tunnel_Message 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Tunnel_Message
    {
        public Tunnel_Message()
        {
        }

        #region Model
        private int _MesID;
        private string _MesTitle;
        private string _MesContent;
        private DateTime _MesDate;
        private DateTime _ModiDate;
        private DateTime _DelDate;
        private int _MesUser;

        public int MesID
        {
            get
            {
                return _MesID;
            }
            set
            {
                _MesID = value;
            }
        }
        public string MesTitle
        {
            get
            {
                return _MesTitle;
            }
            set
            {
                _MesTitle = value;
            }
        }
        public string MesContent
        {
            get
            {
                return _MesContent;
            }
            set
            {
                _MesContent = value;
            }
        }
        public DateTime MesDate
        {
            get
            {
                return _MesDate;
            }
            set
            {
                _MesDate = value;
            }
        }
        public DateTime ModiDate
        {
            get
            {
                return _ModiDate;
            }
            set
            {
                _ModiDate = value;
            }
        }
        public DateTime DelDate
        {
            get
            {
                return _DelDate;
            }
            set
            {
                _DelDate = value;
            }
        }
        public int MesUser
        {
            get
            {
                return _MesUser;
            }
            set
            {
                _MesUser = value;
            }
        }
        #endregion
    }

    
}
