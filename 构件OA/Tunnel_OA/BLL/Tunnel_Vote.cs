using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_Vote ��ժҪ˵����
	/// </summary>
	public class Tunnel_Vote
	{
		private readonly Tunnel.DAL.Tunnel_Vote dal=new Tunnel.DAL.Tunnel_Vote();
		public Tunnel_Vote()
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
		public bool Exists(int vote_Id)
		{
			return dal.Exists(vote_Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_Vote model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Vote model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int vote_Id)
		{
			
			dal.Delete(vote_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_Vote GetModel(int vote_Id)
		{
			
			return dal.GetModel(vote_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
	
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
		public List<Tunnel.Model.Tunnel_Vote> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_Vote> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Vote> modelList = new List<Tunnel.Model.Tunnel_Vote>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Vote model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Vote();
					if(dt.Rows[n]["vote_Id"].ToString()!="")
					{
						model.vote_Id=int.Parse(dt.Rows[n]["vote_Id"].ToString());
					}
					if(dt.Rows[n]["vote_userId"].ToString()!="")
					{
						model.vote_userId=int.Parse(dt.Rows[n]["vote_userId"].ToString());
					}
					model.vote_userGroup=dt.Rows[n]["vote_userGroup"].ToString();
					model.vote_bumGroup=dt.Rows[n]["vote_bumGroup"].ToString();
					model.vote_jsGroup=dt.Rows[n]["vote_jsGroup"].ToString();
					model.vote_Title=dt.Rows[n]["vote_Title"].ToString();
					model.vote_mark=dt.Rows[n]["vote_mark"].ToString();
					if(dt.Rows[n]["vote_Type"].ToString()!="")
					{
						model.vote_Type=int.Parse(dt.Rows[n]["vote_Type"].ToString());
					}
					if(dt.Rows[n]["vote_startDate"].ToString()!="")
					{
						model.vote_startDate=DateTime.Parse(dt.Rows[n]["vote_startDate"].ToString());
					}
					if(dt.Rows[n]["vote_endDate"].ToString()!="")
					{
						model.vote_endDate=DateTime.Parse(dt.Rows[n]["vote_endDate"].ToString());
					}
					if(dt.Rows[n]["vote_seeType"].ToString()!="")
					{
						model.vote_seeType=int.Parse(dt.Rows[n]["vote_seeType"].ToString());
					}
					if(dt.Rows[n]["vote_state"].ToString()!="")
					{
						model.vote_state=int.Parse(dt.Rows[n]["vote_state"].ToString());
					}
					if(dt.Rows[n]["vote_max"].ToString()!="")
					{
						model.vote_max=int.Parse(dt.Rows[n]["vote_max"].ToString());
					}
					if(dt.Rows[n]["vote_top"].ToString()!="")
					{
						model.vote_top=int.Parse(dt.Rows[n]["vote_top"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

        public List<Tunnel.Model.Tunnel_Vote> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_Vote> modelList = new List<Tunnel.Model.Tunnel_Vote>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_Vote model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_Vote();
                    if (dt.Rows[n]["vote_Id"].ToString() != "")
                    {
                        model.vote_Id = int.Parse(dt.Rows[n]["vote_Id"].ToString());
                    }
                    if (dt.Rows[n]["vote_userId"].ToString() != "")
                    {
                        model.vote_userId = int.Parse(dt.Rows[n]["vote_userId"].ToString());
                    }
                    model.vote_userGroup = dt.Rows[n]["vote_userGroup"].ToString();
                    model.vote_bumGroup = dt.Rows[n]["vote_bumGroup"].ToString();
                    model.vote_jsGroup = dt.Rows[n]["vote_jsGroup"].ToString();
                    model.vote_Title = dt.Rows[n]["vote_Title"].ToString();
                    model.vote_mark = dt.Rows[n]["vote_mark"].ToString();
                    if (dt.Rows[n]["vote_Type"].ToString() != "")
                    {
                        model.vote_Type = int.Parse(dt.Rows[n]["vote_Type"].ToString());
                    }
                    if (dt.Rows[n]["vote_startDate"].ToString() != "")
                    {
                        model.vote_startDate = DateTime.Parse(dt.Rows[n]["vote_startDate"].ToString());
                    }
                    if (dt.Rows[n]["vote_endDate"].ToString() != "")
                    {
                        model.vote_endDate = DateTime.Parse(dt.Rows[n]["vote_endDate"].ToString());
                    }
                    if (dt.Rows[n]["vote_seeType"].ToString() != "")
                    {
                        model.vote_seeType = int.Parse(dt.Rows[n]["vote_seeType"].ToString());
                    }
                    if (dt.Rows[n]["vote_state"].ToString() != "")
                    {
                        model.vote_state = int.Parse(dt.Rows[n]["vote_state"].ToString());
                    }
                    if (dt.Rows[n]["vote_max"].ToString() != "")
                    {
                        model.vote_max = int.Parse(dt.Rows[n]["vote_max"].ToString());
                    }
                    if (dt.Rows[n]["vote_top"].ToString() != "")
                    {
                        model.vote_top = int.Parse(dt.Rows[n]["vote_top"].ToString());
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

