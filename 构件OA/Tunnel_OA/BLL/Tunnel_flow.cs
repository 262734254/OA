using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_flow ��ժҪ˵����
	/// </summary>
	public class Tunnel_flow
	{
		private readonly Tunnel.DAL.Tunnel_flow dal=new Tunnel.DAL.Tunnel_flow();
		public Tunnel_flow()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long f_id)
		{
			return dal.Exists(f_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_flow model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_flow model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long f_id)
		{
			
			dal.Delete(f_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_flow GetModel(long f_id)
		{
			
			return dal.GetModel(f_id);
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
		public List<Tunnel.Model.Tunnel_flow> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_flow> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_flow> modelList = new List<Tunnel.Model.Tunnel_flow>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_flow model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_flow();
					//model.f_id=dt.Rows[n]["f_id"].ToString();
					model.f_name=dt.Rows[n]["f_name"].ToString();
					if(dt.Rows[n]["f_bum"].ToString()!="")
					{
						model.f_bum=int.Parse(dt.Rows[n]["f_bum"].ToString());
					}
					if(dt.Rows[n]["f_form"].ToString()!="")
					{
						model.f_form=int.Parse(dt.Rows[n]["f_form"].ToString());
					}
					if(dt.Rows[n]["f_isfile"].ToString()!="")
					{
						model.f_isfile=int.Parse(dt.Rows[n]["f_isfile"].ToString());
					}
					model.f_depict=dt.Rows[n]["f_depict"].ToString();
					if(dt.Rows[n]["f_sort"].ToString()!="")
					{
						model.f_sort=int.Parse(dt.Rows[n]["f_sort"].ToString());
					}
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

