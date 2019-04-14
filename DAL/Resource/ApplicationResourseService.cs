using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Resource;
using System.Data.SqlClient;
using Model;

/*************************
 * ApplicationResourseService类
 * 申请资源信息数据访问类
 *************************/
namespace DAL.Resource
{
    public class ApplicationResourseService : IApplicationResourseService
    {
        private IResourceInfoService rs = new ResourceInfoService();
        private IBorrowApplicationService bas = new BorrowApplicationService();
        private IStockApplicationService sas = new StockApplicationService();

        #region 存储过程
        private const string ADD_APPLICATIONRESOURCE = "usp_add_ApplicationResource";
        private const string UPDATE_APPLICATIONRESOURCE = "usp_update_ApplicationResource";
        private const string DELETE_APPLICATIONRESOURCE = "usp_delete_ApplicationResource";
        private const string GET_APPLICATIONRESOURCE = "usp_get_ApplicationResource";
        private const string SEARCH_APPLICATIONRESOURCE = "usp_search_ApplicationResource";
        private const string SEARCH_APPLICATIONRESOURCE_BY_RESOURCENAME_AND_BORROWTYPE = "usp_search_ApplicationResource_By_ResourceName_And_BorrowType";
        #endregion

        #region IBaseFace 成员

        int IDAL.IBaseFace.Add(object obj)
        {
            int val = 0;
            if (obj is ApplicationResourseInfo)
            {
                ApplicationResourseInfo item = (ApplicationResourseInfo)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@ARID",item.ARType==1?item.Borrow.BAID:item.Stock.SAID),
                    new SqlParameter("@ARType",item.ARType),
                    new SqlParameter("@RIID",item.Resource.RIID),
                    new SqlParameter("@Number",item.Number)
                };
                val = DBHelper.ExecuteNonQueryProc(ADD_APPLICATIONRESOURCE, parms);
            }
            return val;
        }

        int IDAL.IBaseFace.Update(object obj)
        {
            int val = 0;
            if (obj is ApplicationResourseInfo)
            {
                ApplicationResourseInfo item = (ApplicationResourseInfo)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@ARType",item.ARType),
                    new SqlParameter("@RIID",item.Resource.RIID),
                    new SqlParameter("@Number",item.Number),
                    new SqlParameter("@ARID",item.ARType==1?item.Borrow.BAID:item.Stock.SAID)
                };
                val = DBHelper.ExecuteNonQueryProc(UPDATE_APPLICATIONRESOURCE, parms);
            }
            return val;
        }
        #endregion

        #region IApplicationResourseService 成员

        int IApplicationResourseService.Delete(int type, int arid, int riid)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ARType",type),
                new SqlParameter("@RIID",riid),
                new SqlParameter("@ARID",arid)
            };
            int val = DBHelper.ExecuteNonQueryProc(DELETE_APPLICATIONRESOURCE, parms);
            return val;
        }

        object IApplicationResourseService.Get(int type, int arid, int riid)
        {
            ApplicationResourseInfo item = null;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ARType",type),
                new SqlParameter("@RIID",riid),
                new SqlParameter("@ARID",arid)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(GET_APPLICATIONRESOURCE, parms))
            {
                if (reader.Read())
                {
                    if (type == 1)
                        item = new ApplicationResourseInfo((BorrowApplication)bas.Get(reader.GetInt32(0)), reader.GetInt32(1), (ResourceInfo)rs.Get(reader.GetInt32(2)), reader.GetInt32(3));
                    else if (type == 2)
                        item = new ApplicationResourseInfo((StockApplication)sas.Get(reader.GetInt32(0)), reader.GetInt32(1), (ResourceInfo)rs.Get(reader.GetInt32(2)), reader.GetInt32(3));
                    else
                        item = null;
                }
            }
            return item;
        }

        IList<ApplicationResourseInfo> IApplicationResourseService.Search(ApplicationResourseInfo item)
        {
            List<ApplicationResourseInfo> items = new List<ApplicationResourseInfo>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ARType",item.ARType),
                new SqlParameter("@RIID",item.Resource.RIID),
                new SqlParameter("@Number",item.Number),
                new SqlParameter("@ARID",item.ARType==1?item.Borrow.BAID:item.Stock.SAID)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(SEARCH_APPLICATIONRESOURCE, parms))
            {
                while (reader.Read())
                {
                    ApplicationResourseInfo val = null;
                    if (item.ARType == 1)
                        val = new ApplicationResourseInfo((BorrowApplication)bas.Get(reader.GetInt32(0)), reader.GetInt32(1), (ResourceInfo)rs.Get(reader.GetInt32(2)), reader.GetInt32(3));
                    else if (item.ARType == 2)
                        val = new ApplicationResourseInfo((StockApplication)sas.Get(reader.GetInt32(0)), reader.GetInt32(1), (ResourceInfo)rs.Get(reader.GetInt32(2)), reader.GetInt32(3));
                    else
                        return null;
                    items.Add(val);
                }
            }
            return items;
        }

        #endregion

        #region IBaseFace 成员


        int IDAL.IBaseFace.Delete(int id)
        {
            throw new NotImplementedException();
        }

        object IDAL.IBaseFace.Get(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IApplicationResourseService 成员


        IList<ApplicationResourseInfo> IApplicationResourseService.SearchByResourceNameAndBorrowType(string resourceName, int borrowType)
        {
            IList<ApplicationResourseInfo> items = new List<ApplicationResourseInfo>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ResourceName",resourceName),
                new SqlParameter("@BorrowType",borrowType)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(SEARCH_APPLICATIONRESOURCE_BY_RESOURCENAME_AND_BORROWTYPE, parms))
            {
                while (reader.Read())
                {
                    UserInfo user = new UserInfo();
                    user.Name = reader.GetString(3);
                    ApplicationResourseInfo item = new ApplicationResourseInfo(new BorrowApplication(reader.GetInt32(0), user,reader.GetDateTime(2).ToString(), 0, "", "", ""), 1, new ResourceInfo(reader.GetInt32(5), reader.GetString(1), new ResourceType(), new ResourceStore(), new ProviderInfo(), 0, 0, "", "", 0, ""), reader.GetInt32(4));
                    items.Add(item);
                }
            }
            return items;
        }
        #endregion
    }
}
