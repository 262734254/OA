
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace IDAL.Car
{
    public interface ICheerService
    {
        /// <summary>
        /// 按条件查询加油记录
        /// </summary>
        /// <param name="statime"></param>
        /// <param name="endtime"></param>
        /// <param name="c_CarType"></param>
        /// <param name="c_Station"></param>
        /// <returns></returns>
       IList<Cheer> getAllCheer(string statime, string endtime, string c_CarType, string c_Station);

        /// <summary>
       /// 查询所有的加油厂
        /// </summary>
        /// <returns></returns>
       IList<Cheer> getCheerStation();

        /// <summary>
       /// 根据ID查看一条加油详细信息
        /// </summary>
        /// <param name="c_Id"></param>
        /// <returns></returns>
       Cheer getCheerById(int c_Id);

        /// <summary>
       /// 根据ID删除一条加油信息
        /// </summary>
        /// <param name="c_Id"></param>
        /// <returns></returns>
       int deleteCheerById(int c_Id);

        /// <summary>
       /// 更新一条加油信息
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
       int updateCheer(Cheer ch);

        /// <summary>
       /// 添加一条加油信息
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
       int addCheer(Cheer ch);
    }
}
