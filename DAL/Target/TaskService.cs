using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Model;
using IDAL.Target;
using System.Data.Sql;

namespace DAL.Target
{
    public class TaskService : ITaskService
    {

        /// <summary>
        /// 获取所有领导阶层领导 名称
        /// </summary>
        /// <returns>领导名称的集合</returns>
        public IList<UserInfo> GetAllTaskLeaders()
        {
            string proName = "usp_selectAllLeaders";
            DataTable tb = DBHelper.GetDataTableProc(proName, null);
            IList<UserInfo> list = new List<UserInfo>();

            foreach (DataRow r in tb.Rows)
            {
                UserInfo d = new UserInfo();
                d.Name = (string)r["Name"];
                list.Add(d);
            }
            return list;
        }


        /// <summary>
        /// 发送及保存任务
        /// </summary>
        /// <param name="task">任务对象</param>
        /// <returns>所影响行数</returns>
        public int SendTask(Task task)
        {
            string proName = "usp_SendTaskProc";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@Title" ,task.Title),
                    new SqlParameter("@Year",task.Year),
                    new SqlParameter("@mumber",task.Mumber),
			        new SqlParameter("@domain", task.Domain),
					new SqlParameter("@work", task.Work),
					new SqlParameter("@Tasktype", task.Tasktype),
					new SqlParameter("@dutyDepart", task.dutyDepart),
					new SqlParameter("@principal", task.Principal),
					new SqlParameter("@filishTime", task.filishTime),
					new SqlParameter("@extrleader", task.Extrleader),
					new SqlParameter("@Branch", task.Branch),
					new SqlParameter("@Vindicator", task.Vindicator),
					new SqlParameter("@remarks", task.Remarks),
					new SqlParameter("@targetTask", task.targetTask),
					new SqlParameter("@Money", task.Money),
					new SqlParameter("@path", task.Path),
					new SqlParameter("@status", task.Status)
            
           };


            return DBHelper.ExecuteNonQueryProc(proName, pars);


        }


        #region ITaskService 成员

        /// <summary>
        /// 根据任务编号获取任务
        /// </summary>
        /// <param name="id">任务编号</param>
        /// <returns>任务对象</returns>
        public Task GetTaskByTaskId(int id)
        {
            Task t = new Task();
            string proName = "usp_SelectTaskByTaskId";

            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@id", id)))
            {
                if (reader.HasRows)
                {


                    if (reader.Read())
                    {
                        t.Title = reader["Title"].ToString();
                        t.Branch = reader["Branch"].ToString();
                        t.Domain = (string)reader["Domain"];
                        t.dutyDepart = (string)reader["dutyDepart"];
                        t.Extrleader = (string)reader["Extrleader"];
                        t.filishTime = Convert.ToDateTime(reader["filishTime"]);
                        t.Id = id;
                        t.Money = Convert.ToDecimal(reader["Money"]); ;
                        t.Mumber = (int)reader["Mumber"];
                        t.Principal = reader["Principal"].ToString();
                        t.Remarks = reader["Remarks"].ToString();
                        t.Status = (string)reader["Status"];
                        t.targetTask = (string)reader["targetTask"];
                        t.Tasktype = (string)reader["Tasktype"];
                        t.Vindicator = (string)reader["Vindicator"];
                        t.Work = (string)reader["Work"];
                        t.Year = (int)reader["Year"];
                        t.Path = (string)reader["Path"];


                    }


                }
            }
            return t;

        }

        #endregion

        #region ITaskService 成员

        /// <summary>
        /// 更新任务目标
        /// </summary>
        /// <param name="task">任务目标</param>
        /// <returns>受影响行数</returns>
        public int UpdateTask(Task task)
        {
            string proName = "usp_UpdateTask";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@Id" ,task.Id),
                    new SqlParameter("@Title" ,task.Title),
                    new SqlParameter("@Year",task.Year),
                    new SqlParameter("@mumber",task.Mumber),
			        new SqlParameter("@domain", task.Domain),
					new SqlParameter("@work", task.Work),
					new SqlParameter("@Tasktype", task.Tasktype),
					new SqlParameter("@dutyDepart", task.dutyDepart),
					new SqlParameter("@principal", task.Principal),
					new SqlParameter("@filishTime", task.filishTime),
					new SqlParameter("@extrleader", task.Extrleader),
					new SqlParameter("@Branch", task.Branch),
					new SqlParameter("@Vindicator", task.Vindicator),
					new SqlParameter("@remarks", task.Remarks),
					new SqlParameter("@targetTask", task.targetTask),
					new SqlParameter("@Money", task.Money),
					new SqlParameter("@path", task.Path),
					new SqlParameter("@status", task.Status)
            
           };

