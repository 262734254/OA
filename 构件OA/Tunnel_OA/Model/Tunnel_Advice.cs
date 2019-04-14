using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_Advice会签建议表。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_Advice
	{
		public Tunnel_Advice()
		{}
		#region Model
		private long _a_id;
		private int _a_user;
		private int _a_bid;
        private int _a_gid;
		private string _a_content;
		private DateTime _a_time;
		/// <summary>
		/// 
		/// </summary>
		public long a_id
		{
			set{ _a_id=value;}
			get{return _a_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int a_user
		{
			set{ _a_user=value;}
			get{return _a_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int a_bid
		{
			set{ _a_bid=value;}
			get{return _a_bid;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int a_gid
        {
            set { _a_gid = value; }
            get { return _a_gid; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string a_content
		{
			set{ _a_content=value;}
			get{return _a_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime a_time
		{
			set{ _a_time=value;}
			get{return _a_time;}
		}
		#endregion Model

	}
}

