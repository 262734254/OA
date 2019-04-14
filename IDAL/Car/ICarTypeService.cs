using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL.Car
{
    public interface ICarTypeService
    {
        /// <summary>
        /// 查询所有车辆类型
        /// </summary>
        /// <returns></returns>
        IList<Car_Type> GetAllType();

        /// <summary>
        /// 根据ID查询车辆类型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Car_Type GetAllCarsById(int Id);

    }
}
