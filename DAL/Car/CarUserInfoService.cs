using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using IDAL.Car;
namespace DAL.Car
{
   public class CarUserInfoService:ICarUserInfoService
    {
        #region ICarUserInfoService 成员

        public IList<Car_UserInfo> GetAllUserInfo()
        {

            string cars = "usp_CarSelectUserInfo";
            DataTable tb = DBHelper.GetDataTableProc(cars, null);
            IList<Car_UserInfo> list = new List<Car_UserInfo>();
            foreach (DataRow reader in tb.Rows)
            {
                Car_UserInfo userInfo = new Car_UserInfo();
                userInfo.UserId = (int)reader["UserId"];
                userInfo.UserName = (string)reader["UserName"];
                userInfo.Address = (string)reader["Address"];
                userInfo.Age = (int)reader["Age"];
                userInfo.Phone = (string)reader["Phone"];
                userInfo.Sex = (string)reader["Sex"];
                userInfo.State = (string)reader["State"];
                list.Add(userInfo);
            }
            return list;
        }

        #endregion

  

        #region ICarUserInfoService 成员

        /// <summary>
        /// 根据ID查看所有驾驶员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Car_UserInfo GetAllCarsById(int Id)
        {
            string sql = "usp_CarSelectUserInfoById";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@UserId", Id)))
            {
                if (reader.Read())
                {
                    Car_UserInfo userIfo = new Car_UserInfo();
                    userIfo.UserId = (int)reader["UserId"];
                    userIfo.Address = (string)reader["Address"];
                    userIfo.Age = (int)reader["Age"];
                    userIfo.Phone = (string)reader["Phone"];
                    userIfo.Sex = (string)reader["Sex"];
                    userIfo.State = (string)reader["State"];
                    return userIfo;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }

        public IList<Car_UserInfo> usp_CarUserNameState(string State)
        {
            string proName = "usp_CarUserNameState";
            DataTable tb = DBHelper.GetDataTableProc(proName, new SqlParameter("@State", State));
            IList<Car_UserInfo> list = new List<Car_UserInfo>();

            foreach (DataRow r in tb.Rows)
            {
                Car_UserInfo car = new Car_UserInfo();
                car.UserName = (string)r["UserName"];
                list.Add(car);
            }
            return list;
        }
        /// <summary>
        /// 根据姓名查看驾驶员
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public IList<Car_UserInfo> SelectCarsDark(string userName)
        {
            string proName = "usp_CarSelectName";
            DataTable tb = DBHelper.GetDataTableProc(proName, new SqlParameter("@UserName", userName));
            IList<Car_UserInfo> list = new List<Car_UserInfo>();

            foreach (DataRow r in tb.Rows)
            {
                Car_UserInfo car = new Car_UserInfo();
                car.UserName = (string)r["UserName"];
                car.State = (string)r["State"];
                car.Address = (string)r["Address"];
                car.Age = (int)r["Age"];
                car.Phone = (string)r["Phone"];
                car.Sex = (string)r["Sex"];
                car.UserId = (int)r["UserId"];

                list.Add(car);
            }
            return list; 
        }
        /// <summary>
        /// 删除驾驶员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteDriver(string Id)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@CarIds",Id)

          };
            int num = DBHelper.ExecuteNonQueryProc("usp_CarDeleteDriver", para);
            return num;
        }
        /// <summary>
        /// 添加驾驶员
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>

        public int AddDavte(Car_UserInfo userinfo)
        {
              SqlParameter[] para = new SqlParameter[]
          {
          new SqlParameter("@UserName",userinfo.UserName),
          new SqlParameter("@Age",userinfo.Age),
          new SqlParameter("@Sex",userinfo.Sex),
          new SqlParameter("@Address",userinfo.Address),
          new SqlParameter("@phone",userinfo.Phone),
          new SqlParameter("@state",userinfo.State)
          };
            int num = DBHelper.ExecuteNonQueryProc("usp_CasAddUserInfo", para);
            return num;
        }

        #endregion
    }
}
