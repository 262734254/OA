using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

using IDAL.Car;
using OAFactory;

namespace BLL.Car
{
    public class CarTypeManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static ICarTypeService carService = factory.CreateCarTypeService();
        /// <summary>
        /// 根据ID查询车辆信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Car_Type GetAllCarsById(int Id)
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
        /// 查询所有车辆信息
        /// </summary>
        /// <returns></returns>
        public static IList<Car_Type> GetAllType()
        {
            try
            {
                return carService.GetAllType();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
