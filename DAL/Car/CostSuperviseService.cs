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
   public class CostSuperviseService:ICostSuperviseService
    {
        #region ICostSuperviseService 成员

        /// <summary>
        /// 按条件查询费用记录
        /// </summary>
        /// <param name="statime"></param>
        /// <param name="endtime"></param>
        /// <param name="cs_CarType"></param>
        /// <param name="carMark"></param>
        /// <returns></returns>
        public  IList<CostSupervise> getAllCostSupervise(string statime, string endtime, string cs_CarType, string carMark)
        {
            IList<CostSupervise> list = new List<CostSupervise>();
            string sql = "prc_getAllCostSupervise";
            SqlParameter[] parms = new SqlParameter[]
           {
                new SqlParameter("@Statime",statime),
                new SqlParameter("@Endtime",endtime),
                new SqlParameter("@CS_CarType",cs_CarType),
                new SqlParameter("@CarMark",carMark)
           };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, parms))
            {
                while (reader.Read())
                {
                    CostSupervise cs = new CostSupervise();
                    cs.BillPhoto = (string)reader["BillPhoto"];
                    cs.CarMark = (string)reader["CarMark"];
                    cs.CS_CarType = (string)reader["CS_CarType"];
                    cs.CS_Cost = Convert.ToDouble(reader["CS_Cost"]);
                    cs.CS_Date = (DateTime)reader["CS_Date"];
                    cs.CS_Id = (int)reader["CS_Id"];
                    cs.CS_Item = (string)reader["CS_Item"];
                    cs.Remark = (string)reader["Remark"];
                    list.Add(cs);
                }
                reader.Close();
            }
            return list;
        }

       /// <summary>
       /// 查询费用表所有的车牌号
       /// </summary>
       /// <returns></returns>
        public IList<CostSupervise> getCostSupervise()
        {
            IList<CostSupervise> list = new List<CostSupervise>();
            string sql = "pro_getCostSupervise";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, null))
            {
                while (reader.Read())
                {
                    CostSupervise cs = new CostSupervise();
                    cs.CarMark = (string)reader["CarMark"];
                    list.Add(cs);
                }
                reader.Close();
            }
            return list;
        }
        /// <summary>
        /// 更新一条信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public  int updateCostSupervise(CostSupervise cs)
        {
            string sql = "pro_updateCostSupervise";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@CS_Id",cs.CS_Id),
                new SqlParameter("@CS_Date",cs.CS_Date),
                new SqlParameter("@CarMark",cs.CarMark),
                new SqlParameter("@CS_Item",cs.CS_Item),
                new SqlParameter("@CS_Cost",cs.CS_Cost),
                new SqlParameter("@CS_CarType",cs.CS_CarType),
                new SqlParameter("@Remark",cs.Remark),
                new SqlParameter("@BillPhoto",cs.BillPhoto)
            };
            int result = DBHelper.ExecuteNonQueryProc(sql, parms);

            return result;
        }
        /// <summary>
        ///  根据ID查看一条详细信息
        /// </summary>
        /// <param name="c_Id"></param>
        /// <returns></returns>
        public  CostSupervise getCostSuperviseById(int cs_Id)
        {
            IList<Cheer> list = new List<Cheer>();
            string sql = "pro_getCostSuperviseById";
            CostSupervise cs = null;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@CS_Id",cs_Id)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, parms))
            {
                if (reader.Read())
                {
                    cs = new CostSupervise();
                    cs.BillPhoto = (string)reader["BillPhoto"];
                    cs.CarMark = (string)reader["CarMark"];
                    cs.CS_CarType = (string)reader["CS_CarType"];
                    cs.CS_Cost = Convert.ToDouble(reader["CS_Cost"]);
                    cs.CS_Date = (DateTime)reader["CS_Date"];
                    cs.CS_Id = (int)reader["CS_Id"];
                    cs.CS_Item = (string)reader["CS_Item"];
                    cs.Remark = (string)reader["Remark"];
                }
                reader.Close();
            }
            return cs;
        }
        /// <summary>
        /// 根据ID删除一条信息
        /// </summary>
        /// <param name="c_Id"></param>
        public  int delCostSuperviseById(int cs_Id)
        {
            string sql = "pro_delCostSuperviseById";
            int result = DBHelper.ExecuteNonQueryProc(sql, new SqlParameter("@CS_Id", cs_Id));
            return result;
        }
        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="ch"></param>
        public  int addCostSupervise(CostSupervise cs)
        {
            string sql = "pro_addCostSupervise";
            SqlParameter[] parms = new SqlParameter[]
            {
               //new SqlParameter("@CS_Id",cs.CS_Id),
                new SqlParameter("@CS_Date",cs.CS_Date),
                new SqlParameter("@CarMark",cs.CarMark),
                new SqlParameter("@CS_Item",cs.CS_Item),
                new SqlParameter("@CS_Cost",cs.CS_Cost),
                new SqlParameter("@CS_CarType",cs.CS_CarType),
                new SqlParameter("@Remark",cs.Remark),
                new SqlParameter("@BillPhoto",cs.BillPhoto)
            };
            int result = DBHelper.ExecuteNonQueryProc(sql, parms);
            return result;
        }

        #endregion
    }
}
