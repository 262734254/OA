using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_anpai ��ժҪ˵����
	/// </summary>
	public class Tunnel_anpai
	{
		private readonly Tunnel.DAL.Tunnel_anpai dal=new Tunnel.DAL.Tunnel_anpai();
		public Tunnel_anpai()
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
		public bool Exists(int a_id)
		{
			return dal.Exists(a_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_anpai model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_anpai model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int a_id)
		{
			
			dal.Delete(a_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_anpai GetModel(int a_id)
		{
			
			return dal.GetModel(a_id);
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
		public List<Tunnel.Model.Tunnel_anpai> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_anpai> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_anpai> modelList = new List<Tunnel.Model.Tunnel_anpai>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_anpai model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_anpai();
					if(dt.Rows[n]["a_id"].ToString()!="")
					{
						model.a_id=int.Parse(dt.Rows[n]["a_id"].ToString());
					}
					model.a_title=dt.Rows[n]["a_title"].ToString();
					model.a_content=dt.Rows[n]["a_content"].ToString();
					if(dt.Rows[n]["a_date"].ToString()!="")
					{
						model.a_date=DateTime.Parse(dt.Rows[n]["a_date"].ToString());
					}
					model.a_ampm=dt.Rows[n]["a_ampm"].ToString();
					if(dt.Rows[n]["a_userId"].ToString()!="")
					{
						model.a_userId=int.Parse(dt.Rows[n]["a_userId"].ToString());
					}
					if(dt.Rows[n]["a_createDate"].ToString()!="")
					{
						model.a_createDate=DateTime.Parse(dt.Rows[n]["a_createDate"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

        public List<Tunnel.Model.Tunnel_anpai> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_anpai> modelList = new List<Tunnel.Model.Tunnel_anpai>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_anpai model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_anpai();
                    if (dt.Rows[n]["a_id"].ToString() != "")
                    {
                        model.a_id = int.Parse(dt.Rows[n]["a_id"].ToString());
                    }
                    model.a_title = dt.Rows[n]["a_title"].ToString();
                    model.a_content = dt.Rows[n]["a_content"].ToString();
                    if (dt.Rows[n]["a_date"].ToString() != "")
                    {
                        model.a_date = DateTime.Parse(dt.Rows[n]["a_date"].ToString());
                    }
                    model.a_ampm = dt.Rows[n]["a_ampm"].ToString();
                    if (dt.Rows[n]["a_userId"].ToString() != "")
                    {
                        model.a_userId = int.Parse(dt.Rows[n]["a_userId"].ToString());
                    }
                    if (dt.Rows[n]["a_createDate"].ToString() != "")
                    {
                        model.a_createDate = DateTime.Parse(dt.Rows[n]["a_createDate"].ToString());
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

