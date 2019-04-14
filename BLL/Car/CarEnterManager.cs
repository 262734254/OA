using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

using IDAL.Car;
using OAFactory;
 
namespace BLL.Car
{
    public class CarEnterManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static ICarEnterService carService = factory.CreateCarEnterService();
        /// <summary>
        /// 回车登记
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>
        public static int AddEnter(Car_Enter dav)
        {
            try
            {
                return carService.AddEnter(dav);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 出车记录查询
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public static List<Car_Enter> SelectDavnoteDark(string Mark, string typeid, string dept)
        {
            try
            {
                return carService.SelectDavnoteDark(Mark, typeid, dept);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
         /// <summary>
       /// 删除出车记录
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        public static int DeleteDavnote(string Id)
        {
            try
            {
                return carService.DeleteDavnote(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

