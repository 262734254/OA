using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Vote_Info ��ժҪ˵����
	/// </summary>
	public class Vote_Info
	{
		private readonly Tunnel.DAL.Vote_Info dal=new Tunnel.DAL.Vote_Info();
		public Vote_Info()
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
		public bool Exists(int v_id)
		{
			return dal.Exists(v_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Vote_Info model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Vote_Info model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int v_id)
		{
			
			dal.Delete(v_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Vote_Info GetModel(int v_id)
		{
			
			return dal.GetModel(v_id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Tunnel.Model.Vote_Info GetModelByCache(int v_id)
		{
			
			string CacheKey = "Vote_InfoModel-" + v_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(v_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Vote_Info)objModel;
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
		public List<Tunnel.Model.Vote_Info> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Vote_Info> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Vote_Info> modelList = new List<Tunnel.Model.Vote_Info>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Vote_Info model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Vote_Info();
					if(dt.Rows[n]["v_id"].ToString()!="")
					{
						model.v_id=int.Parse(dt.Rows[n]["v_id"].ToString());
					}
					model.v_title=dt.Rows[n]["v_title"].ToString();
					if(dt.Rows[n]["v_count"].ToString()!="")
					{
						model.v_count=int.Parse(dt.Rows[n]["v_count"].ToString());
					}
					model.v_Img=dt.Rows[n]["v_Img"].ToString();
					model.v_author=dt.Rows[n]["v_author"].ToString();
					model.v_remark=dt.Rows[n]["v_remark"].ToString();
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

        /// <summary>
        /// ��ȡ����ͼƬ��źͱ���
        /// </summary>
        /// <param name="vid">ͼƬ���</param>
        /// <param name="otopid">��һ��ͼƬ���</param>
        /// <param name="odownid">��һ��ͼƬ���</param>
        /// <param name="toptitle">��һ��ͼƬ����</param>
        /// <param name="downtitle">��һ��ͼƬ����</param>
        public void GetTopDown(int vid, out int otopid, out int odownid, out string toptitle, out string downtitle)
        {
            dal.GetTopDown(vid, out otopid, out odownid, out toptitle, out downtitle);
        }
        /// <summary>
        /// ���۷�ҳ��ѯ
        /// </summary>
        /// <param name="vateid">���</param>
        /// <param name="pagesize">ÿҳ����</param>
        /// <param name="pageindex">��ǰҳ��</param>
        /// <param name="outvalue">�ܹ�ҳ��</param>
        /// <returns></returns>
        public DataTable SelectListPage(int vateid, int pagesize, int pageindex, out int outvalue)
        {
            return dal.SelectListPage(vateid, pagesize, pageindex, out outvalue);
        }
        /// <summary>
        /// ͼƬ��ҳ��ѯ
        /// </summary>
        /// <param name="pagesize">ÿҳ����</param>
        /// <param name="pageindex">��ǰҳ��</param>
        /// <param name="outvalue">�ܹ�ҳ��</param>
        /// <returns></returns>
        public DataTable SelectImgList(int pagesize, int pageindex, out int outvalue)
        {
            return dal.SelectImgList(pagesize, pageindex, out outvalue);
        }
		#endregion  ��Ա����
	}
}

