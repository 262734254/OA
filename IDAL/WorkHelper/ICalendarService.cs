using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL.WorkHelper
{
   public interface ICalendarService
    {
       Calendar GetAllCalendarByID(int id);
       IList<Calendar> GetAllCalendar();
       int AddCalendar(Calendar cal);
       void GetCalendarById(Calendar cal);
       IList<Calendar> SelectLeaveWord(string calTheme, string remaindTime);
       int DeleteCalendar(int id);
       int UpdateTime(int id);
    }
}
