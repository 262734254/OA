using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_bum ��ժҪ˵����
	/// </summary>
	public class Tunnel_bum
	{
		private readonly Tunnel.DAL.Tunnel_bum dal=new Tunnel.DAL.Tunnel_bum();
		public Tunnel_bum()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long b_id)
		{
			return dal.Exists(b_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_bum model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_bum model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long b_id)
		{
			
			dal.Delete(b_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_bum GetModel(long b_id)
		{
			
			return dal.GetModel(b_id);
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
		public List<Tunnel.Model.Tunnel_bum> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_bum> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_bum> modelList = new List<Tunnel.Model.Tunnel_bum>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_bum model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_bum();
					model.b_id=Convert.ToInt64(dt.Rows[n]["b_id"].ToString());
					model.b_name=dt.Rows[n]["b_name"].ToString();
					if(dt.Rows[n]["b_hid"].ToString()!="")
					{
						model.b_hid=int.Parse(dt.Rows[n]["b_hid"].ToString());
					}
                    if (dt.Rows[n]["b_projectid"].ToString() != "")
                    {
                        model.b_projectid = int.Parse(dt.Rows[n]["b_projectid"].ToString());
                    }
					model.b_depict=dt.Rows[n]["b_depict"].ToString();
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

