using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    public class Tunnel_viewTable
    {
        private int id;
        private int objId;
        private int typeId;
        private int userId;
        private string content;
        private string setDate;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public int ObjId
        {
            set { objId = value; }
            get { return objId; }
        }


        public int TypeId
        {
            set { typeId = value; }
            get { return typeId; }
        }

        public int UserId
        {
            set { userId = value; }
            get { return userId; }
        }


        public string Content
        {
            set { content = value; }
            get { return content; }
        }

        public string SetDate
        {
            set { setDate = value; }
            get { return setDate; }
        }
    }
}
