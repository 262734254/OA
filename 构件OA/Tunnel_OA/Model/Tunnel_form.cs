using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_form�� ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_form
	{
		public Tunnel_form()
		{}
		#region Model
		private long _f_id;
		private string _f_name;
		private int _f_bum;
		private int _f_lcid;
		private int _f_user;
		private DateTime _f_date;
		private string _f_content;
		/// <summary>
		/// 
		/// </summary>
		public long f_id
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string f_name
		{
			set{ _f_name=value;}
			get{return _f_name;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int f_bum
		{
			set{ _f_bum=value;}
			get{return _f_bum;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int f_lcid
		{
			set{ _f_lcid=value;}
			get{return _f_lcid;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int f_user
		{
			set{ _f_user=value;}
			get{return _f_user;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime f_date
		{
			set{ _f_date=value;}
			get{return _f_date;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string f_content
		{
			set{ _f_content=value;}
			get{return _f_content;}
		}
		#endregion Model

	}
}

