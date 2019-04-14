using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
namespace IDAL.Car
{
    public interface ICarDavnoteService
    {
        /// <summary>
        /// 查询所有出车记录
        /// </summary>
        /// <returns></returns>
        IList<Car_Davnote> GetAllDavnote();
        /// <summary>
        /// 通用类
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        List<Car_Davnote> GetDavnote(SqlDataReader reader);
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        List<Car_Davnote> SelectDavnoteDark(string Mark, string typeid, string dept);
        /// <summary>
        /// 删除出车记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteDavnote(string Id);
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Car_Davnote SelectDavnoteById(int Id);
        /// <summary>
        /// 出车登记
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>
        int AddDavte(Car_Davnote dav);
        /// <summary>
        /// 修改出车记录信息
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>
        int UpdateDavte(Car_Davnote dav);

    }
}
