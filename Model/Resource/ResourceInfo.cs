using System;

namespace Model
{
    [Serializable]
    public class ResourceInfo
    {
        public ResourceInfo() { }

        public ResourceInfo(int rIID, string rIName, ResourceType type, ResourceStore store, ProviderInfo provider, int number, double price, string inTime, string rISpec, int rIState, string rIRemark)
        {
            this.rIID = rIID;
            this.rIName = rIName;
            this.type = type;
            this.store = store;
            this.provider = provider;
            this.number = number;
            this.price = price;
            this.inTime = inTime;
            this.rISpec = rISpec;
            this.rIState = rIState;
            this.rIRemark = rIRemark;
        }

        private int rIID = 0;
        private string rIName = "";
        private ResourceType type = new ResourceType();
        private ResourceStore store = new ResourceStore();
        private ProviderInfo provider = new ProviderInfo();
        private int number = 0;
        private double price = 1.11;
        private string inTime="";
        private string rISpec = "";
        private int rIState = 0;
        private string rIRemark = "";

        public string RIRemark
        {
            get { return rIRemark; }
            set { rIRemark = value; }
        }

        public int RIState
        {
            get { return rIState; }
            set { rIState = value; }
        }

        public string RISpec
        {
            get { return rISpec; }
            set { rISpec = value; }
        }

        public string InTime
        {
            get { return inTime; }
            set { inTime = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public ProviderInfo Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        public ResourceStore Store
        {
            get { return store; }
            set { store = value; }
        }

        public ResourceType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string RIName
        {
            get { return rIName; }
            set { rIName = value; }
        }

        public int RIID
        {
            get { return rIID; }
            set { rIID = value; }
        }
    }
}
