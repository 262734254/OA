using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   /// <summary>
   /// 会议申请表实体类
   /// </summary>
   public class MeetingApplication
    {
        private int mID;                                                     //会议申请ID
        private string applicationMan;                                      //会议申请人，关联用户表ID字段
        private string meetTitle;                                          //会议名称
        private string meetContent;                                       //会议大体内容
        private Department departmentID = new Department();              //主办部门
        private string withinEnlistMan;                                 //公司内部出席人员

        private string meetType;                                      //会议类型
        private int meetNumber;                                      //参与人数
        private string compere                   ;                  //主持人
        private string meetingSummary;                             //会议纪要人 
        private string instancyDegree;                            //紧急程度
        private DateTime applicationTime;                        //申请时间
        private DateTime beginTime;                             //开始时间
        private DateTime endTime;                              //结束时间
        private string state;                                 //状态

        private RoomInfo roomInfo = new RoomInfo();

        public RoomInfo RoomInfo
        {
            get { return roomInfo; }
            set { roomInfo = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
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

        public DateTime ApplicationTime
        {
            get { return applicationTime; }
            set { applicationTime = value; }
        }

        public string InstancyDegree
        {
            get { return instancyDegree; }
            set { instancyDegree = value; }
        }
        public string  MeetingSummary
        {
            get { return meetingSummary; }
            set { meetingSummary = value; }
        }
       
        public string  Compere
        {
            get { return compere; }
            set { compere = value; }
        }

        public int MeetNumber
        {
            get { return meetNumber; }
            set { meetNumber = value; }
        }

        public string MeetType
        {
            get { return meetType; }
            set { meetType = value; }
        }

      
        public string WithinEnlistMan
        {
            get { return withinEnlistMan; }
            set { withinEnlistMan = value; }
        }
        public Department DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }
        public string MeetContent
        {
            get { return meetContent; }
            set { meetContent = value; }
        }
        public string MeetTitle
        {
            get { return meetTitle; }
            set { meetTitle = value; }
        }

        public string  ApplicationMan
        {
            get { return applicationMan; }
            set { applicationMan = value; }
        }
        public int MID
        {
            get { return mID; }
            set { mID = value; }
        }
    }
}
