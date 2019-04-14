using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_ProjectReport 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_ProjectReport
	{
		public Tunnel_ProjectReport()
		{}
		#region Model
		private int _report_id;
		private string _report_name;
		private int? _report_class;
		private int? _report_sort;
		private int? _report_state;
		private int? _report_shen;
		private int? _report_order;
		private int? _report_userid;
		/// <summary>
		/// 
		/// </summary>
		public int Report_Id
		{
			set{ _report_id=value;}
			get{return _report_id;}
		}
		/// <summary>
		/// 模版名称
		/// </summary>
		public string Report_Name
		{
			set{ _report_name=value;}
			get{return _report_name;}
		}
		/// <summary>
		/// 分类
		/// </summary>
		public int? Report_Class
		{
			set{ _report_class=value;}
			get{return _report_class;}
		}
		/// <summary>
		/// 类别
		/// </summary>
		public int? Report_Sort
		{
			set{ _report_sort=value;}
			get{return _report_sort;}
		}
		/// <summary>
		/// 状态0、启用 1、停用
		/// </summary>
		public int? Report_State
		{
			set{ _report_state=value;}
			get{return _report_state;}
		}
		/// <summary>
		/// 是否要审核0、不需要 1、需要
		/// </summary>
		public int? Report_Shen
		{
			set{ _report_shen=value;}
			get{return _report_shen;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? Report_Order
		{
			set{ _report_order=value;}
			get{return _report_order;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? Report_UserID
		{
			set{ _report_userid=value;}
			get{return _report_userid;}
		}
		#endregion Model

	}
}

