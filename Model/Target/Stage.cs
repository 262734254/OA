using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Model
{
    /// <summary>
    /// 类stage。
    /// </summary>
    public class Stage
    {
        public Stage()
        { }
        #region Model
        private int sid;
        private int taskid;
        private string stepname;
        private DateTime starttime;
        private DateTime filishtime;
        private string description;
        //是否通过审批 0未审批 1审批
        private int isApprove;

        public override bool Equals(object obj)
        {
            Stage s = (Stage)obj;
            return this.StepName.Equals(s.StepName);

        }
        private string startMonth;

        public string StartMonth
        {
            get { return startMonth; }
            set { startMonth = value; }
        }


        private string endMonth;

        public string EndMonth
        {
            get { return endMonth; }
            set { endMonth = value; }
        }


        private decimal filishRate;

        public decimal FilishRate
        {
            get { return filishRate; }
            set { filishRate = value; }
        }

        public int IsApprove
        {
            get { return isApprove; }
            set { isApprove = value; }
        }
        //是否完成
        private string status;
        //阶段月份
        private string monthlength;

        public string Monthlength
        {
            get { return monthlength; }
            set { monthlength = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private decimal premoney;

        public decimal Premoney
        {
            get { return premoney; }
            set { premoney = value; }
        }
        private decimal? nowmoney;

        public decimal? Nowmoney
        {
            get { return nowmoney; }
            set { nowmoney = value; }
        }
        private string problems;

        public string Problems
        {
            get { return problems; }
            set { problems = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sId
        {
            set { sid = value; }
            get { return sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int taskId
        {
            set { taskid = value; }
            get { return taskid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StepName
        {
            set { stepname = value; }
            get { return stepname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime startTime
        {
            set { starttime = value; }
            get { return starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime filishTime
        {
            set { filishtime = value; }
            get { return filishtime; }
        }

        #endregion Model



    }
}

