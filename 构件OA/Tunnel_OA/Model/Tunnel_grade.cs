using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_grade 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_grade
	{
		public Tunnel_grade()
		{}
		#region Model
		private int _g_id;
		private int? _g_workid;
		private int? _g_checkid;
		private float _g_cent;
		/// <summary>
		/// 
		/// </summary>
		public int g_id
		{
			set{ _g_id=value;}
			get{return _g_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? g_workId
		{
			set{ _g_workid=value;}
			get{return _g_workid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? g_checkId
		{
			set{ _g_checkid=value;}
			get{return _g_checkid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public float g_cent
		{
			set{ _g_cent=value;}
			get{return _g_cent;}
		}
		#endregion Model

	}
}

