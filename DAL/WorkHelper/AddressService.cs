using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.WorkHelper;
using IDAL.Power;
using DAL.Power;
using System.Data;
using System.Data.SqlClient;


namespace DAL.WorkHelper
{
    public class AddressService : IAddressService
    {
        private IUserInfoService userInfo = new UserInfoService();
        #region IAddressService 成员

        IList<Address> IAddressService.getAddress(int selfUserId)
        {
            IList<Address> list = new List<Address>();
            string sql = "usp_selectAddressManagerAllUserSelfUserId";
            
            int selfUser;
            int friendUser;
            Address address = null;
            using (SqlDataReader row = DBHelper.ExecuteReaderProc(sql, new SqlParameter("@SelfUserId", selfUserId)))
            {

                while (row.Read())
                {
                    address = new Address();
                    selfUser = (int)row["SelfUserId"];
                    address.SelfUserId = userInfo.GetAllUserById(selfUser);
                    friendUser = (int)row["FriendUserId"];
                    address.FriendUserId = userInfo.GetAllUserById(friendUser);
                    list.Add(address);
                }

            }
            return list;
        }

        #endregion

        #region IAddressService 成员


        int IAddressService.DeleteAddress(int selfUserId, int friendUserId)
        {
            string sql = "usp_DeleteAddress";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@SelfUserId",selfUserId),
                new SqlParameter("@FriendUserId",friendUserId)
               
            };
            int val = DBHelper.ExecuteNonQueryProc(sql, parms);
            return val;
        }

        #endregion

        #region IAddressService 成员


        Address IAddressService.GetAddressByFriendId(int selfUserId, int friendUserId)
        {
            int selfUser;
            int friendUser;
            Address item = null;
            string sql="usp_selectAddressManagerFriendUserId";
            SqlParameter[] parms=new SqlParameter[]
            {
                new SqlParameter("@SelfUserId",selfUserId),
                new SqlParameter("@FriendUserId",friendUserId)
            };
            using (SqlDataReader reader = DBHelper.ExecuteReaderProc(sql, parms))
            {
                if (reader.Read())
                {
                    item = new Address();
                    selfUser = (int)reader["SelfUserId"];
                    item.SelfUserId = userInfo.GetAllUserById(selfUser);
                    friendUser = (int)reader["FriendUserId"];
                    item.FriendUserId = userInfo.GetAllUserById(friendUser);
                }
            }
            return item;
        }

        #endregion

        #region IAddressService 成员


        public IList<Address> GetAllAddress()
        {
            string sql = "usp_selectAddressManagerAllUser";
            IList<Address> list = new List<Address>();
            int selfUser;
            int friendUser;
            Address address = null;
            using (SqlDataReader row = DBHelper.ExecuteReaderProc(sql, null))
            {

                while (row.Read())
                {
                    address = new Address();
                    selfUser = (int)row["SelfUserId"];
                    address.SelfUserId = userInfo.GetAllUserById(selfUser);
                    friendUser = (int)row["FriendUserId"];
                    address.FriendUserId = userInfo.GetAllUserById(friendUser);
                    list.Add(address);
                }

            }
            return list;
        }

        #endregion
    }
}
