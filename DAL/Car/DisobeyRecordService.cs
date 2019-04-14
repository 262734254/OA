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
   public class DisobeyRecordService:IDisobeyRecordService
    {

        #region IDisobeyRecordService 成员

        /// <summary>
        /// 按条件查询事故违章记录
        /// </summary>
        /// <param name="statime"></param>
        /// <param name="endtime"></param>
        /// <param name="c_CarType"></param>
        /// <param name="c_Station"></param>
        /// <returns></returns>
        public  IList<DisobeyRecord> getAllDisobeyRecord(string statime, string endtime, string dr_CarType, string carMark)
        {
            IList<DisobeyRecord> list = new List<DisobeyRecord>();
            string sql = "prc_getAllDisobeyRecord";
            SqlParameter[] parms = new SqlParameter[]
           {
                new SqlParameter("@Statime",statime),
                new SqlParameter("@Endtime",endtime),
                new SqlParameter("@DR_CarType",dr_CarType),
                new SqlParameter("@CarMark", carMark)
           };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, parms))
            {
                while (reader.Read())
                {
                    DisobeyRecord dr = new DisobeyRecord();
                    dr.BillPhoto = (string)reader["BillPhoto"];
                    dr.CarMark = (string)reader["CarMark"];
                    dr.Dr_CarType = (string)reader["Dr_CarType"];
                    dr.DR_Circs = (string)reader["DR_Circs"];
                    dr.DR_Date = (DateTime)reader["DR_Date"];
                    dr.DR_Department = (string)reader["DR_Department"];
                    dr.DR_Expense = Convert.ToDouble(reader["DR_Expense"]);
                    dr.DR_Explain = (string)reader["DR_Explain"];
                    dr.DR_Id = (int)reader["DR_Id"];
                    dr.DR_Locus = (string)reader["DR_Locus"];
                    dr.DR_People = (string)reader["DR_People"];
                    dr.DR_Sum = Convert.ToDouble(reader["DR_Sum"]);
                    dr.DR_Type = (string)reader["DR_Type"];
                    dr.FactCost = Convert.ToDouble(reader["FactCost"]);
                    dr.Remark = (string)reader["Remark"];
                    list.Add(dr);
                }
                reader.Close();
            }
            return list;
        }
       /// <summary>
       /// 查询事故违章的所有车牌号
       /// </summary>
       /// <returns></returns>
        public  IList<DisobeyRecord> getDisobeyRecordByMark()
        {
            IList<DisobeyRecord> list = new List<DisobeyRecord>();
            string sql = "pro_getDisobeyRecordByMark";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, null))
            {
                while (reader.Read())
                {
                    DisobeyRecord dr = new DisobeyRecord();
                    dr.CarMark = (string)reader["CarMark"];
                    list.Add(dr);
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
        public  int addDisobeyRecord(DisobeyRecord dr)
        {
            string sql = "pro_AddDisobeyRecord";
            SqlParameter[] parms = new SqlParameter[]
            {
            new SqlParameter("@BillPhoto",dr.BillPhoto),
            new SqlParameter("@CarMark",dr.CarMark),
            new SqlParameter("@Dr_CarType",dr.Dr_CarType),
            new SqlParameter("@DR_Circs",dr.DR_Circs),
            new SqlParameter("@DR_Date",dr.DR_Date),
            new SqlParameter("@DR_Department",dr.DR_Department),
            new SqlParameter("@DR_Expense",dr.DR_Expense),
            new SqlParameter("@DR_Explain",dr.DR_Explain),
            new SqlParameter("@DR_Locus",dr.DR_Locus),
            new SqlParameter("@DR_People",dr.DR_People),
            new SqlParameter("@DR_Sum",dr.DR_Sum),
            new SqlParameter("@DR_Type",dr.DR_Type),
            new SqlParameter("@FactCost",dr.FactCost),
            new SqlParameter("@Remark",dr.Remark)
        };
            int result = DBHelper.ExecuteNonQueryProc(sql, parms);
            return result;
        }
        /// <summary>
        /// 跟新一条信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public  int updateDisobeyRecord(DisobeyRecord dr)
        {
            string sql = "pro_updateDisobeyRecord";
            SqlParameter[] parms = new SqlParameter[]
            {
            new SqlParameter("@DR_Id",dr.DR_Id),
            new SqlParameter("@BillPhoto",dr.BillPhoto),
            new SqlParameter("@CarMark",dr.CarMark),
            new SqlParameter("@Dr_CarType",dr.Dr_CarType),
            new SqlParameter("@DR_Circs",dr.DR_Circs),
            new SqlParameter("@DR_Date",dr.DR_Date),
            new SqlParameter("@DR_Department",dr.DR_Department),
            new SqlParameter("@DR_Expense",dr.DR_Expense),
            new SqlParameter("@DR_Explain",dr.DR_Explain),
            new SqlParameter("@DR_Locus",dr.DR_Locus),
            new SqlParameter("@DR_People",dr.DR_People),
            new SqlParameter("@DR_Sum",dr.DR_Sum),
            new SqlParameter("@DR_Type",dr.DR_Type),
            new SqlParameter("@FactCost",dr.FactCost),
            new SqlParameter("@Remark",dr.Remark)
        };
            int result = DBHelper.ExecuteNonQueryProc(sql, parms);
            return result;
        }


        /// <summary>
        ///  根据ID查看一条详细信息
        /// </summary>
        /// <param name="c_Id"></param>
        /// <returns></returns>
        public  DisobeyRecord getDisobeyRecordById(int DR_Id)
        {
            string sql = "pro_getDisobeyRecordById";
            DisobeyRecord dr = null;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@DR_Id",DR_Id)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, parms))
            {
                if (reader.Read())
                {
                    dr = new DisobeyRecord();
                    dr.BillPhoto = (string)reader["BillPhoto"];
                    dr.CarMark = (string)reader["CarMark"];
                    dr.Dr_CarType = (string)reader["Dr_CarType"];
                    dr.DR_Circs = (string)reader["DR_Circs"];
                    dr.DR_Date = (DateTime)reader["DR_Date"];
                    dr.DR_Department = (string)reader["DR_Department"];
                    dr.DR_Expense = Convert.ToDouble(reader["DR_Expense"]);
                    dr.DR_Explain = (string)reader["DR_Explain"];
                    dr.DR_Id = (int)reader["DR_Id"];
                    dr.DR_Locus = (string)reader["DR_Locus"];
                    dr.DR_People = (string)reader["DR_People"];
                    dr.DR_Sum = Convert.ToDouble(reader["DR_Sum"]);
                    dr.DR_Type = (string)reader["DR_Type"];
                    dr.FactCost = Convert.ToDouble(reader["FactCost"]);
                    dr.Remark = (string)reader["Remark"];

                }
                reader.Close();
            }
            return dr;
        }
        /// <summary>
        /// 根据ID删除一条信息
        /// </summary>
        /// <param name="c_Id"></param>
        public  int delDisobeyRecordById(int DR_Id)
        {
            string sql = "pro_delDisobeyRecordById";
            int result = DBHelper.ExecuteNonQueryProc(sql, new SqlParameter("@DR_Id", DR_Id));
            return result;
        }
        #endregion
    }
}
