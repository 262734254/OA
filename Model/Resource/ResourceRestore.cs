using System;

namespace Model
{
    [Serializable]
    public class ResourceRestore
    {
        public ResourceRestore() { }
        public ResourceRestore(int rRID, BorrowApplication borrow, ResourceInfo resource, UserInfo user, string rRTime, int rRNumber, string rRRemark)
        {
            this.rRID = rRID;
            this.borrow = borrow;
            this.resource = resource;
            this.user = user;
            this.rRTime = rRTime;
            this.rRNumber = rRNumber;
            this.rRRemark = rRRemark;
        }

        private int rRID = 0;
        private BorrowApplication borrow = new BorrowApplication();
        private ResourceInfo resource = new ResourceInfo();
        private UserInfo user = new UserInfo();
        private string rRTime;
        private int rRNumber = 0;
        private string rRRemark = "";

        public string RRRemark
        {
            get { return rRRemark; }
            set { rRRemark = value; }
        }

        public int RRNumber
        {
            get { return rRNumber; }
            set { rRNumber = value; }
        }

        public string RRTime
        {
            get { return rRTime; }
            set { rRTime = value; }
        }

        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }

        public ResourceInfo Resource
        {
            get { return resource; }
            set { resource = value; }
        }

        public BorrowApplication Borrow
        {
            get { return borrow; }
            set { borrow = value; }
        }

        public int RRID
        {
            get { return rRID; }
            set { rRID = value; }
        }
    }
}
