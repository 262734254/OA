using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_kaosetting 的摘要说明。
	/// </summary>
	public class Tunnel_kaosetting
	{
		private readonly Tunnel.DAL.Tunnel_kaosetting dal=new Tunnel.DAL.Tunnel_kaosetting();
		public Tunnel_kaosetting()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long k_id)
		{
			return dal.Exists(k_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_kaosetting model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_kaosetting model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long k_id)
		{
			
			dal.Delete(k_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_kaosetting GetModel(long k_id)
		{
			
			return dal.GetModel(k_id);
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
		public List<Tunnel.Model.Tunnel_kaosetting> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_kaosetting> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_kaosetting> modelList = new List<Tunnel.Model.Tunnel_kaosetting>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_kaosetting model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_kaosetting();
					model.k_id=Convert.ToInt64( dt.Rows[n]["k_id"].ToString());
					model.k_amtime=dt.Rows[n]["k_amtime"].ToString();
					model.k_pmtime=dt.Rows[n]["k_pmtime"].ToString();
					model.k_xiu=dt.Rows[n]["k_xiu"].ToString();
					model.k_am2time=dt.Rows[n]["k_am2time"].ToString();
					model.k_pm2time=dt.Rows[n]["k_pm2time"].ToString();
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

