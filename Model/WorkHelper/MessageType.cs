using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public class MessageType
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string msgType = String.Empty;

        public string MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }
    }
}
