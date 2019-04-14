using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
   public class Calendar
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private UserInfo uId = new UserInfo();

        public UserInfo UId
        {
            get { return uId; }
            set { uId = value; }
        }
        private string calTheme = String.Empty;

        public string CalTheme
        {
            get { return calTheme; }
            set { calTheme = value; }
        }
        private string calContent = String.Empty;

        public string CalContent
        {
            get { return calContent; }
            set { calContent = value; }
        }
        private DateTime remaindTime;

        public DateTime RemaindTime
        {
            get { return remaindTime; }
            set { remaindTime = value; }
        }
        private DateTime transactTime;

        public DateTime TransactTime
        {
            get { return transactTime; }
            set { transactTime = value; }
        }
        private string calType = String.Empty;

        public string CalType
        {
            get { return calType; }
            set { calType = value; }
        }
        private string repeat = String.Empty;

        public string Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }

       

   }
}
