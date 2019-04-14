using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL.Car
{
    public interface ICarUserInfoService
    {
        /// <summary>
        /// 查询所有驾驶员
        /// </summary>
        /// <returns></returns>
        IList<Car_UserInfo> GetAllUserInfo();
        /// <summary>
        /// 根据ID查看驾驶员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Car_UserInfo GetAllCarsById(int Id);
        /// <summary>
        /// 根据状态查看驾驶员
        /// </summary>
        /// <param name="State"></param>
        /// <returns></returns>
        IList<Car_UserInfo> usp_CarUserNameState(string State);
        /// <summary>
        /// 根据姓名查看驾驶员
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        IList<Car_UserInfo> SelectCarsDark(string userName);

        /// <summary>
        /// 删除驾驶员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteDriver(string Id);
        /// <summary>
        /// 添加驾驶员
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>
        int AddDavte(Car_UserInfo userinfo);
    }
}
