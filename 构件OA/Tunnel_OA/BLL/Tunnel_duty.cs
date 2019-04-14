using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_duty 的摘要说明。
	/// </summary>
	public class Tunnel_duty
	{
		private readonly Tunnel.DAL.Tunnel_duty dal=new Tunnel.DAL.Tunnel_duty();
		public Tunnel_duty()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long d_id)
		{
			return dal.Exists(d_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_duty model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_duty model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long d_id)
		{
			
			dal.Delete(d_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_duty GetModel(long d_id)
		{
			
			return dal.GetModel(d_id);
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
		public List<Tunnel.Model.Tunnel_duty> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_duty> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_duty> modelList = new List<Tunnel.Model.Tunnel_duty>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_duty model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_duty();
					model.d_id=Convert.ToInt64(dt.Rows[n]["d_id"].ToString());
					model.d_name=dt.Rows[n]["d_name"].ToString();
					model.d_depict=dt.Rows[n]["d_depict"].ToString();
					model.d_flag=dt.Rows[n]["d_flag"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

        public List<Tunnel.Model.Tunnel_duty> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_duty> modelList = new List<Tunnel.Model.Tunnel_duty>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_duty model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_duty();
                    model.d_id = Convert.ToInt64(dt.Rows[n]["d_id"].ToString());
                    model.d_name = dt.Rows[n]["d_name"].ToString();
                    model.d_depict = dt.Rows[n]["d_depict"].ToString();
                    model.d_flag = dt.Rows[n]["d_flag"].ToString();
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

