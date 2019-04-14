using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_PageMessage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_PageMessage
	{
		public Tunnel_PageMessage()
		{}
		#region Model
		private int _pic_id;
		private string _pic_aspxname;
		private string _pic_titlename;
		private string _pic_topicname;
		private string _pic_topimgurl;
		private string _pic_bgcolor;
		/// <summary>
		/// 
		/// </summary>
		public int pic_ID
		{
			set{ _pic_id=value;}
			get{return _pic_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_AspxName
		{
			set{ _pic_aspxname=value;}
			get{return _pic_aspxname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_TitleName
		{
			set{ _pic_titlename=value;}
			get{return _pic_titlename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_TopicName
		{
			set{ _pic_topicname=value;}
			get{return _pic_topicname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_TopImgURL
		{
			set{ _pic_topimgurl=value;}
			get{return _pic_topimgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_BgColor
		{
			set{ _pic_bgcolor=value;}
			get{return _pic_bgcolor;}
		}
		#endregion Model

	}
}

