using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL.Car;
using OAFactory;

namespace BLL.Car
{
   public class CheerManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static ICheerService CheerService = factory.CreateCheerService();
        /// <summary>
        /// 按条件查询加油记录
        /// </summary>
        /// <param name="statime"></param>
        /// <param name="endtime"></param>
        /// <param name="c_CarType"></param>
        /// <param name="c_Station"></para
        /// <returns></returns>
        public static IList<Cheer> getAllCheer(string statime, string endtime, string c_CarType, string c_Station)
        {
            try
            {
                return CheerService.getAllCheer(statime, endtime, c_CarType, c_Station);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 查询所有的加油厂
        /// </summary>
        /// <returns></returns>
        public static IList<Cheer> getCheerStation()
        {
            try
            {
                return CheerService.getCheerStation();
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
        public static Cheer getCheerById(int c_Id)
        {
            try
            {
                return CheerService.getCheerById(c_Id);
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
        public static int deleteCheerById(int c_Id)
        {
            try
            {
                return CheerService.deleteCheerById(c_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 更新一条信息
        /// </summary>
        /// <param name="ch"></param>
        public static int updateCheer(Cheer ch)
        {
            try
            {
                return CheerService.updateCheer(ch);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="ch"></param>
        public static int addCheer(Cheer ch)
        {
            try
            {
                return CheerService.addCheer(ch);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
