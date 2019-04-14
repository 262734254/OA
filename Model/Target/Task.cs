using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Model
{
	/// <summary>
	/// ¿‡task°£
	/// </summary>
	public class Task
	{
        public Task()
        { }
        #region Model
        private int id;
        private string title;
        private int year;
        private decimal? finishRate;

        public decimal? FinishRate
        {
            get { return finishRate; }
            set { finishRate = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private int mumber;
        private string domain;
        private string work;
        private string tasktype;

        public string Tasktype
        {
            get { return tasktype; }
            set { tasktype = value; }
        }
        private string dutydepart;
        private string principal;
        private DateTime filishtime;
        private string extrleader;
        private string branch;
        private string vindicator;
        private string remarks;
        private string targettask;
        private decimal money;
        private string path;
        private string status;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { title = value; }
            get { return title; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int Mumber
        {
            set { mumber = value; }
            get { return mumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Domain
        {
            set { domain = value; }
            get { return domain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Work
        {
            set { work = value; }
            get { return work; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string dutyDepart
        {
            set { dutydepart = value; }
            get { return dutydepart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Principal
        {
            set { principal = value; }
            get { return principal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime filishTime
        {
            set { filishtime = value; }
            get { return filishtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Extrleader
        {
            set { extrleader = value; }
            get { return extrleader; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Branch
        {
            set { branch = value; }
            get { return branch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Vindicator
        {
            set { vindicator = value; }
            get { return vindicator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { remarks = value; }
            get { return remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string targetTask
        {
            set { targettask = value; }
            get { return targettask; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Money
        {
            set { money = value; }
            get { return money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            set { path = value; }
            get { return path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            set { status = value; }
            get { return status; }
        }
        #endregion Model

		
	}
}

