using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_formtype 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_formtype
	{
		public Tunnel_formtype()
		{}
		#region Model
		private int _form_id;
		private string _form_name;
		private int _item_max;
		/// <summary>
		/// 
		/// </summary>
		public int Form_id
		{
			set{ _form_id=value;}
			get{return _form_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Form_name
		{
			set{ _form_name=value;}
			get{return _form_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Item_max
		{
			set{ _item_max=value;}
			get{return _item_max;}
		}
		#endregion Model

	}
}

