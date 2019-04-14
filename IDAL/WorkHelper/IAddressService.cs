using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL.WorkHelper
{
   public interface IAddressService
    {
       IList<Address> getAddress(int selfUserId);
       int DeleteAddress(int selfUserId,int friendUserId);
       Address GetAddressByFriendId(int selfUserId, int friendUserId);
       IList<Address> GetAllAddress();
    }
}
