using System;

namespace Model
{
    [Serializable]
    public class ResourceType
    {
        public ResourceType() { }
        public ResourceType(int rTID, string rTName, string rTRemark)
        {
            this.rTID = rTID;
            this.rTName = rTName;
            this.rTRemark = rTRemark;
        }

        private int rTID = 0;
        private string rTName = "";
        private string rTRemark = "";

        public string RTRemark
        {
            get { return rTRemark; }
            set { rTRemark = value; }
        }

        public string RTName
        {
            get { return rTName; }
            set { rTName = value; }
        }

        public int RTID
        {
            get { return rTID; }
            set { rTID = value; }
        }
    }
}
