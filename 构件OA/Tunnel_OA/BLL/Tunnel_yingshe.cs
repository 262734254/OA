using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_yingshe 的摘要说明。
	/// </summary>
	public class Tunnel_yingshe
	{
		private readonly Tunnel.DAL.Tunnel_yingshe dal=new Tunnel.DAL.Tunnel_yingshe();
		public Tunnel_yingshe()
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
		public bool Exists(int y_id)
		{
			return dal.Exists(y_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Tunnel.Model.Tunnel_yingshe model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public void Update(Tunnel.Model.Tunnel_yingshe model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int y_id)
		{
			
			dal.Delete(y_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tunnel.Model.Tunnel_yingshe GetModel(int y_id)
		{
			
			return dal.GetModel(y_id);
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
        public List<Tunnel.Model.Tunnel_yingshe> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Tunnel.Model.Tunnel_yingshe> DataTableToList(DataTable dt)
		{
            List<Tunnel.Model.Tunnel_yingshe> modelList = new List<Tunnel.Model.Tunnel_yingshe>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Tunnel.Model.Tunnel_yingshe model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Tunnel.Model.Tunnel_yingshe();
					if(dt.Rows[n]["y_id"].ToString()!="")
					{
						model.y_id=int.Parse(dt.Rows[n]["y_id"].ToString());
					}
					if(dt.Rows[n]["y_jsid"].ToString()!="")
					{
						model.y_jsid=int.Parse(dt.Rows[n]["y_jsid"].ToString());
					}
					model.y_qxlist=dt.Rows[n]["y_qxlist"].ToString();
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

