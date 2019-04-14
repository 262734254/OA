using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Model
{
	/// <summary>
	/// ¿‡RolePower°£
	/// </summary>
	public class RolePower
	{
		public RolePower()
		{}
		#region Model
		private int id;
		private int roleid;
		private int powerid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ id=value;}
			get{return id;}
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
		public int PowerId
		{
			set{ powerid=value;}
			get{return powerid;}
		}
		#endregion Model


		
	}
}

