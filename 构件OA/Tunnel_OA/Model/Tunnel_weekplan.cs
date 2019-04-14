using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_weekplan ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_weekplan
	{
		public Tunnel_weekplan()
		{}
		#region Model
		private long _w_id;
		private string _w_title;
		private string _w_content;
		private string _w_address;
		private string _w_time;
		private string _w_daytime;
		private DateTime? _w_adddate;
		private string _w_weekid;
		private string _w_date;
		/// <summary>
		/// 
		/// </summary>
		public long w_id
		{
			set{ _w_id=value;}
			get{return _w_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string w_title
		{
			set{ _w_title=value;}
			get{return _w_title;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string w_content
		{
			set{ _w_content=value;}
			get{return _w_content;}
		}
		/// <summary>
		/// �ص�
		/// </summary>
		public string w_address
		{
			set{ _w_address=value;}
			get{return _w_address;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string w_time
		{
			set{ _w_time=value;}
			get{return _w_time;}
		}
		/// <summary>
		/// ����?����
		/// </summary>
		public string w_daytime
		{
			set{ _w_daytime=value;}
			get{return _w_daytime;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? w_adddate
		{
			set{ _w_adddate=value;}
			get{return _w_adddate;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string w_weekID
		{
			set{ _w_weekid=value;}
			get{return _w_weekid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string w_date
		{
			set{ _w_date=value;}
			get{return _w_date;}
		}
		#endregion Model

	}
}

