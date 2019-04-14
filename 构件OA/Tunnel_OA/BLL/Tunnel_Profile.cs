using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_Profile 的摘要说明。
	/// </summary>
	public class Tunnel_Profile
	{
		private readonly Tunnel.DAL.Tunnel_Profile dal=new Tunnel.DAL.Tunnel_Profile();
		public Tunnel_Profile()
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
		public bool Exists(int p_id)
		{
			return dal.Exists(p_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_Profile model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Profile model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int p_id)
		{
			
			dal.Delete(p_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_Profile GetModel(int p_id)
		{
			
			return dal.GetModel(p_id);
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
		public List<Tunnel.Model.Tunnel_Profile> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}


        
        
        /// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Tunnel.Model.Tunnel_Profile> GetList(PageBase pb, ref int count)
		{
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
			List<Tunnel.Model.Tunnel_Profile> modelList = new List<Tunnel.Model.Tunnel_Profile>();
			int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
			{
				Tunnel.Model.Tunnel_Profile model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Profile();
					if(dt.Rows[n]["p_id"].ToString()!="")
					{
						model.p_id=int.Parse(dt.Rows[n]["p_id"].ToString());
					}
					model.p_name=dt.Rows[n]["p_name"].ToString();
					if(dt.Rows[n]["p_year"].ToString()!="")
					{
						model.p_year=int.Parse(dt.Rows[n]["p_year"].ToString());
					}
					model.p_bum=dt.Rows[n]["p_bum"].ToString();
					model.p_filetype=dt.Rows[n]["p_filetype"].ToString();
					if(dt.Rows[n]["p_uid"].ToString()!="")
					{
						model.p_uid=int.Parse(dt.Rows[n]["p_uid"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_Profile> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Profile> modelList = new List<Tunnel.Model.Tunnel_Profile>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Profile model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Profile();
					if(dt.Rows[n]["p_id"].ToString()!="")
					{
						model.p_id=int.Parse(dt.Rows[n]["p_id"].ToString());
					}
					model.p_name=dt.Rows[n]["p_name"].ToString();
					if(dt.Rows[n]["p_year"].ToString()!="")
					{
						model.p_year=int.Parse(dt.Rows[n]["p_year"].ToString());
					}
					model.p_bum=dt.Rows[n]["p_bum"].ToString();
					model.p_filetype=dt.Rows[n]["p_filetype"].ToString();
					if(dt.Rows[n]["p_uid"].ToString()!="")
					{
						model.p_uid=int.Parse(dt.Rows[n]["p_uid"].ToString());
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

