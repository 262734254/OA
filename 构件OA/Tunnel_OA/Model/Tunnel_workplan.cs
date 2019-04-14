using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_workplan�����ƻ� ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_workplan
	{
		public Tunnel_workplan()
		{}
		#region Model
		private long _w_id;
		private string _w_title;
		private string _w_content;
		private DateTime _w_starttime;
		private DateTime _w_endtime;
		private string _w_depict;
		private int _w_user;
        private string w_ip;
		/// <summary>
		/// �����ƻ�Id
		/// </summary>
		public long w_id
		{
			set{ _w_id=value;}
			get{return _w_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string w_title
		{
			set{ _w_title=value;}
			get{return _w_title;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string w_content
		{
			set{ _w_content=value;}
			get{return _w_content;}
		}
		/// <summary>
		/// ��ʼʱ��
		/// </summary>
		public DateTime w_starttime
		{
			set{ _w_starttime=value;}
			get{return _w_starttime;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime w_endtime
		{
			set{ _w_endtime=value;}
			get{return _w_endtime;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string w_depict
		{
			set{ _w_depict=value;}
			get{return _w_depict;}
		}
		/// <summary>
		/// �û�ID
		/// </summary>
		public int w_user
		{
			set{ _w_user=value;}
			get{return _w_user;}
		}

        /// <summary>
        /// Ip
        /// </summary>
        public string w_Ip
        {
            set { w_ip = value; }
            get { return w_ip; }
        }
		#endregion Model

	}
}

