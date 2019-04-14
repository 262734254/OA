using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_flow 的摘要说明。
	/// </summary>
	public class Tunnel_flow
	{
		private readonly Tunnel.DAL.Tunnel_flow dal=new Tunnel.DAL.Tunnel_flow();
		public Tunnel_flow()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long f_id)
		{
			return dal.Exists(f_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_flow model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_flow model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long f_id)
		{
			
			dal.Delete(f_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_flow GetModel(long f_id)
		{
			
			return dal.GetModel(f_id);
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
		public List<Tunnel.Model.Tunnel_flow> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_flow> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_flow> modelList = new List<Tunnel.Model.Tunnel_flow>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_flow model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_flow();
					//model.f_id=dt.Rows[n]["f_id"].ToString();
					model.f_name=dt.Rows[n]["f_name"].ToString();
					if(dt.Rows[n]["f_bum"].ToString()!="")
					{
						model.f_bum=int.Parse(dt.Rows[n]["f_bum"].ToString());
					}
					if(dt.Rows[n]["f_form"].ToString()!="")
					{
						model.f_form=int.Parse(dt.Rows[n]["f_form"].ToString());
					}
					if(dt.Rows[n]["f_isfile"].ToString()!="")
					{
						model.f_isfile=int.Parse(dt.Rows[n]["f_isfile"].ToString());
					}
					model.f_depict=dt.Rows[n]["f_depict"].ToString();
					if(dt.Rows[n]["f_sort"].ToString()!="")
					{
						model.f_sort=int.Parse(dt.Rows[n]["f_sort"].ToString());
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

