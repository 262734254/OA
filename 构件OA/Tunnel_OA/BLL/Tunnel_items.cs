using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_items ��ժҪ˵����
	/// </summary>
	public class Tunnel_items
	{
		private readonly Tunnel.DAL.Tunnel_items dal=new Tunnel.DAL.Tunnel_items();
		public Tunnel_items()
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
		public bool Exists(int i_id)
		{
			return dal.Exists(i_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_items model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_items model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int i_id)
		{
			
			dal.Delete(i_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_items GetModel(int i_id)
		{
			
			return dal.GetModel(i_id);
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
		public List<Tunnel.Model.Tunnel_items> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        public List<Tunnel.Model.Tunnel_items> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_items> modelList = new List<Tunnel.Model.Tunnel_items>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_items model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_items();
                    if (dt.Rows[n]["i_id"].ToString() != "")
                    {
                        model.i_id = int.Parse(dt.Rows[n]["i_id"].ToString());
                    }
                    model.i_name = dt.Rows[n]["i_name"].ToString();
                    model.year = dt.Rows[n]["year"].ToString();
                    model.moon = dt.Rows[n]["moon"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_items> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_items> modelList = new List<Tunnel.Model.Tunnel_items>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_items model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_items();
					if(dt.Rows[n]["i_id"].ToString()!="")
					{
						model.i_id=int.Parse(dt.Rows[n]["i_id"].ToString());
					}
					model.i_name=dt.Rows[n]["i_name"].ToString();
					model.year=dt.Rows[n]["year"].ToString();
					model.moon=dt.Rows[n]["moon"].ToString();
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

