using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IDAL.Matter;
using OAFactory;
using IDAL.Power;
using Model;


namespace BLL.Power
{
    public class RolePowerManager
    {
        public RolePowerManager()
        {
        }

        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IRolePowerService rolePowerService = factory.CreateRolePowerServcice();


        #region IRolePowerManager 成员


        //static不能延迟初始化 

        public string UpdateRole(Role role)
        {
            return rolePowerService.UpdateRole(role);
        }

        public int DeletePowers(string powerIdsStr)
        {
            return rolePowerService.DeletePowers(powerIdsStr);
        }

        #endregion

        #region IRolePowerManager 成员

        public string AddPower(Model.Power power)
        {
            return rolePowerService.AddPower(power);
        }

        public string AddRole(Role role)
        {
            return rolePowerService.AddRole(role);
        }

        #endregion

        #region IRolePowerManager 成员




        public string DeleteRoleByRoleIds(string roleIds)
        {
            return rolePowerService.DeleteRoleByRoleIds(roleIds);
        }

        #endregion

        #region IRolePowerManager 成员


        public Role SelectRoleByRoleId(int roleid)
        {
            return rolePowerService.SelectRoleByRoleId(roleid);
        }

        #endregion

        #region IRolePowerManager 成员


        public IList<Model.Power> SelectPowersByRoleId(int roleId)
        {
            return rolePowerService.SelectPowersByRoleId(roleId);
        }

        #endregion

        #region IRolePowerManager 成员


        public IList<Role> SelectAllRoles()
        {
            return rolePowerService.SelectAllRoles();
        }

        #endregion

        #region IRolePowerManager 成员


        public IList<Role> SelectAllRolesByUserID(int userId)
        {
            return rolePowerService.SelectAllRolesByUserID(userId);
        }

        public int GiveUserMananyRolesByUserIds(string userIdsStr, string powerIdsStr)
        {
            return rolePowerService.GiveUserMananyRolesByUserIds(userIdsStr, powerIdsStr);
        }

        #endregion

        #region IRolePowerManager 成员


        public IList<Role> selectRolesByRoleName(string roleName, int pageIndex, int PageSize, string where, out int pageCount, out int dataCount)
        {
            return rolePowerService.selectRolesByRoleName(roleName, pageIndex, PageSize, where, out pageCount, out dataCount);
        }

        #endregion


        //根据不同条件查询权限 condition=parent 查询根节点 parenId某父节点的子节点权限
        public IList<Model.Power> GetPowerNodeInfoByConditions(string condition, int parenId)
        {
            return rolePowerService.GetPowerNodeInfoByConditions(condition, parenId);


        }

        public IList<Model.Power> GetPowerByRoleIdAndPrarentId(int roleId, int prarentId)
        {
            return rolePowerService.GetPowerByRoleIdAndPrarentId(roleId, prarentId);
        }

        public int AddRolePower(int roleId, int powerId)
        {
            return rolePowerService.AddRolePower(roleId, powerId);
        }

        //删除角色的权限
        public int DeletePowerRole(int roleId, int powerId)
        {

            return rolePowerService.DeletePowerRole(roleId, powerId);
        }
        public IList<Model.Power> selectAllPowersByUserId(int uid)
        {
            return rolePowerService.selectAllPowersByUserId(uid);

        }

        //禁用页面控件
        public IList<Model.Hidden> selectRoleByHiddenContol(int rold)
        {
            return rolePowerService.selectRoleByHiddenContol(rold);

        }
        //根据用户名查询所有权限
        public DataTable SelectPowersByUID(int userId)
        {
            return rolePowerService.SelectPowersByUID(userId);
        }

        public int DeletePowersByRoleId(int roleId)
        {
            return rolePowerService.DeletePowersByRoleId(roleId);
        }

        public int UpdatePaddingStatus(string staus, int taskId)
        {
            return rolePowerService.UpdatePaddingStatus(staus, taskId);
        }
    }
}
