using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace IDAL.Car
{
    public interface ICarsService
    {
        /// <summary>
        /// 查询所有车辆信息
        /// </summary>
        /// <returns></returns>
        IList<Car_Cars> GetAllCars();
        /// <summary>
        /// 根据ID查询信息
        /// </summary>
        /// <returns></returns>
        Car_Cars GetAllCarsById(int Id);
        /// <summary>
        /// 根据状态查看所有未出车辆
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
    
        IList<Car_Cars> SelectCarMarkState(string State);
        /// <summary>
        /// 修改车辆信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int UpdateCars(Car_Cars cs);
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DcseteCars(string Id);
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        List<Car_Cars> SelectCarsDark(string Mark, string typeid, string state);
        /// <summary>
        /// 通用
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        List<Car_Cars> GetCars(SqlDataReader reader);
        /// <summary>
        /// 添加车辆
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int InsertCars(Car_Cars cs);
        /// <summary>
        /// 根据车牌号获取状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string SelectState(string CarMark);
        /// <summary>
        /// 根据车牌号查看类型
        /// </summary>
        /// <param name="CarMark"></param>
        /// <returns></returns>
        string usp_SelectCarMarkType(string CarMark);

        /// <summary>
        /// 根据ID跟新状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int UpadteCarsByIdSate(int Id);

    }
}
