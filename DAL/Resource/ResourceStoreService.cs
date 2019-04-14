using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using IDAL.Power;
using DAL.Power;
using IDAL.Resource;
using Model;

/*************************
 * ResourceStoreService类
 * 资源室数据访问类
 *************************/
namespace DAL.Resource
{
    public class ResourceStoreService : IResourceStoreService
    {
        private IDepartmentService ds = new DepartmentService();
        private IUserInfoService uis = new UserInfoService();

        private const string ADD_RESOURCESTORE = "usp_add_ResourceStore";
        private const string UPDATE_RESOURCESTORE = "usp_update_ResourceStore";
        private const string DELETE_RESOURCESTORE = "usp_delete_ResourceStore";
        private const string GET_RESOURCESTORE = "usp_get_ResourceStore";
        private const string GET_ALL_RESOURCESTORE = "usp_search_ResourceStore";

        #region IBaseFace 成员

        int IDAL.IBaseFace.Add(object obj)
        {
            int val = 0;
            if (obj is ResourceStore)
            {
                ResourceStore item = (ResourceStore)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@RSName",item.RSName),
                    new SqlParameter("@DID",item.Department.Id),
                    new SqlParameter("@Storage",item.Storage),
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@RSRemark",item.RSRemark)
                };
                val = DBHelper.ExecuteNonQueryProc(ADD_RESOURCESTORE, parms);
            }
            return val;
        }

        int IDAL.IBaseFace.Update(object obj)
        {
            int val = 0;
            if (obj is ResourceRestore)
            {
                ResourceStore item = (ResourceStore)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@RSName",item.RSName),
                    new SqlParameter("@DID",item.Department.Id),
                    new SqlParameter("@Storage",item.Storage),
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@RSRemark",item.RSRemark),
                    new SqlParameter("@RSID",item.RSID)
                };
                val = DBHelper.ExecuteNonQueryProc(UPDATE_RESOURCESTORE, parms);
            }
            return val;
        }

        int IDAL.IBaseFace.Delete(int id)
        {
            int val = DBHelper.ExecuteNonQueryProc(DELETE_RESOURCESTORE, new SqlParameter("@RSID", id));
            return val;
        }

        object IDAL.IBaseFace.Get(int id)
        {
            ResourceStore item = null;
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(GET_RESOURCESTORE, new SqlParameter("@RSID", id)))
            {
                if (reader.Read())
                {
                    item = new ResourceStore(reader.GetInt32(0), reader.GetString(1), (Department)ds.GetAllDepartementById(reader.GetInt32(2)), reader.GetInt32(3), (UserInfo)uis.GetAllUserById(reader.GetInt32(4)), reader.GetString(5));
                }
            }
            return item;
        }

        #endregion

        #region IResourceStoreService 成员

        IList<ResourceStore> IResourceStoreService.GetAllResourceStore(ResourceStore item)
        {
            IList<ResourceStore> items = new List<ResourceStore>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@RSID",item.RSID),
                new SqlParameter("@RSName",item.RSName),
                new SqlParameter("@DID",item.Department.Id),
                new SqlParameter("@Storage",item.Storage),
                new SqlParameter("@UID",item.User.UID),
                new SqlParameter("@RSRemark",item.RSRemark)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(GET_ALL_RESOURCESTORE,parms))
            {
                while (reader.Read())
                {
                    ResourceStore var = new ResourceStore(reader.GetInt32(0), reader.GetString(1), (Department)ds.GetAllDepartementById(reader.GetInt32(2)), reader.GetInt32(3), (UserInfo)uis.GetAllUserById(reader.GetInt32(4)), reader.GetString(5));
                    items.Add(var);
                }
            }
            return items;
        }

        #endregion
    }
}
