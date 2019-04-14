using System;

namespace Model
{
    [Serializable]
    public class ResourceStore
    {
        public ResourceStore() { }
        public ResourceStore(int rSID, string rSName, Department department, int storage, UserInfo user, string rSRemark)
        {
            this.rSID = rSID;
            this.rSName = rSName;
            this.department = department;
            this.storage = storage;
            this.user = user;
            this.rSRemark = rSRemark;
        }

        private int rSID = 0;
        private string rSName = "";
        private Department department = new Department();
        private int storage = 0;
        private UserInfo user = new UserInfo();
        private string rSRemark = "";

        public string RSRemark
        {
            get { return rSRemark; }
            set { rSRemark = value; }
        }

        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }

        public int Storage
        {
            get { return storage; }
            set { storage = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public string RSName
        {
            get { return rSName; }
            set { rSName = value; }
        }

        public int RSID
        {
            get { return rSID; }
            set { rSID = value; }
        }
    }
}
