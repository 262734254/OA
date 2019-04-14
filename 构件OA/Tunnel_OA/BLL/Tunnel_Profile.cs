using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_Profile ��ժҪ˵����
	/// </summary>
	public class Tunnel_Profile
	{
		private readonly Tunnel.DAL.Tunnel_Profile dal=new Tunnel.DAL.Tunnel_Profile();
		public Tunnel_Profile()
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
		public bool Exists(int p_id)
		{
			return dal.Exists(p_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_Profile model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Profile model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int p_id)
		{
			
			dal.Delete(p_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_Profile GetModel(int p_id)
		{
			
			return dal.GetModel(p_id);
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
		public List<Tunnel.Model.Tunnel_Profile> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}


        
        
        /// <summary>
		/// ��������б�
		/// </summary>
        public List<Tunnel.Model.Tunnel_Profile> GetList(PageBase pb, ref int count)
		{
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
			List<Tunnel.Model.Tunnel_Profile> modelList = new List<Tunnel.Model.Tunnel_Profile>();
			int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
			{
				Tunnel.Model.Tunnel_Profile model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Profile();
					if(dt.Rows[n]["p_id"].ToString()!="")
					{
						model.p_id=int.Parse(dt.Rows[n]["p_id"].ToString());
					}
					model.p_name=dt.Rows[n]["p_name"].ToString();
					if(dt.Rows[n]["p_year"].ToString()!="")
					{
						model.p_year=int.Parse(dt.Rows[n]["p_year"].ToString());
					}
					model.p_bum=dt.Rows[n]["p_bum"].ToString();
					model.p_filetype=dt.Rows[n]["p_filetype"].ToString();
					if(dt.Rows[n]["p_uid"].ToString()!="")
					{
						model.p_uid=int.Parse(dt.Rows[n]["p_uid"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_Profile> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Profile> modelList = new List<Tunnel.Model.Tunnel_Profile>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Profile model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Profile();
					if(dt.Rows[n]["p_id"].ToString()!="")
					{
						model.p_id=int.Parse(dt.Rows[n]["p_id"].ToString());
					}
					model.p_name=dt.Rows[n]["p_name"].ToString();
					if(dt.Rows[n]["p_year"].ToString()!="")
					{
						model.p_year=int.Parse(dt.Rows[n]["p_year"].ToString());
					}
					model.p_bum=dt.Rows[n]["p_bum"].ToString();
					model.p_filetype=dt.Rows[n]["p_filetype"].ToString();
					if(dt.Rows[n]["p_uid"].ToString()!="")
					{
						model.p_uid=int.Parse(dt.Rows[n]["p_uid"].ToString());
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

