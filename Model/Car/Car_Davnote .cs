using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类Car_Davnote 。
    /// </summary>
    [Serializable]
    public class Car_Davnote
    {
        public Car_Davnote()
        { }
        #region Model
        private int davnoteid;
        private DateTime davdata;
        private Department davdept=new Department();
        private string davman;
        private Car_Type davtypeid=new Car_Type();
        private string davmark;
        private string davdriver;
        private string davplace;
        private decimal davcourse;
        private string davttion;
        private string davremark;
        private DateTime davreturndata;
        private string davexpand;
        /// <summary>
        /// 
        /// </summary>
        public int DavnoteId
        {
            set { davnoteid = value; }
            get { return davnoteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DavData
        {
            set { davdata = value; }
            get { return davdata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Department DavDept
        {
            set { davdept = value; }
            get { return davdept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DavMan
        {
            set { davman = value; }
            get { return davman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Car_Type DavTypeId
        {
            set { davtypeid = value; }
            get { return davtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DavMark
        {
            set { davmark = value; }
            get { return davmark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DavDriver
        {
            set { davdriver = value; }
            get { return davdriver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DavPlace
        {
            set { davplace = value; }
            get { return davplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DavCourse
        {
            set { davcourse = value; }
            get { return davcourse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DavTtion
        {
            set { davttion = value; }
            get { return davttion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DavRemark
        {
            set { davremark = value; }
            get { return davremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DavReturnData
        {
            set { davreturndata = value; }
            get { return davreturndata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DavExpand
        {
            set { davexpand = value; }
            get { return davexpand; }
        }
        #endregion Model

    }
}