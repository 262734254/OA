using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Resource;
using System.Data.SqlClient;
using IDAL.Power;
using Model;
using IDAL;
using DAL.Power;
/******************************
 * ResourceRestoreService类
 * 资源归还数据访问类
 ******************************/
namespace DAL.Resource
{
    public class ResourceRestoreService : IResourceRestoreService
    {
        private IBorrowApplicationService bas = new BorrowApplicationService();
        private IResourceInfoService ris = new ResourceInfoService();
        private IUserInfoService uis = new UserInfoService();

        private const string ADD_RESOURCERESTORE = "usp_add_ResourceRestore";
        private const string UPDATE_RESOURCERESTORE = "usp_update_ResourceRestore";
        private const string DELETE_RESOURCERESTORE = "usp_delete_ResourceRestore";
        private const string GET_RESOURCERESTORE = "usp_get_ResourceRestore";
        private const string SEARCH_RESOURCERESTORE = "usp_search_ResourceRestore";

        #region IResourceRestoreService 成员

        IList<ResourceRestore> IResourceRestoreService.GetAllResourceRestore(ResourceRestore item)
        {
            IList<ResourceRestore> items = new List<ResourceRestore>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@BAID",item.Borrow.BAID),
                new SqlParameter("@RIID",item.Resource.RIID),
                new SqlParameter("@UID",item.User.UID),
                new SqlParameter("@RRTime",item.RRTime),
                new SqlParameter("@RRNumber",item.RRNumber),
                new SqlParameter("@RRRemark",item.RRRemark),
                new SqlParameter("@RRID",item.RRID)
            };
            using (SqlDataReader sdr = DBHelper.ExecuteReaderProc(SEARCH_RESOURCERESTORE, parms))
            {
                while (sdr.Read())
                {
                    ResourceRestore val = null;
                    val = new ResourceRestore(sdr.GetInt32(0), (BorrowApplication)bas.Get(sdr.GetInt32(1)), (ResourceInfo)ris.Get(sdr.GetInt32(2)), (UserInfo)uis.GetAllUserById(sdr.GetInt32(3)), sdr.GetDateTime(4).ToString(), sdr.GetInt32(5), sdr.GetString(6));
                    items.Add(val);
                }
            }
            return items;
        }

        #endregion

        #region IBaseFace 成员

        int IBaseFace.Add(object obj)
        {
            int val = 0;
            if (obj is ResourceRestore)
            {
                ResourceRestore item = (ResourceRestore)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@BAID",item.Borrow.BAID),
                    new SqlParameter("@RIID",item.Resource.RIID),
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@RRTime",item.RRTime),
                    new SqlParameter("@RRNumber",item.RRNumber),
                    new SqlParameter("@RRRemark",item.RRRemark)
                };
                val = DBHelper.ExecuteNonQueryProc(ADD_RESOURCERESTORE, parms);
            }
            return val;
        }

        int IBaseFace.Update(object obj)
        {
            int val = 0;
            if (obj is ResourceRestore)
            {
                ResourceRestore item = (ResourceRestore)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@BAID",item.Borrow.BAID),
                    new SqlParameter("@RIID",item.Resource.RIID),
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@RRTime",item.RRTime),
                    new SqlParameter("@RRNumber",item.RRNumber),
                    new SqlParameter("@RRRemark",item.RRRemark),
                    new SqlParameter("@RRID",item.RRID)
                };
                val = DBHelper.ExecuteNonQueryProc(UPDATE_RESOURCERESTORE, parms);
            }
            return val;
        }

        int IBaseFace.Delete(int id)
        {
            int val = 0;
            val = DBHelper.ExecuteNonQueryProc(DELETE_RESOURCERESTORE, new SqlParameter("@RRID", id));
            return val;
        }

        object IBaseFace.Get(int id)
        {
            ResourceRestore item = null;
            using (SqlDataReader sdr = DBHelper.ExecuteReaderProc(GET_RESOURCERESTORE, new SqlParameter("@RRID", id)))
            {
                if (sdr.Read())
                    item = new ResourceRestore(sdr.GetInt32(0), (BorrowApplication)bas.Get(sdr.GetInt32(1)), (ResourceInfo)ris.Get(sdr.GetInt32(2)), (UserInfo)uis.GetAllUserById(sdr.GetInt32(3)), sdr.GetDateTime(4).ToString(), sdr.GetInt32(5), sdr.GetString(6));
            }
            return item;
        }

        #endregion
    }
}
