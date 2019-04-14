using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_formtype ��ժҪ˵����
	/// </summary>
	public class Tunnel_formtype
	{
		private readonly Tunnel.DAL.Tunnel_formtype dal=new Tunnel.DAL.Tunnel_formtype();
		public Tunnel_formtype()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Tunnel.Model.Tunnel_formtype model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_formtype model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Form_id)
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			dal.Delete(Form_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public Tunnel.Model.Tunnel_formtype GetModel(int Form_id)
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.GetModel(Form_id);
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
		public List<Tunnel.Model.Tunnel_formtype> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_formtype> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_formtype> modelList = new List<Tunnel.Model.Tunnel_formtype>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_formtype model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_formtype();
					if(dt.Rows[n]["Form_id"].ToString()!="")
					{
						model.Form_id=int.Parse(dt.Rows[n]["Form_id"].ToString());
					}
					model.Form_name=dt.Rows[n]["Form_name"].ToString();
					if(dt.Rows[n]["Item_max"].ToString()!="")
					{
						model.Item_max=int.Parse(dt.Rows[n]["Item_max"].ToString());
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

