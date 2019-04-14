using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Car
{
    /// <summary>
    /// 实体类Car_UserInfo 。
    /// </summary>
    [Serializable]
    public class Car_UserInfo
    {

        public Car_UserInfo()
        { }
        #region Model
        private int userid;
        private string username;
        private int age;
        private string sex;
        private string address;
        private string phone;
        private string state;
        /// <summary>
        /// 
        /// </summary>
        public int UserId
        {
            set { userid = value; }
            get { return userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            set { age = value; }
            get { return age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { sex = value; }
            get { return sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { address = value; }
            get { return address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string State
        {
            set { state = value; }
            get { return state; }
        }
        #endregion Model

    }
}









