using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Matter;
using OAFactory;
using IDAL.Meeting;
using Model;
namespace BLL.Meeting
{
   public static class RoomInfoManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IRoomInfoService roomInfoService = factory.CreateRoomInfoService();

        /// <summary>
        /// 获取根据会场名称查询所有会场信息，会场名称为空，则查询所有
        /// </summa ry>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public static  IList<RoomInfo> GetAllRoomInfo(string roomName)
        {
            return roomInfoService.GetAllRoomInfo(roomName);
        }
       /// <summary>
        /// 新增会场
        /// </summary>
        /// <param name="roomInfo"></param>
        public static  void AddRoomInfo(RoomInfo roomInfo)
        {
            roomInfoService.AddRoomInfo(roomInfo);
        }
        /// <summary>
        /// 删除会场信息
        /// </summary>
        /// <param name="roomId"></param>
        public static  void DeleteRoomInfo(string roomIds)
        {
            roomInfoService.DeleteRoomInfo(roomIds);
        }
        /// <summary>
        /// 根据会场ID查询一条会场信息
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public static  RoomInfo SearchRoomInfoById(int roomId)
        {
            return roomInfoService.SearchRoomInfoById(roomId);  
        }
       /// <summary>
       /// 修改会场信息
       /// </summary>
       /// <param name="roomInfo"></param>
        public static void ModifyRoomInfo(RoomInfo roomInfo)
        {
            roomInfoService.ModifyRoomInfo(roomInfo);
        }
       /// <summary>
        /// 获取所有会议室
        /// </summary>
        /// <returns></returns>
        public static IList<RoomInfo> GetAllRoomInfo()
        {
            return roomInfoService.GetAllRoomInfo();
        }

    }
}
