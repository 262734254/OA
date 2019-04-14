using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_byingshe ��ժҪ˵����
	/// </summary>
	public class Tunnel_byingshe
	{
		private readonly Tunnel.DAL.Tunnel_byingshe dal=new Tunnel.DAL.Tunnel_byingshe();
		public Tunnel_byingshe()
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
		public bool Exists(int by_id)
		{
			return dal.Exists(by_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_byingshe model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_byingshe model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int by_id)
		{
			
			dal.Delete(by_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_byingshe GetModel(int by_id)
		{
			
			return dal.GetModel(by_id);
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
		public List<Tunnel.Model.Tunnel_byingshe> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_byingshe> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_byingshe> modelList = new List<Tunnel.Model.Tunnel_byingshe>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_byingshe model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_byingshe();
					if(dt.Rows[n]["by_id"].ToString()!="")
					{
						model.by_id=int.Parse(dt.Rows[n]["by_id"].ToString());
					}
					model.by_bid=dt.Rows[n]["by_bid"].ToString();
					model.by_list=dt.Rows[n]["by_list"].ToString();
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

