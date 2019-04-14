using System;
using System.Collections.Generic;


using IDAL.Resource;
using IDAL;
using Model;
using IDAL.Power;
using DAL.Power;
using System.Data.SqlClient;

/******************************
 * SpoilageRegisterService类
 * 损坏记录数据访问类
 ******************************/
namespace DAL.Resource
{
    public class SpoilageRegisterService : ISpoilageRegisterService
    {
        private IBorrowApplicationService bas = new BorrowApplicationService();
        private IResourceInfoService rs = new ResourceInfoService();
        private IUserInfoService us = new UserInfoService();

        private const string ADD_SPOILAGEREGISTER = "usp_add_SpoilageRegister";
        private const string UPDATE_SPOILAGEREGISTER = "usp_update_SpoilageRegister";
        private const string DELETE_SPOILAGEREGISTER = "usp_delete_SpoilageRegister";
        private const string GET_SPOILAGEREGISTER = "usp_get_SpoilageRegister";
        private const string SEARCH_SPOILAGEREGISTER = "usp_search_SpoilageRegister";

        #region ISpoilageRegisterService 成员

        IList<SpoilageRegister> ISpoilageRegisterService.GetAllSpoilageRegister(SpoilageRegister item)
        {
            IList<SpoilageRegister> items = new List<SpoilageRegister>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@BAID",item.Borrow.BAID),
                new SqlParameter("@RIID",item.Resourse.RIID),
                new SqlParameter("@UID",item.User.UID),
                new SqlParameter("@SRNo",item.SRNo),
                new SqlParameter("@SRGrade",item.SRGrade),
                new SqlParameter("@SRTime",item.SRTime),
                new SqlParameter("@SRCause",item.SRCause),
                new SqlParameter("@SRRmark",item.SRRemark),
                new SqlParameter("@SRID",item.SRID)
            };
            using (SqlDataReader sdr = DBHelper.ExecuteReaderProc(SEARCH_SPOILAGEREGISTER, parms))
            {
                while (sdr.Read())
                {
                    SpoilageRegister val = new SpoilageRegister(sdr.GetInt32(0), (BorrowApplication)bas.Get(sdr.GetInt32(1)), (ResourceInfo)rs.Get(sdr.GetInt32(2)), (UserInfo)us.GetAllUserById(sdr.GetInt32(3)), sdr.GetInt32(4), sdr.GetString(5), sdr.GetDateTime(6).ToString(), sdr.GetString(7), sdr.GetString(8));
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
            if (obj is SpoilageRegister)
            {
                SpoilageRegister item = (SpoilageRegister)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@BAID",item.Borrow.BAID),
                    new SqlParameter("@RIID",item.Resourse.RIID),
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@SRNo",item.SRNo),
                    new SqlParameter("@SRGrade",item.SRGrade),
                    new SqlParameter("@SRTime",item.SRTime),
                    new SqlParameter("@SRCause",item.SRCause),
                    new SqlParameter("@SRRmark",item.SRRemark)
                };
                val = DBHelper.ExecuteNonQueryProc(ADD_SPOILAGEREGISTER, parms);
            }
            return val;
        }

        int IBaseFace.Update(object obj)
        {
            int val = 0;
            if (obj is SpoilageRegister)
            {
                SpoilageRegister item = (SpoilageRegister)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@BAID",item.Borrow.BAID),
                    new SqlParameter("@RIID",item.Resourse.RIID),
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@SRNo",item.SRNo),
                    new SqlParameter("@SRGrade",item.SRGrade),
                    new SqlParameter("@SRTime",item.SRTime),
                    new SqlParameter("@SRCause",item.SRCause),
                    new SqlParameter("@SRRmark",item.SRRemark),
                    new SqlParameter("@SRID",item.SRID)
                };
                val = DBHelper.ExecuteNonQueryProc(UPDATE_SPOILAGEREGISTER, parms);
            }
            return val;
        }

        int IBaseFace.Delete(int id)
        {
            int val = 0;
            val = DBHelper.ExecuteNonQueryProc(DELETE_SPOILAGEREGISTER, new SqlParameter("@SRID", id));
            return val;
        }

        object IBaseFace.Get(int id)
        {
            SpoilageRegister item = null;
            using (SqlDataReader sdr = DBHelper.ExecuteReaderProc(GET_SPOILAGEREGISTER, new SqlParameter("@SRID", id)))
            {
                if (sdr.Read())
                    item = new SpoilageRegister(sdr.GetInt32(0), (BorrowApplication)bas.Get(sdr.GetInt32(1)), (ResourceInfo)rs.Get(sdr.GetInt32(2)), (UserInfo)us.GetAllUserById(sdr.GetInt32(3)), sdr.GetInt32(4), sdr.GetString(5), sdr.GetDateTime(6).ToString(), sdr.GetString(7), sdr.GetString(8));
            }
            return item;
        }

        #endregion
    }
}
