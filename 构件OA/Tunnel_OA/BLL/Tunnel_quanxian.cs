using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_quanxian ��ժҪ˵����
	/// </summary>
	public class Tunnel_quanxian
	{
		private readonly Tunnel.DAL.Tunnel_quanxian dal=new Tunnel.DAL.Tunnel_quanxian();
		public Tunnel_quanxian()
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
		public bool Exists(int q_id)
		{
			return dal.Exists(q_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Add(Tunnel.Model.Tunnel_quanxian model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public void Update(Tunnel.Model.Tunnel_quanxian model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int q_id)
		{
			
			dal.Delete(q_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public Tunnel.Model.Tunnel_quanxian GetModel(int q_id)
		{
			
			return dal.GetModel(q_id);
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
        public List<Tunnel.Model.Tunnel_quanxian> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
        public List<Tunnel.Model.Tunnel_quanxian> DataTableToList(DataTable dt)
		{
            List<Tunnel.Model.Tunnel_quanxian> modelList = new List<Tunnel.Model.Tunnel_quanxian>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Tunnel.Model.Tunnel_quanxian model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Tunnel.Model.Tunnel_quanxian();
					if(dt.Rows[n]["q_id"].ToString()!="")
					{
						model.q_id=int.Parse(dt.Rows[n]["q_id"].ToString());
					}
					model.q_name=dt.Rows[n]["q_name"].ToString();
					model.q_mark=dt.Rows[n]["q_mark"].ToString();
                    model.q_rId = Convert.ToInt32(dt.Rows[n]["q_rId"].ToString());
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

