using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// 实体类Car_Enter 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>

    [Serializable]
    public class Car_Enter
    {
        public Car_Enter()
        { }
        #region Model
        private int enterId;

        public int EnterId
        {
            get { return enterId; }
            set { enterId = value; }
        }
        private DateTime enterData;

        public DateTime EnterData
        {
            get { return enterData; }
            set { enterData = value; }
        }
        private Department dept = new Department();

        public Department Dept
        {
            get { return dept; }
            set { dept = value; }
        }
        private string man;

        public string Man
        {
            get { return man; }
            set { man = value; }
        }
        private Car_Type typeid = new Car_Type();

        public Car_Type Typeid
        {
            get { return typeid; }
            set { typeid = value; }
        }
        private string mark;

        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        private string dirver;

        public string Dirver
        {
            get { return dirver; }
            set { dirver = value; }
        }
        private string place;

        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        private decimal course;

        public decimal Course
        {
            get { return course; }
            set { course = value; }
        }
        private string ttion;

        public string Ttion
        {
            get { return ttion; }
            set { ttion = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private DateTime returnData;

        public DateTime ReturnData
        {
            get { return returnData; }
            set { returnData = value; }
        }

        private DateTime shiJiReturnDatd;

        public DateTime ShiJiReturnDatd
        {
            get { return shiJiReturnDatd; }
            set { shiJiReturnDatd = value; }
        }
        private decimal huiCheLiCheng;

        public decimal HuiCheLiCheng
        {
            get { return huiCheLiCheng; }
            set { huiCheLiCheng = value; }
        }
        #endregion Model


    }
}
