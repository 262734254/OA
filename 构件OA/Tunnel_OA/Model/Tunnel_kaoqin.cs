using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_kaoqin ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_kaoqin
	{
		public Tunnel_kaoqin()
		{}
		#region Model
		private long _k_id;
		private DateTime? _k_date;
		private string _k_amtime;
		private string _k_pmtime;
		private string _k_endtime;
		private int? _k_user;
		private int? _k_ifsb;
		/// <summary>
		/// 
		/// </summary>
		public long k_id
		{
			set{ _k_id=value;}
			get{return _k_id;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public DateTime? k_date
		{
			set{ _k_date=value;}
			get{return _k_date;}
		}
		/// <summary>
		/// ����Ǽ�ʱ��
		/// </summary>
		public string k_amtime
		{
			set{ _k_amtime=value;}
			get{return _k_amtime;}
		}
		/// <summary>
		/// ����Ǽ�ʱ��
		/// </summary>
		public string k_pmtime
		{
			set{ _k_pmtime=value;}
			get{return _k_pmtime;}
		}
		/// <summary>
		/// �°�Ǽ�ʱ��
		/// </summary>
		public string k_endtime
		{
			set{ _k_endtime=value;}
			get{return _k_endtime;}
		}
		/// <summary>
		/// �Ǽ���ID
		/// </summary>
		public int? k_user
		{
			set{ _k_user=value;}
			get{return _k_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? k_ifsb
		{
			set{ _k_ifsb=value;}
			get{return _k_ifsb;}
		}
		#endregion Model

	}
}

