using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Model
{
    /// <summary>
    /// ¿‡Powers°£
    /// </summary>
    public class Power
    {
        public Power()
        { }
        #region Model
        private int powerid;
        private string powername;
        private string url;
        private int? prarentid;
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PowerId
        {
            set { powerid = value; }
            get { return powerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PowerName
        {
            set { powername = value; }
            get { return powername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string URL
        {
            set { url = value; }
            get { return url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? prarentId
        {
            set { prarentid = value; }
            get { return prarentid; }
        }
        #endregion Model



    }
}

