using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_Advice ��ժҪ˵����
	/// </summary>
	public class Tunnel_Advice
	{
		private readonly Tunnel.DAL.Tunnel_Advice dal=new Tunnel.DAL.Tunnel_Advice();
		public Tunnel_Advice()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long a_id)
		{
			return dal.Exists(a_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_Advice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Advice model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long a_id)
		{
			
			dal.Delete(a_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_Advice GetModel(long a_id)
		{
			
			return dal.GetModel(a_id);
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
		public List<Tunnel.Model.Tunnel_Advice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_Advice> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Advice> modelList = new List<Tunnel.Model.Tunnel_Advice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Advice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Advice();
					//model.a_id=dt.Rows[n]["a_id"].ToString();
					if(dt.Rows[n]["a_user"].ToString()!="")
					{
						model.a_user=int.Parse(dt.Rows[n]["a_user"].ToString());
					}
					if(dt.Rows[n]["a_bid"].ToString()!="")
					{
						model.a_bid=int.Parse(dt.Rows[n]["a_bid"].ToString());
					}
					model.a_content=dt.Rows[n]["a_content"].ToString();
					if(dt.Rows[n]["a_time"].ToString()!="")
					{
						model.a_time=DateTime.Parse(dt.Rows[n]["a_time"].ToString());
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

