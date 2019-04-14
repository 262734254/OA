using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_byingshe 。(属性说明自动提取数据库字段的描述信息)
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
		/// 部门ID
		/// </summary>
		public string by_bid
		{
			set{ _by_bid=value;}
			get{return _by_bid;}
		}
		/// <summary>
		/// 部门权限
		/// </summary>
		public string by_list
		{
			set{ _by_list=value;}
			get{return _by_list;}
		}
		#endregion Model

	}
}

