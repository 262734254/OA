
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL.Meeting
{
    /// <summary>
    /// 会场安排信息接口
    /// </summary>
   public interface IRoomArrageService
    {
       //根据会议室名称查询会议室使用情况，
       IList<RoomArrage> SearchRoomArrageStateByRoomName(string roomName);
       void AddRoomArrage(RoomArrage roomArrage);
    }
}
