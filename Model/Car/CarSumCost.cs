using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Car
{
    [Serializable()]
   public class CarSumCost
    {

        private int carSumCostId;      //车辆费用编号

        public int CarSumCostId
        {
            get { return carSumCostId; }
            set { carSumCostId = value; }
        }
        private string carMark;        //车牌号

        public string CarMark
        {
            get { return carMark; }
            set { carMark = value; }
        }
        private double monthCost;      //月保费

        public double MonthCost
        {
            get { return monthCost; }
            set { monthCost = value; }
        }
        private double bridgeCost;      //路桥费

        public double BridgeCost
        {
            get { return bridgeCost; }
            set { bridgeCost = value; }
        }
        private double maintainCost;    //临时保管费

        public double MaintainCost
        {
            get { return maintainCost; }
            set { maintainCost = value; }
        }
        private double carwashCost;     //洗车费

        public double CarwashCost
        {
            get { return carwashCost; }
            set { carwashCost = value; }
        }
        private double insuranceCost;   //保险费

        public double InsuranceCost
        {
            get { return insuranceCost; }
            set { insuranceCost = value; }
        }
        private double cheerCost;      //加油费

        public double CheerCost
        {
            get { return cheerCost; }
            set { cheerCost = value; }
        }
        private double serviceCost;    //维修费

        public double ServiceCost
        {
            get { return serviceCost; }
            set { serviceCost = value; }
        }
        private double DisobeyRecorCost;  //事故违章费

        public double DisobeyRecorCost1
        {
            get { return DisobeyRecorCost; }
            set { DisobeyRecorCost = value; }
        }
        private double elseCost;        //其它费用

        public double ElseCost
        {
            get { return elseCost; }
            set { elseCost = value; }
        }
       
 
    }
}
