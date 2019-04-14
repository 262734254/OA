using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_duty职务 。(属性说明自动提取数据库字段的描述信息)
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
		/// 职务名称
		/// </summary>
		public string d_name
		{
			set{ _d_name=value;}
			get{return _d_name;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string d_depict
		{
			set{ _d_depict=value;}
			get{return _d_depict;}
		}
		/// <summary>
		/// 权限
		/// </summary>
		public string d_flag
		{
			set{ _d_flag=value;}
			get{return _d_flag;}
		}
		#endregion Model

	}
}

