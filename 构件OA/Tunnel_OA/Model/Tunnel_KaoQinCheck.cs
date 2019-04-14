using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_KaoQinCheck 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_KaoQinCheck
	{
		public Tunnel_KaoQinCheck()
		{}
		#region Model
		private int _s_id;
		private int? _s_year;
		private int? _s_moon;
		private int? _s_bid;
		private string _s_bname;
		private int? _s_uid;
		private DateTime? _s_date;
		/// <summary>
		/// 
		/// </summary>
		public int s_id
		{
			set{ _s_id=value;}
			get{return _s_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? s_year
		{
			set{ _s_year=value;}
			get{return _s_year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? s_moon
		{
			set{ _s_moon=value;}
			get{return _s_moon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? s_bid
		{
			set{ _s_bid=value;}
			get{return _s_bid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string s_bname
		{
			set{ _s_bname=value;}
			get{return _s_bname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? s_uid
		{
			set{ _s_uid=value;}
			get{return _s_uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? s_date
		{
			set{ _s_date=value;}
			get{return _s_date;}
		}
		#endregion Model

	}
}

