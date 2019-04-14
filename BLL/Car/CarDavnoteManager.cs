using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.Car;
using OAFactory;
namespace BLL.Car
{
    public class CarDavnoteManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static ICarDavnoteService carService = factory.CreateCarDavnoteService();
        /// <summary>
        /// 条件查询信息
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public static List<Car_Davnote> SelectDavnoteDark(string Mark, string typeid, string dept)
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
        /// 删除出车记录信息
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
        /// <summary>
        /// 根据ID查看详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Car_Davnote SelectDavnoteById(int Id)
        {
            try
            {
                return carService.SelectDavnoteById(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 添加出车记录信息
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>
        public static int AddDavte(Car_Davnote dav)
        {
            try
            {
                return carService.AddDavte(dav);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 修改出车记录
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>
        public static int UpdateDavte(Car_Davnote dav)
        {
            try
            {
                return carService.UpdateDavte(dav);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
