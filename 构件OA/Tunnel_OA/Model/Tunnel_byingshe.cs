using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_byingshe ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_byingshe
	{
		public Tunnel_byingshe()
		{
            by_list = "";
        }
		#region Model
		private int _by_id;
		private string _by_bid;
		private string _by_list;
		/// <summary>
		/// 
		/// </summary>
		public int by_id
		{
			set{ _by_id=value;}
			get{return _by_id;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public string by_bid
		{
			set{ _by_bid=value;}
			get{return _by_bid;}
		}
		/// <summary>
		/// ����Ȩ��
		/// </summary>
		public string by_list
		{
			set{ _by_list=value;}
			get{return _by_list;}
		}
		#endregion Model

	}
}

