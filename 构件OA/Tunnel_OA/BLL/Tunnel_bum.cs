using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_bum 的摘要说明。
	/// </summary>
	public class Tunnel_bum
	{
		private readonly Tunnel.DAL.Tunnel_bum dal=new Tunnel.DAL.Tunnel_bum();
		public Tunnel_bum()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long b_id)
		{
			return dal.Exists(b_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_bum model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_bum model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long b_id)
		{
			
			dal.Delete(b_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_bum GetModel(long b_id)
		{
			
			return dal.GetModel(b_id);
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
		public List<Tunnel.Model.Tunnel_bum> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_bum> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_bum> modelList = new List<Tunnel.Model.Tunnel_bum>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_bum model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_bum();
					model.b_id=Convert.ToInt64(dt.Rows[n]["b_id"].ToString());
					model.b_name=dt.Rows[n]["b_name"].ToString();
					if(dt.Rows[n]["b_hid"].ToString()!="")
					{
						model.b_hid=int.Parse(dt.Rows[n]["b_hid"].ToString());
					}
                    if (dt.Rows[n]["b_projectid"].ToString() != "")
                    {
                        model.b_projectid = int.Parse(dt.Rows[n]["b_projectid"].ToString());
                    }
					model.b_depict=dt.Rows[n]["b_depict"].ToString();
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

