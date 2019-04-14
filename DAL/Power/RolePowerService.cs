using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL.Power;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Power
{
    public class RolePowerService : IRolePowerService
    {

        #region IRolePowerService 成员

        public string AddPower(Model.Power power)
        {

            string proName = "usp_AddNewPower";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@PowerName" ,power.PowerName),
                    new SqlParameter("@URL",power.URL),
                    new SqlParameter("@prarentId",power.prarentId),
                    new SqlParameter("@description",power.Description),
           };
            return DBHelper.ExecuteNonQueryProc(proName, pars).ToString();

        }

        public string AddRole(Role role)
        {

            string proName = "usp_AddNewRole";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@RoleName" ,role.RoleName),
                    new SqlParameter("@Description",role.Description),
                     new SqlParameter("@departMentId",role.Department.Id),
                    new SqlParameter("@YesOrNo",role.RoleName)
           };
            return DBHelper.ExecuteNonQueryProcOutPut(proName, 3, pars).ToString();


        }

        public string UpdateRole(Role role)
        {
            string proName = "usp_UpdateRole";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@roleId" ,role.roleId),
                    new SqlParameter("@RoleName" ,role.RoleName),
                    new SqlParameter("@Description",role.Description),
                    new SqlParameter("@departmentId",role.Department.Id),
                    new SqlParameter("@YesOrNo",role.RoleName)
           };
            return DBHelper.ExecuteNonQueryProcOutPut(proName, 4, pars).ToString();

        }

        public int DeletePowers(string powerIdsStr)
        {
            string proName = "usp_DeletePower";

            return DBHelper.ExecuteNonQueryProc(proName, new SqlParameter("@PowerIdsStr", powerIdsStr));

        }

        #endregion


        #region IRolePowerService 成员

        /// <summary>
        /// 角色查询使用存储过程分页
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="pageIndex">页数索引</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="where">条件</param>
        /// <param name="pageCount">页数</param>
        /// <param name="dataCount">总记录数</param>
        /// <returns>角色列表集合</returns>
        public IList<Role> selectRolesByRoleName(string roleName, int pageIndex, int PageSize, string where, out int pageCount, out int dataCount)
        {
            //如果角色名称为空 则查询所有角色 否则查询角色
            if (roleName.Trim() == "")
                where = "";
            else
                where = "roleName like  '%" + roleName + "%'";

            IList<Role> list = new List<Role>();
            string proName = "sp_page";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@strTable" ,"Role"),
                    new SqlParameter("@strColumn","RoleId"),
                    new SqlParameter("@intColType",SqlDbType.Int,4),
                    new SqlParameter("@intOrder",SqlDbType.Int,4),
                    new SqlParameter("@strColumnlist" ,"*"),
                    new SqlParameter("@intPageSize",PageSize),
                    new SqlParameter("@intPageNum",pageIndex),           
                    new SqlParameter("@strWhere",where),          
                    new SqlParameter("@intPageCount",4),
                    new SqlParameter("@dataCount",1)
           };
            pars[2].Value = 0;
            pars[3].Value = 0;
            SqlCommand cmd = new SqlCommand(proName, DBHelper.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            pars[8].Direction = ParameterDirection.Output;
            pars[9].Direction = ParameterDirection.Output;
            cmd.Parameters.AddRange(pars);
            pageCount = 0;
            dataCount = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.roleId = (int)reader["roleId"];
                        role.RoleName = (string)reader["RoleName"];
                        role.Description = (string)reader["Description"];
                        list.Add(role);
                    }

                }

            }

            pageCount = Convert.ToInt32(cmd.Parameters[8].Value);////放在ExecuteReader关闭之后取值
            dataCount = Convert.ToInt32(cmd.Parameters[9].Value);

            return list;

        }

        #endregion

        #region IRolePowerService 成员


        public string DeleteRoleByRoleIds(string roleIds)
        {
            string proName = "usp_DeleteRoleByRoleIds";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@roleIdsStr",roleIds),
                new SqlParameter("@yesOrNo","")
           
            };
            return DBHelper.ExecuteNonQueryProcOutPut(proName, 1, pars).ToString();

        }

        #endregion

        #region IRolePowerService 成员


        public Role SelectRoleByRoleId(int roleid)
        {
            string proName = "usp_selectRoleByRoleId";
            Role role = new Role();

            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@roleId", roleid)))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {

                        role.roleId = (int)reader["roleId"];
                        role.RoleName = (string)reader["RoleName"];
                        role.Description = (string)reader["Description"];
                        role.Department.Id = (int)reader["departmentId"];
                    }

                }

            }
            return role;
        }

        #endregion

        #region IRolePowerService 成员


        public IList<Model.Power> SelectPowersByRoleId(int roleId)
        {

            string proName = "usp_selectPowersByRoleId";
            IList<Model.Power> list = new List<Model.Power>();
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@roleId", roleId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model.Power power = new Model.Power();
                        power.Description = (string)reader["Description"];
                        power.PowerId = (int)reader["PowerId"];
                        power.PowerName = (string)reader["PowerName"];
                        power.prarentId = (int)reader["prarentId"];
                        power.URL = (string)reader["URL"];

                        list.Add(power);
                    }

                }
            }
            return list;
        }

        #endregion

        #region IRolePowerService 成员


        public IList<Role> SelectAllRoles()
        {
            IList<Role> list = new List<Role>();
            string proName = "usp_selectAllRoles";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, null))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.roleId = (int)reader["roleId"];
                        role.RoleName = (string)reader["RoleName"];
                        role.Description = (string)reader["Description"];
                        list.Add(role);
                    }

                }

            }

            return list;

        }

        #endregion

        #region IRolePowerService 成员


        public IList<Role> SelectAllRolesByUserID(int userId)
        {
            IList<Role> list = new List<Role>();
            string proName = "usp_SelectAllRolesByUserID";
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@uid", userId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.roleId = (int)reader["roleId"];
                        role.RoleName = (string)reader["RoleName"];
                        role.Description = (string)reader["Description"];
                        list.Add(role);
                    }

                }

            }

            return list;
        }

        #endregion

        #region IRolePowerService 成员


        public int GiveUserMananyRolesByUserIds(string userIdsStr, string powerIdsStr)
        {
            string proName = "usp_GiveUserMananyRolesByUserIds";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@sql" ,userIdsStr),
                    new SqlParameter("@sql2" ,powerIdsStr)
                   
           };
            return DBHelper.ExecuteNonQueryProc(proName, pars);

        }

        #endregion

        #region IRolePowerService 成员


        public IList<Model.Power> GetPowerNodeInfoByConditions(string condition, int parenId)
        {
            IList<Model.Power> list = new List<Model.Power>();
            string proName = "Usp_GetPowerNodeInfoByConditions";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@str" ,condition),
                    new SqlParameter("@nodeId" ,parenId)
                   
           };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, pars))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model.Power p = new Model.Power();
                        p.PowerId = (int)reader["PowerId"];
                        p.PowerName = (string)reader["PowerName"];
                        p.prarentId = (int)reader["prarentId"];
                        p.URL = (string)reader["URL"];
                        p.Description = (string)reader["Description"];
                        list.Add(p);
                    }

                }

            }

            return list;
        }

        #endregion

        #region IRolePowerService 成员


        public IList<Model.Power> GetPowerByRoleIdAndPrarentId(int roleId, int prarentId)
        {

            IList<Model.Power> list = new List<Model.Power>();
            string proName = "Usp_GetPowerByRoleIdAndPrarentId";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@roleId" ,roleId),
                    new SqlParameter("@prarentId" ,prarentId)
                   
           };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, pars))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model.Power p = new Model.Power();
                        p.PowerId = (int)reader["PowerId"];
                        p.PowerName = (string)reader["PowerName"];
                        p.prarentId = (int)reader["prarentId"];
                        p.URL = (string)reader["URL"];
                        p.Description = (string)reader["Description"];
                        list.Add(p);
                    }

                }

            }

            return list;



        }

        #endregion

        #region IRolePowerService 成员


        public int AddRolePower(int roleId, int powerId)
        {

            string proName = "usp_AddRolePwer";
            SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@roleId" ,roleId),
                    new SqlParameter("@powerId" ,powerId)
                   
           };
            return DBHelper.ExecuteNonQueryProc(proName, pars);
        }

        #endregion

        #region IRolePowerService 成员


        public int DeletePowerRole(int roleId, int powerId)
        {

            string proName = "usp_DeleteRolePwer";
            SqlParameter[] pars = new SqlParameter[]
            {
                     new SqlParameter("@roleId" ,roleId),
                    new SqlParameter("@powerId" ,powerId)
                   
           };
            return DBHelper.ExecuteNonQueryProc(proName, pars);
        }

        #endregion

        #region IRolePowerService 成员


        public IList<Model.Power> selectAllPowersByUserId(int uid)
        {
            IList<Model.Power> list = new List<Model.Power>();
            string proName = "usp_selectAllPowersByUserId";

            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@uid", uid)))
            {
                while (reader.Read())
                {
                    Model.Power p = new Model.Power();
                    p.PowerId = (int)reader["PowerId"];
                    p.PowerName = (string)reader["PowerName"];
                    p.prarentId = (int)reader["prarentId"];
                    p.URL = (string)reader["URL"];
                    p.Description = (string)reader["Description"];
                    list.Add(p);
                }



            }

            return list;
        }

        #endregion

        #region IRolePowerService 成员


        public IList<Hidden> selectRoleByHiddenContol(int rold)
        {
            IList<Model.Hidden> list = new List<Model.Hidden>();
            string proName = "usp_selectRoleByHiddenContol";

            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(proName, new SqlParameter("@roleId", rold)))
            {

                while (reader.Read())
                {
                    Model.Hidden p = new Model.Hidden();
                    p.Add = (int)reader["Add"];
                    p.Checke = (int)reader["checked"];
                    p.Comein = (int)reader["Comein"];
                    p.Delete = (int)reader["Delete"];
                    p.Id = (int)reader["Id"];
                    p.Select = (int)reader["Select"];
                    p.Roleid = (int)reader["Roleid"];
                    p.Send = (int)reader["Send"];
                    p.Update = (int)reader["Update"];
                    p.Back = (int)reader["Back"];

                    list.Add(p);
                }



            }

            return list;
        }


        //根据用户名查询所有权限
        public DataTable SelectPowersByUID(int userId)
        {

            string proName = "usp_selectPowersByUID";

            DataTable dt = DBHelper.GetDataTableProc(proName, new SqlParameter("@UId", userId));

            return dt;



        }

        public int DeletePowersByRoleId(int roleId)
        {
            string proName = "usp_DeletePowersByRoleId";

            return DBHelper.ExecuteNonQueryProc(proName, new SqlParameter("@roleId", roleId));

          
        }

        #endregion

        #region IRolePowerService 成员


        public int UpdatePaddingStatus(string staus, int taskId)
        {
            string proName = "usp_UpdatePaddingStatus";
             SqlParameter[] pars = new SqlParameter[]
            {
                    new SqlParameter("@staus" ,staus),
                    new SqlParameter("@taskId" ,taskId)
                   
            };
            return DBHelper.ExecuteNonQueryProc(proName, pars);

        }

        #endregion
    }
}
