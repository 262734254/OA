using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_weekstate ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_weekstate
	{
		public Tunnel_weekstate()
		{}
		#region Model
		private string _week_id;
		private int? _week_state;
		/// <summary>
		/// 
		/// </summary>
		public string week_ID
		{
			set{ _week_id=value;}
			get{return _week_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? week_state
		{
			set{ _week_state=value;}
			get{return _week_state;}
		}
		#endregion Model

	}
}

