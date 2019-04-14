using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_flow流程表 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_flow
	{
		public Tunnel_flow()
		{}
		#region Model
		private long _f_id;
		private string _f_name;
		private int _f_bum;
		private int _f_form;
		private int _f_isfile;
		private string _f_depict;
		private int _f_sort;
        private int _f_state;
        private int _f_stype;


        /// <summary>
        /// 是否需要审核
        /// </summary>
        public int f_state
        {
            set { _f_state = value; }
            get { return _f_state; }
        }
        /// <summary>
        /// 审核人类型
        /// </summary>
        public int f_stype
        {
            set { _f_stype = value; }
            get { return _f_stype; }
        }
		/// <summary>
		/// 
		/// </summary>
        public long f_id
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		/// <summary>
		/// 流程名称
		/// </summary>
		public string f_name
		{
			set{ _f_name=value;}
			get{return _f_name;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public int f_bum
		{
			set{ _f_bum=value;}
			get{return _f_bum;}
		}
		/// <summary>
		/// 表单ID
		/// </summary>
		public int f_form
		{
			set{ _f_form=value;}
			get{return _f_form;}
		}
		/// <summary>
		/// 是否允许附件
		/// </summary>
		public int f_isfile
		{
			set{ _f_isfile=value;}
			get{return _f_isfile;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string f_depict
		{
			set{ _f_depict=value;}
			get{return _f_depict;}
		}
		/// <summary>
		/// 分类
		/// </summary>
		public int f_sort
		{
			set{ _f_sort=value;}
			get{return _f_sort;}
		}
		#endregion Model

	}
}

