using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Model;
using IDAL.Power;

namespace DAL.Power
{
    public class DepartmentService:IDepartmentService
    {

        #region IDepartmentService 成员

        public IList<Department> GetAllDepartment()
        {
            string proName = "usp_selectAllDepartment";
            DataTable tb = DBHelper.GetDataTableProc(proName, null);
            IList<Department> list = new List<Department>();

            foreach (DataRow r in tb.Rows)
            {
                Department d = new Department();
                d.Id = (int)r["DID"];
              
                d.Departmentname = (string)r["departmentName"];
                d.Departmentmoney = Convert.ToDecimal(r["Departmentmoney"]);

                list.Add(d);
            }
            return list;
        }

      public  Department GetAllDepartementById(int id)
        {
            string proName = "usp_selectDepartmentoById";

            Department d = null;
            using (SqlDataReader r = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@DID", id)))
            {
                if (r.Read())
                {
                    d = new Department();
                    d.Id = (int)r["DID"];
                    d.Departmentname = (string)r["departmentName"];
                    d.Departmentmoney = Convert.ToDecimal(r["Departmentmoney"]);

                }

            }
            return d;
        }

        #endregion
    }
}
