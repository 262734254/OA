using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类VoteLog 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class VoteLog
	{
		public VoteLog()
		{}
		#region Model
		private int _vg_id;
		private DateTime _vg_setdate;
		private int _vg_userid;
		private int _vg_voteid;
		/// <summary>
		/// 
		/// </summary>
		public int vg_id
		{
			set{ _vg_id=value;}
			get{return _vg_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime vg_setDate
		{
			set{ _vg_setdate=value;}
			get{return _vg_setdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int vg_userId
		{
			set{ _vg_userid=value;}
			get{return _vg_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int vg_voteId
		{
			set{ _vg_voteid=value;}
			get{return _vg_voteid;}
		}
		#endregion Model

	}
}

