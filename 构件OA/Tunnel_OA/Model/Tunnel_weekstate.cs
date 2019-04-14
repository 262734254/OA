using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_weekstate 。(属性说明自动提取数据库字段的描述信息)
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

