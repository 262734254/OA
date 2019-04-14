using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

using IDAL.Car;
using OAFactory;

namespace BLL.Car
{
  public  class CarsManager
  {
      #region  访问数据访问类公共方法
      private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

      private static ICarsService carService = factory.CreateCarService();
      #endregion


      #region ICarsManager 成员
      /// <summary>
      /// 查询所有车辆信息
      /// </summary>
      /// <returns></returns>
      public static IList<Car_Cars> GetAllCars()
      {

          try
          {
              return carService.GetAllCars();
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }
      }

      #endregion
      /// <summary>
      /// 根据ID查询车辆信息
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
      public static Car_Cars GetAllCarsById(int Id)
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
      /// 修改车辆信息
      /// </summary>
      /// <param name="cs"></param>
      /// <returns></returns>
      public static int UpdateCars(Car_Cars cs)
      {
          try
          {
              return carService.UpdateCars(cs);
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
      public static int DcseteCars(string Id)
      {
          try
          {
              return carService.DcseteCars(Id);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }
      }
      /// <summary>
      /// 条件查询车辆信息
      /// </summary>
      /// <param name="Mark"></param>
      /// <param name="typeid"></param>
      /// <param name="state"></param>
      /// <returns></returns>
      public static List<Car_Cars> SelectCarsDark(string Mark, string typeid, string state)
      {
          try
          {
              return carService.SelectCarsDark(Mark, typeid, state);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }
      }
      /// <summary>
      ///  添加车辆信息
      /// </summary>
      /// <param name="cs"></param>
      /// <returns></returns>
      public static int InsertCars(Car_Cars cs)
      {
          try
          {
              return carService.InsertCars(cs);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }
      }
      /// <summary>
      /// 根据状态查看未出车的车牌号
      /// </summary>
      /// <param name="State"></param>
      /// <returns></returns>
      public IList<Car_Cars> SelectCarMarkState(string State)
      {
          try
          {
              return carService.SelectCarMarkState(State);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }
      }
      /// <summary>
      /// 根据车牌号查看状态
      /// </summary>
      /// <param name="CarMark"></param>
      /// <returns></returns>
      public static string SelectState(string CarMark)
      {
          try
          {
              return carService.SelectState(CarMark);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }
      }

      /// <summary>
      /// 根据车牌号查看状态
      /// </summary>
      /// <param name="CarMark"></param>
      /// <returns></returns>
      public static string usp_SelectCarMarkType(string CarMark)
      {
          try
          {
              return carService.usp_SelectCarMarkType(CarMark);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }
      }
          /// <summary>
        /// 根据ID跟新状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
      public static int UpadteCarsByIdSate(int Id)
      {
          try
          {
              return carService.UpadteCarsByIdSate(Id);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }
      }

  }
}
