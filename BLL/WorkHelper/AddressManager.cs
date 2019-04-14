using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Matter;
using OAFactory;
using IDAL.WorkHelper;
using Model;

namespace BLL.WorkHelper
{
   public class AddressManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

       
        private static IAddressService addressService = factory.CreateAddressServcive();
        public static IList<Address> getAddress(int selfUserId)
        { 
           return addressService.getAddress(selfUserId);
        }

        public static  int DeleteAddress(int selfUserId, int friendUserId)
        {
            return addressService.DeleteAddress(selfUserId, friendUserId);
        }
        public static Address GetAddressByFriendId(int selfUserId, int friendUserId)
        {
            return addressService.GetAddressByFriendId(selfUserId, friendUserId);
        }
        public static IList<Address> GetAllAddress()
        {
            return addressService.GetAllAddress();
        }

    }
}
