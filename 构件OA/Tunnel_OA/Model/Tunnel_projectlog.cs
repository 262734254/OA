using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_projectlog������־ ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_projectlog
	{
		public Tunnel_projectlog()
		{}
		#region Model
		private long _pl_id;
		private string _pl_title;
		private string _pl_content;
		private DateTime _pl_time;
		private int _pl_user;
        private string pl_ip;
		/// <summary>
		/// 
		/// </summary>
		public long pl_id
		{
			set{ _pl_id=value;}
			get{return _pl_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string pl_title
		{
			set{ _pl_title=value;}
			get{return _pl_title;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string pl_content
		{
			set{ _pl_content=value;}
			get{return _pl_content;}
		}
		/// <summary>
		/// �ύʱ��
		/// </summary>
		public DateTime pl_time
		{
			set{ _pl_time=value;}
			get{return _pl_time;}
		}
		/// <summary>
		/// �ύ��ID
		/// </summary>
		public int pl_user
		{
			set{ _pl_user=value;}
			get{return _pl_user;}
		}

        /// <summary>
        /// �û�Ip
        /// </summary>
        public string pl_Ip
        {
            set { pl_ip = value; }
            get { return pl_ip; }
        }
		#endregion Model

	}
}

