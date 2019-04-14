using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Matter;
using OAFactory;
using Model;
using IDAL.Meeting;
namespace BLL.Meeting
{
   public class MeetingSummaryManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IMeetingSummaryService meetingService = factory.CreateMeetingSummaryService();

        #region IMeetingSummaryService 成员
        /// <summary>
        /// //添加会议纪要信息
        /// </summary>
        /// <param name="meetingSummary"></param>
        public static void AddMeetingSummary(MeetingSummary meetingSummary)
        {
            meetingService.AddMeetingSummary(meetingSummary);
        }
        /// <summary>
        /// 更新会议纪要信息
        /// </summary>
        /// <param name="meetingSummary"></param>
        public static void UpdateMeetingSummary(MeetingSummary meetingSummary)
        {
            meetingService.UpdateMeetingSummary(meetingSummary);
        }
        /// <summary>
        /// 删除会议纪要信息
        /// </summary>
        /// <param name="strMSID"></param>
        public static void DelMeetingSummary(string strMSID)
        {
            meetingService.DelMeetingSummary(strMSID);
        }
        /// <summary>
        /// 根据会议纪要ID查询会议纪要详情信息
        /// </summary>
        /// <param name="MSID"></param>
        /// <returns></returns>
        public static MeetingSummary GetMeetingSummaryById(int MSID)
        {
            return meetingService.GetMeetingSummaryById(MSID);
        }
        /// <summary>
        /// 根据会议名称，开始时间和结束时间查询会议纪要信息
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static IList<MeetingSummary> SearchMeetingSummary(string roomName, string beginTime, string endTime)
        {
            return meetingService.SearchMeetingSummary(roomName, beginTime, endTime);
        }

        #endregion
    }
}
