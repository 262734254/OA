using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_information 公告新闻。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_information
	{
		public Tunnel_information()
		{}
		#region Model
		private long _i_id;
		private string _i_title;
		private int _i_sort;
		private int _i_user;
		private DateTime _i_time;
		private int _i_hit;
		private string _i_content;
        private string i_ip;
        private string _i_files;
        private int _i_audituser;
        private string _i_auditmark;
        private string _i_audittime;
        /// <summary>
        /// 审核人
        /// </summary>
        public int i_audituser
        {
            get { return _i_audituser; }
            set { _i_audituser = value; }
        }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string i_auditmark
        {
            get { return _i_auditmark; }
            set { _i_auditmark = value; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public string i_audittime
        {
            get { return _i_audittime; }
            set { _i_audittime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string i_files
        {
            set { _i_files = value; }
            get { return _i_files; }
        }
		/// <summary>
		/// 
		/// </summary>
		public long i_id
		{
			set{ _i_id=value;}
			get{return _i_id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string i_title
		{
			set{ _i_title=value;}
			get{return _i_title;}
		}
		/// <summary>
        /// 分类 0是新闻 1公告
		/// </summary>
		public int i_sort
		{
			set{ _i_sort=value;}
			get{return _i_sort;}
		}
		/// <summary>
		/// 添加人ID
		/// </summary>
		public int i_user
		{
			set{ _i_user=value;}
			get{return _i_user;}
		}
		/// <summary>
		/// 添加时间
   
		/// </summary>
		public DateTime i_time
		{
			set{ _i_time=value;}
			get{return _i_time;}
		}
		/// <summary>
		/// 点击量
		/// </summary>
		public int i_hit
		{
			set{ _i_hit=value;}
			get{return _i_hit;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string i_content
		{
			set{ _i_content=value;}
			get{return _i_content;}
		}

        /// <summary>
        /// 用户Ip
        /// </summary>
        public string i_Ip
        {
            set { i_ip = value; }
            get { return i_ip; }
        }
		#endregion Model

	}
}

