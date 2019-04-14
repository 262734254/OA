using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_log ��ժҪ˵����
	/// </summary>
	public class Tunnel_log
	{
		private readonly Tunnel.DAL.Tunnel_log dal=new Tunnel.DAL.Tunnel_log();
		public Tunnel_log()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long l_id)
		{
			return dal.Exists(l_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_log model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_log model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long l_id)
		{
			
			dal.Delete(l_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_log GetModel(long l_id)
		{
			
			return dal.GetModel(l_id);
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
		public List<Tunnel.Model.Tunnel_log> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_log> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_log> modelList = new List<Tunnel.Model.Tunnel_log>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_log model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_log();
					//model.l_id=dt.Rows[n]["l_id"].ToString();
					if(dt.Rows[n]["l_user"].ToString()!="")
					{
						model.l_user=int.Parse(dt.Rows[n]["l_user"].ToString());
					}
					if(dt.Rows[n]["l_time"].ToString()!="")
					{
						model.l_time=DateTime.Parse(dt.Rows[n]["l_time"].ToString());
					}
					model.l_content=dt.Rows[n]["l_content"].ToString();
					model.l_ip=dt.Rows[n]["l_ip"].ToString();
					if(dt.Rows[n]["l_sort"].ToString()!="")
					{
						model.l_sort=int.Parse(dt.Rows[n]["l_sort"].ToString());
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

