using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.Car;
using System.Data.SqlClient;
using System.Data;
using DAL.Power;

namespace DAL.Car
{
    public class CarDavnoteService : ICarDavnoteService
    {
        
        DepartmentService dept = new DepartmentService();
        CarTypeService carType = new CarTypeService();
       

        #region ICarDavnoteService 成员

        /// <summary>
        /// 通用
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public List<Car_Davnote> GetDavnote(SqlDataReader reader)

        {
           
            List<Car_Davnote> list = new List<Car_Davnote>();

            while (reader.Read())
            {
                Car_Davnote dav = new Car_Davnote();
                dav.DavCourse = Decimal.Parse(reader["DavCourse"].ToString());
                dav.DavData = DateTime.Parse(reader["DavData"].ToString());
                dav.DavDept =dept.GetAllDepartementById((int)reader["DavDept"]);
                dav.DavDriver = reader["DavDriver"].ToString();
                dav.DavMan = reader["DavMan"].ToString();
                dav.DavMark = reader["DavMark"].ToString();
                dav.DavPlace = reader["DavPlace"].ToString();
                dav.DavReturnData = DateTime.Parse(reader["DavReturnData"].ToString());
                dav.DavRemark = reader["DavRemark"].ToString();
                dav.DavTtion = reader["Davttion"].ToString();
                dav.DavTypeId = carType.GetAllCarsById((int)reader["DavTypeId"]);
              
                dav.DavnoteId = Convert.ToInt32(reader["DavnoteId"].ToString());
                list.Add(dav);
            }
            return list;
        }

        #endregion


        #region ICarDavnoteService 成员
       /// <summary>
       /// 查询所有出车记录
       /// </summary>
       /// <returns></returns>
        public IList<Car_Davnote> GetAllDavnote()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据条件查询出车记录
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public List<Car_Davnote> SelectDavnoteDark(string Mark, string typeid, string dept)
        {
            SqlParameter[] para = new SqlParameter[] 
           { 
               new SqlParameter("@CarMark",Mark),
                new SqlParameter("@Typeid",typeid),
                 new SqlParameter("@Dept",dept)
           };
            SqlDataReader reader = (SqlDataReader)DBHelper.ExecuteReaderProc(".usp_SelectCarsDavnote", para);
            List<Car_Davnote> list = GetDavnote(reader);
            return list;
        }

        #endregion

        #region ICarDavnoteService 成员

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
            int num = DBHelper.ExecuteNonQueryProc("usp_DeleteCarDavnote", para);
            return num;
        }

        #endregion

        #region ICarDavnoteService 成员

        /// <summary>
        /// 根据查看详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Car_Davnote SelectDavnoteById(int Id)
        {
            SqlParameter[] para = new SqlParameter[] 
           { 
               new SqlParameter("@DavnoteId",Id)
           };
            SqlDataReader reader = (SqlDataReader)DBHelper.ExecuteReaderProc("usp_SelectDavnoteById", para);
            List<Car_Davnote> list = GetDavnote(reader);
            Car_Davnote dav = list[0];
            return dav;
        }

        #endregion

        #region ICarDavnoteService 成员

        /// <summary>
        /// 添加一条出车信息
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>
        public int AddDavte(Car_Davnote dav)
        {
            SqlParameter[] para = new SqlParameter[] 
           { 
               new SqlParameter("@DavData",dav.DavData),
			   new SqlParameter("@DavDept",dav.DavDept.Id),
			   new SqlParameter("@DavMan",dav.DavMan),
			   new SqlParameter("@DavTypeid",dav.DavTypeId.TypeId),
			   new SqlParameter("@DavMark",dav.DavMark),
			   new SqlParameter("@DavDriver",dav.DavDriver),
			   new SqlParameter("@DavPlace",dav.DavPlace),
			   new SqlParameter("@DavCouse",dav.DavCourse),
			   new SqlParameter("@Davttion",dav.DavTtion),
			   new SqlParameter("@DavreData",dav.DavReturnData),
			   new SqlParameter("@DavRemark",dav.DavRemark)
			  
           };
            int num = DBHelper.ExecuteNonQueryProc("usp_AddCarDavnote", para);
            return num;
        }

        #endregion

        #region ICarDavnoteService 成员

        /// <summary>
        /// 修改出车记录
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>
        public int UpdateDavte(Car_Davnote dav)
        {
            SqlParameter[] para = new SqlParameter[] 
           { 
               new SqlParameter("@DavnoteId",dav.DavnoteId),
               new SqlParameter("@DavData",dav.DavData),
			   new SqlParameter("@DavDept",dav.DavDept.Id),
			   new SqlParameter("@DavMan",dav.DavMan),
			   new SqlParameter("@DavTypeid",dav.DavTypeId.TypeId),
			   new SqlParameter("@DavMark",dav.DavMark),
			   new SqlParameter("@DavDriver",dav.DavDriver),
			   new SqlParameter("@DavPlace",dav.DavPlace),
			   new SqlParameter("@DavCouse",dav.DavCourse),
			   new SqlParameter("@Davttion",dav.DavTtion),
			   new SqlParameter("@DavreData",dav.DavReturnData),
			   new SqlParameter("@DavRemark",dav.DavRemark)
			  
           };
            int num = DBHelper.ExecuteNonQueryProc("usp_UpdateCarDavnote", para);
            return num;
        }

        #endregion
    }
}
