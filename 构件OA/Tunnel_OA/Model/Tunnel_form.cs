using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_form表单 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_form
	{
		public Tunnel_form()
		{}
		#region Model
		private long _f_id;
		private string _f_name;
		private int _f_bum;
		private int _f_lcid;
		private int _f_user;
		private DateTime _f_date;
		private string _f_content;
		/// <summary>
		/// 
		/// </summary>
		public long f_id
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		/// <summary>
		/// 表单名称
		/// </summary>
		public string f_name
		{
			set{ _f_name=value;}
			get{return _f_name;}
		}
		/// <summary>
		/// 所属部门
		/// </summary>
		public int f_bum
		{
			set{ _f_bum=value;}
			get{return _f_bum;}
		}
		/// <summary>
		/// 流程ID
		/// </summary>
		public int f_lcid
		{
			set{ _f_lcid=value;}
			get{return _f_lcid;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public int f_user
		{
			set{ _f_user=value;}
			get{return _f_user;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime f_date
		{
			set{ _f_date=value;}
			get{return _f_date;}
		}
		/// <summary>
		/// 表单内容
		/// </summary>
		public string f_content
		{
			set{ _f_content=value;}
			get{return _f_content;}
		}
		#endregion Model

	}
}

