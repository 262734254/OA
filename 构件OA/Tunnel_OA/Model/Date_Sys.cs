using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Date_Sys ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Date_Sys
	{
		public Date_Sys()
		{}
		#region Model
		private int _d_id;
		private int _d_userid;
		private DateTime? _d_beginpoll_date;
		private DateTime? _d_endpoll_date;
		private DateTime? _d_proce_date;
		/// <summary>
		/// 
		/// </summary>
		public int d_Id
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int d_userId
		{
			set{ _d_userid=value;}
			get{return _d_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? d_beginPoll_Date
		{
			set{ _d_beginpoll_date=value;}
			get{return _d_beginpoll_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? d_endPoll_Date
		{
			set{ _d_endpoll_date=value;}
			get{return _d_endpoll_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? d_proce_Date
		{
			set{ _d_proce_date=value;}
			get{return _d_proce_date;}
		}
		#endregion Model

	}
}

