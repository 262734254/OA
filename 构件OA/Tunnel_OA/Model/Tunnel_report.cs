using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_report报告 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_report
	{
		public Tunnel_report()
		{}
		#region Model
		private long _r_id;
		private string _r_title;
		private string _r_file;
		private DateTime _r_time;
		private int _r_from;
		private int _r_user;
        private string r_content;
        private string r_toemail;
        private string r_ip;
		/// <summary>
		/// 
		/// </summary>
		public long r_id
		{
			set{ _r_id=value;}
			get{return _r_id;}
		}
		/// <summary>
		/// 报告标题
		/// </summary>
		public string r_title
		{
			set{ _r_title=value;}
			get{return _r_title;}
		}
		/// <summary>
		/// 附件
		/// </summary>
		public string r_file
		{
			set{ _r_file=value;}
			get{return _r_file;}
		}
		/// <summary>
		/// 提交时间
		/// </summary>
		public DateTime r_time
		{
			set{ _r_time=value;}
			get{return _r_time;}
		}
		/// <summary>
		/// 收报告人ID
		/// </summary>
		public int r_from
		{
			set{ _r_from=value;}
			get{return _r_from;}
		}
		/// <summary>
		/// 提交人ID
		/// </summary>
		public int r_user
		{
			set{ _r_user=value;}
			get{return _r_user;}
		}
        /// <summary>
        /// 报告内容
        /// </summary>
        public string r_Content
        {
            set { r_content = value; }
            get { return r_content; }
        }

        /// <summary>
        /// 接受人的邮箱
        /// </summary>
        public string r_toEmail
        {
            set { r_toemail = value; }
            get { return r_toemail; }
        }

        /// <summary>
        /// 操作人Ip
        /// </summary>
        public string r_Ip
        {
            set { r_ip = value; }
            get { return r_ip; }
        }
        
		#endregion Model

	}
}

