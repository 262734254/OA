using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类Car_Byapply 
    /// </summary>
    [Serializable]
    public class Car_Byapply
    {
        public Car_Byapply()
        { }
        #region Model
        private int byapplyid;
        private DateTime bydata;
        private Department bydept = new Department();
        private string byman;
        private Car_Type bytypeid = new Car_Type();
        private string bycause;
        private string bydttion;
        private DateTime byredata;
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ByapplyId
        {
            set { byapplyid = value; }
            get { return byapplyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ByData
        {
            set { bydata = value; }
            get { return bydata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Department ByDept
        {
            set { bydept = value; }
            get { return bydept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ByMan
        {
            set { byman = value; }
            get { return byman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Car_Type ByTypeid
        {
            set { bytypeid = value; }
            get { return bytypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ByCause
        {
            set { bycause = value; }
            get { return bycause; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ByDttion
        {
            set { bydttion = value; }
            get { return bydttion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ByReData
        {
            set { byredata = value; }
            get { return byredata; }
        }
         #endregion
    }
}
     

    
