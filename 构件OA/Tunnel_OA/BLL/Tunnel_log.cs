using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_log 的摘要说明。
	/// </summary>
	public class Tunnel_log
	{
		private readonly Tunnel.DAL.Tunnel_log dal=new Tunnel.DAL.Tunnel_log();
		public Tunnel_log()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long l_id)
		{
			return dal.Exists(l_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_log model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_log model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long l_id)
		{
			
			dal.Delete(l_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_log GetModel(long l_id)
		{
			
			return dal.GetModel(l_id);
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
		public List<Tunnel.Model.Tunnel_log> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_log> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_log> modelList = new List<Tunnel.Model.Tunnel_log>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_log model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_log();
					//model.l_id=dt.Rows[n]["l_id"].ToString();
					if(dt.Rows[n]["l_user"].ToString()!="")
					{
						model.l_user=int.Parse(dt.Rows[n]["l_user"].ToString());
					}
					if(dt.Rows[n]["l_time"].ToString()!="")
					{
						model.l_time=DateTime.Parse(dt.Rows[n]["l_time"].ToString());
					}
					model.l_content=dt.Rows[n]["l_content"].ToString();
					model.l_ip=dt.Rows[n]["l_ip"].ToString();
					if(dt.Rows[n]["l_sort"].ToString()!="")
					{
						model.l_sort=int.Parse(dt.Rows[n]["l_sort"].ToString());
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

