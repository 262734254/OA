using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Model;
using IDAL.Power;

namespace DAL.Power
{
    public class UserInfoService : IUserInfoService
    {
       
 
       


        #region IUserInfoService 成员
        /// <summary>
        ///根据部门ID查询该部门下的所有员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      public  IList<UserInfo> GetAllUsersByDepartmentId(int id)
        {
            string proName = "usp_selectAllUserByDepartmentId";
            DataTable tb = DBHelper.GetDataTableProc(proName, new SqlParameter("@DepartmentId", id));
            IList<UserInfo> list = new List<UserInfo>();

            foreach (DataRow r in tb.Rows)
            {
                UserInfo d = new UserInfo();
                d.Name = (string)r["Name"];
                d.UID = (int)r["UID"];
                list.Add(d);
            }
            return list;

        }
        /// <summary>
        /// 根据用户ID查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public UserInfo GetAllUserById(int id)
        {
            IDepartmentService department = new DepartmentService();
            int classId;
            string proName = "usp_selectUserInfoById";
            UserInfo d = null;
            using (SqlDataReader r = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@UID", id)))
            {
                if(r.Read())
                {
                    d = new UserInfo();
                    d.Name = (string)r["Name"];
                    d.Sex = (string)r["Sex"];
                    d.Age = (int)r["Age"];
                    d.IdentityCard = (string)r["IdentityCard"];
                    d.Password = (string)r["Password"];
                    d.MobilePhone = (int)r["MobilePhone"];
                    d.HomePhone = (string)r["HomePhone"];
                    d.Address = (string)r["HomePhone"];
                    d.Qq = (int)r["Qq"];
                    d.Email = (string)r["Email"];
                    d.Msn = (string)r["Msn"];
                    d.Remark = (string)r["Remark"];
                    d.UserStatus = (string)r["UserStatus"];
                    classId = (int)r["DepartmentID"];
                    d.UID = (int)r["UID"];
                    d.Department = department.GetAllDepartementById(classId);
                    d.Picture = (string)r["Picture"];

                }
                else
                {
                    return null;
                }

            }
            return d;
        }

        #endregion

        
        #region IUserInfoService 成员

        /// <summary>
        /// 查询所有员工信息
        /// </summary>
        /// <returns></returns>
       public IList<UserInfo> GetAllUser()
        {
            IDepartmentService department = new DepartmentService();
            int classId;
            string proName = "usp_selectUserInfo";

            DataTable tb = DBHelper.GetDataTableProc(proName, null);
            IList<UserInfo> list = new List<UserInfo>();
            foreach (DataRow r in tb.Rows)
            {
                UserInfo d = new UserInfo();
                d.Name = (string)r["Name"];
                d.Sex = (string)r["Sex"];
                d.Age = (int)r["Age"];
                d.IdentityCard = (string)r["IdentityCard"];
                d.Password = (string)r["Password"];
                d.MobilePhone = (int)r["MobilePhone"];
                d.HomePhone = (string)r["HomePhone"];
                d.Address = (string)r["HomePhone"];
                d.Qq = (int)r["Qq"];
                d.Email = (string)r["Email"];
                d.Msn = (string)r["Msn"];
                d.Remark = (string)r["Remark"];
                d.UserStatus = (string)r["UserStatus"];
                classId = (int)r["DepartmentID"];
                d.UID = (int)r["UID"];
                d.Department = department.GetAllDepartementById(classId);
                d.Picture = (string)r["Picture"];
                list.Add(d);

            }
            return list;
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
       public int AddCalendar(UserInfo userInfo)
        {
            string sql = "usp_InsertUserInfo";
            SqlParameter[] para = new SqlParameter[]
            {
            new SqlParameter("@Name",userInfo.Name),
            new SqlParameter("@Sex",userInfo.Sex),
            new SqlParameter("@Age",userInfo.Age),
            new SqlParameter("@IdentityCard",userInfo.IdentityCard),
            new SqlParameter("@Password",userInfo.Password),
            new SqlParameter("@MobilePhone",userInfo.MobilePhone),
            new SqlParameter("@HomePhone",userInfo.HomePhone),
            new SqlParameter("@Address",userInfo.Address),
            new SqlParameter("@Qq",userInfo.Qq),
            new SqlParameter("@Email",userInfo.Email),
            new SqlParameter("@Msn",userInfo.Msn),
            new SqlParameter("@Remark",userInfo.Remark),
            new SqlParameter("@UserStatus",userInfo.UserStatus),
            new SqlParameter("@DepartmentID",userInfo.Department.Id),
            new SqlParameter("@Picture",userInfo.Picture)
            
            };
            return DBHelper.ExecuteNonQueryProc(sql, para);
        }

        #endregion

        #region IUserInfoService 成员

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="uId"></param>
        public void UpdateUserInfo(UserInfo uId)
        {
            string sql = "usp_UpdateUserInfoById";
            SqlParameter[] para = new SqlParameter[]
           {
              new SqlParameter("@UID",uId.UID),
               new SqlParameter("@Name",uId.Name),
               new SqlParameter("@Sex",uId.Sex),
               new SqlParameter("@Age",uId.Age),
               new SqlParameter("@IdentityCard",uId.IdentityCard),
               new SqlParameter("@Password",uId.Password),
               new SqlParameter("@Address",uId.Address),
               new SqlParameter("@MobilePhone",uId.MobilePhone),
               new SqlParameter("@HomePhone",uId.HomePhone),
               new SqlParameter("@Qq",uId.Qq),
               new SqlParameter("@Email",uId.Email),
               new SqlParameter("@Msn",uId.Msn),
               new SqlParameter("@Remark",uId.Remark),
               new SqlParameter("@UserStatus",uId.UserStatus),
               new SqlParameter("@DepartmentID",uId.Department.Id),
               new SqlParameter("@Picture",uId.Picture),
           };
            DBHelper.ExecuteNonQueryProc(sql, para);
        }

        #endregion

        #region IUserInfoService 成员

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public UserInfo Login(string userName)
        {
           
            IDepartmentService department = new DepartmentService();
            
            string proName = "usp_LoginUser";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName)
                
            };
            UserInfo d = null;
            using (SqlDataReader r = DBHelper.ExecuteReaderProc(proName, para))
            {
                if(r.Read())
                {
                    d = new UserInfo();
                    d.Name = (string)r["Name"];
                    d.Sex = (string)r["Sex"];
                    d.Age = (int)r["Age"];
                    d.IdentityCard = (string)r["IdentityCard"];
                    d.Password = (string)r["Password"];
                    d.MobilePhone = (int)r["MobilePhone"];
                    d.HomePhone = (string)r["HomePhone"];
                    d.Address = (string)r["HomePhone"];
                    d.Qq = (int)r["Qq"];
                    d.Email = (string)r["Email"];
                    d.Msn = (string)r["Msn"];
                    d.Remark = (string)r["Remark"];
                    d.UserStatus = (string)r["UserStatus"];
                    d.UID = (int)r["UID"];
                    d.Department = department.GetAllDepartementById(Convert.ToInt32(r["DepartmentID"]));
                    d.Picture = (string)r["Picture"];

                    return d;
                }
                else
                {
                    return null;
                }

            }
           
        }

