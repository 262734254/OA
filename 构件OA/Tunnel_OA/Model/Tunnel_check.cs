using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_check 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_check
	{
		public Tunnel_check()
		{}
		#region Model
		private int _c_id;
		private int? _c_userid;
		private int? _c_itemsid;
		private int? _c_score;
		private string  _c_income;
		private string _c_date;
		/// <summary>
		/// 
		/// </summary>
		public int c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_userId
		{
			set{ _c_userid=value;}
			get{return _c_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_itemsId
		{
			set{ _c_itemsid=value;}
			get{return _c_itemsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_score
		{
			set{ _c_score=value;}
			get{return _c_score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_income
		{
			set{ _c_income=value;}
			get{return _c_income;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_date
		{
			set{ _c_date=value;}
			get{return _c_date;}
		}
		#endregion Model

	}
}

