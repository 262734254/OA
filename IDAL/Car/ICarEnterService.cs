using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;


namespace IDAL.Car
{
    public interface ICarEnterService
    {
        IList<Car_Enter> GetAllEnter();
        /// <summary>
        /// 回车登记
        /// </summary>
        /// <param name="dav"></param>
        /// <returns></returns>
        int AddEnter(Car_Enter dav);
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        List<Car_Enter> SelectDavnoteDark(string Mark, string typeid, string dept);
        /// <summary>
        /// 通用类
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        List<Car_Enter> GetDavnote(SqlDataReader reader);
        /// 删除出车记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteDavnote(string Id);
    }
}