        #endregion

        #region IUserInfoService 成员


        public IList<UserInfo> SelectUserInfoByAll(string identityCard, string name, string userStatus, string departmentID)
        {
            int departments;
            
            string sql = "usp_SelectUserInfoAll";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("@Name",name==null?"":name),
              new SqlParameter("@IdentityCard",identityCard==null?"":identityCard),
              new SqlParameter("@UserStatus",userStatus==null?"":userStatus),
              new SqlParameter("@DepartmentID",departmentID==null?"":departmentID)
            };
            IList<UserInfo> list = new List<UserInfo>();
            IDepartmentService department = new DepartmentService();

            using (DataTable table = DBHelper.GetDataTableProc(sql, para))
            {
                foreach (DataRow row in table.Rows)
                {
                    UserInfo user = new UserInfo();
                    user.UID = (int)row["UID"];
                    user.Name = (string)row["Name"];
                    user.Sex = (string)row["Sex"];
                    user.Age = (int)row["Age"];
                    user.IdentityCard = (string)row["IdentityCard"];
                    user.Password = (string)row["Password"];
                    user.MobilePhone = (int)row["MobilePhone"];
                    user.HomePhone = (string)row["HomePhone"];
                    user.Address = (string)row["Address"];
                    user.Qq = (int)row["Qq"];
                    user.Msn = (string)row["Msn"];
                    user.Email = (string)row["Email"];
                    user.Remark = (string)row["Remark"];
                    user.UserStatus = (string)row["UserStatus"];
                    departments = (int)row["DepartmentID"];
                    user.Department = department.GetAllDepartementById(departments);
                    user.Picture = (string)row["Picture"];
                    list.Add(user);
                }
                return list;
            }
        }

