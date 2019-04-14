using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Model
{
	/// <summary>
	/// ¿‡Examine°£
	/// </summary>
	public class Examine
	{
		public Examine()
		{}
		#region Model
		private int eid;
		private int? requisitionid;
		private string requisitiontype;
        private UserInfo examineUID = new UserInfo();

        public UserInfo ExamineUID
        {
            get { return examineUID; }
            set { examineUID = value; }
        }

       

		private string examineidea;
		private DateTime? endtime;
		private string isapproved;
		/// <summary>
		/// 
		/// </summary>
		public int EID
		{
			set{ eid=value;}
			get{return eid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RequisitionID
		{
			set{ requisitionid=value;}
			get{return requisitionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RequisitionType
		{
			set{ requisitiontype=value;}
			get{return requisitiontype;}
		}
		/// <summary>
		/// 
		/// </summary>
		
		/// <summary>
		/// 
		/// </summary>
		public string ExamineIdea
		{
			set{ examineidea=value;}
			get{return examineidea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndTime
		{
			set{ endtime=value;}
			get{return endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsApproved
		{
			set{ isapproved=value;}
			get{return isapproved;}
		}
		#endregion Model


		
	}
}

