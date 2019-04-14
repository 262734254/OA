using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_weekplan ��ժҪ˵����
	/// </summary>
	public class Tunnel_weekplan
	{
		private readonly Tunnel.DAL.Tunnel_weekplan dal=new Tunnel.DAL.Tunnel_weekplan();
		public Tunnel_weekplan()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string week_id)
		{
            return dal.Exists(week_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_weekplan model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_weekplan model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int w_id)
		{
			
			dal.Delete(w_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_weekplan GetModel(long w_id)
		{
			
			return dal.GetModel(w_id);
		}

	

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_weekplan> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_weekplan> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_weekplan> modelList = new List<Tunnel.Model.Tunnel_weekplan>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_weekplan model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_weekplan();
					//model.w_id=dt.Rows[n]["w_id"].ToString();
					model.w_title=dt.Rows[n]["w_title"].ToString();
					model.w_content=dt.Rows[n]["w_content"].ToString();
					model.w_address=dt.Rows[n]["w_address"].ToString();
					model.w_time=dt.Rows[n]["w_time"].ToString();
					model.w_daytime=dt.Rows[n]["w_daytime"].ToString();
					if(dt.Rows[n]["w_adddate"].ToString()!="")
					{
						model.w_adddate=DateTime.Parse(dt.Rows[n]["w_adddate"].ToString());
					}
					//model.w_weekID=dt.Rows[n]["w_weekID"].ToString();
					model.w_date=dt.Rows[n]["w_date"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

