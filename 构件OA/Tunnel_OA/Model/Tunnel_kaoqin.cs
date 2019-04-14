using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_kaoqin 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_kaoqin
	{
		public Tunnel_kaoqin()
		{}
		#region Model
		private long _k_id;
		private DateTime? _k_date;
		private string _k_amtime;
		private string _k_pmtime;
		private string _k_endtime;
		private int? _k_user;
		private int? _k_ifsb;
		/// <summary>
		/// 
		/// </summary>
		public long k_id
		{
			set{ _k_id=value;}
			get{return _k_id;}
		}
		/// <summary>
		/// 考勤日期
		/// </summary>
		public DateTime? k_date
		{
			set{ _k_date=value;}
			get{return _k_date;}
		}
		/// <summary>
		/// 上午登记时间
		/// </summary>
		public string k_amtime
		{
			set{ _k_amtime=value;}
			get{return _k_amtime;}
		}
		/// <summary>
		/// 下午登记时间
		/// </summary>
		public string k_pmtime
		{
			set{ _k_pmtime=value;}
			get{return _k_pmtime;}
		}
		/// <summary>
		/// 下班登记时间
		/// </summary>
		public string k_endtime
		{
			set{ _k_endtime=value;}
			get{return _k_endtime;}
		}
		/// <summary>
		/// 登记人ID
		/// </summary>
		public int? k_user
		{
			set{ _k_user=value;}
			get{return _k_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? k_ifsb
		{
			set{ _k_ifsb=value;}
			get{return _k_ifsb;}
		}
		#endregion Model

	}
}

