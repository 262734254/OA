using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Meeting;
using OAFactory;
using Model;
namespace BLL.Meeting
{
   /// <summary>
   /// 会议申请表
   /// </summary>
   public class MeetingApplicationManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IMeetingApplicationService meetingAppService = factory.CreateMeetingApplicationService();
        #region  会议申请实现类
        /// <summary>
        /// 添加会议申请单
        /// </summary>
        /// <param name="meetingApplication"></param>
        public static  void AddMeetingApplication(Model.MeetingApplication meetingApplication)
        {
            meetingAppService.AddMeetingApplication(meetingApplication);
        }
        /// <summary>
        /// 根据会议名称和主办部门查询会议申请列表
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public static  IList<Model.MeetingApplication> SearchMeetingApplication(string roomName, int departmentId)
        {
            return meetingAppService.SearchMeetingApplication(roomName,departmentId);
        }

        /// <summary>
        /// 根据会议申请单号查询一条会议申请信息
        /// </summary>
        /// <param name="MSID"></param>
        /// <returns></returns>
        public static  Model.MeetingApplication GetMeetingApplicationById(int MSID)
        {
            return meetingAppService.GetMeetingApplicationById(MSID);
        }
        /// <summary>
        /// 根据申请单号删除一条会议申请信息，但注意，只能删除未召开的会议
        /// </summary>
        /// <param name="MSID"></param>
        public static  void DelMeetingApplication(int MSID)
        {
            meetingAppService.DelMeetingApplication(MSID);
        }
        /// <summary>
        /// 修改会议申请信息
        /// </summary>
        /// <param name="meetingApplication"></param>
        public static  void UpdateMeetintApplication(Model.MeetingApplication meetingApplication)
        {
            meetingAppService.UpdateMeetintApplication(meetingApplication);
        }
        /// <summary>
        /// 审批会议，更新状态
        /// </summary>
        /// <param name="id"></param>
        public static void ModifyMeetingState(int id,string state)
        {
           meetingAppService.ModifyMeetingState(id, state);
        }
        #endregion
    }
}