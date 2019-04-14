using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_CView 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_CView
	{
		public Tunnel_CView()
		{}
		#region Model
		private long _c_id;
		private long _c_fid;
		private long _c_uid;
		private int? _c_read;
		private DateTime? _c_readdate;
		private string _c_content;
		/// <summary>
		/// 
		/// </summary>
		public long c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long c_fid
		{
			set{ _c_fid=value;}
			get{return _c_fid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long c_uid
		{
			set{ _c_uid=value;}
			get{return _c_uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_read
		{
			set{ _c_read=value;}
			get{return _c_read;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? c_readdate
		{
			set{ _c_readdate=value;}
			get{return _c_readdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_content
		{
			set{ _c_content=value;}
			get{return _c_content;}
		}
		#endregion Model

	}
}

