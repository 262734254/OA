using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_items 。(属性说明自动提取数据库字段的描述信息)
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
		/// 工程项目名称
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

