using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_Votei ��ժҪ˵����
	/// </summary>
	public class Tunnel_Votei
	{
		private readonly Tunnel.DAL.Tunnel_Votei dal=new Tunnel.DAL.Tunnel_Votei();
		public Tunnel_Votei()
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
		public bool Exists(int ivote_Id)
		{
			return dal.Exists(ivote_Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_Votei model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Votei model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ivote_Id)
		{
			
			dal.Delete(ivote_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_Votei GetModel(int ivote_Id)
		{
			
			return dal.GetModel(ivote_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Tunnel.Model.Tunnel_Votei GetModelByCache(int ivote_Id)
		{
			
			string CacheKey = "Tunnel_VoteiModel-" + ivote_Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ivote_Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_Votei)objModel;
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
		public List<Tunnel.Model.Tunnel_Votei> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_Votei> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Votei> modelList = new List<Tunnel.Model.Tunnel_Votei>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Votei model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Votei();
					if(dt.Rows[n]["ivote_Id"].ToString()!="")
					{
						model.ivote_Id=int.Parse(dt.Rows[n]["ivote_Id"].ToString());
					}
					model.ivote_Title=dt.Rows[n]["ivote_Title"].ToString();
					if(dt.Rows[n]["ivote_Count"].ToString()!="")
					{
						model.ivote_Count=int.Parse(dt.Rows[n]["ivote_Count"].ToString());
					}
					model.ivote_yesUserId=dt.Rows[n]["ivote_yesUserId"].ToString();
					if(dt.Rows[n]["ivote_voteId"].ToString()!="")
					{
						model.ivote_voteId=int.Parse(dt.Rows[n]["ivote_voteId"].ToString());
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

