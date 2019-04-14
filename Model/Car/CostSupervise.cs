using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable()]
   public class CostSupervise
    {
        private int cS_Id;            //费用管理编号

        public int CS_Id
        {
            get { return cS_Id; }
            set { cS_Id = value; }
        }
        private DateTime cS_Date;     //费用日期

        public DateTime CS_Date
        {
            get { return cS_Date; }
            set { cS_Date = value; }
        }
        private string carMark;       //车牌号

        public string CarMark
        {
            get { return carMark; }
            set { carMark = value; }
        }
        private string cS_Item;       //费用项

        public string CS_Item
        {
            get { return cS_Item; }
            set { cS_Item = value; }
        }
        private double cS_Cost;      //费用金额

        public double CS_Cost
        {
            get { return cS_Cost; }
            set { cS_Cost = value; }
        }
        private string cS_CarType;    //车辆类型

        public string CS_CarType
        {
            get { return cS_CarType; }
            set { cS_CarType = value; }
        }
        private string remark;        //备注

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string billPhoto;     //清单照片

        public string BillPhoto
        {
            get { return billPhoto; }
            set { billPhoto = value; }
        }
    }
}
