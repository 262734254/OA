using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_step 的摘要说明。
	/// </summary>
	public class Tunnel_step
	{
		private readonly Tunnel.DAL.Tunnel_step dal=new Tunnel.DAL.Tunnel_step();
		public Tunnel_step()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long s_id)
		{
			return dal.Exists(s_id);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_step model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_step model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long s_id)
		{
			
			dal.Delete(s_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_step GetModel(long s_id)
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
        /// 获得数据记录数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
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
		public List<Tunnel.Model.Tunnel_step> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_step> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_step> modelList = new List<Tunnel.Model.Tunnel_step>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_step model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_step();
					model.s_id=int.Parse(dt.Rows[n]["s_id"].ToString());
					model.s_name=dt.Rows[n]["s_name"].ToString();
					if(dt.Rows[n]["s_num"].ToString()!="")
					{
						model.s_num=int.Parse(dt.Rows[n]["s_num"].ToString());
					}
					model.s_zid=dt.Rows[n]["s_zid"].ToString();
					if(dt.Rows[n]["s_lid"].ToString()!="")
					{
						model.s_lid=int.Parse(dt.Rows[n]["s_lid"].ToString());
					}
					model.s_depict=dt.Rows[n]["s_depict"].ToString();
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

