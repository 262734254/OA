using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_form ��ժҪ˵����
	/// </summary>
	public class Tunnel_form
	{
		private readonly Tunnel.DAL.Tunnel_form dal=new Tunnel.DAL.Tunnel_form();
		public Tunnel_form()
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
        /// ���ӱ�����
        /// </summary>
        public int Name_Add(Tunnel.Model.Tunnel_form model)
        {
            return dal.Name_Add(model);
        }

		/// <summary>
		/// ��Ʊ�����
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_form model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_form model)
		{
			dal.Update(model);
		}

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update_Name(Tunnel.Model.Tunnel_form model)
        {
            dal.Update_Name(model);
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
		public Tunnel.Model.Tunnel_form GetModel(long f_id)
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
		public List<Tunnel.Model.Tunnel_form> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_form> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_form> modelList = new List<Tunnel.Model.Tunnel_form>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_form model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_form();
					//model.f_id=dt.Rows[n]["f_id"].ToString();
					model.f_name=dt.Rows[n]["f_name"].ToString();
					if(dt.Rows[n]["f_bum"].ToString()!="")
					{
						model.f_bum=int.Parse(dt.Rows[n]["f_bum"].ToString());
					}
					if(dt.Rows[n]["f_lcid"].ToString()!="")
					{
						model.f_lcid=int.Parse(dt.Rows[n]["f_lcid"].ToString());
					}
					if(dt.Rows[n]["f_user"].ToString()!="")
					{
						model.f_user=int.Parse(dt.Rows[n]["f_user"].ToString());
					}
					if(dt.Rows[n]["f_date"].ToString()!="")
					{
						model.f_date=DateTime.Parse(dt.Rows[n]["f_date"].ToString());
					}
					model.f_content=dt.Rows[n]["f_content"].ToString();
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

