using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tunnel.BLL;

namespace Tunnel.BLL
{
    public class Tunnel_InfoType
    {
        private Tunnel.DAL.Tunnel_InfoType infoTypeDAL;
        private Tunnel.DAL.Tunnel_InfoType m_InfoTypeDAL
        {
            get
            {
                if (null == infoTypeDAL)
                    infoTypeDAL = new Tunnel.DAL.Tunnel_InfoType();
                return infoTypeDAL;
            }
        }

        public Tunnel_InfoType()
        {
        }

        public DataSet GetList(string strWhere)
        {
            return m_InfoTypeDAL.GetList(strWhere);
        }
    }
}
