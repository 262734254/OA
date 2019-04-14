using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_items 的摘要说明。
	/// </summary>
	public class Tunnel_items
	{
		private readonly Tunnel.DAL.Tunnel_items dal=new Tunnel.DAL.Tunnel_items();
		public Tunnel_items()
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
		public bool Exists(int i_id)
		{
			return dal.Exists(i_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_items model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_items model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int i_id)
		{
			
			dal.Delete(i_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_items GetModel(int i_id)
		{
			
			return dal.GetModel(i_id);
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
		public List<Tunnel.Model.Tunnel_items> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        public List<Tunnel.Model.Tunnel_items> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_items> modelList = new List<Tunnel.Model.Tunnel_items>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_items model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_items();
                    if (dt.Rows[n]["i_id"].ToString() != "")
                    {
                        model.i_id = int.Parse(dt.Rows[n]["i_id"].ToString());
                    }
                    model.i_name = dt.Rows[n]["i_name"].ToString();
                    model.year = dt.Rows[n]["year"].ToString();
                    model.moon = dt.Rows[n]["moon"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_items> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_items> modelList = new List<Tunnel.Model.Tunnel_items>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_items model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_items();
					if(dt.Rows[n]["i_id"].ToString()!="")
					{
						model.i_id=int.Parse(dt.Rows[n]["i_id"].ToString());
					}
					model.i_name=dt.Rows[n]["i_name"].ToString();
					model.year=dt.Rows[n]["year"].ToString();
					model.moon=dt.Rows[n]["moon"].ToString();
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

