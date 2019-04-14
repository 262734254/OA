using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 会场安排信息实体类
    /// </summary>
    public class RoomArrage
    {
        private int id;  //会场安排信息ID

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime beginTime;//开始时间

        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }
        private DateTime endTime;//结束时间

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private string roomName;//会场名称

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        private string meetingType;//会议类型

        public string MeetingType
        {
            get { return meetingType; }
            set { meetingType = value; }
        }
        private string romeState;//会场状态

        public string RomeState
        {
            get { return romeState; }
            set { romeState = value; }
        }
        private string chargeMan;//会议负责人

        public string ChargeMan
        {
            get { return chargeMan; }
            set { chargeMan = value; }
        }
        private string instancyDegree;//紧急程度

        public string InstancyDegree
        {
            get { return instancyDegree; }
            set { instancyDegree = value; }
        }
        private string remark;//备注

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}