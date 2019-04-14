using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_Chat 的摘要说明。
	/// </summary>
	public class Tunnel_Chat
	{
		private readonly Tunnel.DAL.Tunnel_Chat dal=new Tunnel.DAL.Tunnel_Chat();
		public Tunnel_Chat()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Chat_ID)
		{
			return dal.Exists(Chat_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_Chat model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Chat model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long Chat_ID)
		{
			
			dal.Delete(Chat_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_Chat GetModel(long Chat_ID)
		{
			
			return dal.GetModel(Chat_ID);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_Chat> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_Chat> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Chat> modelList = new List<Tunnel.Model.Tunnel_Chat>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Chat model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Chat();
					//model.Chat_ID=dt.Rows[n]["Chat_ID"].ToString();
					//model.Chat_UserID=dt.Rows[n]["Chat_UserID"].ToString();
					model.Chat_UserName=dt.Rows[n]["Chat_UserName"].ToString();
					model.Chat_Content=dt.Rows[n]["Chat_Content"].ToString();
					if(dt.Rows[n]["Chat_Date"].ToString()!="")
					{
						model.Chat_Date=DateTime.Parse(dt.Rows[n]["Chat_Date"].ToString());
					}
					if(dt.Rows[n]["Chat_State"].ToString()!="")
					{
						model.Chat_State=int.Parse(dt.Rows[n]["Chat_State"].ToString());
					}
					//model.Chat_ToUserID=dt.Rows[n]["Chat_ToUserID"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

