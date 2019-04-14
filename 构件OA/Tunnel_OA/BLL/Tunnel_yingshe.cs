using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_yingshe ��ժҪ˵����
	/// </summary>
	public class Tunnel_yingshe
	{
		private readonly Tunnel.DAL.Tunnel_yingshe dal=new Tunnel.DAL.Tunnel_yingshe();
		public Tunnel_yingshe()
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
		public bool Exists(int y_id)
		{
			return dal.Exists(y_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Add(Tunnel.Model.Tunnel_yingshe model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public void Update(Tunnel.Model.Tunnel_yingshe model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int y_id)
		{
			
			dal.Delete(y_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public Tunnel.Model.Tunnel_yingshe GetModel(int y_id)
		{
			
			return dal.GetModel(y_id);
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
        public List<Tunnel.Model.Tunnel_yingshe> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
        public List<Tunnel.Model.Tunnel_yingshe> DataTableToList(DataTable dt)
		{
            List<Tunnel.Model.Tunnel_yingshe> modelList = new List<Tunnel.Model.Tunnel_yingshe>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Tunnel.Model.Tunnel_yingshe model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Tunnel.Model.Tunnel_yingshe();
					if(dt.Rows[n]["y_id"].ToString()!="")
					{
						model.y_id=int.Parse(dt.Rows[n]["y_id"].ToString());
					}
					if(dt.Rows[n]["y_jsid"].ToString()!="")
					{
						model.y_jsid=int.Parse(dt.Rows[n]["y_jsid"].ToString());
					}
					model.y_qxlist=dt.Rows[n]["y_qxlist"].ToString();
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

