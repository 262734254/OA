using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_ProJectMent 。(属性说明自动提取数据库字段的描述信息)
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
		/// 项目启动时间
		/// </summary>
		public DateTime Pro_StartDate
		{
			set{ _pro_startdate=value;}
			get{return _pro_startdate;}
		}
		/// <summary>
		/// 项目结束时间
		/// </summary>
		public DateTime Pro_EndDate
		{
			set{ _pro_enddate=value;}
			get{return _pro_enddate;}
		}
		/// <summary>
		/// 人员需求计划提交时间
		/// </summary>
		public DateTime Pro_ManDate
		{
			set{ _pro_mandate=value;}
			get{return _pro_mandate;}
		}
		/// <summary>
		/// 人员需求计划提交结束时间
		/// </summary>
		public DateTime Pro_ManEndDate
		{
			set{ _pro_manenddate=value;}
			get{return _pro_manenddate;}
		}
		/// <summary>
		/// 合同签订计划提交时间
		/// </summary>
		public DateTime Pro_ContractDate
		{
			set{ _pro_contractdate=value;}
			get{return _pro_contractdate;}
		}
		/// <summary>
		/// 合同签订计划提交结束时间
		/// </summary>
		public DateTime Pro_ContractEndDate
		{
			set{ _pro_contractenddate=value;}
			get{return _pro_contractenddate;}
		}
		/// <summary>
		/// 设备需求计划提交时间
		/// </summary>
		public DateTime Pro_EquipmentDate
		{
			set{ _pro_equipmentdate=value;}
			get{return _pro_equipmentdate;}
		}
		/// <summary>
		/// 设备需求计划结束时间
		/// </summary>
		public DateTime Pro_EquipmentEndDate
		{
			set{ _pro_equipmentenddate=value;}
			get{return _pro_equipmentenddate;}
		}
		/// <summary>
		/// 材料进场计划提交时间
		/// </summary>
		public DateTime Pro_MaterialDate
		{
			set{ _pro_materialdate=value;}
			get{return _pro_materialdate;}
		}
		/// <summary>
		/// 材料进场计划结束时间
		/// </summary>
		public DateTime Pro_MaterialEndDate
		{
			set{ _pro_materialenddate=value;}
			get{return _pro_materialenddate;}
		}
		/// <summary>
		/// 施工方案编制计划提交时间
		/// </summary>
		public DateTime Pro_PlanDate
		{
			set{ _pro_plandate=value;}
			get{return _pro_plandate;}
		}
		/// <summary>
		/// 施工方案编制计划结束时间
		/// </summary>
		public DateTime Pro_PlanEndDate
		{
			set{ _pro_planenddate=value;}
			get{return _pro_planenddate;}
		}
		/// <summary>
		/// 安全申报计划提交时间
		/// </summary>
		public DateTime Pro_SecurityDate
		{
			set{ _pro_securitydate=value;}
			get{return _pro_securitydate;}
		}
		/// <summary>
		/// 安全申报计划结束时间
		/// </summary>
		public DateTime Pro_SecurityEndDate
		{
			set{ _pro_securityenddate=value;}
			get{return _pro_securityenddate;}
		}
		/// <summary>
		/// 项目状态
		/// </summary>
		public int Pro_Status
		{
			set{ _pro_status=value;}
			get{return _pro_status;}
		}
		/// <summary>
		/// 项目经理
		/// </summary>
		public long Pro_Manager
		{
			set{ _pro_manager=value;}
			get{return _pro_manager;}
		}
		#endregion Model

	}
}

