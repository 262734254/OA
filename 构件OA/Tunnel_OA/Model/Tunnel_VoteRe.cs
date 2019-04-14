using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_VoteRe 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_VoteRe
	{
		public Tunnel_VoteRe()
		{}
		#region Model
		private int _vote_id;
		private string _vote_message;
		private DateTime? _vate_date;
		private int? _vate_userid;
		private int? _vate_voteid;
		/// <summary>
		/// 
		/// </summary>
		public int vote_Id
		{
			set{ _vote_id=value;}
			get{return _vote_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vote_Message
		{
			set{ _vote_message=value;}
			get{return _vote_message;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? vate_Date
		{
			set{ _vate_date=value;}
			get{return _vate_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vate_userId
		{
			set{ _vate_userid=value;}
			get{return _vate_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vate_voteId
		{
			set{ _vate_voteid=value;}
			get{return _vate_voteid;}
		}
		#endregion Model

	}
}

