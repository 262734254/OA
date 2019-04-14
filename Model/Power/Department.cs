using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Model
{
	/// <summary>
	/// Ààdepartment¡£
	/// </summary>
    /// 
    [Serializable]
    public class Department
    {
        public Department()
        { }
        #region Model
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        private decimal? departmentmoney;

        public decimal? Departmentmoney
        {
            get { return departmentmoney; }
            set { departmentmoney = value; }
        }

        private string departmentname;

        public string Departmentname
        {
            get { return departmentname; }
            set { departmentname = value; }
        }
        
        
        /// <summary>
        /// 
        /// </summary>
       
        #endregion Model


		
	}
}

