using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_exam 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_exam
	{
		public Tunnel_exam()
		{}
		#region Model
		private long _e_id;
		private int _e_gid;
		private int _e_bid;
		private DateTime _e_time;
		private int _e_user;
		private DateTime _e_endtime;
        private string _e_nextbuser;
		private long _e_nextbid;
		/// <summary>
		/// 
		/// </summary>
		public long e_id
		{
			set{ _e_id=value;}
			get{return _e_id;}
		}
        /// <summary>
        /// 自定义流程执行人
        /// </summary>
        public string e_nextbuser
        {
            set { _e_nextbuser = value; }
            get { return _e_nextbuser; }
        }
		/// <summary>
		/// 公文ID
		/// </summary>
		public int e_gid
		{
			set{ _e_gid=value;}
			get{return _e_gid;}
		}
		/// <summary>
		/// 步骤ID
		/// </summary>
		public int e_bid
		{
			set{ _e_bid=value;}
			get{return _e_bid;}
		}
		/// <summary>
		/// 执行时间
		/// </summary>
		public DateTime e_time
		{
			set{ _e_time=value;}
			get{return _e_time;}
		}
		/// <summary>
		/// 步骤执行人ID
		/// </summary>
		public int e_user
		{
			set{ _e_user=value;}
			get{return _e_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime e_endtime
		{
			set{ _e_endtime=value;}
			get{return _e_endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long e_nextbid
		{
			set{ _e_nextbid=value;}
			get{return _e_nextbid;}
		}
		#endregion Model

	}
}

