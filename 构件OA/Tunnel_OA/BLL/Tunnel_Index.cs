using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_Index ��ժҪ˵����
	/// </summary>
	public class Tunnel_Index
	{
        private readonly Tunnel.DAL.Tunnel_Index dal = new Tunnel.DAL.Tunnel_Index();
		public Tunnel_Index()
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
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_index model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Update(Tunnel.Model.Tunnel_index model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_index GetModel(int id)
		{
			
			return dal.GetModel(id);
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
		public List<Tunnel.Model.Tunnel_index> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_index> DataTableToList(DataTable dt)
		{
            List<Tunnel.Model.Tunnel_index> modelList = new List<Tunnel.Model.Tunnel_index>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Tunnel.Model.Tunnel_index model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Tunnel.Model.Tunnel_index();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["typeId"].ToString()!="")
					{
						model.TypeId=int.Parse(dt.Rows[n]["typeId"].ToString());
					}
					model.Title=dt.Rows[n]["title"].ToString();
					model.Content=dt.Rows[n]["content"].ToString();
					model.ImagePaht=dt.Rows[n]["imagePaht"].ToString();
					model.HtmlSource=dt.Rows[n]["htmlSource"].ToString();
					if(dt.Rows[n]["setDate"].ToString()!="")
					{
						model.SetDate=Convert.ToString(dt.Rows[n]["setDate"].ToString());
					}
					if(dt.Rows[n]["userId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["userId"].ToString());
					}
					model.Files=dt.Rows[n]["files"].ToString();
                    model.Filename = dt.Rows[n]["filename"].ToString();
					modelList.Add(model);
				}
			}
			return (List<Tunnel.Model.Tunnel_index>)modelList;
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

        public DataSet GetNewsHead(string id)
        {
            return dal.GetNewsHead(id);
        }
		#endregion  ��Ա����
	}
}

