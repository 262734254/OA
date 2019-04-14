using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.Car;
using OAFactory;
namespace BLL.Car
{
   public class DisobeyRecordManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IDisobeyRecordService DisobeyRecordService = factory.CreateDisobeyRecordService();
        /// <summary>
        /// 按条件查询事故违章记录
        /// </summary>
        /// <param name="statime"></param>
        /// <param name="endtime"></param>
        /// <param name="c_CarType"></param>
        /// <param name="c_Station"></param>
        /// <returns></returns>
        public static IList<DisobeyRecord> getAllDisobeyRecord(string statime, string endtime, string dr_CarType, string carMark)
        {
            try
            {
                return DisobeyRecordService.getAllDisobeyRecord(statime, endtime, dr_CarType, carMark);
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
        public static int addDisobeyRecord(DisobeyRecord dr)
        {
            try
            {
                return DisobeyRecordService.addDisobeyRecord(dr);
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
        public static int updateDisobeyRecord(DisobeyRecord dr)
        {
            try
            {
                return DisobeyRecordService.updateDisobeyRecord(dr);
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
        public static DisobeyRecord getDisobeyRecordById(int DR_Id)
        {
            try
            {
                return DisobeyRecordService.getDisobeyRecordById(DR_Id);
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
        public static int delDisobeyRecordById(int DR_Id)
        {
            try
            {
                return DisobeyRecordService.delDisobeyRecordById(DR_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 查询事故违章的所有车牌号
        /// </summary>
        /// <returns></returns>
        public static IList<DisobeyRecord> getDisobeyRecordByMark()
        {
            try
            {
                return DisobeyRecordService.getDisobeyRecordByMark();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
