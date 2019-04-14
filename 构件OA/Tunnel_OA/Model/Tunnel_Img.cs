using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_Img 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_Img
	{
		public Tunnel_Img()
		{}
		#region Model
		private int _i_id;
		private string _i_name;
		private string _i_uri;
		private DateTime? _i_date;
		private int? _i_user;
		private string _i_type;
		private string _i_year;
		/// <summary>
		/// 
		/// </summary>
		public int i_id
		{
			set{ _i_id=value;}
			get{return _i_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string i_name
		{
			set{ _i_name=value;}
			get{return _i_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string i_uri
		{
			set{ _i_uri=value;}
			get{return _i_uri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? i_date
		{
			set{ _i_date=value;}
			get{return _i_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_user
		{
			set{ _i_user=value;}
			get{return _i_user;}
		}
		/// <summary>
		/// 工地、会议、企业文化
		/// </summary>
		public string i_type
		{
			set{ _i_type=value;}
			get{return _i_type;}
		}
		/// <summary>
		/// 年份
		/// </summary>
		public string i_year
		{
			set{ _i_year=value;}
			get{return _i_year;}
		}
		#endregion Model

	}
}

