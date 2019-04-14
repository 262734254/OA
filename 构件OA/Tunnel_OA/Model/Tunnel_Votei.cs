using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_Votei 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_Votei
	{
		public Tunnel_Votei()
		{}
		#region Model
		private int _ivote_id;
		private string _ivote_title;
		private int? _ivote_count;
		private string _ivote_yesuserid;
		private int? _ivote_voteid;
		/// <summary>
		/// 
		/// </summary>
		public int ivote_Id
		{
			set{ _ivote_id=value;}
			get{return _ivote_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ivote_Title
		{
			set{ _ivote_title=value;}
			get{return _ivote_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ivote_Count
		{
			set{ _ivote_count=value;}
			get{return _ivote_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ivote_yesUserId
		{
			set{ _ivote_yesuserid=value;}
			get{return _ivote_yesuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ivote_voteId
		{
			set{ _ivote_voteid=value;}
			get{return _ivote_voteid;}
		}
		#endregion Model

	}
}

