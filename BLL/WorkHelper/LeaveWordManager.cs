using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Matter;
using OAFactory;
using IDAL.Car;
using IDAL.WorkHelper;
using Model;
namespace BLL.WorkHelper
{
  public class LeaveWordManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        //private static ICarsService carService = factory.CreateCarService();
        private static ILeaveWordService leaveWordService = factory.CreateLeaveWordService();
        public static IList<LeaveWord> GetAllLeaveWord()
        {
            return leaveWordService.GetAllLeaveWord();
        }
        public static LeaveWord GetLeaveWordMsgTypeId(int msgTypeId)
        {
            return leaveWordService.GetLeaveWordMsgTypeId(msgTypeId);
        }
        public static int AddLeaveWord(LeaveWord leave)
        {
            return leaveWordService.AddLeaveWord(leave);
        }
        public static LeaveWord GetLeaveWordById(int id)
        {
            return leaveWordService.GetLeaveWordById(id);
        }
        public static IList<LeaveWord> SelectLeaveWordByAll(string msgTypeId, string msgState, string meetingBeginTime)
        {
            return leaveWordService.SelectLeaveWordByAll(msgTypeId, msgState, meetingBeginTime);
        }
        public static void DeleteLeaveWordById(int id)
        {
            leaveWordService.DeleteLeaveWordById(id);
        }
        public static IList<LeaveWord> GetAllLeaveWordTitle(string msgState)
        {
            return leaveWordService.GetAllLeaveWordTitle(msgState);
        }

   }
}
