using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_yingshe 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_yingshe
	{
		public Tunnel_yingshe()
		{
            y_qxlist = "";
        }
		#region Model
		private int _y_id;
		private int _y_jsid;
		private string _y_qxlist;
		/// <summary>
		/// 
		/// </summary>
		public int y_id
		{
			set{ _y_id=value;}
			get{return _y_id;}
		}
		/// <summary>
		/// 角色id
		/// </summary>
		public int y_jsid
		{
			set{ _y_jsid=value;}
			get{return _y_jsid;}
		}
		/// <summary>
		/// 权限列表
		/// </summary>
		public string y_qxlist
		{
			set{ _y_qxlist=value;}
			get{return _y_qxlist;}
		}
		#endregion Model

	}
}

