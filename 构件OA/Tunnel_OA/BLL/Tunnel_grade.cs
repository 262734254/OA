using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_grade 的摘要说明。
	/// </summary>
	public class Tunnel_grade
	{
		private readonly Tunnel.DAL.Tunnel_grade dal=new Tunnel.DAL.Tunnel_grade();
		public Tunnel_grade()
		{}
		#region  成员方法

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
		public bool Exists(int g_id)
		{
			return dal.Exists(g_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_grade model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_grade model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int g_id)
		{
			
			dal.Delete(g_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_grade GetModel(int g_id)
		{
			
			return dal.GetModel(g_id);
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
		public List<Tunnel.Model.Tunnel_grade> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_grade> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_grade> modelList = new List<Tunnel.Model.Tunnel_grade>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_grade model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_grade();
					if(dt.Rows[n]["g_id"].ToString()!="")
					{
						model.g_id=int.Parse(dt.Rows[n]["g_id"].ToString());
					}
					if(dt.Rows[n]["g_workId"].ToString()!="")
					{
						model.g_workId=int.Parse(dt.Rows[n]["g_workId"].ToString());
					}
					if(dt.Rows[n]["g_checkId"].ToString()!="")
					{
						model.g_checkId=int.Parse(dt.Rows[n]["g_checkId"].ToString());
					}
					if(dt.Rows[n]["g_cent"].ToString()!="")
					{
						model.g_cent=Convert.ToSingle(dt.Rows[n]["g_cent"].ToString());
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

