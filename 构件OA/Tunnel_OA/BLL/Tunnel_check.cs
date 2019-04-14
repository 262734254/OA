using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_check ��ժҪ˵����
	/// </summary>
	public class Tunnel_check
	{
		private readonly Tunnel.DAL.Tunnel_check dal=new Tunnel.DAL.Tunnel_check();
		public Tunnel_check()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int c_id)
		{
			return dal.Exists(c_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_check model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_check model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int c_id)
		{
			
			dal.Delete(c_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_check GetModel(int c_id)
		{
			
			return dal.GetModel(c_id);
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
		public List<Tunnel.Model.Tunnel_check> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_check> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_check> modelList = new List<Tunnel.Model.Tunnel_check>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_check model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_check();
					if(dt.Rows[n]["c_id"].ToString()!="")
					{
						model.c_id=int.Parse(dt.Rows[n]["c_id"].ToString());
					}
					if(dt.Rows[n]["c_userId"].ToString()!="")
					{
						model.c_userId=int.Parse(dt.Rows[n]["c_userId"].ToString());
					}
					if(dt.Rows[n]["c_itemsId"].ToString()!="")
					{
						model.c_itemsId=int.Parse(dt.Rows[n]["c_itemsId"].ToString());
					}
					if(dt.Rows[n]["c_score"].ToString()!="")
					{
						model.c_score=int.Parse(dt.Rows[n]["c_score"].ToString());
					}
					if(dt.Rows[n]["c_income"].ToString()!="")
					{
						model.c_income=dt.Rows[n]["c_income"].ToString();
					}
					model.c_date=dt.Rows[n]["c_date"].ToString();
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

