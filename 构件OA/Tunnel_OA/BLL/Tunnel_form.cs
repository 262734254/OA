using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_form 的摘要说明。
	/// </summary>
	public class Tunnel_form
	{
		private readonly Tunnel.DAL.Tunnel_form dal=new Tunnel.DAL.Tunnel_form();
		public Tunnel_form()
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
        /// 增加表单名称
        /// </summary>
        public int Name_Add(Tunnel.Model.Tunnel_form model)
        {
            return dal.Name_Add(model);
        }

		/// <summary>
		/// 设计表单内容
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_form model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_form model)
		{
			dal.Update(model);
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update_Name(Tunnel.Model.Tunnel_form model)
        {
            dal.Update_Name(model);
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
		public Tunnel.Model.Tunnel_form GetModel(long f_id)
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
		public List<Tunnel.Model.Tunnel_form> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_form> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_form> modelList = new List<Tunnel.Model.Tunnel_form>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_form model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_form();
					//model.f_id=dt.Rows[n]["f_id"].ToString();
					model.f_name=dt.Rows[n]["f_name"].ToString();
					if(dt.Rows[n]["f_bum"].ToString()!="")
					{
						model.f_bum=int.Parse(dt.Rows[n]["f_bum"].ToString());
					}
					if(dt.Rows[n]["f_lcid"].ToString()!="")
					{
						model.f_lcid=int.Parse(dt.Rows[n]["f_lcid"].ToString());
					}
					if(dt.Rows[n]["f_user"].ToString()!="")
					{
						model.f_user=int.Parse(dt.Rows[n]["f_user"].ToString());
					}
					if(dt.Rows[n]["f_date"].ToString()!="")
					{
						model.f_date=DateTime.Parse(dt.Rows[n]["f_date"].ToString());
					}
					model.f_content=dt.Rows[n]["f_content"].ToString();
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

