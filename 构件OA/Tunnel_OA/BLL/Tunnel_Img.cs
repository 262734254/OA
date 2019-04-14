using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_Img 的摘要说明。
	/// </summary>
	public class Tunnel_Img
	{
		private readonly Tunnel.DAL.Tunnel_Img dal=new Tunnel.DAL.Tunnel_Img();
		public Tunnel_Img()
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
		public int  Add(Tunnel.Model.Tunnel_Img model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Img model)
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
		public Tunnel.Model.Tunnel_Img GetModel(int i_id)
		{
			
			return dal.GetModel(i_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Tunnel.Model.Tunnel_Img GetModelByCache(int i_id)
		{
			
			string CacheKey = "Tunnel_ImgModel-" + i_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(i_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_Img)objModel;
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
		public List<Tunnel.Model.Tunnel_Img> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_Img> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_Img> modelList = new List<Tunnel.Model.Tunnel_Img>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_Img model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_Img();
                    if (dt.Rows[n]["i_id"].ToString() != "")
                    {
                        model.i_id = int.Parse(dt.Rows[n]["i_id"].ToString());
                    }
                    model.i_name = dt.Rows[n]["i_name"].ToString();
                    model.i_uri = dt.Rows[n]["i_uri"].ToString();
                    if (dt.Rows[n]["i_date"].ToString() != "")
                    {
                        model.i_date = DateTime.Parse(dt.Rows[n]["i_date"].ToString());
                    }
                    if (dt.Rows[n]["i_user"].ToString() != "")
                    {
                        model.i_user = int.Parse(dt.Rows[n]["i_user"].ToString());
                    }
                    if (dt.Rows[n]["i_type"].ToString() != "")
                    {
                        model.i_type = dt.Rows[n]["i_type"].ToString();
                    }
                    if (dt.Rows[n]["i_year"].ToString() != "")
                    {
                        model.i_year =dt.Rows[n]["i_year"].ToString();
                    }                 
                    modelList.Add(model);
                }
            }
            return modelList;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_Img> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Img> modelList = new List<Tunnel.Model.Tunnel_Img>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Img model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Img();
					if(dt.Rows[n]["i_id"].ToString()!="")
					{
						model.i_id=int.Parse(dt.Rows[n]["i_id"].ToString());
					}
					model.i_name=dt.Rows[n]["i_name"].ToString();
					model.i_uri=dt.Rows[n]["i_uri"].ToString();
					if(dt.Rows[n]["i_date"].ToString()!="")
					{
						model.i_date=DateTime.Parse(dt.Rows[n]["i_date"].ToString());
					}
					if(dt.Rows[n]["i_user"].ToString()!="")
					{
						model.i_user=int.Parse(dt.Rows[n]["i_user"].ToString());
					}
					model.i_type=dt.Rows[n]["i_type"].ToString();
					model.i_year=dt.Rows[n]["i_year"].ToString();
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

