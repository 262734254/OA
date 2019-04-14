
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL.WorkHelper
{
    public interface ILeaveWordService
    {
        IList<LeaveWord> GetAllLeaveWord();
        LeaveWord GetLeaveWordMsgTypeId(int msgTypeId);
        int AddLeaveWord(LeaveWord leave);
        LeaveWord GetLeaveWordById(int id);
        IList<LeaveWord> SelectLeaveWordByAll(string msgTypeId, string msgState, string meetingBeginTime);
        void DeleteLeaveWordById(int id);
        IList<LeaveWord> GetAllLeaveWordTitle(string msgState);
       
    }
}
