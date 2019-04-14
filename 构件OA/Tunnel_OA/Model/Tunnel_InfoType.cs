using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    public class Tunnel_InfoType
    {
        private int autoID;
        private int headID;
        private string itemName;
        private string m_url;

        public int AutoID
        {
            get
            {
                return autoID;
            }
            set
            {
                autoID = value;
            }
        }
        public int HeadID
        {
            get
            {
                return headID;
            }
            set
            {
                headID = value;
            }
        }
        public string ItemName
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
            }
        }
        public string Url
        {
            get
            {
                return m_url;
            }
            set
            {
                m_url = value;
            }
        }
    }
}
