using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_uyingshe ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_uyingshe
	{
		public Tunnel_uyingshe()
		{
            uy_list = "";
        }
		#region Model
		private int _uy_id;
		private string _uy_uid;
		private string _uy_list;
		/// <summary>
		/// 
		/// </summary>
		public int uy_id
		{
			set{ _uy_id=value;}
			get{return _uy_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uy_uid
		{
			set{ _uy_uid=value;}
			get{return _uy_uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uy_list
		{
			set{ _uy_list=value;}
			get{return _uy_list;}
		}
		#endregion Model

	}
}

