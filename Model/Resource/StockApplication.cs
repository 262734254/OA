using System;

namespace Model
{
    [Serializable]
    public class StockApplication
    {
        public StockApplication() { }
        public StockApplication(int sAID, UserInfo user, string sATime, double needCharge, string sACause, string sARemark, string isExamine)
        {
            this.sAID = sAID;
            this.user = user;
            this.sATime = sATime;
            this.needCharge = needCharge;
            this.sACause = sACause;
            this.sARemark = sARemark;
            this.isExamine = isExamine;
            
        }

        private int sAID = 0;
        private UserInfo user = new UserInfo();
        private string sATime = "";
        private double needCharge = 0;
        private string sACause = "";
        private string sARemark = "";
        private string isExamine = "";

        public string IsExamine
        {
            get { return isExamine; }
            set { isExamine = value; }
        }

        public string SARemark
        {
            get { return sARemark; }
            set { sARemark = value; }
        }

        public string SACause
        {
            get { return sACause; }
            set { sACause = value; }
        }

        public double NeedCharge
        {
            get { return needCharge; }
            set { needCharge = value; }
        }

        public string SATime
        {
            get { return sATime; }
            set { sATime = value; }
        }

        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }

        public int SAID
        {
            get { return sAID; }
            set { sAID = value; }
        }
    }
}
