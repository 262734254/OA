using System;
using System.Data;
using System.Text;

namespace Model
{
    /// <summary>
    /// ¿‡task°£
    /// </summary>
    /// 
    [Serializable]
    public class UserInfo
    {
        public UserInfo()
        { }
        #region Model
        private int uid;
        private string name;
        private string sex;
        private int age;
        private string identitycard;
        private string password;
        private int mobilephone;
        private string homephone;
        private string address;
        private int? qq;
        private string email;
        private string msn;
        private string remark;
        private string userstatus;
        private Department department=new Department();
        private string picture;

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UID
        {
            set { uid = value; }
            get { return uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { name = value; }
            get { return name; }
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
        public int Age
        {
            set { age = value; }
            get { return age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IdentityCard
        {
            set { identitycard = value; }
            get { return identitycard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { password = value; }
            get { return password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MobilePhone
        {
            set { mobilephone = value; }
            get { return mobilephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HomePhone
        {
            set { homephone = value; }
            get { return homephone; }
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
        public int? Qq
        {
            set { qq = value; }
            get { return qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { email = value; }
            get { return email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Msn
        {
            set { msn = value; }
            get { return msn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { remark = value; }
            get { return remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserStatus
        {
            set { userstatus = value; }
            get { return userstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
       
        #endregion Model
    }
}
