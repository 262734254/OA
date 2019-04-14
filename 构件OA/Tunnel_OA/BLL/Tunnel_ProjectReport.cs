using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_ProjectReport ��ժҪ˵����
	/// </summary>
	public class Tunnel_ProjectReport
	{
		private readonly Tunnel.DAL.Tunnel_ProjectReport dal=new Tunnel.DAL.Tunnel_ProjectReport();
		public Tunnel_ProjectReport()
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
		public bool Exists(int Report_Id)
		{
			return dal.Exists(Report_Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_ProjectReport model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_ProjectReport model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Report_Id)
		{
			
			dal.Delete(Report_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_ProjectReport GetModel(int Report_Id)
		{
			
			return dal.GetModel(Report_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Tunnel.Model.Tunnel_ProjectReport GetModelByCache(int Report_Id)
		{
			
			string CacheKey = "Tunnel_ProjectReportModel-" + Report_Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Report_Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_ProjectReport)objModel;
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
		public List<Tunnel.Model.Tunnel_ProjectReport> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_ProjectReport> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_ProjectReport> modelList = new List<Tunnel.Model.Tunnel_ProjectReport>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_ProjectReport model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_ProjectReport();
					if(dt.Rows[n]["Report_Id"].ToString()!="")
					{
						model.Report_Id=int.Parse(dt.Rows[n]["Report_Id"].ToString());
					}
					model.Report_Name=dt.Rows[n]["Report_Name"].ToString();
					if(dt.Rows[n]["Report_Class"].ToString()!="")
					{
						model.Report_Class=int.Parse(dt.Rows[n]["Report_Class"].ToString());
					}
					if(dt.Rows[n]["Report_Sort"].ToString()!="")
					{
						model.Report_Sort=int.Parse(dt.Rows[n]["Report_Sort"].ToString());
					}
					if(dt.Rows[n]["Report_State"].ToString()!="")
					{
						model.Report_State=int.Parse(dt.Rows[n]["Report_State"].ToString());
					}
					if(dt.Rows[n]["Report_Shen"].ToString()!="")
					{
						model.Report_Shen=int.Parse(dt.Rows[n]["Report_Shen"].ToString());
					}
					if(dt.Rows[n]["Report_Order"].ToString()!="")
					{
						model.Report_Order=int.Parse(dt.Rows[n]["Report_Order"].ToString());
					}
					if(dt.Rows[n]["Report_UserID"].ToString()!="")
					{
						model.Report_UserID=int.Parse(dt.Rows[n]["Report_UserID"].ToString());
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

