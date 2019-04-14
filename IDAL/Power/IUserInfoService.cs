using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL.Power
{
    public interface IUserInfoService
    {

         IList<UserInfo> GetAllUsersByDepartmentId(int id);
         UserInfo GetAllUserById(int id);
         IList<UserInfo> GetAllUser();
         int AddCalendar(UserInfo userInfo);
         void UpdateUserInfo(UserInfo uId);
         UserInfo Login(string userName);
         IList<UserInfo> SelectUserInfoByAll(string identityCard, string name, string userStatus, string departmentID);
         UserInfo GetUserState(string userState);
         void ModifyPassword(int uid,string password);
         int GetLeaveIDByMName(string name);
         IList<UserInfo> GetAllUserInfoName(string name);
    }
}
