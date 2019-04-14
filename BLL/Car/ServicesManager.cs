using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.Car;
using OAFactory;
namespace BLL.Car
{
   public class ServicesManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IServicesService ServicesService = factory.CreateServiceService();
        /// <summary>
        /// 按条件查询维修信息
        /// </summary>
        /// <param name="statime"></param>
        /// <param name="endtime"></param>
        /// <param name="carType"></param>
        /// <param name="s_FactoryName"></param>
        /// <returns></returns>
        public static IList<Services> getAllService(string statime, string endtime, string carType, string s_FactoryName)
        {
            try
            {
                return ServicesService.getAllService(statime, endtime, carType, s_FactoryName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 查询所有维修厂的名字
        /// </summary>
        /// <returns></returns>
        public static int addService(Services se)
        {
            try
            {
                return ServicesService.addService(se);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static int updateService(Services se)
        {
            try
            {
                return ServicesService.updateService(se);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 跟新一条信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Services getServiceById(int s_Id)
        {
            try
            {
                return ServicesService.getServiceById(s_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        ///  根据ID查看一条详细信息
        /// </summary>
        /// <param name="c_Id"></param>
        /// <returns></returns>
        public static int deleteServiceById(int s_Id)
        {
            try
            {
                return ServicesService.deleteServiceById(s_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
       /// <summary>
        /// 根据ID删除一条信息
        /// </summary>
        /// <param name="c_Id"></param>
        public IList<Services> getFactoryName()
        {
            try
            {
                return ServicesService.getFactoryName();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 查询所有车辆状态为维修信息
        /// </summary>
        /// <returns></returns>
        public IList<Car_Cars> getCarsByType()
        {
            try
            {
                return ServicesService.getCarsByType();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
