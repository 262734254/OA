using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_Remind ��ժҪ˵����
	/// </summary>
	public class Tunnel_Remind
	{
		private readonly Tunnel.DAL.Tunnel_Remind dal=new Tunnel.DAL.Tunnel_Remind();
		public Tunnel_Remind()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long m_id)
		{
			return dal.Exists(m_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public long Add(Tunnel.Model.Tunnel_Remind model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Remind model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long m_id)
		{
			
			dal.Delete(m_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_Remind GetModel(long m_id)
		{
			
			return dal.GetModel(m_id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Tunnel.Model.Tunnel_Remind GetModelByCache(long m_id)
		{
			
			string CacheKey = "Tunnel_RemindModel-" + m_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(m_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_Remind)objModel;
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
		public List<Tunnel.Model.Tunnel_Remind> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_Remind> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Remind> modelList = new List<Tunnel.Model.Tunnel_Remind>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Remind model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Remind();
                    if (dt.Rows[n]["m_id"].ToString() != "")
                    {
                        model.m_id = long.Parse(dt.Rows[n]["m_id"].ToString());
                    }
					model.m_title=dt.Rows[n]["m_title"].ToString();
					model.m_url=dt.Rows[n]["m_url"].ToString();
					//model.m_touser=dt.Rows[n]["m_touser"].ToString();
					if(dt.Rows[n]["m_time"].ToString()!="")
					{
						model.m_time=DateTime.Parse(dt.Rows[n]["m_time"].ToString());
					}
					if(dt.Rows[n]["m_isread"].ToString()!="")
					{
						model.m_isread=int.Parse(dt.Rows[n]["m_isread"].ToString());
					}
					if(dt.Rows[n]["m_callTime"].ToString()!="")
					{
						model.m_callTime=DateTime.Parse(dt.Rows[n]["m_callTime"].ToString());
					}
					if(dt.Rows[n]["m_type"].ToString()!="")
					{
						model.m_type=int.Parse(dt.Rows[n]["m_type"].ToString());
					}
					if(dt.Rows[n]["m_typeid"].ToString()!="")
					{
						model.m_typeid=int.Parse(dt.Rows[n]["m_typeid"].ToString());
					}
                    if (dt.Rows[n]["m_bid"].ToString() != "")
                    {
                        model.m_bid = int.Parse(dt.Rows[n]["m_bid"].ToString());
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

