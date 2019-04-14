using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tunnel.BLL
{
    public class Systemtime
    {
        static List<string> list;//本周日期
        /// <summary>
        /// 获取本周日期字符串
        /// </summary>
        /// <returns>日期字符串</returns>
        public static List<string> GetThisWeekDate()
        {
            list = new List<string>(); 
            DateTime someDay = DateTime.Today;
            int wd = (int)someDay.DayOfWeek;      //今天星期几
//            for (int i = 1 - wd; i < 8 - wd; i++)
            for (int i = -2; i < 1; i++)
            {
                DateTime currentDay = someDay.AddDays(i);
                list.Add(currentDay.ToString().Split(' ')[0].ToString());
            }
            return list;
        }
        /// <summary>
        /// 验证日期格式是否正确
        /// </summary>
        /// <param name="times">日期字符串</param>
        /// <returns>true为正确，false为错误</returns>
        public static bool AuthenticationTime(string times)
        {
            Regex reg = new Regex(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
            return reg.Match(times).Success;
        }
    }

}


