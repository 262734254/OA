using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_MingXing ��ժҪ˵����
	/// </summary>
	public class Tunnel_MingXing
	{
		private readonly Tunnel.DAL.Tunnel_MingXing dal=new Tunnel.DAL.Tunnel_MingXing();
		public Tunnel_MingXing()
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
		public bool Exists(int m_id)
		{
			return dal.Exists(m_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_MingXing model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_MingXing model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int m_id)
		{
			
			dal.Delete(m_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_MingXing GetModel(int m_id)
		{
			
			return dal.GetModel(m_id);
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
		public List<Tunnel.Model.Tunnel_MingXing> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        public List<Tunnel.Model.Tunnel_MingXing> GetModelMingXIng(string strWhere)
        {
            DataSet ds = dal.GetListMingXing(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_MingXing> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_MingXing> modelList = new List<Tunnel.Model.Tunnel_MingXing>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_MingXing model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_MingXing();
					if(dt.Rows[n]["m_id"].ToString()!="")
					{
						model.m_id=int.Parse(dt.Rows[n]["m_id"].ToString());
					}
					if(dt.Rows[n]["m_uid"].ToString()!="")
					{
						model.m_uid=int.Parse(dt.Rows[n]["m_uid"].ToString());
					}
					model.m_img=dt.Rows[n]["m_img"].ToString();
					model.m_content=dt.Rows[n]["m_content"].ToString();
                    model.Title = dt.Rows[n]["m_title"].ToString();
					if(dt.Rows[n]["m_year"].ToString()!="")
					{
						model.m_year=int.Parse(dt.Rows[n]["m_year"].ToString());
					}
					if(dt.Rows[n]["m_moon"].ToString()!="")
					{
						model.m_moon=int.Parse(dt.Rows[n]["m_moon"].ToString());
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

