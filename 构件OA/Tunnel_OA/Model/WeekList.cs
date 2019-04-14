using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    public class WeekList
    {
        public WeekList()
        {
        
        }
        private string week;
        private string date;
        private string mouth;

        public string Mouth
        {
            get { return mouth; }
            set { mouth = value; }
        }
        private string day;

        public string Day
        {
            get { return day; }
            set { day = value; }
        }
        public string Week
        {
            get { return week; }
            set { week = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
