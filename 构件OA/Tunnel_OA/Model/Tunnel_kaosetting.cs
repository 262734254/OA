using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_kaosetting�������� ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_kaosetting
	{
		public Tunnel_kaosetting()
		{}
		#region Model
		private long _k_id;
		private string _k_amtime;
		private string _k_pmtime;
		private string _k_xiu;
		private string _k_am2time;
		private string _k_pm2time;
		/// <summary>
		/// 
		/// </summary>
		public long k_id
		{
			set{ _k_id=value;}
			get{return _k_id;}
		}
		/// <summary>
		/// �����ϰ�ʱ��
		/// </summary>
		public string k_amtime
		{
			set{ _k_amtime=value;}
			get{return _k_amtime;}
		}
		/// <summary>
		/// �����ϰ�ʱ��
		/// </summary>
		public string k_pmtime
		{
			set{ _k_pmtime=value;}
			get{return _k_pmtime;}
		}
		/// <summary>
		/// ��ĩ��Ϣ��
		/// </summary>
		public string k_xiu
		{
			set{ _k_xiu=value;}
			get{return _k_xiu;}
		}
		/// <summary>
		/// �����°�ʱ��
		/// </summary>
		public string k_am2time
		{
			set{ _k_am2time=value;}
			get{return _k_am2time;}
		}
		/// <summary>
		/// �����°�ʱ��
		/// </summary>
		public string k_pm2time
		{
			set{ _k_pm2time=value;}
			get{return _k_pm2time;}
		}
		#endregion Model

	}
}

