using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_MingXing 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_MingXing
	{
		public Tunnel_MingXing()
		{}
		#region Model
		private int _m_id;
		private int? _m_uid;
		private string _m_img;
		private string _m_content;
		private int? _m_year;
		private int? _m_moon;
        private string m_title;

        public string Title
        {
            get { return m_title; }
            set { m_title = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? m_uid
		{
			set{ _m_uid=value;}
			get{return _m_uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_img
		{
			set{ _m_img=value;}
			get{return _m_img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_content
		{
			set{ _m_content=value;}
			get{return _m_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? m_year
		{
			set{ _m_year=value;}
			get{return _m_year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? m_moon
		{
			set{ _m_moon=value;}
			get{return _m_moon;}
		}
		#endregion Model

	}
}

