using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using IDAL.Car;
namespace DAL.Car
{
   public class ServicesService:IServicesService
    {
       CarTypeService carType = new CarTypeService();
        #region IServicesService 成员
       /// <summary>
       /// 按条件查询维修信息
       /// </summary>
       /// <param name="statime"></param>
       /// <param name="endtime"></param>
       /// <param name="carType"></param>
       /// <param name="s_FactoryName"></param>
       /// <returns></returns>
        public  IList<Services> getAllService(string statime, string endtime, string carType, string s_FactoryName)
        {
            IList<Services> list = new List<Services>();
            string sql = "prc_getAllService";
            SqlParameter[] parms = new SqlParameter[]
           {
                new SqlParameter("@BeginDate",statime),
                new SqlParameter("@EndDate",endtime),
                new SqlParameter("@CarType",carType),
                new SqlParameter("@S_FactoryName", s_FactoryName)
           };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, parms))
            {
                while (reader.Read())
                {
                    Services se = new Services();
                    se.BeginDate = (DateTime)reader["BeginDate"];
                    se.BillPhoto = (string)reader["BillPhoto"];
                    se.CarMark = (string)reader["CarMark"];
                    se.CarType = (string)reader["CarType"];
                    se.EndDate = (DateTime)reader["EndDate"];
                    se.JerquePeople = (string)reader["JerquePeople"];
                    se.S_Branch = (string)reader["S_Branch"];
                    se.S_Cost = Convert.ToDouble(reader["S_Cost"]);
                    se.S_FactoryName = (string)reader["S_FactoryName"];
                    se.S_Id = (int)reader["S_Id"];
                    se.S_People = (string)reader["S_People"];
                    se.S_Result = (string)reader["S_Result"];
                    se.S_Type = (string)reader["S_Type"];
                    se.S_Reason = (string)reader["S_Reason"];
                    se.UseCost = Convert.ToDouble(reader["UseCost"]);
                    list.Add(se);
                }
                reader.Close();
            }
            return list;
        }
       /// <summary>
       /// 查询所有维修厂的名字
       /// </summary>
       /// <returns></returns>
        public IList<Services> getFactoryName()
        {
            IList<Services> list = new List<Services>();
            string sql = "pro_getFactoryName";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, null))
            {
                while (reader.Read())
                {
                    Services se = new Services();
                    se.S_FactoryName = (string)reader["S_FactoryName"];
                    //se.S_Id = (int)reader["S_Id"];
                    list.Add(se);
                }
                reader.Close();
            }
            return list;
        }
       
        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public  int addService(Services se)
        {
            string sql = "pro_AddService";
            SqlParameter[] parms = new SqlParameter[]
            {
            new SqlParameter("BillPhoto",se.BillPhoto),
            new SqlParameter("@CarMark",se.CarMark),
            new SqlParameter("@CarType",se.CarType),
            new SqlParameter("@BeginDate",se.BeginDate),
            new SqlParameter("@EndDate",se.EndDate),
            new SqlParameter("@JerquePeople",se.JerquePeople),
            new SqlParameter("@S_Branch",se.S_Branch),
            new SqlParameter("@S_Cost",se.S_Cost),
            new SqlParameter("@S_FactoryName",se.S_FactoryName),
            new SqlParameter("@S_People",se.S_People),
            new SqlParameter("@S_Result",se.S_Result),
            new SqlParameter("@S_Type",se.S_Type),
            new SqlParameter("@S_Reason",se.S_Reason),
            new SqlParameter("@UseCost",se.UseCost)
        };
            int result = DBHelper.ExecuteNonQueryProc(sql, parms);
            return result;
        }
        /// <summary>
        /// 跟新一条信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public  int updateService(Services se)
        {
            string sql = "pro_updateService";
            SqlParameter[] parms = new SqlParameter[]
            {
 
            new SqlParameter("@S_Id",se.S_Id),
             new SqlParameter("@BeginDate",se.BeginDate),
            new SqlParameter("@BillPhoto",se.BillPhoto),
            new SqlParameter("@CarMark",se.CarMark),
            new SqlParameter("@CarType",se.CarType),
            new SqlParameter("@EndDate",se.EndDate),
            new SqlParameter("@JerquePeople",se.JerquePeople),
            new SqlParameter("S_Branch",se.S_Branch),
            new SqlParameter("@S_Cost",se.S_Cost),
            new SqlParameter("@S_FactoryName",se.S_FactoryName),
            new SqlParameter("@S_People",se.S_People),
            new SqlParameter("@S_Result",se.S_Result),
            new SqlParameter("@S_Type",se.S_Type),
            new SqlParameter("@S_Reason",se.S_Reason),
            new SqlParameter("@UseCost",se.UseCost)
        };
            int result = DBHelper.ExecuteNonQueryProc(sql, parms);
            return result;
        }

    
        /// <summary>
        ///  根据ID查看一条详细信息
        /// </summary>
        /// <param name="c_Id"></param>
        /// <returns></returns>
        public  Services getServiceById(int s_Id)
        {
            string sql = "pro_getServiceById";
            Services se = null;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@S_Id",s_Id)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, parms))
            {
                if (reader.Read())
                {
                    se = new Services();
                    se.BeginDate = (DateTime)reader["BeginDate"];
                    se.BillPhoto = (string)reader["BillPhoto"];
                    se.CarMark = (string)reader["CarMark"];
                    se.CarType = (string)reader["CarType"];
                    se.EndDate = (DateTime)reader["EndDate"];
                    se.JerquePeople = (string)reader["JerquePeople"];
                    se.S_Branch = (string)reader["S_Branch"];
                    se.S_Cost = Convert.ToDouble(reader["S_Cost"]);
                    se.S_FactoryName = (string)reader["S_FactoryName"];
                    se.S_Id = (int)reader["S_Id"];
                    se.S_People = (string)reader["S_People"];
                    se.S_Result = (string)reader["S_Result"];
                    se.S_Type = (string)reader["S_Type"];
                    se.S_Reason = (string)reader["S_Reason"];
                    se.UseCost = Convert.ToDouble(reader["UseCost"]);
                }
                reader.Close();
            }
            return se;
        }
        /// <summary>
        /// 根据ID删除一条信息
        /// </summary>
        /// <param name="c_Id"></param>
        public  int deleteServiceById(int s_Id)
        {
            string sql = "pro_deleteServiceById";
            int result = DBHelper.ExecuteNonQueryProc(sql, new SqlParameter("@S_Id", s_Id));
            return result;
        }
        /// <summary>
        /// 查询所有车辆状态为维修信息
        /// </summary>
        /// <returns></returns>
        public IList<Car_Cars>  getCarsByType()
        {
            IList<Car_Cars> list = new List<Car_Cars>();
            string cars = "pro_getCarsByType";
            DataTable tb = DBHelper.GetDataTableProc(cars, null);
            foreach (DataRow r in tb.Rows)
            {
                Car_Cars Car = new Car_Cars();
                Car.Car_Id = (int)r["Car_Id"];
                Car.CarMark = (string)r["CarMark"];
                Car.Seating = (int)r["Seating"];
                Car.Typeid = carType.GetAllCarsById((int)r["Typeid"]);
                Car.BuyData = (DateTime)r["BuyData"];
                Car.BuyMoney = Convert.ToDecimal(r["BuyMoney"]);
                Car.Buywork = (string)r["Buywork"];
                Car.State = (string)r["State"];
                Car.ReMark = (string)r["ReMark"];
                list.Add(Car);
            }
            return list;
        }

        #endregion
    }
}
