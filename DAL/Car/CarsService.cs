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
    public class CarsService : ICarsService
    {
        CarTypeService carType = new CarTypeService();
        #region ICarsService 成员
        /// <summary>
        /// 查询所有车辆信息
        /// </summary>
        /// <returns></returns>
        public IList<Car_Cars> GetAllCars()
        {
            string cars = "usp_SelcectCas";
            DataTable tb = DBHelper.GetDataTableProc(cars, null);
            IList<Car_Cars> list = new List<Car_Cars>();
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
        /// <summary>
        /// 根据ID查询车辆信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Car_Cars GetAllCarsById(int Id)
        {
            string sql = "usp_SelcectCarsById";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@Id", Id)))
            {
                if (reader.Read())
                {
                    Car_Cars Car = new Car_Cars();
                    Car.Car_Id = (int)reader["Car_Id"];
                    Car.CarMark = (string)reader["CarMark"];
                    Car.Seating = (int)reader["Seating"];
                    Car.Typeid = carType.GetAllCarsById((int)reader["Typeid"]);
                    Car.BuyData = (DateTime)reader["BuyData"];
                    Car.BuyMoney = Convert.ToDecimal(reader["BuyMoney"]);
                    Car.Buywork = (string)reader["Buywork"];
                    Car.State = (string)reader["State"];
                    Car.ReMark = (string)reader["ReMark"];

                    return Car;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据状态查看车牌号码
        /// </summary>
        /// <param name="State"></param>
        /// <returns></returns>
        public IList<Car_Cars> SelectCarMarkState(string State)
        {
            string proName = "usp_SelectCarMarkState";
            DataTable tb = DBHelper.GetDataTableProc(proName, new SqlParameter("@State", State));
            IList<Car_Cars> list = new List<Car_Cars>();

            foreach (DataRow r in tb.Rows)
            {
                Car_Cars car = new Car_Cars();
                car.CarMark = (string)r["CarMark"];
                list.Add(car);
            }
            return list;
        }
        /// <summary>
        /// 修改车辆信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int UpdateCars(Car_Cars cs)
        {
            SqlParameter[] para = new SqlParameter[]
          {
          new SqlParameter("@Carid",cs.Car_Id),
          new SqlParameter("@BuyData",cs.BuyData),
          new SqlParameter("@BuyMoney",cs.BuyMoney),
          new SqlParameter("@Buywork",cs.Buywork),
          new SqlParameter("@CarMark",cs.CarMark),
          new SqlParameter("@ReMark",cs.ReMark),
          new SqlParameter("@State",cs.State),
          new SqlParameter("@Typeid",cs.Typeid.TypeId),
          new SqlParameter("@seating",cs.Seating)
          };
            int num = DBHelper.ExecuteNonQueryProc("up_updateCars", para);
            return num;
        }
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DcseteCars(string Id)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@CarIds",Id)

          };
            int num = DBHelper.ExecuteNonQueryProc("usp_deleteCars", para);
            return num;
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<Car_Cars> SelectCarsDark(string Mark, string typeid, string state)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@CarMark",Mark),
             new SqlParameter("@Typeid",typeid),
             new SqlParameter("@state",state)

          };
            SqlDataReader reader = (SqlDataReader)DBHelper.ExecuteReaderProc("usp_SelectCarsDark", para);
            List<Car_Cars> list = GetCars(reader);
            return list;
        }

        public List<Car_Cars> GetCars(SqlDataReader reader)
        {
            List<Car_Cars> list = new List<Car_Cars>();
            while (reader.Read())
            {
                Car_Cars Car = new Car_Cars();
                Car.Car_Id = (int)reader["Car_Id"];
                Car.CarMark = (string)reader["CarMark"];
                Car.Seating = (int)reader["Seating"];
                Car.Typeid = carType.GetAllCarsById((int)reader["Typeid"]);
                Car.BuyData = (DateTime)reader["BuyData"];
                Car.BuyMoney = Convert.ToDecimal(reader["BuyMoney"]);
                Car.Buywork = (string)reader["Buywork"];
                Car.State = (string)reader["State"];
                Car.ReMark = (string)reader["ReMark"];
                list.Add(Car);
            }
            return list;
        }
        /// <summary>
        /// 添加车辆
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int InsertCars(Car_Cars cs)
        {
            SqlParameter[] para = new SqlParameter[]
          {
          new SqlParameter("@BuyData",cs.BuyData),
          new SqlParameter("@BuyMoney",cs.BuyMoney),
          new SqlParameter("@Buywork",cs.Buywork),
          new SqlParameter("@CarMark",cs.CarMark),
          new SqlParameter("@ReMark",cs.ReMark),
          new SqlParameter("@State",cs.State),
          new SqlParameter("@Typeid",cs.Typeid.TypeId),
          new SqlParameter("@seating",cs.Seating)
          };
            int num = DBHelper.ExecuteNonQueryProc("usp_AddCars", para);
            return num;
        }
        /// <summary>
        /// 根据车牌号查看状态
        /// </summary>
        /// <param name="CarMark"></param>
        /// <returns></returns>
        public string SelectState(string CarMark)
        {
            SqlParameter[] para = new SqlParameter[]
          {
               new SqlParameter("@CarMark",CarMark)
          };
            string number = string.Empty;
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc("usp_SelectState", para))
            {
                if (reader.Read())
                {
                    number = reader["State"].ToString();
                }
            }
            return number;
        }

        #endregion

        #region ICarsService 成员

        /// <summary>
        /// 根据车牌号查看类型
        /// </summary>
        /// <param name="CarMark"></param>
        /// <returns></returns>
        public string usp_SelectCarMarkType(string CarMark)
        {
            SqlParameter[] para = new SqlParameter[]
          {
               new SqlParameter("@CarMark",CarMark)
          };
            string number = string.Empty;
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc("usp_SelectCarMarkType", para))
            {
                if (reader.Read())
                {
                    number = reader["Typeid"].ToString();
                }
            }
            return number;
        }

        #endregion

        #region ICarsService 成员

        /// <summary>
        /// 根据ID跟新状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int UpadteCarsByIdSate(int Id)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@CarId",Id)

          };
            int num = DBHelper.ExecuteNonQueryProc("usp_CarUpdateByIdCars", para);
            return num;
        }

        #endregion
    }
}
