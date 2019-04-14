using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_KaoQinCheck 的摘要说明。
	/// </summary>
	public class Tunnel_KaoQinCheck
	{
		private readonly Tunnel.DAL.Tunnel_KaoQinCheck dal=new Tunnel.DAL.Tunnel_KaoQinCheck();
		public Tunnel_KaoQinCheck()
		{}
		#region  成员方法

        /// <summary>
        /// 根据年月查询数据是否存在
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="bid">部门ID</param>
        /// <returns>0不存在，1存在</returns>
        public int ExitsDate(string year, string month,string bid)
        {
            int result = 0;
            Tunnel.DAL.Tunnel_KaoQinCheck kqc = new Tunnel.DAL.Tunnel_KaoQinCheck();
            result = kqc.Exist(year, month,bid);
            return result;
        }

        /// <summary>
        /// 验证当月考勤是否存在
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="bid">部门ID</param>
        /// <returns>0未审核，1审核</returns>
        public int ExitsKaoQin(string year, string month, string bid)
        { 
            int result=0;
            Tunnel.DAL.Tunnel_KaoQinCheck kqc = new Tunnel.DAL.Tunnel_KaoQinCheck();
            result = kqc.Exist(year, month, bid);
            return result;
        }

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int s_id)
		{
			return dal.Exists(s_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_KaoQinCheck model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_KaoQinCheck model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int s_id)
		{
			
			dal.Delete(s_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_KaoQinCheck GetModel(int s_id)
		{
			
			return dal.GetModel(s_id);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_KaoQinCheck> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_KaoQinCheck> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_KaoQinCheck> modelList = new List<Tunnel.Model.Tunnel_KaoQinCheck>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_KaoQinCheck model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_KaoQinCheck();
					if(dt.Rows[n]["s_id"].ToString()!="")
					{
						model.s_id=int.Parse(dt.Rows[n]["s_id"].ToString());
					}
					if(dt.Rows[n]["s_year"].ToString()!="")
					{
						model.s_year=int.Parse(dt.Rows[n]["s_year"].ToString());
					}
					if(dt.Rows[n]["s_moon"].ToString()!="")
					{
						model.s_moon=int.Parse(dt.Rows[n]["s_moon"].ToString());
					}
					if(dt.Rows[n]["s_bid"].ToString()!="")
					{
						model.s_bid=int.Parse(dt.Rows[n]["s_bid"].ToString());
					}
					model.s_bname=dt.Rows[n]["s_bname"].ToString();
					if(dt.Rows[n]["s_uid"].ToString()!="")
					{
						model.s_uid=int.Parse(dt.Rows[n]["s_uid"].ToString());
					}
					if(dt.Rows[n]["s_date"].ToString()!="")
					{
						model.s_date=DateTime.Parse(dt.Rows[n]["s_date"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

