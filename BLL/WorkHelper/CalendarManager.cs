using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

using IDAL.Matter;
using OAFactory;
using IDAL.WorkHelper;


namespace BLL.WorkHelper
{
    public class CalendarManager
    {

        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        // private static ICarsService carService = factory.CreateCarService();
        private static ICalendarService calendar = factory.CreateCalendarService();
        public static int AddCalendar(Calendar cal)
        {
            return calendar.AddCalendar(cal);
        }
        public static Calendar GetAllCalendarByID(int id)
        {
            return calendar.GetAllCalendarByID(id);
        }
        public static IList<Calendar> GetAllCalendar()
        {
            return calendar.GetAllCalendar();
        }
        public static void GetCalendarById(Calendar cal)
        {
            calendar.GetCalendarById(cal);
        }
        public static IList<Calendar> SelectLeaveWord(string calTheme, string remaindTime)
        {
            return calendar.SelectLeaveWord(calTheme, remaindTime);
        }
        public static int DeleteCalendar(int id)
        {
            return calendar.DeleteCalendar(id);
        }
        public static int UpdateTime(int id)
        {
            return calendar.UpdateTime(id);
        }
       
    }
}
