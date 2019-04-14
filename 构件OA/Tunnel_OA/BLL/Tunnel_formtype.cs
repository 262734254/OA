using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_formtype 的摘要说明。
	/// </summary>
	public class Tunnel_formtype
	{
		private readonly Tunnel.DAL.Tunnel_formtype dal=new Tunnel.DAL.Tunnel_formtype();
		public Tunnel_formtype()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Tunnel.Model.Tunnel_formtype model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_formtype model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Form_id)
		{
			//该表无主键信息，请自定义主键/条件字段
			dal.Delete(Form_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tunnel.Model.Tunnel_formtype GetModel(int Form_id)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(Form_id);
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
		public List<Tunnel.Model.Tunnel_formtype> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_formtype> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_formtype> modelList = new List<Tunnel.Model.Tunnel_formtype>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_formtype model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_formtype();
					if(dt.Rows[n]["Form_id"].ToString()!="")
					{
						model.Form_id=int.Parse(dt.Rows[n]["Form_id"].ToString());
					}
					model.Form_name=dt.Rows[n]["Form_name"].ToString();
					if(dt.Rows[n]["Item_max"].ToString()!="")
					{
						model.Item_max=int.Parse(dt.Rows[n]["Item_max"].ToString());
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

