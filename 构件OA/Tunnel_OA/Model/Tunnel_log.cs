using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_log������־��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_log
	{
		public Tunnel_log()
		{}
		#region Model
		private long _l_id;
		private int _l_user;
		private DateTime _l_time;
		private string _l_content;
		private string _l_ip;
		private int _l_sort;
		/// <summary>
		/// 
		/// </summary>
		public long l_id
		{
			set{ _l_id=value;}
			get{return _l_id;}
		}
		/// <summary>
		/// �û�ID
		/// </summary>
		public int l_user
		{
			set{ _l_user=value;}
			get{return _l_user;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime l_time
		{
			set{ _l_time=value;}
			get{return _l_time;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string l_content
		{
			set{ _l_content=value;}
			get{return _l_content;}
		}
		/// <summary>
		/// IP
		/// </summary>
		public string l_ip
		{
			set{ _l_ip=value;}
			get{return _l_ip;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int l_sort
		{
			set{ _l_sort=value;}
			get{return _l_sort;}
		}
		#endregion Model

	}
}

