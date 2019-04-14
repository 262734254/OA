using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_information �������š�(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �����
        /// </summary>
        public int i_audituser
        {
            get { return _i_audituser; }
            set { _i_audituser = value; }
        }
        /// <summary>
        /// ��˱�ע
        /// </summary>
        public string i_auditmark
        {
            get { return _i_auditmark; }
            set { _i_auditmark = value; }
        }
        /// <summary>
        /// ���ʱ��
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
		/// ����
		/// </summary>
		public string i_title
		{
			set{ _i_title=value;}
			get{return _i_title;}
		}
		/// <summary>
        /// ���� 0������ 1����
		/// </summary>
		public int i_sort
		{
			set{ _i_sort=value;}
			get{return _i_sort;}
		}
		/// <summary>
		/// �����ID
		/// </summary>
		public int i_user
		{
			set{ _i_user=value;}
			get{return _i_user;}
		}
		/// <summary>
		/// ���ʱ��
   
		/// </summary>
		public DateTime i_time
		{
			set{ _i_time=value;}
			get{return _i_time;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int i_hit
		{
			set{ _i_hit=value;}
			get{return _i_hit;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string i_content
		{
			set{ _i_content=value;}
			get{return _i_content;}
		}

        /// <summary>
        /// �û�Ip
        /// </summary>
        public string i_Ip
        {
            set { i_ip = value; }
            get { return i_ip; }
        }
		#endregion Model

	}
}

