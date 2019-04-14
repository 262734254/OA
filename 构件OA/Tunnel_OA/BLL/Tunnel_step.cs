using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_step ��ժҪ˵����
	/// </summary>
	public class Tunnel_step
	{
		private readonly Tunnel.DAL.Tunnel_step dal=new Tunnel.DAL.Tunnel_step();
		public Tunnel_step()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long s_id)
		{
			return dal.Exists(s_id);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_step model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_step model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long s_id)
		{
			
			dal.Delete(s_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_step GetModel(long s_id)
		{
			
			return dal.GetModel(s_id);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// ������ݼ�¼��
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
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
		public List<Tunnel.Model.Tunnel_step> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_step> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_step> modelList = new List<Tunnel.Model.Tunnel_step>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_step model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_step();
					model.s_id=int.Parse(dt.Rows[n]["s_id"].ToString());
					model.s_name=dt.Rows[n]["s_name"].ToString();
					if(dt.Rows[n]["s_num"].ToString()!="")
					{
						model.s_num=int.Parse(dt.Rows[n]["s_num"].ToString());
					}
					model.s_zid=dt.Rows[n]["s_zid"].ToString();
					if(dt.Rows[n]["s_lid"].ToString()!="")
					{
						model.s_lid=int.Parse(dt.Rows[n]["s_lid"].ToString());
					}
					model.s_depict=dt.Rows[n]["s_depict"].ToString();
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

