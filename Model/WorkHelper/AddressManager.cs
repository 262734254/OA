using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{[Serializable]
   public class AddressManager
    {
       
        private UserInfo selfUserId;

       public UserInfo SelfUserId
       {
           get { return selfUserId; }
           set { selfUserId = value; }
       }
       private UserInfo friendUserId;

       public UserInfo FriendUserId
       {
           get { return friendUserId; }
           set { friendUserId = value; }
       }
       private string groupId;

       public string GroupId
       {
           get { return groupId; }
           set { groupId = value; }
       }
    }
}
