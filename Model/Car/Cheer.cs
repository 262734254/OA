using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable()]
  public  class Cheer
    {
        private int c_Id;            //加油编号

        public int C_Id
        {
            get { return c_Id; }
            set { c_Id = value; }
        }
        private DateTime c_Date;     //加油日期

        public DateTime C_Date
        {
            get { return c_Date; }
            set { c_Date = value; }
        }
        private string c_CheerType;     //加油类型

        public string C_CheerType
        {
            get { return c_CheerType; }
            set { c_CheerType = value; }
        }

        private string carMark;     //车牌号

        public string CarMark
        {
            get { return carMark; }
            set { carMark = value; }
        }
        private string c_Station;    //加油站

        public string C_Station
        {
            get { return c_Station; }
            set { c_Station = value; }
        }
        private string c_CarType;     //车辆类型 

        public string C_CarType
        {
            get { return c_CarType; }
            set { c_CarType = value; }
        }


        private double c_Sum;       //加油金额

        public double C_Sum
        {
            get { return c_Sum; }
            set { c_Sum = value; }
        }
        private string remark;       //备注

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string billPhoto;    //清单照片

        public string BillPhoto
        {
            get { return billPhoto; }
            set { billPhoto = value; }
        }
    }
}
