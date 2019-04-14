using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

using IDAL.Car;
using OAFactory;


namespace BLL.Car
{
    public class CarUserInfoManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static ICarUserInfoService carService = factory.CreateCarUserInfoService();

        public static IList<Car_UserInfo> GetAllUserInfo()
        {
            return carService.GetAllUserInfo();
        }
        public static Car_UserInfo GetAllCarsById(int Id)
        {

            try
            {
                return carService.GetAllCarsById(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 根据状态查看所有驾驶员
        /// </summary>
        /// <param name="State"></param>
        /// <returns></returns>
        public static IList<Car_UserInfo> usp_CarUserNameState(string State)
        {
            try
            {
                return carService.usp_CarUserNameState(State);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 删除驾驶员信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static int DeleteDriver(string Id)
        {
            try
            {
                return carService.DeleteDriver(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
        /// <summary>
        ///添加驾驶员信息
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public static int AddDavte(Car_UserInfo userinfo)
        {
            try
            {
                return carService.AddDavte(userinfo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 根据姓名查看驾驶员信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static IList<Car_UserInfo> SelectCarsDark(string userName)
        {
            try
            {
                return carService.SelectCarsDark(userName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
