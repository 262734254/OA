using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_flowclass流程分类表 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_flowclass
	{
		public Tunnel_flowclass()
		{}
		#region Model
		private long _fc_id;
		private string _fc_name;
        private string _fc_desin;

        /// <summary>
        /// 分类备注
        /// </summary>
        public string Fc_desin
        {
            get { return _fc_desin; }
            set { _fc_desin = value; }
        }
		/// <summary>
        /// 分类ID
		/// </summary>
		public long fc_id
		{
			set{ _fc_id=value;}
			get{return _fc_id;}
		}
		/// <summary>
		/// 分类名称
		/// </summary>
		public string fc_name
		{
			set{ _fc_name=value;}
			get{return _fc_name;}
		}
		#endregion Model

	}
}

