using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.Matter;
using OAFactory;
using IDAL.Meeting;

namespace BLL.Meeting
{
   public class RoomArrageManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IRoomArrageService roomArrageService = factory.CreateRoomArrageService();
             /// <summary>
        /// 根据会场名称查询会场安排信息
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public static  IList<RoomArrage> SearchRoomArrageStateByRoomName(string roomName)
        {
            return roomArrageService.SearchRoomArrageStateByRoomName(roomName);
        }
       /// <summary>
        /// 添加会场安排信息
        /// </summary>
        /// <param name="roomArrage"></param>
        public static  void AddRoomArrage(RoomArrage roomArrage)
        {
            roomArrageService.AddRoomArrage(roomArrage);
        }
    }
}
