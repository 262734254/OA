using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_work 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_work
	{
		public Tunnel_work()
		{}
		#region Model
		private int _w_id;
		private string _w_bumname;
		private int? _w_maxcent;
		private string _w_workname;
		/// <summary>
		/// 
		/// </summary>
		public int w_id
		{
			set{ _w_id=value;}
			get{return _w_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string w_bumName
		{
			set{ _w_bumname=value;}
			get{return _w_bumname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? w_maxCent
		{
			set{ _w_maxcent=value;}
			get{return _w_maxcent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string w_workName
		{
			set{ _w_workname=value;}
			get{return _w_workname;}
		}
		#endregion Model

	}
}

