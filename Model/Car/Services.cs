using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable()]
   public class Services
   {
       private int s_Id;              //维修编号

       public int S_Id
       {
           get { return s_Id; }
           set { s_Id = value; }
       }
       private string s_Branch;        //报 修 部门

       public string S_Branch
       {
           get { return s_Branch; }
           set { s_Branch = value; }
       }
       private string s_People;        //报  修 人

       public string S_People
       {
           get { return s_People; }
           set { s_People = value; }
       }
       private string carMark;             //车牌号码

       public string CarMark
       {
           get { return carMark; }
           set { carMark = value; }
       }
       private string s_Type;          //维修类型

       public string S_Type
       {
           get { return s_Type; }
           set { s_Type = value; }
       }
       private DateTime beginDate;      //进厂日期

       public DateTime BeginDate
       {
           get { return beginDate; }
           set { beginDate = value; }
       }
       private DateTime endDate;       //出厂日期

       public DateTime EndDate
       {
           get { return endDate; }
           set { endDate = value; }
       }
       private string s_FactoryName;   //维修厂名称

       public string S_FactoryName
       {
           get { return s_FactoryName; }
           set { s_FactoryName = value; }
       }
       private string jerquePeople;    //验  收 人

       public string JerquePeople
       {
           get { return jerquePeople; }
           set { jerquePeople = value; }
       }
       private double s_Cost;         //报 修 费用


       public double S_Cost
       {
           get { return s_Cost; }
           set { s_Cost = value; }
       }
       private double useCost;        //使用费用

       public double UseCost
       {
           get { return useCost; }
           set { useCost = value; }
       }
       private string s_Reason; //维修原因

       public string S_Reason
       {
           get { return s_Reason; }
           set { s_Reason = value; }
       }
       private string carType;          //维修原因

       public string CarType
       {
           get { return carType; }
           set { carType = value; }
       }
       private string s_Result;         //维修结果

       public string S_Result
       {
           get { return s_Result; }
           set { s_Result = value; }
       }
       private string billPhoto;         //清单照片

       public string BillPhoto
       {
           get { return billPhoto; }
           set { billPhoto = value; }
       }
    }
}
