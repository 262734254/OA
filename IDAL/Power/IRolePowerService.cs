using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL.Power
{
   public interface IRolePowerService
    {
        /// 添加权限
       string AddPower(Model.Power power);

        //添加角色
        string AddRole(Role role);

        //修改角色
        string UpdateRole(Role role);

        //删除权限
        int DeletePowers(string powerIdsStr);


        //批量删除角色 包括单个角色
        string DeleteRoleByRoleIds(string roleIds);

        //根据角色编号查询角色
        Role SelectRoleByRoleId(int roleid);

        //查询某个角色所拥有的所有权限
        IList<Model.Power> SelectPowersByRoleId(int roleId);

        //查询所有的角色
        IList<Role> SelectAllRoles();

        //根据用户编号查询拥有的角色
        IList<Role> SelectAllRolesByUserID(int userId);

        // 批量给用户分配多个角色
        int GiveUserMananyRolesByUserIds(string userIdsStr, string powerIdsStr);

        //根据角色名称查询所有角色 分页带条件的存储过程
        IList<Role> selectRolesByRoleName(string roleName, int pageIndex, int PageSize, string where, out int pageCount, out int dataCount);

        //根据不同条件查询权限 condition=parent 查询根节点 parenId某父节点的子节点权限
        IList<Model.Power> GetPowerNodeInfoByConditions(string condition,int parenId);


        //根据角色编号和模块编号获取权限
        IList<Model.Power> GetPowerByRoleIdAndPrarentId(int roleId, int prarentId);

         //给角色添加权限
        int AddRolePower(int roleId, int powerId);

         //删除角色的权限
        int DeletePowerRole(int roleId, int powerId);

         //查询用户所有的的权限
        IList<Model.Power> selectAllPowersByUserId(int uid);

       //禁用页面控件
        IList<Model.Hidden> selectRoleByHiddenContol(int rold);

        //根据用户Id查询所有权限
        DataTable SelectPowersByUID(int userId);

       //删除所有权限
        int DeletePowersByRoleId(int roleId);

        int UpdatePaddingStatus(string staus, int taskId);
   }
}
