using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_kaoqin ��ժҪ˵����
	/// </summary>
	public class Tunnel_kaoqin
	{
		private readonly Tunnel.DAL.Tunnel_kaoqin dal=new Tunnel.DAL.Tunnel_kaoqin();
		public Tunnel_kaoqin()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long k_id)
		{
			return dal.Exists(k_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_kaoqin model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_kaoqin model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long k_id)
		{
			
			dal.Delete(k_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_kaoqin GetModel(long k_id)
		{
			
			return dal.GetModel(k_id);
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
		public List<Tunnel.Model.Tunnel_kaoqin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_kaoqin> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_kaoqin> modelList = new List<Tunnel.Model.Tunnel_kaoqin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_kaoqin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_kaoqin();
					model.k_id=Convert.ToInt64(dt.Rows[n]["k_id"].ToString());
					if(dt.Rows[n]["k_date"].ToString()!="")
					{
						model.k_date=DateTime.Parse(dt.Rows[n]["k_date"].ToString());
					}
					model.k_amtime=dt.Rows[n]["k_amtime"].ToString();
					model.k_pmtime=dt.Rows[n]["k_pmtime"].ToString();
					model.k_endtime=dt.Rows[n]["k_endtime"].ToString();
					if(dt.Rows[n]["k_user"].ToString()!="")
					{
						model.k_user=int.Parse(dt.Rows[n]["k_user"].ToString());
					}
					if(dt.Rows[n]["k_ifsb"].ToString()!="")
					{
						model.k_ifsb=int.Parse(dt.Rows[n]["k_ifsb"].ToString());
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

