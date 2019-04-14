using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_Chat 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_Chat
	{
		public Tunnel_Chat()
		{}
		#region Model
		private long _chat_id;
		private long _chat_userid;
		private string _chat_username;
		private string _chat_content;
		private DateTime? _chat_date;
		private int _chat_state;
		private long _chat_touserid;
		/// <summary>
		/// 
		/// </summary>
		public long Chat_ID
		{
			set{ _chat_id=value;}
			get{return _chat_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Chat_UserID
		{
			set{ _chat_userid=value;}
			get{return _chat_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Chat_UserName
		{
			set{ _chat_username=value;}
			get{return _chat_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Chat_Content
		{
			set{ _chat_content=value;}
			get{return _chat_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Chat_Date
		{
			set{ _chat_date=value;}
			get{return _chat_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Chat_State
		{
			set{ _chat_state=value;}
			get{return _chat_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Chat_ToUserID
		{
			set{ _chat_touserid=value;}
			get{return _chat_touserid;}
		}
		#endregion Model

	}
}

