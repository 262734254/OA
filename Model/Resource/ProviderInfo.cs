using System;

namespace Model
{
    [Serializable]
    public class ProviderInfo
    {
        public ProviderInfo() { }
        public ProviderInfo(int pID, string pName, string dutyNo, string linkMan, string linkPhone, string address)
        {
            this.pID = pID;
            this.PName = pName;
            this.dutyNo = dutyNo;
            this.linkMan = linkMan;
            this.linkPhone = linkPhone;
            this.address = address;
        }
        private int pID = 0;
        private string pName = "";
        private string dutyNo = "";
        private string linkMan = "";
        private string linkPhone = "";
        private string address = "";

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string LinkPhone
        {
            get { return linkPhone; }
            set { linkPhone = value; }
        }

        public string LinkMan
        {
            get { return linkMan; }
            set { linkMan = value; }
        }

        public string DutyNo
        {
            get { return dutyNo; }
            set { dutyNo = value; }
        }

        public string PName
        {
            get { return pName; }
            set { pName = value; }
        }

        public int PID
        {
            get { return pID; }
            set { pID = value; }
        }
    }
}
