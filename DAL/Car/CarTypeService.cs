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
  public   class CarTypeService:ICarTypeService

    {
        #region ICarTypeService 成员

        public IList<Car_Type> GetAllType()
        {
           string sql = "usp_SelcectCarType";
            List<Car_Type> list = new List<Car_Type>();
            using (DataTable table = DBHelper.GetDataTableProc(sql))
            {
                foreach (DataRow row in table.Rows)
                {
                    Car_Type cartype = new Car_Type();
                    cartype.TypeId = (int)row["TypeId"];
                    cartype.Genre = (string)row["Genre"];

                    list.Add(cartype);
                }
                return list;
            }
        }

        public Car_Type GetAllCarsById(int Id)
        {
            string sql = "usp_SelcectCarsTypeById";
            SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@Id", Id));
            if (reader.Read())
            {
                Car_Type car = new Car_Type();
                car.TypeId = (int)reader["TypeId"];
                car.Genre = (string)reader["Genre"];
                
                reader.Close();
                return car;



            }
            else
            {
                reader.Close();
                return null;


            }
        }

        #endregion

    }
}
