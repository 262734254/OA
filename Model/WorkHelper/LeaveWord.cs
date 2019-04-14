using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
   public class LeaveWord
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string msgTitle = String.Empty;

        public string MsgTitle
        {
            get { return msgTitle; }
            set { msgTitle = value; }
        }
        private string msgContent;

        public string MsgContent
        {
            get { return msgContent; }
            set { msgContent = value; }
        }
        private MessageType msgTypeId = new MessageType();

        public MessageType MsgTypeId
        {
            get { return msgTypeId; }
            set { msgTypeId = value; }
        }
        private UserInfo senderUser = new UserInfo();

        public UserInfo SenderUser
        {
            get { return senderUser; }
            set { senderUser = value; }
        }
        private UserInfo receiverUser = new UserInfo();

        public UserInfo ReceiverUser
        {
            get { return receiverUser; }
            set { receiverUser = value; }
        }
        private DateTime msgSendTime;

        public DateTime MsgSendTime
        {
            get { return msgSendTime; }
            set { msgSendTime = value; }
        }
        private string msgState;

        public string MsgState
        {
            get { return msgState; }
            set { msgState = value; }
        }
        private string meetingAddr;

        public string MeetingAddr
        {
            get { return meetingAddr; }
            set { meetingAddr = value; }
        }
        private string chargeMan;

        public string ChargeMan
        {
            get { return chargeMan; }
            set { chargeMan = value; }
        }
        private DateTime meetingBeginTime;

        public DateTime MeetingBeginTime
        {
            get { return meetingBeginTime; }
            set { meetingBeginTime = value; }
        }
        private string meetingType;

        public string MeetingType
        {
            get { return meetingType; }
            set { meetingType = value; }
        }
        private string isAgree;

        public string IsAgree
        {
            get { return isAgree; }
            set { isAgree = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
       
    }
}
