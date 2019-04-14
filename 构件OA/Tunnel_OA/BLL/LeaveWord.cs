using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���LeaveWord ��ժҪ˵����
	/// </summary>
	public class LeaveWord
	{
		private readonly Tunnel.DAL.LeaveWord dal=new Tunnel.DAL.LeaveWord();
		public LeaveWord()
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
		public bool Exists(int lw_Id)
		{
			return dal.Exists(lw_Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Tunnel.Model.LeaveWord model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.LeaveWord model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int lw_Id)
		{
			
			dal.Delete(lw_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.LeaveWord GetModel(int lw_Id)
		{
			
			return dal.GetModel(lw_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Tunnel.Model.LeaveWord GetModelByCache(int lw_Id)
		{
			
			string CacheKey = "LeaveWordModel-" + lw_Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(lw_Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.LeaveWord)objModel;
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
		public List<Tunnel.Model.LeaveWord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.LeaveWord> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.LeaveWord> modelList = new List<Tunnel.Model.LeaveWord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.LeaveWord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.LeaveWord();
					if(dt.Rows[n]["lw_Id"].ToString()!="")
					{
						model.lw_Id=int.Parse(dt.Rows[n]["lw_Id"].ToString());
					}
					if(dt.Rows[n]["lw_SetDate"].ToString()!="")
					{
						model.lw_SetDate=DateTime.Parse(dt.Rows[n]["lw_SetDate"].ToString());
					}
					model.lw_Content=dt.Rows[n]["lw_Content"].ToString();
					if(dt.Rows[n]["lw_UserId"].ToString()!="")
					{
						model.lw_UserId=int.Parse(dt.Rows[n]["lw_UserId"].ToString());
					}
					if(dt.Rows[n]["lw_VateId"].ToString()!="")
					{
						model.lw_VateId=int.Parse(dt.Rows[n]["lw_VateId"].ToString());
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

