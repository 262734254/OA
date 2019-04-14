using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
   
        /// <summary>
        /// 报表模版管理
        /// </summary>
        [Serializable]
        public class Tunnel_ModelType
        {
            private int re_Id;

            public int Re_Id
            {
                get { return re_Id; }
                set { re_Id = value; }
            }
            private string re_Name;

            public string Re_Name
            {
                get { return re_Name; }
                set { re_Name = value; }
            }
            private int re_Num;

            public int Re_Num
            {
                get { return re_Num; }
                set { re_Num = value; }
            }
            private int re_ParentId;

            public int Re_ParentId
            {
                get { return re_ParentId; }
                set { re_ParentId = value; }
            }
        
    }
}
