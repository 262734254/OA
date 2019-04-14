using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_mailվ������ ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����
		/// </summary>
		public string m_title
		{
			set{ _m_title=value;}
			get{return _m_title;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string m_content
		{
			set{ _m_content=value;}
			get{return _m_content;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int m_from
		{
			set{ _m_from=value;}
			get{return _m_from;}
		}
		/// <summary>
		/// �ռ���
		/// </summary>
        public int m_to
		{
			set{ _m_to=value;}
			get{return _m_to;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string m_file
		{
			set{ _m_file=value;}
			get{return _m_file;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime m_time
		{
			set{ _m_time=value;}
			get{return _m_time;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int m_sort
		{
			set{ _m_sort=value;}
			get{return _m_sort;}
		}
		/// <summary>
		/// ״̬
		/// </summary>
		public int m_state
		{
			set{ _m_state=value;}
			get{return _m_state;}
		}

        /// <summary>
        /// ������1 �յ���0
        /// </summary>
        public int m_Main
        {
            set { m_main = value; }
            get { return m_main; }
        }

        /// <summary>
        /// �û�Ip
        /// </summary>
        public string m_Ip
        {
            set { m_ip = value; }
            get { return m_ip; }
        }
		#endregion Model

	}
}

