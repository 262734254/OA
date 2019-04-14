using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_PageMessage ��ժҪ˵����
	/// </summary>
	public class Tunnel_PageMessage
	{
		private readonly Tunnel.DAL.Tunnel_PageMessage dal=new Tunnel.DAL.Tunnel_PageMessage();
        
		public Tunnel_PageMessage()
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
		public bool Exists(int pic_ID)
		{
			return dal.Exists(pic_ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_PageMessage model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_PageMessage model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int pic_ID)
		{
			
			dal.Delete(pic_ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_PageMessage GetModel(int pic_ID)
		{
			
			return dal.GetModel(pic_ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Tunnel.Model.Tunnel_PageMessage GetModelByCache(int pic_ID)
		{
			
			string CacheKey = "Tunnel_PageMessageModel-" + pic_ID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(pic_ID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_PageMessage)objModel;
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
		public List<Tunnel.Model.Tunnel_PageMessage> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_PageMessage> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_PageMessage> modelList = new List<Tunnel.Model.Tunnel_PageMessage>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_PageMessage model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_PageMessage();
					if(dt.Rows[n]["pic_ID"].ToString()!="")
					{
						model.pic_ID=int.Parse(dt.Rows[n]["pic_ID"].ToString());
					}
					model.pic_AspxName=dt.Rows[n]["pic_AspxName"].ToString();
					model.pic_TitleName=dt.Rows[n]["pic_TitleName"].ToString();
					model.pic_TopicName=dt.Rows[n]["pic_TopicName"].ToString();
					model.pic_TopImgURL=dt.Rows[n]["pic_TopImgURL"].ToString();
					model.pic_BgColor=dt.Rows[n]["pic_BgColor"].ToString();
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

