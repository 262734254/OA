using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_Advice 的摘要说明。
	/// </summary>
	public class Tunnel_Advice
	{
		private readonly Tunnel.DAL.Tunnel_Advice dal=new Tunnel.DAL.Tunnel_Advice();
		public Tunnel_Advice()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long a_id)
		{
			return dal.Exists(a_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_Advice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Advice model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long a_id)
		{
			
			dal.Delete(a_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_Advice GetModel(long a_id)
		{
			
			return dal.GetModel(a_id);
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
		public List<Tunnel.Model.Tunnel_Advice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_Advice> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Advice> modelList = new List<Tunnel.Model.Tunnel_Advice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Advice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Advice();
					//model.a_id=dt.Rows[n]["a_id"].ToString();
					if(dt.Rows[n]["a_user"].ToString()!="")
					{
						model.a_user=int.Parse(dt.Rows[n]["a_user"].ToString());
					}
					if(dt.Rows[n]["a_bid"].ToString()!="")
					{
						model.a_bid=int.Parse(dt.Rows[n]["a_bid"].ToString());
					}
					model.a_content=dt.Rows[n]["a_content"].ToString();
					if(dt.Rows[n]["a_time"].ToString()!="")
					{
						model.a_time=DateTime.Parse(dt.Rows[n]["a_time"].ToString());
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

