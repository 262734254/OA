using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Model
{
	/// <summary>
	/// ¿‡UserRole°£
	/// </summary>
	public class UserRole
	{
		public UserRole()
		{}
		#region Model
		private int id;
        private UserInfo userid = new UserInfo();

        public UserInfo Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        private Role roleid = new Role();

        public Role Roleid
        {
            get { return roleid; }
            set { roleid = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ id=value;}
			get{return id;}
		}
		
		#endregion Model


	
	}
}

