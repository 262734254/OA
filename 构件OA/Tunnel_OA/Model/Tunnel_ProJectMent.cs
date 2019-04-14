using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_ProJectMent ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_ProJectMent
	{
		public Tunnel_ProJectMent()
		{}
		#region Model
		private long _pro_id;
		private string _pro_title;
		private string _pro_name;
		private DateTime _pro_startdate;
		private DateTime _pro_enddate;
		private DateTime _pro_mandate;
		private DateTime _pro_manenddate;
		private DateTime _pro_contractdate;
		private DateTime _pro_contractenddate;
		private DateTime _pro_equipmentdate;
		private DateTime _pro_equipmentenddate;
		private DateTime _pro_materialdate;
		private DateTime _pro_materialenddate;
		private DateTime _pro_plandate;
		private DateTime _pro_planenddate;
		private DateTime _pro_securitydate;
		private DateTime _pro_securityenddate;
		private int _pro_status;
		private long _pro_manager;
		/// <summary>
		/// 
		/// </summary>
		public long Pro_Id
		{
			set{ _pro_id=value;}
			get{return _pro_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pro_Title
		{
			set{ _pro_title=value;}
			get{return _pro_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pro_Name
		{
			set{ _pro_name=value;}
			get{return _pro_name;}
		}
		/// <summary>
		/// ��Ŀ����ʱ��
		/// </summary>
		public DateTime Pro_StartDate
		{
			set{ _pro_startdate=value;}
			get{return _pro_startdate;}
		}
		/// <summary>
		/// ��Ŀ����ʱ��
		/// </summary>
		public DateTime Pro_EndDate
		{
			set{ _pro_enddate=value;}
			get{return _pro_enddate;}
		}
		/// <summary>
		/// ��Ա����ƻ��ύʱ��
		/// </summary>
		public DateTime Pro_ManDate
		{
			set{ _pro_mandate=value;}
			get{return _pro_mandate;}
		}
		/// <summary>
		/// ��Ա����ƻ��ύ����ʱ��
		/// </summary>
		public DateTime Pro_ManEndDate
		{
			set{ _pro_manenddate=value;}
			get{return _pro_manenddate;}
		}
		/// <summary>
		/// ��ͬǩ���ƻ��ύʱ��
		/// </summary>
		public DateTime Pro_ContractDate
		{
			set{ _pro_contractdate=value;}
			get{return _pro_contractdate;}
		}
		/// <summary>
		/// ��ͬǩ���ƻ��ύ����ʱ��
		/// </summary>
		public DateTime Pro_ContractEndDate
		{
			set{ _pro_contractenddate=value;}
			get{return _pro_contractenddate;}
		}
		/// <summary>
		/// �豸����ƻ��ύʱ��
		/// </summary>
		public DateTime Pro_EquipmentDate
		{
			set{ _pro_equipmentdate=value;}
			get{return _pro_equipmentdate;}
		}
		/// <summary>
		/// �豸����ƻ�����ʱ��
		/// </summary>
		public DateTime Pro_EquipmentEndDate
		{
			set{ _pro_equipmentenddate=value;}
			get{return _pro_equipmentenddate;}
		}
		/// <summary>
		/// ���Ͻ����ƻ��ύʱ��
		/// </summary>
		public DateTime Pro_MaterialDate
		{
			set{ _pro_materialdate=value;}
			get{return _pro_materialdate;}
		}
		/// <summary>
		/// ���Ͻ����ƻ�����ʱ��
		/// </summary>
		public DateTime Pro_MaterialEndDate
		{
			set{ _pro_materialenddate=value;}
			get{return _pro_materialenddate;}
		}
		/// <summary>
		/// ʩ���������Ƽƻ��ύʱ��
		/// </summary>
		public DateTime Pro_PlanDate
		{
			set{ _pro_plandate=value;}
			get{return _pro_plandate;}
		}
		/// <summary>
		/// ʩ���������Ƽƻ�����ʱ��
		/// </summary>
		public DateTime Pro_PlanEndDate
		{
			set{ _pro_planenddate=value;}
			get{return _pro_planenddate;}
		}
		/// <summary>
		/// ��ȫ�걨�ƻ��ύʱ��
		/// </summary>
		public DateTime Pro_SecurityDate
		{
			set{ _pro_securitydate=value;}
			get{return _pro_securitydate;}
		}
		/// <summary>
		/// ��ȫ�걨�ƻ�����ʱ��
		/// </summary>
		public DateTime Pro_SecurityEndDate
		{
			set{ _pro_securityenddate=value;}
			get{return _pro_securityenddate;}
		}
		/// <summary>
		/// ��Ŀ״̬
		/// </summary>
		public int Pro_Status
		{
			set{ _pro_status=value;}
			get{return _pro_status;}
		}
		/// <summary>
		/// ��Ŀ����
		/// </summary>
		public long Pro_Manager
		{
			set{ _pro_manager=value;}
			get{return _pro_manager;}
		}
		#endregion Model

	}
}

