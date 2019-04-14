using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL.Meeting
{
    /// <summary>
    /// 会场信息接口
    /// </summary>
   public interface IRoomInfoService
    {
        //所有会场信息
        IList<RoomInfo> GetAllRoomInfo();
       //获取根据会场名称查询所有会场信息，会场名称为空，则查询所有
       IList<RoomInfo> GetAllRoomInfo(string roomName);
       //新增会场
       void AddRoomInfo(RoomInfo roomInfo);
       //修改会场信息
       void ModifyRoomInfo(RoomInfo roomInfo);
       //删除会场信息
       void DeleteRoomInfo(string roomIds);
       //根据会场ID查询一条会场信息
       RoomInfo SearchRoomInfoById(int roomId);

    }
}
