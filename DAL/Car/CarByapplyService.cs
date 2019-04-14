using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using IDAL.Car;
using DAL.Power;
namespace DAL.Car
{
   
   public class CarByapplyService:ICarByapplyService
    {
       DepartmentService dept = new DepartmentService();
        CarTypeService carType = new CarTypeService();
       
        #region ICarByapplyService 成员

        public IList<Car_Byapply> GetAllCarByapply()
        {
            string cars = "up_CarSelectByApply";
            DataTable tb = DBHelper.GetDataTableProc(cars, null);
            IList<Car_Byapply> list = new List<Car_Byapply>();
            foreach (DataRow r in tb.Rows)
            {
                Car_Byapply Car = new Car_Byapply();
                Car.ByapplyId = (int)r["ByapplyId"];
                Car.ByCause = (string)r["ByCause"];
                Car.ByData = (DateTime)r["ByData"];
                Car.ByDept = dept.GetAllDepartementById ((int)r["ByDept"]);
                Car.ByMan = (string)r["ByMan"];
                Car.ByDttion = (string)r["ByDttion"];
                Car.ByReData = (DateTime)r["ByReData"];
                Car.ByTypeid = carType.GetAllCarsById((int)r["ByTypeid"]);
                Car.State = (string)r["State"];
                list.Add(Car);
            }
            return list;
        }

        #endregion

        #region ICarByapplyService 成员
       /// <summary>
       /// 用车申请
       /// </summary>
       /// <param name="byapply"></param>
       /// <returns></returns>
        public int InsertByCar(Car_Byapply byapply)
        {
            SqlParameter[] para = new SqlParameter[] 
           {
            new SqlParameter("@ByData",byapply.ByData),
            new SqlParameter("@ByDept",byapply.ByDept.Id),
            new SqlParameter("@ByMan",byapply.ByMan),
            new SqlParameter("@ByTypeid",byapply.ByTypeid.TypeId),
            new SqlParameter("@ByCause",byapply.ByCause),
            new SqlParameter("@ByDttion",byapply.ByDttion),
            new SqlParameter("@ByreData",byapply.ByReData)
           
           };
            int num = DBHelper.ExecuteNonQueryProc("usp_CarInsetBuyApply", para);
            return num;
        }
       
        #endregion

        #region ICarByapplyService 成员

       /// <summary>
       /// 条件查询
       /// </summary>
       /// <param name="ByMan"></param>
       /// <param name="typeid"></param>
       /// <param name="state"></param>
       /// <returns></returns>
        public List<Car_Byapply> usp_CarSelectByappy(string ByMan, string typeid, string state)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@ByMan",ByMan),
             new SqlParameter("@Typeid",typeid),
             new SqlParameter("@state",state)

          };
            SqlDataReader reader = (SqlDataReader)DBHelper.ExecuteReaderProc("usp_CarSelectByappyName", para);
            List<Car_Byapply> list = GetCars(reader);
            return list;
        }

        #endregion

        #region ICarByapplyService 成员

       /// <summary>
       /// 通用
       /// </summary>
       /// <param name="reader"></param>
       /// <returns></returns>
        public List<Car_Byapply> GetCars(SqlDataReader reader)
        {
            List<Car_Byapply> list = new List<Car_Byapply>();
            while (reader.Read())
            {
                Car_Byapply Car = new Car_Byapply();
                Car.ByapplyId = (int)reader["ByapplyId"];
                Car.ByCause = (string)reader["ByCause"];
                Car.ByData = (DateTime)reader["ByData"];
                Car.ByDept = dept.GetAllDepartementById((int)reader["ByDept"]);
                Car.ByMan = (string)reader["ByMan"];
                Car.ByDttion = (string)reader["ByDttion"];
                Car.ByReData = (DateTime)reader["ByReData"];
                Car.ByTypeid = carType.GetAllCarsById((int)reader["ByTypeid"]);
                Car.State = (string)reader["State"];
                list.Add(Car);
            }
            return list;
        }

        #endregion


        #region ICarByapplyService 成员


        public Car_Byapply GetAllCarsByappyById(int Id)
        {
            string sql = "usp_CarSelcectByapplyById";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@ByapplyId", Id)))
            {
                if (reader.Read())
                {
                    Car_Byapply Car = new Car_Byapply();
                    Car.ByapplyId = (int)reader["ByapplyId"];
                    Car.ByCause = (string)reader["ByCause"];
                    Car.ByData = (DateTime)reader["ByData"];
                    Car.ByDept = dept.GetAllDepartementById((int)reader["ByDept"]);
                    Car.ByMan = (string)reader["ByMan"];
                    Car.ByDttion = (string)reader["ByDttion"];
                    Car.ByReData = (DateTime)reader["ByReData"];
                    Car.ByTypeid = carType.GetAllCarsById((int)reader["ByTypeid"]);
                    Car.State = (string)reader["State"];
                    return Car;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }

        #endregion

        #region ICarByapplyService 成员


      
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
         public int DeleteByapply(string Id)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@CarIds",Id)

          };
            int num = DBHelper.ExecuteNonQueryProc("usp_CardeleteApplyById", para);
            return num;
        }
        

        #endregion

         #region ICarByapplyService 成员

       /// <summary>
       /// 根据ID更新状态
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
         public int UpadteByapplySate(int Id,string state)
         {
             SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@ByapplyId",Id),
             new SqlParameter("@State",state)

          };
             int num = DBHelper.ExecuteNonQueryProc("usp_CarUpdateByIdByaapy", para);
             return num;
         }

         #endregion
    }
}
