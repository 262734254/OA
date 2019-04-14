using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 会议纪要实体类
    /// </summary>
    public class MeetingSummary
    {
        private int mSID;                   //会议纪要ID
        private string meetingTitle;        //会议主题  
        private string meetingContent;      //会议内容
        private DateTime beginTime;         //开始时间
        private DateTime endTime;           //结束时间
        private string missingPeople;       //缺席人员
        private string chargeMan;    //负责人
        private string visitor;      //参与者
        private string compere;      //主持人

        public string Compere
        {
            get { return compere; }
            set { compere = value; }
        }

        public string Visitor
        {
            get { return visitor; }
            set { visitor = value; }
        }

        public string ChargeMan
        {
            get { return chargeMan; }
            set { chargeMan = value; }
        }

        public string MissingPeople
        {
            get { return missingPeople; }
            set { missingPeople = value; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        public string MeetingContent
        {
            get { return meetingContent; }
            set { meetingContent = value; }
        }

        public string MeetingTitle
        {
            get { return meetingTitle; }
            set { meetingTitle = value; }
        }

        public int MSID
        {
            get { return mSID; }
            set { mSID = value; }
        }
    }
}
