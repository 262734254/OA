using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Vote_Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Vote_Info
	{
		public Vote_Info()
		{}
		#region Model
		private int _v_id;
		private string _v_title;
		private int _v_count;
		private string _v_img;
		private string _v_author;
		private string _v_remark;
		/// <summary>
		/// 
		/// </summary>
		public int v_id
		{
			set{ _v_id=value;}
			get{return _v_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v_title
		{
			set{ _v_title=value;}
			get{return _v_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int v_count
		{
			set{ _v_count=value;}
			get{return _v_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v_Img
		{
			set{ _v_img=value;}
			get{return _v_img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v_author
		{
			set{ _v_author=value;}
			get{return _v_author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v_remark
		{
			set{ _v_remark=value;}
			get{return _v_remark;}
		}
		#endregion Model

	}
}

