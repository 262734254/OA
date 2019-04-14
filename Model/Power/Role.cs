using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Model
{
	/// <summary>
	/// ¿‡Role°£
	/// </summary>
	public class Role
	{
		public Role()
		{}
		#region Model
		private int roleid;
		private string rolename;
		private string description;
        private Department department=new Department();

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int roleId
		{
			set{ roleid=value;}
			get{return roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ rolename=value;}
			get{return rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ description=value;}
			get{return description;}
		}
		#endregion Model


		
	}
}