        #endregion

        #region IUserInfoService 成员


        public UserInfo GetUserState(string userState)
        {
            IDepartmentService department = new DepartmentService();
            int classId;
            string proName = "usp_selectUserState";
            UserInfo d = null;
            using (SqlDataReader r = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@UserStatus", userState)))
            {
                if (r.Read())
                {
                    d = new UserInfo();
                    d.Name = (string)r["Name"];
                    d.Sex = (string)r["Sex"];
                    d.Age = (int)r["Age"];
                    d.IdentityCard = (string)r["IdentityCard"];
                    d.Password = (string)r["Password"];
                    d.MobilePhone = (int)r["MobilePhone"];
                    d.HomePhone = (string)r["HomePhone"];
                    d.Address = (string)r["HomePhone"];
                    d.Qq = (int)r["Qq"];
                    d.Email = (string)r["Email"];
                    d.Msn = (string)r["Msn"];
                    d.Remark = (string)r["Remark"];
                    d.UserStatus = (string)r["UserStatus"];
                    classId = (int)r["DepartmentID"];
                    d.UID = (int)r["UID"];
                    d.Department = department.GetAllDepartementById(classId);
                    d.Picture = (string)r["Picture"];

                }
                else
                {
                    return null;
                }

            }
            return d;
        }

        #endregion

        #region IUserInfoService 成员

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="uid"></param>
        public void ModifyPassword(int uid,string password)
        {
            string sql = "usp_ModifyPassword";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@uid",uid),
                new SqlParameter("@password",password)
            };
            DBHelper.ExecuteNonQueryProc(sql,para);
        }

        #endregion
       

        /// <summary>
        /// 根据接收者名称得到消息ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetLeaveIDByMName(string name)
        {
            int id = 0;
            string sql = "usp_GetUserIDByName";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@Name", name)))
            {
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["UID"]);
                }
            }
            return id;
        }



        #region IUserInfoService 成员


        public IList<UserInfo> GetAllUserInfoName(string name)
        {
            int departments;
            string sql = "usp_selectAddressManagerName";
            IList<UserInfo> list = new List<UserInfo>();
            IDepartmentService department = new DepartmentService();
            UserInfo user = null;
            using (DataTable table = DBHelper.GetDataTableProc(sql, new SqlParameter("@Name", name)))
            {
                foreach (DataRow row in table.Rows)
                {
                    user = new UserInfo(); 
                    user.UID = (int)row["UID"];
                    user.Name = (string)row["Name"];
                    user.Sex = (string)row["Sex"];
                    user.Age = (int)row["Age"];
                    user.IdentityCard = (string)row["IdentityCard"];
                    user.Password = (string)row["Password"];
                    user.MobilePhone = (int)row["MobilePhone"];
                    user.HomePhone = (string)row["HomePhone"];
                    user.Address = (string)row["Address"];
                    user.Qq = (int)row["Qq"];
                    user.Msn = (string)row["Msn"];
                    user.Email = (string)row["Email"];
                    user.Remark = (string)row["Remark"];
                    user.UserStatus = (string)row["UserStatus"];
                    departments = (int)row["DepartmentID"];
                    user.Department = department.GetAllDepartementById(departments);
                    user.Picture = (string)row["Picture"];
                    list.Add(user);
                }
                return list;
            }
        }

        #endregion
    }
}
