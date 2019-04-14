using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_quanxian 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_quanxian
	{
		public Tunnel_quanxian()
		{}
		#region Model
		private int _q_id;
		private string _q_name;
		private string _q_mark;
        private int _q_rId;

        public int q_rId
        {
            get { return _q_rId; }
            set { _q_rId = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int q_id
		{
			set{ _q_id=value;}
			get{return _q_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string q_name
		{
			set{ _q_name=value;}
			get{return _q_name;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string q_mark
		{
			set{ _q_mark=value;}
			get{return _q_mark;}
		}
		#endregion Model

	}
}

