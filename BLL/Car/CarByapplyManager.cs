using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using BLL.Car;
using IDAL.Car;
using OAFactory;

namespace BLL.Car
{
   public class CarByapplyManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static ICarByapplyService carService = factory.CreateCarByapplyServcie();
      /// <summary>
      /// 申请用车
      /// </summary>
      /// <param name="byapply"></param>
      /// <returns></returns>
        public static int InsertByCar(Car_Byapply byapply)
        {
            try
            {
                return carService.InsertByCar(byapply);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

       /// <summary>
       /// 查询所有的信息 
       /// </summary>
       /// <returns></returns>
        public static  IList<Car_Byapply> GetAllCarByapply()
        {
            try
            {
                return carService.GetAllCarByapply();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
       
       /// <summary>
       /// 通用
       /// </summary>
       /// <param name="reader"></param>
       /// <returns></returns>
        public static List<Car_Byapply> usp_CarSelectByappy(string ByMan, string typeid, string state)
        {
            try
            {
                return carService.usp_CarSelectByappy(ByMan, typeid, state);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public static Car_Byapply GetAllCarsByappyById(int Id)
        {
            try
            {
                return carService.GetAllCarsByappyById(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
          /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static int DeleteByapply(string Id)
        {
            try
            {
                return carService.DeleteByapply(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
        /// <summary>
       /// 根据ID更新状态
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        public  static int UpadteByapplySate(int Id,string state)
        {
            try
            {
                return carService.UpadteByapplySate(Id,state);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
