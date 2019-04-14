using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_jiaose 的摘要说明。
	/// </summary>
	public class Tunnel_jiaose
	{
		private readonly Tunnel.DAL.Tunnel_jiaose dal=new Tunnel.DAL.Tunnel_jiaose();
		public Tunnel_jiaose()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long j_id)
		{
			return dal.Exists(j_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_jiaose model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public void Update(Tunnel.Model.Tunnel_jiaose model)
		{
			dal.Update(model);
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateJS(int id,int sort)
        {
            return dal.UpdateSort(id,sort);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long j_id)
		{
			
			dal.Delete(j_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tunnel.Model.Tunnel_jiaose GetModel(long j_id)
		{
			
			return dal.GetModel(j_id);
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
        public List<Tunnel.Model.Tunnel_jiaose> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Tunnel.Model.Tunnel_jiaose> DataTableToList(DataTable dt)
		{
            List<Tunnel.Model.Tunnel_jiaose> modelList = new List<Tunnel.Model.Tunnel_jiaose>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Tunnel.Model.Tunnel_jiaose model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Tunnel.Model.Tunnel_jiaose();
					model.j_id=Convert.ToInt64(dt.Rows[n]["j_id"].ToString());
					if(dt.Rows[n]["j_name"].ToString()!="")
					{
						model.j_name=dt.Rows[n]["j_name"].ToString();
					}
					if(dt.Rows[n]["j_depict"].ToString()!="")
					{
						model.j_depict=dt.Rows[n]["j_depict"].ToString();
					}
					model.j_flag=dt.Rows[n]["j_flag"].ToString();
					if(dt.Rows[n]["j_zdyjs"].ToString()!="")
					{
						model.j_zdyjs=int.Parse(dt.Rows[n]["j_zdyjs"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

        public List<Tunnel.Model.Tunnel_jiaose> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_jiaose> modelList = new List<Tunnel.Model.Tunnel_jiaose>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_jiaose model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_jiaose();
                    model.j_id=Convert.ToInt64(dt.Rows[n]["j_id"].ToString());
                    if (dt.Rows[n]["j_name"].ToString() != "")
                    {
                        model.j_name = dt.Rows[n]["j_name"].ToString();
                    }
                    if (dt.Rows[n]["j_depict"].ToString() != "")
                    {
                        model.j_depict = dt.Rows[n]["j_depict"].ToString();
                    }
                    model.j_flag = dt.Rows[n]["j_flag"].ToString();
                    if (dt.Rows[n]["j_zdyjs"].ToString() != "")
                    {
                        model.j_zdyjs = int.Parse(dt.Rows[n]["j_zdyjs"].ToString());
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

