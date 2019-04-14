using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL.Matter;
using IDAL.Power;
using System.Data.SqlClient;
using Model;
using System.Data;

namespace DAL.Matter
{
    public class ExamineService : IExamineService
    {
       
        /// <summary>
        /// 添加审批记录
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int AddExamine(Examine e)
        {
            string proName = "usp_AddExamine";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@RequisitionID" ,e.RequisitionID),
                    new SqlParameter("@RequisitionType",e.RequisitionType),
                    new SqlParameter("@ExamineUID",e.ExamineUID.UID),
                     new SqlParameter("@ExamineIdea",e.ExamineIdea),
                    new SqlParameter("@EndTime",e.EndTime),
                    new SqlParameter("@IsApprove",e.IsApproved),
                    
                   
           };
            return DBHelper.ExecuteNonQueryProc(proName, pars);


        }


        /// <summary>
        /// 根据审批类型查询审批记录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<Examine> SearchExamineByType(string type)
        {

            IUserInfoService userService = new DAL.Power.UserInfoService();

            string sql = "usp_SearchExamineByType";
            IList<Examine> list = new List<Examine>();
            using (DataTable dt = DBHelper.GetDataTableProc(sql, new SqlParameter("@Type", type)))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Examine e = new Examine();
                    e.EID = Convert.ToInt32(row["EID"]);
                    e.EndTime = Convert.ToDateTime(row["EndTime"]);
                    e.ExamineIdea = row["ExamineIdea"].ToString();
                    e.ExamineUID = userService.GetAllUserById(Convert.ToInt32(row["ExamineUID"]));
                    e.IsApproved = row["IsApprove"].ToString();
                    e.RequisitionType = row["RequisitionType"].ToString();
                    e.RequisitionID = Convert.ToInt32(row["RequisitionID"]);

                    list.Add(e);
                }
            }
            return list;
        }

      
      

        /// <summary>
        /// 根据ID查询一条审批记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Examine GetExaminById(int id)
        {
            IUserInfoService userService = new DAL.Power.UserInfoService();

            string sql = "usp_GetExaminById";
            Examine e = new Examine();
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@Id", id)))
            {
                if (reader.Read())
                {

                    e.EID = Convert.ToInt32(reader["EID"]);
                    e.EndTime = Convert.ToDateTime(reader["EndTime"]);
                    e.ExamineIdea = reader["ExamineIdea"].ToString();
                    e.ExamineUID = userService.GetAllUserById(Convert.ToInt32(reader["ExamineUID"]));
                    e.IsApproved = reader["IsApprove"].ToString();
                    e.RequisitionType = reader["RequisitionType"].ToString();
                    e.RequisitionID = Convert.ToInt32(reader["RequisitionID"]);

                    reader.Close();
                    return e;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            return e;
        }


        /// <summary>
        /// 根据状态和类型获取所有申请信息
        /// </summary>
        /// <param name="state"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<Pending> SearchPending(string state, string type)
        {
            string sql = "usp_Examine";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@State",state),
                new SqlParameter("@Type",type)
            };
            IList<Pending> list = new List<Pending>();
            using (DataTable dt = DBHelper.GetDataTableProc(sql, para))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Pending p = new Pending();
                    p.Id = Convert.ToInt32(row["id"]);
                    p.Title = row["Title"].ToString();
                    p.ResponseMan = row["ResponseMan"].ToString();
                    p.States = row["States"].ToString();
                    p.ApplicationType = row["ApplicationType"].ToString();
                    p.Timer = row["Timer"].ToString();
                    list.Add(p);
                }
                
            }
            return list;


        }


        #region IExamineService 成员

        /// <summary>
        /// 终结申请
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        public void ModifyApplicationById(string type, int id)
        {
            string sql = "usp_ModifyApplicationByType";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Type",type),
                new SqlParameter("@Id",id)
            };
            DBHelper.ExecuteNonQueryProc(sql,para);
        }

        #endregion

        #region IExamineService 成员

        /// <summary>
        /// 根据审批记录ID删除一项审批记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEXamine(int id)
        {
            string sql = "usp_DeleteExamineById";
            DBHelper.ExecuteNonQueryProc(sql,new SqlParameter("@EID",id));
        }

        #endregion
    }
}
