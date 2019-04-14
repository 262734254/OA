using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���VoteLog ��ժҪ˵����
	/// </summary>
	public class VoteLog
	{
		private readonly Tunnel.DAL.VoteLog dal=new Tunnel.DAL.VoteLog();
		public VoteLog()
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
		public bool Exists(int vg_id)
		{
			return dal.Exists(vg_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Tunnel.Model.VoteLog model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.VoteLog model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int vg_id)
		{
			
			dal.Delete(vg_id);
		}
        /// <summary>
        /// ɾ��ͶƱ��¼
        /// </summary>
        /// <param name="vg_voteId"></param>
        public void DeleteByVote_ID(int vg_voteId)
        {
            dal.DeleteByVote_ID(vg_voteId);
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.VoteLog GetModel(int vg_id)
		{
			
			return dal.GetModel(vg_id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Tunnel.Model.VoteLog GetModelByCache(int vg_id)
		{
			
			string CacheKey = "VoteLogModel-" + vg_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(vg_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.VoteLog)objModel;
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
		public List<Tunnel.Model.VoteLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.VoteLog> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.VoteLog> modelList = new List<Tunnel.Model.VoteLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.VoteLog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.VoteLog();
					if(dt.Rows[n]["vg_id"].ToString()!="")
					{
						model.vg_id=int.Parse(dt.Rows[n]["vg_id"].ToString());
					}
					if(dt.Rows[n]["vg_setDate"].ToString()!="")
					{
						model.vg_setDate=DateTime.Parse(dt.Rows[n]["vg_setDate"].ToString());
					}
					if(dt.Rows[n]["vg_userId"].ToString()!="")
					{
						model.vg_userId=int.Parse(dt.Rows[n]["vg_userId"].ToString());
					}
					if(dt.Rows[n]["vg_voteId"].ToString()!="")
					{
						model.vg_voteId=int.Parse(dt.Rows[n]["vg_voteId"].ToString());
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

