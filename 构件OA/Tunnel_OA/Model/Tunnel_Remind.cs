using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_Remind ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����ID
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
		/// ��Ϣ����
		/// </summary>
		public string m_title
		{
			set{ _m_title=value;}
			get{return _m_title;}
		}
		/// <summary>
		/// ��ϢURL
		/// </summary>
		public string m_url
		{
			set{ _m_url=value;}
			get{return _m_url;}
		}
		/// <summary>
		/// ��Ϣ��ʾ��
		/// </summary>
		public long m_touser
		{
			set{ _m_touser=value;}
			get{return _m_touser;}
		}
		/// <summary>
		/// ��Ϣʱ��
		/// </summary>
		public DateTime m_time
		{
			set{ _m_time=value;}
			get{return _m_time;}
		}
		/// <summary>
		/// �Ƿ��Ѷ�
		/// </summary>
		public int m_isread
		{
			set{ _m_isread=value;}
			get{return _m_isread;}
		}
		/// <summary>
		/// ��ʾʱ��
		/// </summary>
		public DateTime m_callTime
		{
			set{ _m_calltime=value;}
			get{return _m_calltime;}
		}
		/// <summary>
		/// ��Ϣ����
		/// </summary>
		public int m_type
		{
			set{ _m_type=value;}
			get{return _m_type;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int m_typeid
		{
			set{ _m_typeid=value;}
			get{return _m_typeid;}
		}
		#endregion Model

	}
}

