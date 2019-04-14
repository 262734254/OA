using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_exam ��ժҪ˵����
	/// </summary>
	public class Tunnel_exam
	{
		private readonly Tunnel.DAL.Tunnel_exam dal=new Tunnel.DAL.Tunnel_exam();
		public Tunnel_exam()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long e_id)
		{
			return dal.Exists(e_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_exam model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_exam model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long e_id)
		{
			
			dal.Delete(e_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_exam GetModel(long e_id)
		{
			
			return dal.GetModel(e_id);
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
		public List<Tunnel.Model.Tunnel_exam> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_exam> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_exam> modelList = new List<Tunnel.Model.Tunnel_exam>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_exam model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_exam();
					//model.e_id=dt.Rows[n]["e_id"].ToString();
					if(dt.Rows[n]["e_gid"].ToString()!="")
					{
						model.e_gid=int.Parse(dt.Rows[n]["e_gid"].ToString());
					}
					if(dt.Rows[n]["e_bid"].ToString()!="")
					{
						model.e_bid=int.Parse(dt.Rows[n]["e_bid"].ToString());
					}
					if(dt.Rows[n]["e_time"].ToString()!="")
					{
						model.e_time=DateTime.Parse(dt.Rows[n]["e_time"].ToString());
					}
					if(dt.Rows[n]["e_user"].ToString()!="")
					{
						model.e_user=int.Parse(dt.Rows[n]["e_user"].ToString());
					}
					if(dt.Rows[n]["e_endtime"].ToString()!="")
					{
						model.e_endtime=DateTime.Parse(dt.Rows[n]["e_endtime"].ToString());
					}
					//model.e_nextbid=dt.Rows[n]["e_nextbid"].ToString();
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

