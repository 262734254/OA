using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_dyingshe ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_dyingshe
	{
		public Tunnel_dyingshe()
		{
            dy_list = "";
        }
		#region Model
		private int _dy_id;
		private string _dy_did;
		private string _dy_list;
		/// <summary>
		/// 
		/// </summary>
		public int dy_id
		{
			set{ _dy_id=value;}
			get{return _dy_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dy_did
		{
			set{ _dy_did=value;}
			get{return _dy_did;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dy_list
		{
			set{ _dy_list=value;}
			get{return _dy_list;}
		}
		#endregion Model

	}
}

