using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace IDAL.Car
{
   public interface ICarByapplyService
    {
       /// <summary>
       /// 用车申请
       /// </summary>
       /// <param name="byapply"></param>
       /// <returns></returns>
       int InsertByCar(Car_Byapply byapply);
       IList<Car_Byapply> GetAllCarByapply();
       /// <summary>
       /// 条件查询
       /// </summary>
       /// <param name="Mark"></param>
       /// <param name="typeid"></param>
       /// <param name="state"></param>
       /// <returns></returns>
       List<Car_Byapply> usp_CarSelectByappy(string ByMan, string typeid, string state);
       /// <summary>
       /// 通用
       /// </summary>
       /// <param name="reader"></param>
       /// <returns></returns>
       List<Car_Byapply> GetCars(SqlDataReader reader);
       /// 根据ID查询信息
       /// </summary>
       /// <returns></returns>
       Car_Byapply GetAllCarsByappyById(int Id);
       /// <summary>
       /// 删除车辆信息
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       int DeleteByapply(string Id);
       /// <summary>
       /// 根据ID跟新状态
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       int UpadteByapplySate(int Id,string state);
    }
}
