using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_dutyְ�� ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_duty
	{
		public Tunnel_duty()
		{}
		#region Model
		private long _d_id;
		private string _d_name;
		private string _d_depict;
		private string _d_flag;
		/// <summary>
		/// 
		/// </summary>
		public long d_id
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// ְ������
		/// </summary>
		public string d_name
		{
			set{ _d_name=value;}
			get{return _d_name;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string d_depict
		{
			set{ _d_depict=value;}
			get{return _d_depict;}
		}
		/// <summary>
		/// Ȩ��
		/// </summary>
		public string d_flag
		{
			set{ _d_flag=value;}
			get{return _d_flag;}
		}
		#endregion Model

	}
}

