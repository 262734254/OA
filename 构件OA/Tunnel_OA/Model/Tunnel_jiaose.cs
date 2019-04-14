using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_jiaose 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_jiaose
	{
		public Tunnel_jiaose()
		{}
		#region Model
		private long _j_id;
		private string _j_name;
		private string _j_depict;
		private string _j_flag;
		private int _j_zdyjs;
		/// <summary>
		/// 
		/// </summary>
		public long j_id
		{
			set{ _j_id=value;}
			get{return _j_id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
        public string j_name
		{
			set{ _j_name=value;}
			get{return _j_name;}
		}
		/// <summary>
		/// 描述
		/// </summary>
        public string j_depict
		{
			set{ _j_depict=value;}
			get{return _j_depict;}
		}
		/// <summary>
		/// 权限
		/// </summary>
		public string j_flag
		{
			set{ _j_flag=value;}
			get{return _j_flag;}
		}
		/// <summary>
		/// 是否自定义角色  0 则无自定义
		/// </summary>
		public int j_zdyjs
		{
			set{ _j_zdyjs=value;}
			get{return _j_zdyjs;}
		}
		#endregion Model

	}
}

