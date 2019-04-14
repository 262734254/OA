using System;

namespace Model
{
    [Serializable]
    public class BorrowApplication
    {
        public BorrowApplication() { }
        public BorrowApplication(int bAID, UserInfo user, string bATime, int bAType, string exigentGrade, string isExamine, string bARemark)
        {
            this.bAID = bAID;
            this.user = user;
            this.bATime = bATime;
            this.bAType = bAType;
            this.exigentGrade = exigentGrade;
            this.bARemark = bARemark;
            this.isExamine = isExamine;
        }

        private int bAID = 0;
        private UserInfo user = new UserInfo();
        private string bATime="";
        private int bAType = 0;
        private string exigentGrade = "";
        private string bARemark = "";
        private string isExamine = "";

        public string IsExamine
        {
            get { return isExamine; }
            set { isExamine = value; }
        }

       
        public string BARemark
        {
            get { return bARemark; }
            set { bARemark = value; }
        }

        public string ExigentGrade
        {
            get { return exigentGrade; }
            set { exigentGrade = value; }
        }

        public int BAType
        {
            get { return bAType; }
            set { bAType = value; }
        }

        public string BATime
        {
            get { return bATime; }
            set { bATime = value; }
        }

        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }

        public int BAID
        {
            get { return bAID; }
            set { bAID = value; }
        }
    }
}
