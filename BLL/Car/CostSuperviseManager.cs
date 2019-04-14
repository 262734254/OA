using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.Car;
using OAFactory;

namespace BLL.Car
{
   public class CostSuperviseManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static ICostSuperviseService CostSuperviseService = factory.CreateCostSuperviseService();
        /// <summary>
        /// 按条件查询费用记录
        /// </summary>
        /// <param name="statime"></param>
        /// <param name="endtime"></param>
        /// <param name="cs_CarType"></param>
        /// <param name="carMark"></param>
        /// <returns></returns>
        public static IList<CostSupervise> getAllCostSupervise(string statime, string endtime, string cs_CarType, string carMark)
        {
            try
            {
                return CostSuperviseService.getAllCostSupervise(statime, endtime, cs_CarType, carMark);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 更新一条信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public static int updateCostSupervise(CostSupervise cs)
        {
            try
            {
                return CostSuperviseService.updateCostSupervise(cs);
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
        public static CostSupervise getCostSuperviseById(int cs_Id)
        {
            try
            {
                return CostSuperviseService.getCostSuperviseById(cs_Id);
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
        public static int delCostSuperviseById(int cs_Id)
        {
            try
            {
                return CostSuperviseService.delCostSuperviseById(cs_Id);
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
        public static int addCostSupervise(CostSupervise cs)
        {
            try
            {
                return CostSuperviseService.addCostSupervise(cs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 查询费用表所有的车牌号
        /// </summary>
        /// <returns></returns>
        public IList<CostSupervise> getCostSupervise()
        {
            try
            {
                return CostSuperviseService.getCostSupervise();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
