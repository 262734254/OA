using System;

namespace Model
{
    [Serializable]
    public class SpoilageRegister
    {
        public SpoilageRegister() { }
        public SpoilageRegister(int sRID, BorrowApplication borrow, ResourceInfo resourse, UserInfo user, int sRNo, string sRGrade, string sRTime, string sRCause, string sRRemark)
        {
            this.sRID = sRID;
            this.borrow = borrow;
            this.resourse = resourse;
            this.user = user;
            this.sRNo = sRNo;
            this.sRGrade = sRGrade;
            this.sRTime = sRTime;
            this.sRCause = sRCause;
            this.sRRemark = sRRemark;
        }

        private int sRID = 0;
        private BorrowApplication borrow = new BorrowApplication();

        
        private ResourceInfo resourse = new ResourceInfo();
        private UserInfo user = new UserInfo();
        private int sRNo = 0;
        private string sRGrade = "";
        private string sRTime ="";
        private string sRCause = "";
        private string sRRemark = "";

        public string SRRemark
        {
            get { return sRRemark; }
            set { sRRemark = value; }
        }

        public string SRCause
        {
            get { return sRCause; }
            set { sRCause = value; }
        }

        public string SRTime
        {
            get { return sRTime; }
            set { sRTime = value; }
        }

        public string SRGrade
        {
            get { return sRGrade; }
            set { sRGrade = value; }
        }

        public int SRNo
        {
            get { return sRNo; }
            set { sRNo = value; }
        }

        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }

        public ResourceInfo Resourse
        {
            get { return resourse; }
            set { resourse = value; }
        }

        public BorrowApplication Borrow
        {
            get { return borrow; }
            set { borrow = value; }
        }

        public int SRID
        {
            get { return sRID; }
            set { sRID = value; }
        }
    }
}
