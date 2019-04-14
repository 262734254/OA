using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL.Matter;
using OAFactory;

using IDAL.Target;
using IDAL.Power;
using Model;


namespace BLL.Target
{
    public class TaskManager
    {

        //利用抽象工厂创建service
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        //利用抽象工厂创建任务下达访问对象
        private static ITaskService taskService = factory.CreateTaskService();





        public IList<Department> GetAllDepartment()
        {   //实例化部门访问对象
            IDepartmentService departmentService = factory.CreateDepartmentService();
            return departmentService.GetAllDepartment();
        }

        public IList<UserInfo> GetAllTaskLeaders()
        {
            return taskService.GetAllTaskLeaders();
        }


        public IList<UserInfo> GetAllUsersByDepartmentId(int id)
        {
            //实例化用户访问对象
            IUserInfoService us = factory.CreateUserInfoService(); ;
            return us.GetAllUsersByDepartmentId(id);
        }

        public int SendTask(Task task)
        {
            return taskService.SendTask(task);
        }




        #region ITaskManager 成员


        public IList<Task> SelectTaskByConditions(string year, string month, string status, string field)
        {
            return taskService.SelectTaskByConditions(year, month, status, field);
        }

        public Task GetTaskByTaskId(int id)
        {
            return taskService.GetTaskByTaskId(id);
        }

        public int UpdateTask(Task task)
        {
            return taskService.UpdateTask(task);
        }

        public IList<Stage> SelectTaskAllStageByTaskId(int id)
        {
            return taskService.SelectTaskAllStageByTaskId(id);
        }

        #endregion


        #region ITaskManager 成员


        public int SendTasksStageToExec(Stage stage)
        {
            return taskService.SendTasksStageToExec(stage);
        }

        #endregion

        #region ITaskManager 成员


        public IList<Stage> SelecTaskAllStageProcessByTaskId(int taskId)
        {
            return taskService.SelecTaskAllStageProcessByTaskId(taskId);
        }

        #endregion

        #region ITaskManager 成员


        public int UpdateAlltheStage(Stage stage)
        {
            return taskService.UpdateAlltheStage(stage);
        }

        #endregion


        public static string UpdateTaskNowStatus(int taskId)
        {
            return taskService.UpdateTaskNowStatus(taskId);

        }
        public static int UpdateTaskFinshStatus(int taskId)
        {

            return taskService.UpdateTaskFinshStatus(taskId);
        }

        public static IList<Task> GetAllTaskFinishRate(string year, string month, string type)
        {

            return taskService.GetAllTaskFinishRate(year, month, type);
        }


        public static string CheckSendTaskTitle(string title)
        {
            return taskService.CheckSendTaskTitle(title);
        }

        //获取任务的最新进度
        public static IList<Stage> SelectStageAllProcByTaskId(int taskId, string year, string month, string type)
        {
            return taskService.SelectStageAllProcByTaskId(taskId, year, month, type);
        }
        public IList<Model.Task> SelectAllNoStepTask(int uid, int s)
        {
            return taskService.SelectAllNoStepTask(uid, s);

        }

        //提交任务完成申请单
        public int SubmitTaskFishRequest(Pending p)
        {
            return taskService.SubmitTaskFishRequest(p);
        }

        public int UpdateStageStatus(int num, string status)
        {
            return taskService.UpdateStageStatus(num, status);
        }


        public IList<Stage> GetStageListDataShow()
        {
            return taskService.GetStageListDataShow();
        }

    }
}
