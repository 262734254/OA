using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_items ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_items
	{
		public Tunnel_items()
		{}
		#region Model
		private int _i_id;
		private string _i_name;
		private string _year;
		private string _moon;
		/// <summary>
		/// 
		/// </summary>
		public int i_id
		{
			set{ _i_id=value;}
			get{return _i_id;}
		}
		/// <summary>
		/// ������Ŀ����
		/// </summary>
		public string i_name
		{
			set{ _i_name=value;}
			get{return _i_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string year
		{
			set{ _year=value;}
			get{return _year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string moon
		{
			set{ _moon=value;}
			get{return _moon;}
		}
		#endregion Model

	}
}

