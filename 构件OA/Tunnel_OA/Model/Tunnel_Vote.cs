using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_Vote 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_Vote
	{
		public Tunnel_Vote()
		{}
		#region Model
		private int _vote_id;
		private int? _vote_userid;
		private string _vote_usergroup;
		private string _vote_bumgroup;
		private string _vote_jsgroup;
		private string _vote_title;
		private string _vote_mark;
		private int? _vote_type;
		private DateTime? _vote_startdate;
		private DateTime? _vote_enddate;
		private int? _vote_seetype;
		private int? _vote_state;
		private int? _vote_max;
		private int? _vote_top;
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
		public int? vote_userId
		{
			set{ _vote_userid=value;}
			get{return _vote_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vote_userGroup
		{
			set{ _vote_usergroup=value;}
			get{return _vote_usergroup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vote_bumGroup
		{
			set{ _vote_bumgroup=value;}
			get{return _vote_bumgroup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vote_jsGroup
		{
			set{ _vote_jsgroup=value;}
			get{return _vote_jsgroup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vote_Title
		{
			set{ _vote_title=value;}
			get{return _vote_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vote_mark
		{
			set{ _vote_mark=value;}
			get{return _vote_mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vote_Type
		{
			set{ _vote_type=value;}
			get{return _vote_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? vote_startDate
		{
			set{ _vote_startdate=value;}
			get{return _vote_startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? vote_endDate
		{
			set{ _vote_enddate=value;}
			get{return _vote_enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vote_seeType
		{
			set{ _vote_seetype=value;}
			get{return _vote_seetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vote_state
		{
			set{ _vote_state=value;}
			get{return _vote_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vote_max
		{
			set{ _vote_max=value;}
			get{return _vote_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vote_top
		{
			set{ _vote_top=value;}
			get{return _vote_top;}
		}
		#endregion Model

	}
}

