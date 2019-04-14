
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 会议室实体类
    /// </summary>
    public class RoomInfo
    {
        private int rID;                //会议室ID
        private string roomName;        //会议室名称
        private int containNum;         //容纳人数
        private string equip;           //室内设备

        public string Equip
        {
            get { return equip; }
            set { equip = value; }
        }
        private string romeAddr;        //会议室地点           
        private string romeCondition;

        public string RomeCondition
        {
            get { return romeCondition; }
            set { romeCondition = value; }
        }
        public string RomeAddr
        {
            get { return romeAddr; }
            set { romeAddr = value; }
        }
        public int ContainNum
        {
            get { return containNum; }
            set { containNum = value; }
        }

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }

        public int RID
        {
            get { return rID; }
            set { rID = value; }
        }
    }
}

