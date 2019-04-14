using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL.Meeting
{
    /// <summary>
    /// 会议申请表接口
    /// </summary>
   public interface IMeetingApplicationService
    {
       //添加会议申请单
       void AddMeetingApplication(MeetingApplication meetingApplication);
       //查询会议申请单(根据会议名称和主办部门查询)
       IList<MeetingApplication> SearchMeetingApplication(string roomName,int departmentId);
       //根据ID查询会议申请单
       MeetingApplication GetMeetingApplicationById(int MSID);
       //根据申请单号删除一条会议申请
       void DelMeetingApplication(int MSID);
       //修改会议申请单
       void UpdateMeetintApplication(MeetingApplication meetingApplication);
      void ModifyMeetingState(int id,string state);

    }
}
