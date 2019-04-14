using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Matter;
using OAFactory;
using IDAL.Car;
using IDAL.WorkHelper;
using Model;
namespace BLL.WorkHelper
{
   public class MessageTypeManger
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        //private static ICarsService carService = factory.CreateCarService();
        private static IMessageType message = factory.CreateMessageType();
        public static MessageType GetMessageTypeById(int typeId)
        {
            return message.GetMessageTypeById(typeId);
        }
        public static IList<MessageType> GetMessageType()
        {
            return message.GetMessageType();
        }

    }
}
