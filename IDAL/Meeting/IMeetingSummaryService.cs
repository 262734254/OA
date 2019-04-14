
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL.Meeting
{
   public interface IMeetingSummaryService
    {
       //添加会议纪要信息
       void AddMeetingSummary(MeetingSummary meetingSummary);
       //更新会议纪要信息
       void UpdateMeetingSummary(MeetingSummary meetingSummary);
       //删除会议纪要信息
       void DelMeetingSummary(string strMSID);
       //根据会议纪要ID查询会议纪要详情信息
       MeetingSummary GetMeetingSummaryById(int MSID);
       //根据会议名称，开始时间和结束时间查询会议纪要信息
       IList<MeetingSummary> SearchMeetingSummary(string roomName,string beginTime,string endTime);
    }
}
