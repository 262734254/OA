using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_weekstate ��ժҪ˵����
	/// </summary>
	public class Tunnel_weekstate
	{
		private readonly Tunnel.DAL.Tunnel_weekstate dal=new Tunnel.DAL.Tunnel_weekstate();
		public Tunnel_weekstate()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string week_ID)
		{
			return dal.Exists(week_ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Tunnel.Model.Tunnel_weekstate model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_weekstate model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string week_ID)
		{
			
			dal.Delete(week_ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_weekstate GetModel(string week_ID)
		{
			
			return dal.GetModel(week_ID);
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
		public List<Tunnel.Model.Tunnel_weekstate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_weekstate> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_weekstate> modelList = new List<Tunnel.Model.Tunnel_weekstate>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_weekstate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_weekstate();
					model.week_ID=dt.Rows[n]["week_ID"].ToString();
					if(dt.Rows[n]["week_state"].ToString()!="")
					{
						model.week_state=int.Parse(dt.Rows[n]["week_state"].ToString());
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

