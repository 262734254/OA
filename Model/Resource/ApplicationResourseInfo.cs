using System;

namespace Model
{
    [Serializable]
    public class ApplicationResourseInfo
    {
        public ApplicationResourseInfo() { }

        public ApplicationResourseInfo(BorrowApplication borrow,int type, ResourceInfo resource, int number)
        {
            this.borrow = borrow;
            this.aRType = type;
            this.resource = resource;
            this.number = number;
        }

        public ApplicationResourseInfo(StockApplication stock,int type,ResourceInfo resource, int number)
        {
            this.stock = stock;
            this.aRType = type;
            this.resource = resource;
            this.number = number;
        }
       
        public ApplicationResourseInfo(int type,ResourceInfo resource, int number)
        {
            this.aRType = type;
            this.resource = resource;
            this.number = number;
        }

        private BorrowApplication borrow = new BorrowApplication();
        private StockApplication stock = new StockApplication();
        private int aRType = 0;
        private ResourceInfo resource = new ResourceInfo();
        private int number = 0;
        
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        
        public ResourceInfo Resource
        {
            get { return resource; }
            set { resource = value; }
        }

        public int ARType
        {
            get { return aRType; }
            set { aRType = value; }
        }

        public BorrowApplication Borrow
        {
            get { return borrow; }
            set { borrow = value; }
        }

        public StockApplication Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
