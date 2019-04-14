using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_Cfile 的摘要说明。
	/// </summary>
	public class Tunnel_Cfile
	{
		private readonly Tunnel.DAL.Tunnel_Cfile dal=new Tunnel.DAL.Tunnel_Cfile();
		public Tunnel_Cfile()
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
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_Cfile model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Cfile model)
		{
			dal.Update(model);
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
		public Tunnel.Model.Tunnel_Cfile GetModel(long f_id)
		{
			
			return dal.GetModel(f_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Tunnel.Model.Tunnel_Cfile GetModelByCache(long f_id)
		{
			
			string CacheKey = "Tunnel_CfileModel-" + f_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(f_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_Cfile)objModel;
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
		public List<Tunnel.Model.Tunnel_Cfile> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_Cfile> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Cfile> modelList = new List<Tunnel.Model.Tunnel_Cfile>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Cfile model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Cfile();
					//model.f_id=dt.Rows[n]["f_id"].ToString();
					model.f_title=dt.Rows[n]["f_title"].ToString();
					if(dt.Rows[n]["f_type"].ToString()!="")
					{
						model.f_type=int.Parse(dt.Rows[n]["f_type"].ToString());
					}
					model.f_content=dt.Rows[n]["f_content"].ToString();
					model.f_file=dt.Rows[n]["f_file"].ToString();
					//model.f_first=dt.Rows[n]["f_first"].ToString();
					model.f_other=dt.Rows[n]["f_other"].ToString();
					if(dt.Rows[n]["f_date"].ToString()!="")
					{
						model.f_date=DateTime.Parse(dt.Rows[n]["f_date"].ToString());
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

        public List<Tunnel.Model.Tunnel_Cfile> GetList(PageBase pb,int uid, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_Cfile> modelList = new List<Tunnel.Model.Tunnel_Cfile>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_Cfile model;
                for (int n = 0; n < rowsCount; n++)
                {
                    bool isreaed = false;
                    model = new Tunnel.Model.Tunnel_Cfile();
                    model.f_id = Convert.ToInt64(dt.Rows[n]["f_id"].ToString());
                    model.f_title = dt.Rows[n]["f_title"].ToString();
                    model.f_file = dt.Rows[n]["f_file"].ToString();
                    model.f_type = Convert.ToInt32(dt.Rows[n]["f_type"].ToString());
                    if (dt.Rows[n]["f_date"].ToString() != "")
                    {
                        model.f_date = DateTime.Parse(dt.Rows[n]["f_date"].ToString());
                    }
                    if (dt.Rows[n]["f_user"].ToString() != "")
                    {
                        model.f_user = int.Parse(dt.Rows[n]["f_user"].ToString());
                    }
                    if (dt.Rows[n]["f_first"].ToString() != "")
                    {
                        model.f_first = int.Parse(dt.Rows[n]["f_first"].ToString());
                    }
                    if ((uid != model.f_first || model.f_first == 0))
                    {
                        DataSet ds = Tunnel.Data.DbHelperSQL.Query("select * from Tunnel_cView where c_fid=" + model.f_id);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (model.f_first.ToString().Equals(dr["c_uid"].ToString()))
                            {
                                if (dr["c_read"].ToString() == "1")
                                {
                                    isreaed = true;
                                }
                            }
                            if (isreaed || model.f_first == 0)
                            {
                                if (uid.ToString() == dr["c_uid"].ToString())
                                {
                                    modelList.Add(model);
                                }
                            }
                        }
                    }
                    else
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public List<Tunnel.Model.Tunnel_Cfile> GetList(PageBase pb,ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_Cfile> modelList = new List<Tunnel.Model.Tunnel_Cfile>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_Cfile model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_Cfile();
                    model.f_id = Convert.ToInt64(dt.Rows[n]["f_id"].ToString());
                    model.f_title = dt.Rows[n]["f_title"].ToString();
                    model.f_file = dt.Rows[n]["f_file"].ToString();
                    model.f_type = Convert.ToInt32(dt.Rows[n]["f_type"].ToString());
                    if (dt.Rows[n]["f_date"].ToString() != "")
                    {
                        model.f_date = DateTime.Parse(dt.Rows[n]["f_date"].ToString());
                    }
                    if (dt.Rows[n]["f_user"].ToString() != "")
                    {
                        model.f_user = int.Parse(dt.Rows[n]["f_user"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}

