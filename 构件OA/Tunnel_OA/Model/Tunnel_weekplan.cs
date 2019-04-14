using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_weekplan 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_weekplan
	{
		public Tunnel_weekplan()
		{}
		#region Model
		private long _w_id;
		private string _w_title;
		private string _w_content;
		private string _w_address;
		private string _w_time;
		private string _w_daytime;
		private DateTime? _w_adddate;
		private string _w_weekid;
		private string _w_date;
		/// <summary>
		/// 
		/// </summary>
		public long w_id
		{
			set{ _w_id=value;}
			get{return _w_id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string w_title
		{
			set{ _w_title=value;}
			get{return _w_title;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string w_content
		{
			set{ _w_content=value;}
			get{return _w_content;}
		}
		/// <summary>
		/// 地点
		/// </summary>
		public string w_address
		{
			set{ _w_address=value;}
			get{return _w_address;}
		}
		/// <summary>
		/// 几点
		/// </summary>
		public string w_time
		{
			set{ _w_time=value;}
			get{return _w_time;}
		}
		/// <summary>
		/// 上午?下午
		/// </summary>
		public string w_daytime
		{
			set{ _w_daytime=value;}
			get{return _w_daytime;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? w_adddate
		{
			set{ _w_adddate=value;}
			get{return _w_adddate;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string w_weekID
		{
			set{ _w_weekid=value;}
			get{return _w_weekid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string w_date
		{
			set{ _w_date=value;}
			get{return _w_date;}
		}
		#endregion Model

	}
}

