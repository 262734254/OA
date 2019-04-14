using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_Index 的摘要说明。
	/// </summary>
	public class Tunnel_Index
	{
        private readonly Tunnel.DAL.Tunnel_Index dal = new Tunnel.DAL.Tunnel_Index();
		public Tunnel_Index()
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
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_index model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Tunnel.Model.Tunnel_index model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_index GetModel(int id)
		{
			
			return dal.GetModel(id);
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
		public List<Tunnel.Model.Tunnel_index> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_index> DataTableToList(DataTable dt)
		{
            List<Tunnel.Model.Tunnel_index> modelList = new List<Tunnel.Model.Tunnel_index>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Tunnel.Model.Tunnel_index model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Tunnel.Model.Tunnel_index();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["typeId"].ToString()!="")
					{
						model.TypeId=int.Parse(dt.Rows[n]["typeId"].ToString());
					}
					model.Title=dt.Rows[n]["title"].ToString();
					model.Content=dt.Rows[n]["content"].ToString();
					model.ImagePaht=dt.Rows[n]["imagePaht"].ToString();
					model.HtmlSource=dt.Rows[n]["htmlSource"].ToString();
					if(dt.Rows[n]["setDate"].ToString()!="")
					{
						model.SetDate=Convert.ToString(dt.Rows[n]["setDate"].ToString());
					}
					if(dt.Rows[n]["userId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["userId"].ToString());
					}
					model.Files=dt.Rows[n]["files"].ToString();
                    model.Filename = dt.Rows[n]["filename"].ToString();
					modelList.Add(model);
				}
			}
			return (List<Tunnel.Model.Tunnel_index>)modelList;
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

        public DataSet GetNewsHead(string id)
        {
            return dal.GetNewsHead(id);
        }
		#endregion  成员方法
	}
}

