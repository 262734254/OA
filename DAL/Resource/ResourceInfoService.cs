using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using Model;
using IDAL.Resource;
using IDAL;

/******************************
 * ResourceInfoService类
 * 资源信息数据访问类
 ******************************/
namespace DAL.Resource
{
    public class ResourceInfoService : IResourceInfoService
    {
        private IResourceTypeService rts = new ResourceTypeService();
        private IResourceStoreService rss = new ResourceStoreService();
        private IProviderInfoService ps = new ProviderInfoService();

        private const string ADD_RESOURCE = "usp_add_Resource";
        private const string UPDATE_RESOURCE = "usp_update_Resource";
        private const string DELETE_RESOURCE = "usp_delete_Resource";
        private const string GET_RESOURCE = "usp_get_Resource";
        private const string GET_ALL_RESOURCEINFO = "usp_search_Resource";

        #region IBaseFace 成员

        int IBaseFace.Add(object obj)
        {
            int val = 0;
            if (obj is ResourceInfo)
            {
                ResourceInfo item = (ResourceInfo)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@RIName",item.RIName),
                    new SqlParameter("@RTID",item.Type.RTID),
                    new SqlParameter("@RSID",item.Store.RSID),
                    new SqlParameter("@PID",item.Provider.PID),
                    new SqlParameter("@Number",item.Number),
                    new SqlParameter("@Price",item.Price),
                    new SqlParameter("@InTime",item.InTime),
                    new SqlParameter("@RISpec",item.RISpec),
                    new SqlParameter("@RIState",item.RIState),
                    new SqlParameter("@RIRemark",item.RIRemark)
                };
                val = DBHelper.ExecuteNonQueryProc(ADD_RESOURCE, parms);
            }
            return val;
        }

        int IBaseFace.Update(object obj)
        {
            int val = 0;
            if (obj is ResourceInfo)
            {
                ResourceInfo item = (ResourceInfo)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@RIName",item.RIName),
                    new SqlParameter("@RTID",item.Type.RTID),
                    new SqlParameter("@RSID",item.Store.RSID),
                    new SqlParameter("@PID",item.Provider.PID),
                    new SqlParameter("@Number",item.Number),
                    new SqlParameter("@Price",item.Price),
                    new SqlParameter("@InTime",item.InTime),
                    new SqlParameter("@RISpec",item.RISpec),
                    new SqlParameter("@RIState",item.RIState),
                    new SqlParameter("@RIRemark",item.RIRemark),
                    new SqlParameter("@RIID",item.RIID)
                };
                val = DBHelper.ExecuteNonQueryProc(UPDATE_RESOURCE, parms);
            }
            return val;
        }

        int IBaseFace.Delete(int id)
        {
            int val = DBHelper.ExecuteNonQueryProc(DELETE_RESOURCE, new SqlParameter("@RIID", id));
            return val;
        }

        object IBaseFace.Get(int id)
        {
            ResourceInfo item = null;
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(GET_RESOURCE, new SqlParameter("@RIID", id)))
            {
                if (reader.Read())
                {
                    item = new ResourceInfo(reader.GetInt32(0), reader.GetString(1), (ResourceType)rts.Get(reader.GetInt32(2)), (ResourceStore)rss.Get(reader.GetInt32(3)), (ProviderInfo)ps.Get(reader.GetInt32(4)), reader.GetInt32(5), reader.GetDouble(6), reader.GetDateTime(7).ToString(), reader.GetString(8), reader.GetInt32(9), reader.GetString(10));
                }
            }
            return item;
        }

        #endregion

        #region IResourceInfoService 成员

        IList<ResourceInfo> IResourceInfoService.GetAllResourceInfo(ResourceInfo item)
        {
            IList<ResourceInfo> items = new List<ResourceInfo>();
            SqlParameter[] parms=new SqlParameter[]
            {
                new SqlParameter("@RIName",item.RIName),
                new SqlParameter("@RTID",item.Type.RTID),
                new SqlParameter("@RSID",item.Store.RSID),
                new SqlParameter("@PID",item.Provider.PID),
                new SqlParameter("@Number",item.Number),
                new SqlParameter("@Price",item.Price),
                new SqlParameter("@InTime",item.InTime),
                new SqlParameter("@RISpec",item.RISpec),
                new SqlParameter("@RIState",item.RIState),
                new SqlParameter("@RIRemark",item.RIRemark),
                new SqlParameter("@RIID",item.RIID)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(GET_ALL_RESOURCEINFO, parms))
            {
                while (reader.Read())
                {
                    ResourceInfo ri = new ResourceInfo(reader.GetInt32(0), reader.GetString(1), (ResourceType)rts.Get(reader.GetInt32(2)), (ResourceStore)rss.Get(reader.GetInt32(3)), (ProviderInfo)ps.Get(reader.GetInt32(4)), reader.GetInt32(5),reader.GetDouble(6),reader.GetDateTime(7).ToString(), reader.GetString(8), reader.GetInt32(9), reader.GetString(10));
                    items.Add(ri);
                }
            }
            return items;
        }

        #endregion
    }
}
