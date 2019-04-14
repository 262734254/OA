using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_Remind 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_Remind
	{
		public Tunnel_Remind()
		{}
		#region Model
		private long _m_id;
		private string _m_title;
		private string _m_url;
		private long _m_touser;
		private DateTime _m_time;
		private int _m_isread;
		private DateTime _m_calltime;
		private int _m_type;
		private int _m_typeid;
        private int _m_bid;

        /// <summary>
        /// 步骤ID
        /// </summary>
        public int m_bid
        {
            get { return _m_bid; }
            set { _m_bid = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public long m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 消息标题
		/// </summary>
		public string m_title
		{
			set{ _m_title=value;}
			get{return _m_title;}
		}
		/// <summary>
		/// 消息URL
		/// </summary>
		public string m_url
		{
			set{ _m_url=value;}
			get{return _m_url;}
		}
		/// <summary>
		/// 消息提示人
		/// </summary>
		public long m_touser
		{
			set{ _m_touser=value;}
			get{return _m_touser;}
		}
		/// <summary>
		/// 消息时间
		/// </summary>
		public DateTime m_time
		{
			set{ _m_time=value;}
			get{return _m_time;}
		}
		/// <summary>
		/// 是否已读
		/// </summary>
		public int m_isread
		{
			set{ _m_isread=value;}
			get{return _m_isread;}
		}
		/// <summary>
		/// 提示时间
		/// </summary>
		public DateTime m_callTime
		{
			set{ _m_calltime=value;}
			get{return _m_calltime;}
		}
		/// <summary>
		/// 消息类型
		/// </summary>
		public int m_type
		{
			set{ _m_type=value;}
			get{return _m_type;}
		}
		/// <summary>
		/// 类型ID
		/// </summary>
		public int m_typeid
		{
			set{ _m_typeid=value;}
			get{return _m_typeid;}
		}
		#endregion Model

	}
}

