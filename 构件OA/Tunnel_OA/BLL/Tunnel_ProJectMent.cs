using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_ProJectMent ��ժҪ˵����
	/// </summary>
	public class Tunnel_ProJectMent
	{
		private readonly Tunnel.DAL.Tunnel_ProJectMent dal=new Tunnel.DAL.Tunnel_ProJectMent();
		public Tunnel_ProJectMent()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long Pro_Id)
		{
			return dal.Exists(Pro_Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_ProJectMent model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_ProJectMent model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long Pro_Id)
		{
			
			dal.Delete(Pro_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_ProJectMent GetModel(long Pro_Id)
		{
			
			return dal.GetModel(Pro_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Tunnel.Model.Tunnel_ProJectMent GetModelByCache(long Pro_Id)
		{
			
			string CacheKey = "Tunnel_ProJectMentModel-" + Pro_Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Pro_Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_ProJectMent)objModel;
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
		public List<Tunnel.Model.Tunnel_ProJectMent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_ProJectMent> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_ProJectMent> modelList = new List<Tunnel.Model.Tunnel_ProJectMent>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_ProJectMent model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_ProJectMent();
					//model.Pro_Id=dt.Rows[n]["Pro_Id"].ToString();
					model.Pro_Title=dt.Rows[n]["Pro_Title"].ToString();
					model.Pro_Name=dt.Rows[n]["Pro_Name"].ToString();
					if(dt.Rows[n]["Pro_StartDate"].ToString()!="")
					{
						model.Pro_StartDate=DateTime.Parse(dt.Rows[n]["Pro_StartDate"].ToString());
					}
					if(dt.Rows[n]["Pro_EndDate"].ToString()!="")
					{
						model.Pro_EndDate=DateTime.Parse(dt.Rows[n]["Pro_EndDate"].ToString());
					}
					if(dt.Rows[n]["Pro_ManDate"].ToString()!="")
					{
						model.Pro_ManDate=DateTime.Parse(dt.Rows[n]["Pro_ManDate"].ToString());
					}
					if(dt.Rows[n]["Pro_ManEndDate"].ToString()!="")
					{
						model.Pro_ManEndDate=DateTime.Parse(dt.Rows[n]["Pro_ManEndDate"].ToString());
					}
					if(dt.Rows[n]["Pro_ContractDate"].ToString()!="")
					{
						model.Pro_ContractDate=DateTime.Parse(dt.Rows[n]["Pro_ContractDate"].ToString());
					}
					if(dt.Rows[n]["Pro_ContractEndDate"].ToString()!="")
					{
						model.Pro_ContractEndDate=DateTime.Parse(dt.Rows[n]["Pro_ContractEndDate"].ToString());
					}
					if(dt.Rows[n]["Pro_EquipmentDate"].ToString()!="")
					{
						model.Pro_EquipmentDate=DateTime.Parse(dt.Rows[n]["Pro_EquipmentDate"].ToString());
					}
					if(dt.Rows[n]["Pro_EquipmentEndDate"].ToString()!="")
					{
						model.Pro_EquipmentEndDate=DateTime.Parse(dt.Rows[n]["Pro_EquipmentEndDate"].ToString());
					}
					if(dt.Rows[n]["Pro_MaterialDate"].ToString()!="")
					{
						model.Pro_MaterialDate=DateTime.Parse(dt.Rows[n]["Pro_MaterialDate"].ToString());
					}
					if(dt.Rows[n]["Pro_MaterialEndDate"].ToString()!="")
					{
						model.Pro_MaterialEndDate=DateTime.Parse(dt.Rows[n]["Pro_MaterialEndDate"].ToString());
					}
					if(dt.Rows[n]["Pro_PlanDate"].ToString()!="")
					{
						model.Pro_PlanDate=DateTime.Parse(dt.Rows[n]["Pro_PlanDate"].ToString());
					}
					if(dt.Rows[n]["Pro_PlanEndDate"].ToString()!="")
					{
						model.Pro_PlanEndDate=DateTime.Parse(dt.Rows[n]["Pro_PlanEndDate"].ToString());
					}
					if(dt.Rows[n]["Pro_SecurityDate"].ToString()!="")
					{
						model.Pro_SecurityDate=DateTime.Parse(dt.Rows[n]["Pro_SecurityDate"].ToString());
					}
					if(dt.Rows[n]["Pro_SecurityEndDate"].ToString()!="")
					{
						model.Pro_SecurityEndDate=DateTime.Parse(dt.Rows[n]["Pro_SecurityEndDate"].ToString());
					}
					if(dt.Rows[n]["Pro_Status"].ToString()!="")
					{
						model.Pro_Status=int.Parse(dt.Rows[n]["Pro_Status"].ToString());
					}
					//model.Pro_Manager=dt.Rows[n]["Pro_Manager"].ToString();
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

