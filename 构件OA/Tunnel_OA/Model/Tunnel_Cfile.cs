using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_Cfile 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_Cfile
	{
		public Tunnel_Cfile()
		{}
		#region Model
		private long _f_id;
		private string _f_title;
		private int _f_type;
		private string _f_content;
		private string _f_file;
		private long _f_first;
		private string _f_other;
        private long _f_user;
		private DateTime _f_date;
		/// <summary>
		/// 
		/// </summary>
		public long f_id
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}

        /// <summary>
        /// 
        /// </summary>
        public long f_user
        {
            set { _f_user = value; }
            get { return _f_user; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string f_title
		{
			set{ _f_title=value;}
			get{return _f_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int f_type
		{
			set{ _f_type=value;}
			get{return _f_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string f_content
		{
			set{ _f_content=value;}
			get{return _f_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string f_file
		{
			set{ _f_file=value;}
			get{return _f_file;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long f_first
		{
			set{ _f_first=value;}
			get{return _f_first;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string f_other
		{
			set{ _f_other=value;}
			get{return _f_other;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime f_date
		{
			set{ _f_date=value;}
			get{return _f_date;}
		}
		#endregion Model

	}
}

