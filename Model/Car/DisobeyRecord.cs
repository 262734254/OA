using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable()]
   public class DisobeyRecord
    {
        private int dR_Id;              //事故违章编号

        public int DR_Id
        {
            get { return dR_Id; }
            set { dR_Id = value; }
        }
        private string carMark;         //车牌号

        public string CarMark
        {
            get { return carMark; }
            set { carMark = value; }
        }
        private string dR_Department;   //事 故 违章部门

        public string DR_Department
        {
            get { return dR_Department; }
            set { dR_Department = value; }
        }
        private string dR_People;        //事故违章人

        public string DR_People
        {
            get { return dR_People; }
            set { dR_People = value; }
        }

        private string dR_Locus;         //事 故 违章地点

        public string DR_Locus
        {
            get { return dR_Locus; }
            set { dR_Locus = value; }
        }
        private DateTime dR_Date;        //事故违章日期

        public DateTime DR_Date
        {
            get { return dR_Date; }
            set { dR_Date = value; }
        }
        private double dR_Sum;          //罚 款 金额

        public double DR_Sum
        {
            get { return dR_Sum; }
            set { dR_Sum = value; }
        }


        private string dR_Circs;         //伤 亡 情况

        public string DR_Circs
        {
            get { return dR_Circs; }
            set { dR_Circs = value; }
        }
        private double dR_Expense;      //经  济  损  失

        public double DR_Expense
        {
            get { return dR_Expense; }
            set { dR_Expense = value; }
        }
        private double factCost;        //实际赔偿费

        public double FactCost
        {
            get { return factCost; }
            set { factCost = value; }
        }


        private string dR_Type;          //类型（违章，事故）

        public string DR_Type
        {
            get { return dR_Type; }
            set { dR_Type = value; }
        }
        private string dr_CarType;       //用车类型

        public string Dr_CarType
        {
            get { return dr_CarType; }
            set { dr_CarType = value; }
        }


        private string dR_Explain;       //情况说明

        public string DR_Explain
        {
            get { return dR_Explain; }
            set { dR_Explain = value; }
        }
        private string remark;           //备     注

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string billPhoto;        //清单照片

        public string BillPhoto
        {
            get { return billPhoto; }
            set { billPhoto = value; }
        }

    }
}