            return DBHelper.ExecuteNonQueryProc(proName, pars);


        }

        #endregion

        #region ITaskService 成员

        /// <summary>
        /// 根据条件查询所有任务
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="status">状态</param>
        /// <param name="field">领域</param>
        /// <returns>任务对象的集合</returns>
        public IList<Task> SelectTaskByConditions(string year, string month, string status, string field)
        {
            string proName = "usp_SelectTaskByConditions";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@Yearstr" ,year),
                    new SqlParameter("@Monthstr" ,month),
                    new SqlParameter("@status",status),
                    new SqlParameter("@field",field)
    
           };

            IList<Task> list = new List<Task>();

            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, pars))
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        Task t = new Task();
                        t.Title = reader["Title"].ToString();
                        t.Branch = reader["Branch"].ToString();
                        t.Domain = (string)reader["Domain"];
                        t.dutyDepart = (string)reader["dutyDepart"];
                        t.Extrleader = (string)reader["Extrleader"];
                        t.filishTime = Convert.ToDateTime(reader["filishTime"]);
                        t.Id = (int)reader["id"];
                        t.Money = Convert.ToDecimal(reader["Money"]); ;
                        t.Mumber = (int)reader["Mumber"];
                        t.Principal = reader["Principal"].ToString();
                        t.Remarks = reader["Remarks"].ToString();
                        t.Status = (string)reader["Status"];
                        t.targetTask = (string)reader["targetTask"];
                        t.Tasktype = (string)reader["Tasktype"];
                        t.Vindicator = (string)reader["Vindicator"];
                        t.Work = (string)reader["Work"];
                        t.Year = (int)reader["Year"];
                        t.Path = (string)reader["Path"];
                        list.Add(t);

                    }


                }
            }
            return list;

        }

        /// <summary>
        /// 查询某个任务的各个阶段的详细
        /// </summary>
        /// <param name="id">任务编号</param>
        /// <returns>阶段的集合</returns>
        public IList<Stage> SelectTaskAllStageByTaskId(int id)
        {


            string proName = "usp_SelecTaskAllStageProcessByTaskId";

            IList<Stage> list = new List<Stage>();
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@taskId", id)))
            {
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        Stage t = new Stage();
                        t.Description = reader["Description"].ToString();
                        t.filishTime = Convert.ToDateTime(reader["filishTime"]);

                        t.Nowmoney = Convert.ToDecimal(reader["Nowmoney"]);
                        t.Premoney = Convert.ToDecimal(reader["Premoney"]); ;
                        t.Problems = (string)reader["Problems"];
                        t.sId = (int)reader["sId"];
                        t.startTime = Convert.ToDateTime(reader["startTime"]);
                        t.StepName = (string)reader["StepName"];
                        t.Status = t.Nowmoney >= t.Premoney ? "已完成" : "未达标";//完成状态
                        t.Monthlength = t.startTime.Month.ToString() + "~" + t.filishTime.Month.ToString();//完成该阶段月份
                        t.taskId = id;
                        list.Add(t);

                    }


                }
            }
            return list;
        }

        #endregion



        #region ITaskService 成员


        public int SendTasksStageToExec(Stage stage)
        {

            string proName = "usp_SendStageProc";
            SqlParameter[] parameters = new SqlParameter[]{
					new SqlParameter("@taskId",stage.taskId),
					new SqlParameter("@StepName", stage.StepName),
					new SqlParameter("@startTime", stage.startTime),
					new SqlParameter("@filishTime", stage.filishTime),
					new SqlParameter("@description", stage.Description),
					new SqlParameter("@preMoney", stage.Premoney),
					new SqlParameter("@nowMoney", stage.Nowmoney),
					new SqlParameter("@problems", stage.Problems),
                    new SqlParameter("@SId",stage.sId),
                 };

            SqlCommand cmd = new SqlCommand(proName, DBHelper.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            parameters[8].Direction = ParameterDirection.Output;
            cmd.Parameters.AddRange(parameters);
            int num = 0;
            cmd.ExecuteScalar();
            //using (SqlDataReader reader = cmd.ExecuteReader())
            //{
            //    if (reader.Read())
            //    {

            //    }


            //}
            num = Convert.ToInt32(cmd.Parameters[8].Value);//放在ExecuteReader关闭之后取值
            return num;
        }



        #endregion

        #region ITaskService 成员


        public IList<Stage> SelecTaskAllStageProcessByTaskId(int taskId)
        {


            string proName = "usp_SelecTaskAllStageProcessByTaskId";

            IList<Stage> list = new List<Stage>();

            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@taskId", taskId)))
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        Stage t = new Stage();
                        t.StepName = reader["StepName"].ToString();
                        t.startTime = Convert.ToDateTime(reader["startTime"]);
                        t.filishTime = Convert.ToDateTime(reader["filishTime"]);
                        t.Description = (string)reader["description"];
                        t.Premoney = Convert.ToDecimal(reader["preMoney"]);
                        t.Nowmoney = Convert.ToDecimal(reader["nowMoney"]);
                        t.sId = (int)reader["sId"];
                        t.taskId = (int)reader["taskId"];
                        t.Problems = reader["problems"].ToString();

                        list.Add(t);

                    }


                }
            }
            return list;



        }

        #endregion

        #region ITaskService 成员


        public int UpdateAlltheStage(Stage stage)
        {

            string proName = "usp_UpdateAlltheStage";
            SqlParameter[] parameters = new SqlParameter[]{
					new SqlParameter("@description", stage.Description),
					new SqlParameter("@nowMoney", stage.Nowmoney),
					new SqlParameter("@problems", stage.Problems),
                    new SqlParameter("@SId",stage.sId),
                 };

            return DBHelper.ExecuteNonQueryProc(proName, parameters);


        }

        #endregion

        #region ITaskService 成员


        public string UpdateTaskNowStatus(int taskId)
        {
            string proName = "usp_updateTaskNowStatus";
            SqlParameter[] parameters = new SqlParameter[]{
					new SqlParameter("@TaskId", taskId),
					new SqlParameter("@StringOut", ""),
					
                 };
            return DBHelper.ExecuteNonQueryProcOutPut(proName, 1, parameters).ToString();

        }

        #endregion

        #region ITaskService 成员


        public int UpdateTaskFinshStatus(int taskId)
        {
            string proName = "usp_UpdateTaskFinshStatus";

            return DBHelper.ExecuteNonQueryProc(proName, new SqlParameter("@TaskId", taskId));
        }

        #endregion

        #region ITaskService 成员


        public IList<Task> GetAllTaskFinishRate(string year, string month, string type)
        {
            IList<Task> list = new List<Task>();
            string proName = "usp_GetAllTaskFinishRate";
            SqlParameter[] parameters = new SqlParameter[]{
					new SqlParameter("@year", year==null?"":year),
					new SqlParameter("@month",month==null?"":month),
					new SqlParameter("@type",type==null?"":type),
                 };

            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, parameters))
            {
                while (reader.Read())
                {
                    Task t = new Task();
                    t.Id = (int)reader["id"];
                    t.Title = reader["title"].ToString();
                    t.FinishRate = Convert.ToDecimal(reader["FinishRate"]);
                    list.Add(t);

                }
            }
            return list;


        }

        #endregion

        #region ITaskService 成员


        public string CheckSendTaskTitle(string title)
        {
            string proName = "usp_CheckSendTaskTitle";
            SqlParameter[] parameters = new SqlParameter[]{
					new SqlParameter("@taskName", title),
					new SqlParameter("@outPut", ""),
					
                 };
            return DBHelper.ExecuteNonQueryProcOutPut(proName, 1, parameters).ToString();
        }

        #endregion

        #region ITaskService 成员


        public IList<Stage> SelectStageAllProcByTaskId(int taskId, string year, string month, string type)
        {
            IList<Stage> list = new List<Stage>();
            string proName = "usp_SelectStageAllProcByTaskId";
            SqlParameter[] parameters = new SqlParameter[]{
					new SqlParameter("@TaskId",taskId  ),
					new SqlParameter("@year",year==null?"":year),
					new SqlParameter("@month",month==null?"":month ),
					new SqlParameter("@type",type==null?"":type),
                 };

            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, parameters))
            {
                while (reader.Read())
                {
                    Stage t = new Stage();
                    t.sId = (int)reader["SID"];
                    t.StepName = reader["StepName"].ToString();
                    t.StartMonth = reader["start"].ToString();
                    t.EndMonth = reader["end"].ToString();
                    t.FilishRate = Convert.ToDecimal(reader["filishRate"]);
                    list.Add(t);

                }
            }
            return list;
        }

        public IList<Model.Task> SelectAllNoStepTask(int uid, int staus)
        {

            IList<Model.Task> list = new List<Model.Task>();
            string proName = "usp_SelectAllNoStepTask";
            SqlParameter[] parameters = new SqlParameter[]{
					new SqlParameter("@uid",uid  ),
					new SqlParameter("@status",staus),
					
                 };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, parameters))
            {

                while (reader.Read())
                {
                    Task t = new Task();
                    t.Title = reader["Title"].ToString();
                    t.Branch = reader["Branch"].ToString();
                    t.Domain = (string)reader["Domain"];
                    t.dutyDepart = (string)reader["dutyDepart"];
                    t.Extrleader = (string)reader["Extrleader"];
                    t.filishTime = Convert.ToDateTime(reader["filishTime"]);
                    t.Id = (int)reader["id"]; ;
                    t.Money = Convert.ToDecimal(reader["Money"]); ;
                    t.Mumber = (int)reader["Mumber"];
                    t.Principal = reader["Principal"].ToString();
                    t.Remarks = reader["Remarks"].ToString();
                    t.Status = (string)reader["Status"];
                    t.targetTask = (string)reader["targetTask"];
                    t.Tasktype = (string)reader["Tasktype"];
                    t.Vindicator = (string)reader["Vindicator"];
                    t.Work = (string)reader["Work"];
                    t.Year = (int)reader["Year"];
                    t.Path = (string)reader["Path"];
                    list.Add(t);

                }



            }
            return list;


        }
        #endregion

        #region ITaskService 成员


        public int SubmitTaskFishRequest(Pending p)
        {
            string proName = "usp_SubmitTaskFishRequest";
            SqlParameter[] pars = new SqlParameter[]
            {
                  
                    new SqlParameter("@Title" ,p.Title),
                    new SqlParameter("@responseMan",p.ResponseMan),
                    new SqlParameter("@timer ",p.Timer),
			        new SqlParameter("@applicationType", p.ApplicationType),
					new SqlParameter("@states",p.States),
					new SqlParameter("@taskId", p.Task.Id),
					
            
           };

            return DBHelper.ExecuteNonQueryProc(proName, pars);
        }


        public int UpdateStageStatus(int num, string status)
        {
            string proName = "usp_UpdateStageStatus";
            SqlParameter[] pars = new SqlParameter[]
            {
                  
                    new SqlParameter("@taskId" ,num),
                    new SqlParameter("@status",status)    
            
           };
            return DBHelper.ExecuteNonQueryProc(proName, pars);
        }
        #endregion

        #region ITaskService 成员


        public IList<Stage> GetStageListDataShow()
        {

            IList<Stage> listStage = new List<Stage>();
            Stage stage = new Stage();
            stage.StepName = "第一阶段";
            listStage.Add(stage);

            stage = new Stage();
            stage.StepName = "第二阶段";
            listStage.Add(stage);

            stage = new Stage();
            stage.StepName = "第三阶段";
            listStage.Add(stage);

            stage = new Stage();
            stage.StepName = "第四阶段";
            listStage.Add(stage);

            stage = new Stage();
            stage.StepName = "第五阶段";
            listStage.Add(stage);

            stage = new Stage();
            stage.StepName = "第六阶段";
            listStage.Add(stage);

            return listStage;


        }

        #endregion
    }
}
