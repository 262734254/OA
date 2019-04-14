using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_anpai 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_anpai
	{
		public Tunnel_anpai()
		{}
		#region Model
		private int _a_id;
		private string _a_title;
		private string _a_content;
		private DateTime? _a_date;
		private string _a_ampm;
		private int? _a_userid;
		private DateTime? _a_createdate;
		/// <summary>
		/// 
		/// </summary>
		public int a_id
		{
			set{ _a_id=value;}
			get{return _a_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string a_title
		{
			set{ _a_title=value;}
			get{return _a_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string a_content
		{
			set{ _a_content=value;}
			get{return _a_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? a_date
		{
			set{ _a_date=value;}
			get{return _a_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string a_ampm
		{
			set{ _a_ampm=value;}
			get{return _a_ampm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? a_userId
		{
			set{ _a_userid=value;}
			get{return _a_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? a_createDate
		{
			set{ _a_createdate=value;}
			get{return _a_createdate;}
		}
		#endregion Model

	}
}

