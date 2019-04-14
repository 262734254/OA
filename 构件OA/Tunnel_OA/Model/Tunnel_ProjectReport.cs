using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_ProjectReport ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_ProjectReport
	{
		public Tunnel_ProjectReport()
		{}
		#region Model
		private int _report_id;
		private string _report_name;
		private int? _report_class;
		private int? _report_sort;
		private int? _report_state;
		private int? _report_shen;
		private int? _report_order;
		private int? _report_userid;
		/// <summary>
		/// 
		/// </summary>
		public int Report_Id
		{
			set{ _report_id=value;}
			get{return _report_id;}
		}
		/// <summary>
		/// ģ������
		/// </summary>
		public string Report_Name
		{
			set{ _report_name=value;}
			get{return _report_name;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int? Report_Class
		{
			set{ _report_class=value;}
			get{return _report_class;}
		}
		/// <summary>
		/// ���
		/// </summary>
		public int? Report_Sort
		{
			set{ _report_sort=value;}
			get{return _report_sort;}
		}
		/// <summary>
		/// ״̬0������ 1��ͣ��
		/// </summary>
		public int? Report_State
		{
			set{ _report_state=value;}
			get{return _report_state;}
		}
		/// <summary>
		/// �Ƿ�Ҫ���0������Ҫ 1����Ҫ
		/// </summary>
		public int? Report_Shen
		{
			set{ _report_shen=value;}
			get{return _report_shen;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int? Report_Order
		{
			set{ _report_order=value;}
			get{return _report_order;}
		}
		/// <summary>
		/// �û�ID
		/// </summary>
		public int? Report_UserID
		{
			set{ _report_userid=value;}
			get{return _report_userid;}
		}
		#endregion Model

	}
}

