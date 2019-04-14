using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_bum部门表 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_bum
	{
		public Tunnel_bum()
		{}
		#region Model
		private long _b_id;
		private string _b_name;
		private int _b_hid;
		private string _b_depict;
        private int _b_projectid;

        /// <summary>
        /// 是否为项部，是就存上对存项经部ID
        /// </summary>
        public int b_projectid
        {
            get { return _b_projectid; }
            set { _b_projectid = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		public long b_id
		{
			set{ _b_id=value;}
			get{return _b_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string b_name
		{
			set{ _b_name=value;}
			get{return _b_name;}
		}
		/// <summary>
		/// 上级部门ID
		/// </summary>
		public int b_hid
		{
			set{ _b_hid=value;}
			get{return _b_hid;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string b_depict
		{
			set{ _b_depict=value;}
			get{return _b_depict;}
		}
		#endregion Model

	}
}

