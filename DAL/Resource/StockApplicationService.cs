using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Resource;
using IDAL;
using Model;
using System.Data.SqlClient;
using IDAL.Power;
using DAL.Power;

/******************************
 * StockApplicationService类
 * 采购申请数据访问类
 ******************************/
namespace DAL.Resource
{
    public class StockApplicationService : IStockApplicationService
    {
        private IUserInfoService us = new UserInfoService();

        private const string ADD_STOCKAPPLICATION = "usp_add_StockApplication";
        private const string UPDATE_STOCKAPPLICATION = "usp_update_StockApplication";
        private const string DELETE_STOCKAPPLICATION = "usp_delete_StockApplication";
        private const string GET_STOCKAPPLICATION = "usp_get_StockApplication";
        private const string SEARCH_STOCKAPPLICATION = "usp_search_StockApplication";

        #region IBaseFace 成员

        int IBaseFace.Add(object obj)
        {
            int val = 0;
            if (obj is StockApplication)
            {
                StockApplication item = (StockApplication)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@SATime",item.SATime),
                    new SqlParameter("@NeedCharge",item.NeedCharge),
                    new SqlParameter("@SACause",item.SACause),
                    new SqlParameter("@SARemark",item.SARemark),
                    new SqlParameter("@IsExamine",item.IsExamine)
                };
                val = DBHelper.ExecuteScalarProc(ADD_STOCKAPPLICATION, parms);
            }
            return val;
        }

        int IBaseFace.Update(object obj)
        {
            int val = 0;
            if (obj is StockApplication)
            {
                StockApplication item = (StockApplication)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@SATime",item.SATime),
                    new SqlParameter("@NeedCharge",item.NeedCharge),
                    new SqlParameter("@SACause",item.SACause),
                    new SqlParameter("@SARemark",item.SARemark),
                    new SqlParameter("@IsExamine",item.IsExamine),
                    new SqlParameter("@SAID",item.SAID)
                };
                val = DBHelper.ExecuteNonQueryProc(UPDATE_STOCKAPPLICATION, parms);
            }
            return val;
        }

        int IBaseFace.Delete(int id)
        {
            int val = 0;
            val = DBHelper.ExecuteNonQueryProc(DELETE_STOCKAPPLICATION, new SqlParameter("@SAID", id));
            return val;
        }

        object IBaseFace.Get(int id)
        {
            StockApplication item = null;
            using (SqlDataReader sdr = DBHelper.ExecuteReaderProc(GET_STOCKAPPLICATION, new SqlParameter("@SAID", id)))
            {
                if (sdr.Read())
                    item = new StockApplication(sdr.GetInt32(0),(UserInfo)us.GetAllUserById(sdr.GetInt32(1)),sdr.GetDateTime(2).ToString(),sdr.GetDouble(3),sdr.GetString(4),sdr.GetString(5),sdr.GetString(6));
            }
            return item;
        }

        #endregion

        #region IStockApplicationService 成员

        IList<StockApplication> IStockApplicationService.Search(StockApplication item)
        {
            IList<StockApplication> items = new List<StockApplication>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UID",item.User.UID),
                new SqlParameter("@SATime",item.SATime),
                new SqlParameter("@NeedCharge",item.NeedCharge),
                new SqlParameter("@SACause",item.SACause),
                new SqlParameter("@SARemark",item.SARemark),
                new SqlParameter("@IsExamine",item.IsExamine),
                new SqlParameter("@SAID",item.SAID)
            };
            using (SqlDataReader sdr = DBHelper.ExecuteReaderProc(SEARCH_STOCKAPPLICATION, parms))
            {
                while (sdr.Read())
                {
                    StockApplication val = new StockApplication(sdr.GetInt32(0), (UserInfo)us.GetAllUserById(sdr.GetInt32(1)), sdr.GetDateTime(2).ToString(), sdr.GetDouble(3), sdr.GetString(4), sdr.GetString(5), sdr.GetString(6));
                    items.Add(val);
                }
            }
            return items;
        }

        #endregion
    }
}
