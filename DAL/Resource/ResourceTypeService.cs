using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using IDAL.Resource;
using IDAL;
using Model;

/******************************
 * ResourceTypeService类
 * 资源类型数据访问类
 ******************************/
namespace DAL.Resource
{
    public class ResourceTypeService : IResourceTypeService
    {

        private const string ADD_RESOURCETYPE = "usp_add_ResourceType";
        private const string UPDATE_RESOURCETYPE = "usp_update_ResourceType";
        private const string DELETE_RESOURCETYPE = "usp_delete_ResourceType";
        private const string GET_RESOURCETYPE = "usp_get_ResourceType";
        private const string GET_ALL_RESOURCETYPE = "usp_search_ResourceType";//

        #region IBaseFace 成员

        int IBaseFace.Add(object obj)
        {
            int val = 0;
            if (obj is ResourceType)
            {
                ResourceType item = (ResourceType)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@RTName",item.RTName),
                    new SqlParameter("@RTRemark",item.RTRemark)
                };
                val = DBHelper.ExecuteNonQueryProc(ADD_RESOURCETYPE, parms);
            }
            return val;
        }

        int IBaseFace.Update(object obj)
        {
            int val = 0;
            if (obj is ResourceType)
            {
                ResourceType item = (ResourceType)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@RTName",item.RTName),
                    new SqlParameter("@RTRemark",item.RTRemark),
                    new SqlParameter("@RTID",item.RTID)
                };
                val = DBHelper.ExecuteNonQueryProc(UPDATE_RESOURCETYPE, parms);
            }
            return val;
        }

        int IBaseFace.Delete(int id)
        {
            int val = DBHelper.ExecuteNonQueryProc(DELETE_RESOURCETYPE, new SqlParameter("@RTID", id));
            return val;
        }

        object IBaseFace.Get(int id)
        {
            ResourceType item = null;
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(GET_RESOURCETYPE, new SqlParameter("@RTID", id)))
            {
                if (reader.Read())
                {
                    item = new ResourceType(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }
            return item;
        }


        #endregion

        #region IResourceTypeService 成员

        IList<ResourceType> IResourceTypeService.GetAllResourceType(ResourceType item)
        {
            IList<ResourceType> items = new List<ResourceType>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@RTID",item.RTID),
                new SqlParameter("@RTName",item.RTName),
                new SqlParameter("@RTRemark",item.RTRemark)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(GET_ALL_RESOURCETYPE, parms))
            {
                while (reader.Read())
                {
                    ResourceType rt = new ResourceType(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    items.Add(rt);
                }
            }
            return items;
        }

        #endregion
    }
}
