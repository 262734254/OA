using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

using IDAL.Matter;
using OAFactory;
using IDAL.Car;
using IDAL.Power;
namespace BLL.Power
{
    public class UserInfoManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

      
        private static IUserInfoService userService = factory.CreateUserInfoService();


        /// <summary>
        ///根据部门ID查询该部门下的所有员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<UserInfo> GetAllUsersByDepartmentId(int id)
        {
            return userService.GetAllUsersByDepartmentId(id);
        }
        /// <summary>
        /// 根据用户ID查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserInfo GetAllUserById(int id)
        {
            return userService.GetAllUserById(id);
        }
        /// <summary>
        /// 查询所有员工信息
        /// </summary>
        /// <returns></returns>
        public static IList<UserInfo> GetAllUser() 
        {
            return userService.GetAllUser();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static int AddCalendar(UserInfo userInfo)
        {
            return userService.AddCalendar(userInfo);
        }
        /// <summary>
        /// /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="uId"></param>
        /// </summary>
        /// <param name="uId"></param>
        public static void UpdateUserInfo(UserInfo uId)
        {
            userService.UpdateUserInfo(uId);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="uid"></param>
        public static  void ModifyPassword(int uid,string password)
        {
            userService.ModifyPassword(uid,password);
        }
        /// <summary>
        /// /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
       public static bool Login(string userName, string password,out UserInfo user,out string message)
        {
            bool falg = false;
            UserInfo u = userService.Login(userName);
            if (u!=null)
            {
                if (u.Password==password)
                {
                    user = u;
                    message = "登录成功";
                    falg = true;
                }
                else
                {
                    user = null;
                    falg = false;
                    message = "密码不正确";
                }
            }
            else
            {
                user = null;
                message = "用户名不存在";
                falg = true;
            }
            return falg;
        }
       public static IList<UserInfo> SelectUserInfoByAll(string identityCard, string name, string userStatus, string departmentID) 
       {
           return userService.SelectUserInfoByAll(identityCard, name, userStatus, departmentID);
       }
       public static UserInfo GetUserState(string userState)
       {
           return userService.GetUserState(userState);
       }

         /// <summary>
        /// 根据接收者名称得到消息ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
       public static int GetLeaveIDByMName(string name)
       {
           return userService.GetLeaveIDByMName(name);
       }
       public static IList<UserInfo> GetAllUserInfoName(string name)
       {
           return userService.GetAllUserInfoName(name);
       }
    }
}
