using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_Profile 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_Profile
	{
		public Tunnel_Profile()
		{}
		#region Model
		private int _p_id;
		private string _p_name;
		private int? _p_year;
		private string _p_bum;
		private string _p_filetype;
		private int? _p_uid;
		/// <summary>
		/// 
		/// </summary>
		public int p_id
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? p_year
		{
			set{ _p_year=value;}
			get{return _p_year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_bum
		{
			set{ _p_bum=value;}
			get{return _p_bum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_filetype
		{
			set{ _p_filetype=value;}
			get{return _p_filetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? p_uid
		{
			set{ _p_uid=value;}
			get{return _p_uid;}
		}
		#endregion Model

	}
}

