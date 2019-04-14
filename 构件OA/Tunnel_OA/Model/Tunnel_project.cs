using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_project工程表 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_project
	{
		public Tunnel_project()
		{}
		#region Model
		private long _p_id;
		private string _p_name;
		private string _p_yname;
		private string _p_jname;
		private string _p_xfile;
		private string _p_zfile;
		private int _p_user;
        private string p_ip;
		/// <summary>
		/// 
		/// </summary>
		public long p_id
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 工程名称
		/// </summary>
		public string p_name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// 业主名称
		/// </summary>
		public string p_yname
		{
			set{ _p_yname=value;}
			get{return _p_yname;}
		}
		/// <summary>
		/// 监理方
		/// </summary>
		public string p_jname
		{
			set{ _p_jname=value;}
			get{return _p_jname;}
		}
		/// <summary>
		/// 项目概况
		/// </summary>
		public string p_xfile
		{
			set{ _p_xfile=value;}
			get{return _p_xfile;}
		}
		/// <summary>
		/// 组织结构
		/// </summary>
		public string p_zfile
		{
			set{ _p_zfile=value;}
			get{return _p_zfile;}
		}
		/// <summary>
		/// 发布人ID
		/// </summary>
		public int p_user
		{
			set{ _p_user=value;}
			get{return _p_user;}
		}

        /// <summary>
        /// 用户Ip
        /// </summary>
        public string p_Ip 
        {
            set { p_ip = value; }
            get { return p_ip; }
        }
		#endregion Model

	}
}

