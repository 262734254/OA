
using IDAL.Resource;
using IDAL.Power;
using DAL.Power;
using Model;
using System.Data.SqlClient;
using System.Collections.Generic;


/******************************
 * BorrowApplicationService类
 * 资源借用申请数据访问类
 ******************************/
namespace DAL.Resource
{
    public class BorrowApplicationService:IBorrowApplicationService
    {
        private IResourceInfoService rs = new ResourceInfoService();
        private IProviderInfoService ps = new ProviderInfoService();
        private IUserInfoService uis = new UserInfoService();

        private const string ADD_BORROWAPPLICATION = "usp_add_BorrowApplication";
        private const string UPDATE_BORROWAPPLICATION = "usp_update_BorrowApplication";
        private const string DELETE_BORROWAPPLICATION = "usp_delete_BorrowApplication";
        private const string GET_BORROWAPPLICATION = "usp_get_BorrowApplication";
        private const string SEARCH_BORROWAPPLICATION = "usp_search_BorrowApplication";

        #region IBaseFace 成员

        int IDAL.IBaseFace.Add(object obj)
        {
            int val = 0;
            if (obj is BorrowApplication)
            {
                BorrowApplication item = (BorrowApplication)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@BATime",item.BATime),
                    new SqlParameter("@BAType",item.BAType),
                    new SqlParameter("@ExigentGrade",item.ExigentGrade),
                    new SqlParameter("@BARemark",item.BARemark),
                    new SqlParameter("@IsExamine",item.IsExamine)
                };
                val = DBHelper.ExecuteScalarProc(ADD_BORROWAPPLICATION, parms);
            }
            return val;
        }

        int IDAL.IBaseFace.Update(object obj)
        {
            int val = 0;
            if (obj is BorrowApplication)
            {
                BorrowApplication item = (BorrowApplication)obj;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@BAID",item.BAID),
                    new SqlParameter("@UID",item.User.UID),
                    new SqlParameter("@BATime",item.BATime),
                    new SqlParameter("@BAType",item.BAType),
                    new SqlParameter("@ExigentGrade",item.ExigentGrade),
                    new SqlParameter("@BARemark",item.BARemark),
                    new SqlParameter("@IsExamine",item.IsExamine)
                };
                val = DBHelper.ExecuteNonQueryProc(UPDATE_BORROWAPPLICATION, parms);
            }
            return val;
        }

        int IDAL.IBaseFace.Delete(int id)
        {
            int val = DBHelper.ExecuteNonQueryProc(DELETE_BORROWAPPLICATION, new SqlParameter("@BAID", id));
            return val;
        }

        object IDAL.IBaseFace.Get(int id)
        {
            BorrowApplication item = null;
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(GET_BORROWAPPLICATION, new SqlParameter("@BAID", id)))
            {
                if (reader.Read())
                {
                    item = new BorrowApplication(reader.GetInt32(0), (UserInfo)uis.GetAllUserById(reader.GetInt32(1)), reader.GetDateTime(2).ToString(), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                }
            }
            return item;
        }

        #endregion

        #region IBorrowApplicationService 成员

        IList<BorrowApplication> IBorrowApplicationService.GetAllBorrowApplication(BorrowApplication item)
        {
            IList<BorrowApplication> items = new List<BorrowApplication>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@BAID",item.BAID),
                new SqlParameter("@UID",item.User.UID),
                new SqlParameter("@BATime",item.BATime),
                new SqlParameter("@BAType",item.BAType),
                new SqlParameter("@ExigentGrade",item.ExigentGrade),
                new SqlParameter("@BARemark",item.BARemark),
                new SqlParameter("@IsExamine",item.IsExamine)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(SEARCH_BORROWAPPLICATION, parms))
            {
                while (reader.Read())
                {
                    BorrowApplication var = new BorrowApplication(reader.GetInt32(0), (UserInfo)uis.GetAllUserById(reader.GetInt32(1)), reader.GetDateTime(2).ToString(), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                    items.Add(var);
                }
            }
            return items;
        }

        #endregion
    }
}
