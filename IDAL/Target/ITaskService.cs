using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL.Target
{
    public interface ITaskService
    {
        /// 获取所有领导阶层领导名称
        IList<UserInfo> GetAllTaskLeaders();
        /// 发送及保存任务
        int SendTask(Task task);

        /// 根据条件查询所有任务
        IList<Task> SelectTaskByConditions(string year, string month, string status, string field);
        /// 根据任务编号获取任务
        Task GetTaskByTaskId(int id);
        /// 更新任务目标
        int UpdateTask(Task task);

        /// 查询某个任务的各个阶段的详细
        IList<Stage> SelectTaskAllStageByTaskId(int id);

        //相关部门主管发送给目标任务划分阶段并给部门人员执行
        int SendTasksStageToExec(Stage stage);

        //查看某一目标任务的各个阶段的情况
        IList<Stage> SelecTaskAllStageProcessByTaskId(int taskId);

        //更新阶段的最新执行情况
        int UpdateAlltheStage(Stage stage);
        
        //更新任务的当前状态
        string UpdateTaskNowStatus(int taskId);

        //更新任务的完成状态
        int UpdateTaskFinshStatus(int taskId);

        //显示所有任务完成状态
        IList<Task> GetAllTaskFinishRate(string year, string month, string type);

        //验证是否存在重复任务标题
        string CheckSendTaskTitle(string title);

        //获取任务的最新进度
        IList<Stage> SelectStageAllProcByTaskId(int taskId, string year, string month, string type);

        //获取未分配阶段或者已经分配阶段的任务
        IList<Model.Task> SelectAllNoStepTask(int uid,int status);

        //提交任务完成申请单
        int SubmitTaskFishRequest(Pending p);

        //更新为执行中
        int UpdateStageStatus(int num, string status);

        IList<Stage> GetStageListDataShow();
     
    }
}
