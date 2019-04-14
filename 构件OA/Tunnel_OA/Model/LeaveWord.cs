using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类LeaveWord 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class LeaveWord
	{
		public LeaveWord()
		{}
		#region Model
		private int _lw_id;
		private DateTime _lw_setdate;
		private string _lw_content;
		private int _lw_userid;
		private int _lw_vateid;
		/// <summary>
		/// 
		/// </summary>
		public int lw_Id
		{
			set{ _lw_id=value;}
			get{return _lw_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lw_SetDate
		{
			set{ _lw_setdate=value;}
			get{return _lw_setdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lw_Content
		{
			set{ _lw_content=value;}
			get{return _lw_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int lw_UserId
		{
			set{ _lw_userid=value;}
			get{return _lw_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int lw_VateId
		{
			set{ _lw_vateid=value;}
			get{return _lw_vateid;}
		}
		#endregion Model

	}
}

