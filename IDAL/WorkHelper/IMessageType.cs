using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL.WorkHelper
{
   public interface IMessageType
    {
       MessageType GetMessageTypeById(int typeId);
       IList<MessageType> GetMessageType();
    }
}
