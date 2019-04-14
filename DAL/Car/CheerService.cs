
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
   public class CheerService:ICheerService
    {

        #region ICheerService 成员

        /// <summary>
        /// 按条件查询加油记录
        /// </summary>
        /// <param name="statime"></param>
        /// <param name="endtime"></param>
        /// <param name="c_CarType"></param>
        /// <param name="c_Station"></para
        /// <returns></returns>
        public  IList<Cheer> getAllCheer(string statime, string endtime, string c_CarType, string c_Station)
        {
            IList<Cheer> list = new List<Cheer>();
            string sql = "prc_getAllCheer";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@Statime",statime),
                new SqlParameter("@Endtime",endtime),
                new SqlParameter("@C_CarType",c_CarType),
                new SqlParameter("@C_Station",c_Station)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, parms))
            {
                while (reader.Read())
                {
                    Cheer cheer = new Cheer();
                    cheer.BillPhoto = (string)reader["BillPhoto"];
                    cheer.C_CarType = (string)reader["C_CarType"];
                    cheer.C_CheerType = (string)reader["C_CheerType"];
                    cheer.C_Date = (DateTime)reader["C_Date"];
                    cheer.C_Id = (int)reader["C_Id"];
                    cheer.C_Station = (string)reader["C_Station"];
                    cheer.C_Sum = Convert.ToDouble(reader["C_Sum"]);
                    cheer.CarMark = (string)reader["CarMark"];
                    cheer.Remark = (string)reader["Remark"];
                    list.Add(cheer);
                }
                reader.Close();
            }
            return list;
        }
        /// <summary>
        /// 查询所有的加油厂
        /// </summary>
        /// <returns></returns>
        public  IList<Cheer> getCheerStation()
        {
            IList<Cheer> list = new List<Cheer>();
            string sql = "prc_getCheerStation";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, null))
            {
                while (reader.Read())
                {
                    Cheer cheer = new Cheer();
                    cheer.C_Station = (string)reader["C_Station"];
                    list.Add(cheer);
                }
                reader.Close();
            }
            return list;
        }
        /// <summary>
        ///  根据ID查看一条详细信息
        /// </summary>
        /// <param name="c_Id"></param>
        /// <returns></returns>
        public  Cheer getCheerById(int c_Id)
        {
            string sql = "pro_getCheerById";
            Cheer cheer = null;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@C_Id",c_Id)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, parms))
            {
                if (reader.Read())
                {
                    cheer = new Cheer();
                    cheer.BillPhoto = (string)reader["BillPhoto"];
                    cheer.C_CarType = (string)reader["C_CarType"];
                    cheer.C_CheerType = (string)reader["C_CheerType"];
                    cheer.C_Date = (DateTime)reader["C_Date"];
                    cheer.C_Id = (int)reader["C_Id"];
                    cheer.C_Station = (string)reader["C_Station"];
                    cheer.C_Sum = Convert.ToDouble(reader["C_Sum"]);
                    cheer.Remark = (string)reader["Remark"];
                    cheer.CarMark = (string)reader["CarMark"];

                }
                reader.Close();
            }
            return cheer;
        }
        /// <summary>
        /// 根据ID删除一条信息
        /// </summary>
        /// <param name="c_Id"></param>
        public  int deleteCheerById(int c_Id)
        {
            string sql = "pro_deleteCheerById";
            int result = DBHelper.ExecuteNonQueryProc(sql, new SqlParameter("@C_Id", c_Id));
            return result;
        }
        /// <summary>
        /// 更新一条信息
        /// </summary>
        /// <param name="ch"></param>
        public  int updateCheer(Cheer ch)
        {
            string sql = "pro_updateCheer";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@BillPhoto",ch.BillPhoto),
                new SqlParameter("@C_CarType",ch.C_CarType),
                new SqlParameter("@C_CheerType",ch.C_CheerType),
                new SqlParameter("@C_Date",ch.C_Date),
                new SqlParameter("@C_Id",ch.C_Id),
                new SqlParameter("@C_Station",ch.C_Station),
                new SqlParameter("@C_Sum",ch.C_Sum),
                new SqlParameter("@CarMark",ch.CarMark),
                new SqlParameter("@Remark",ch.Remark)
            };
            int result = DBHelper.ExecuteNonQueryProc(sql, parms);

            return result;
        }
        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="ch"></param>
        public  int addCheer(Cheer ch)
        {
            string sql = "pro_AddCheer";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@BillPhoto",ch.BillPhoto),
                new SqlParameter("@C_CarType",ch.C_CarType),
                new SqlParameter("@C_CheerType",ch.C_CheerType),
                new SqlParameter("@C_Date",ch.C_Date),
                new SqlParameter("@C_Id",ch.C_Id),
                new SqlParameter("@C_Station",ch.C_Station),
                new SqlParameter("@C_Sum",ch.C_Sum),
                new SqlParameter("@CarMark",ch.CarMark),
                new SqlParameter("@Remark",ch.Remark)
            };
            int result = DBHelper.ExecuteNonQueryProc(sql, parms);

            return result;
        }


        #endregion
    }
}
