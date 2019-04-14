using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_mail站内邮箱 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_mail
	{
		public Tunnel_mail()
		{}
		#region Model
		private long _m_id;
		private string _m_title;
		private string _m_content;
		private int _m_from;
        private int _m_to;
		private string _m_file;
		private DateTime _m_time;
        private int _m_sort;
		private int _m_state;
        private int m_main;
        private string m_ip;
		/// <summary>
		/// 
		/// </summary>
		public long m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 主题
		/// </summary>
		public string m_title
		{
			set{ _m_title=value;}
			get{return _m_title;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string m_content
		{
			set{ _m_content=value;}
			get{return _m_content;}
		}
		/// <summary>
		/// 发件人
		/// </summary>
		public int m_from
		{
			set{ _m_from=value;}
			get{return _m_from;}
		}
		/// <summary>
		/// 收件人
		/// </summary>
        public int m_to
		{
			set{ _m_to=value;}
			get{return _m_to;}
		}
		/// <summary>
		/// 附件
		/// </summary>
		public string m_file
		{
			set{ _m_file=value;}
			get{return _m_file;}
		}
		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime m_time
		{
			set{ _m_time=value;}
			get{return _m_time;}
		}
		/// <summary>
		/// 分类
		/// </summary>
		public int m_sort
		{
			set{ _m_sort=value;}
			get{return _m_sort;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int m_state
		{
			set{ _m_state=value;}
			get{return _m_state;}
		}

        /// <summary>
        /// 发的是1 收的是0
        /// </summary>
        public int m_Main
        {
            set { m_main = value; }
            get { return m_main; }
        }

        /// <summary>
        /// 用户Ip
        /// </summary>
        public string m_Ip
        {
            set { m_ip = value; }
            get { return m_ip; }
        }
		#endregion Model

	}
}

