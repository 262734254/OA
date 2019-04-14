
using System;
using System.Collections.Generic;

using System.Data.SqlClient;

using IDAL.Resource;
using Model;

/******************************
 * ProviderInfoService类
 * 供应商数据访问类
 ******************************/
namespace DAL.Resource
{
    public class ProviderInfoService : IProviderInfoService
    {
        private const string ADD_PROVIDER = "usp_add_Provider";
        private const string UPDATE_PROVIDER = "usp_update_Provider";
        private const string DELETE_PROVIDER = "usp_delete_Provider";
        private const string GET_PROVIDER = "usp_get_Provider";
        private const string GET_ALL_PROVIDER = "usp_search_Provider";//

        #region IBaseFace 成员

        int IDAL.IBaseFace.Add(object obj)
        {
            int val = 0;
            if (obj is ProviderInfo)
            {
                ProviderInfo item = (ProviderInfo)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@PName",item.PName),
                    new SqlParameter("@DutyNo",item.DutyNo),
                    new SqlParameter("@LinkMan",item.LinkMan),
                    new SqlParameter("@LinkPhone",item.LinkPhone),
                    new SqlParameter("@Address",item.Address)
                };
                val = DBHelper.ExecuteNonQueryProc(ADD_PROVIDER, parms);
            }
            return val;
        }

        int IDAL.IBaseFace.Update(object obj)
        {
            int val = 0;
            if (obj is ProviderInfo)
            {
                ProviderInfo item = (ProviderInfo)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@PName",item.PName),
                    new SqlParameter("@DutyNo",item.DutyNo),
                    new SqlParameter("@LinkMan",item.LinkMan),
                    new SqlParameter("@LinkPhone",item.LinkPhone),
                    new SqlParameter("@Address",item.Address),
                    new SqlParameter("@PID",item.PID)
                };
                val = DBHelper.ExecuteNonQueryProc(UPDATE_PROVIDER, parms);
            }
            return val;
        }

        int IDAL.IBaseFace.Delete(int id)
        {
            int val = 0;
            val = DBHelper.ExecuteNonQueryProc(DELETE_PROVIDER, new SqlParameter("@PID", id));
            return val;
        }

        object IDAL.IBaseFace.Get(int id)
        {
            ProviderInfo item = null;
            using (SqlDataReader sdr = DBHelper.ExecuteReaderProc(GET_PROVIDER, new SqlParameter("@PID", id)))
            {
                if (sdr.Read())
                    item = new ProviderInfo(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5));
            }
            return item;
        }

        #endregion

        #region IProviderInfoService 成员

        IList<ProviderInfo> IProviderInfoService.GetAllProvider(ProviderInfo item)
        {
            IList<ProviderInfo> items = new List<ProviderInfo>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@PName",item.PName),
                new SqlParameter("@DutyNo",item.DutyNo),
                new SqlParameter("@LinkMan",item.LinkMan),
                new SqlParameter("@LinkPhone",item.LinkPhone),
                new SqlParameter("@Address",item.Address),
                new SqlParameter("@PID",item.PID)
            };
            using (SqlDataReader sdr = DBHelper.ExecuteReaderProc(GET_ALL_PROVIDER, parms))
            {
                while (sdr.Read())
                {
                    ProviderInfo val = new ProviderInfo(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5));
                    items.Add(val);
                }
            }
            return items;
        }

        #endregion
    }
}
