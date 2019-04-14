using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Vote_Config 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Vote_Config
	{
		public Vote_Config()
		{}
		#region Model
		private int _c_id;
		private string _c_name;
		private int _c_type;
		/// <summary>
		/// 
		/// </summary>
		public int c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_name
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int c_type
		{
			set{ _c_type=value;}
			get{return _c_type;}
		}
		#endregion Model

	}
}

