using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{[Serializable]
    public class Address
    {
       
        private UserInfo selfUserId = new UserInfo();

       public UserInfo SelfUserId
       {
           get { return selfUserId; }
           set { selfUserId = value; }
       }
       private UserInfo friendUserId = new UserInfo();

       public UserInfo FriendUserId
       {
           get { return friendUserId; }
           set { friendUserId = value; }
       }
  
    }
}
