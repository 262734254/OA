using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_meeting会议 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_meeting
	{
		public Tunnel_meeting()
		{}
		#region Model
		private long _m_id;
		private string _m_title;
		private string _m_content;
		private string _m_menber;
		private DateTime _m_startime;
		private DateTime _m_endtime;
		private int _m_user;
		private int _m_state;
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
		/// 标题
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
		/// 参加人
		/// </summary>
		public string m_menber
		{
			set{ _m_menber=value;}
			get{return _m_menber;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime m_startime
		{
			set{ _m_startime=value;}
			get{return _m_startime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime m_endtime
		{
			set{ _m_endtime=value;}
			get{return _m_endtime;}
		}
		/// <summary>
		/// 发布人ID
		/// </summary>
		public int m_user
		{
			set{ _m_user=value;}
			get{return _m_user;}
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

