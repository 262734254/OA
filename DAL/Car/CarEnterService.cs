using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using IDAL.Car;
using DAL.Power;

namespace DAL.Car
{
   public class CarEnterService:ICarEnterService
    {
        DepartmentService dept = new DepartmentService();
        CarTypeService carType = new CarTypeService();

        #region ICarEnterService 成员

        public IList<Car_Enter> GetAllEnter()
        {
            throw new NotImplementedException();
        }

        public int AddEnter(Car_Enter dav)
        {
            SqlParameter[] para = new SqlParameter[] 
           { 
           
                new SqlParameter("@EnterData",dav.EnterData),
               new SqlParameter("@Dept",dav.Dept.Id),
               new SqlParameter("@Man",dav.Man),
               new SqlParameter("@Typeid",dav.Typeid.TypeId),
               new SqlParameter("@Mark",dav.Mark),
               new SqlParameter("@Driver",dav.Dirver),
               new SqlParameter("@Place",dav.Place),
               new SqlParameter("@Couse",dav.Course),
               new SqlParameter("@ttion",dav.Ttion),
               new SqlParameter("@Remark",dav.Remark),
               new SqlParameter("@ReturnData",dav.ReturnData),
               new SqlParameter("@ShiJiReturnDatd",dav.ShiJiReturnDatd),
               new SqlParameter("@HuiCheLiCheng",dav.HuiCheLiCheng)
			  
           };
            int num = DBHelper.ExecuteNonQueryProc("usp_CarRetuanDate", para);
            return num;
        }

        #endregion

        #region ICarEnterService 成员


        public List<Car_Enter> SelectDavnoteDark(string Mark, string typeid, string dept)
        {
            SqlParameter[] para = new SqlParameter[] 
           { 
               new SqlParameter("@CarMark",Mark),
                new SqlParameter("@Typeid",typeid),
                 new SqlParameter("@Dept",dept)
           };
            SqlDataReader reader = (SqlDataReader)DBHelper.ExecuteReaderProc("usp_SelectCarsOutCarJiLu", para);
            List<Car_Enter> list = GetDavnote(reader);
            return list;
        }

        #endregion

        #region ICarEnterService 成员


        public List<Car_Enter> GetDavnote(SqlDataReader reader)
        {
            List<Car_Enter> list = new List<Car_Enter>();

            while (reader.Read())
            {
                Car_Enter dav = new Car_Enter();
                dav.Course = Decimal.Parse(reader["Course"].ToString());
                dav.EnterData = DateTime.Parse(reader["EnterData"].ToString());
                dav.Dept = dept.GetAllDepartementById((int)reader["Dept"]);
                dav.Dirver = reader["Driver"].ToString();
                dav.Man = reader["Man"].ToString();
                dav.Mark = reader["Mark"].ToString();
                dav.Place = reader["Place"].ToString();
                dav.ReturnData = DateTime.Parse(reader["ReturnData"].ToString());
                dav.Remark = reader["Remark"].ToString();
                dav.Ttion = reader["Ttion"].ToString();
                dav.Typeid = carType.GetAllCarsById((int)reader["Typeid"]);
                dav.HuiCheLiCheng = Decimal.Parse(reader["HuiCheLiCheng"].ToString()); ;
                dav.ShiJiReturnDatd = DateTime.Parse(reader["ShiJiReturnDatd"].ToString());
                dav.EnterId = Convert.ToInt32(reader["EnterId"].ToString());
                list.Add(dav);
            }
            return list;
        }

        #endregion

        #region ICarEnterService 成员

       /// <summary>
       /// 删除出车记录
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        public int DeleteDavnote(string Id)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@CarIds",Id)

          };
            int num = DBHelper.ExecuteNonQueryProc("usp_CarsDeleteEnter", para);
            return num;
        }

        #endregion
    }
}
