using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// ҵ���߼���Tunnel_KaoQinCheck ��ժҪ˵����
	/// </summary>
	public class Tunnel_KaoQinCheck
	{
		private readonly Tunnel.DAL.Tunnel_KaoQinCheck dal=new Tunnel.DAL.Tunnel_KaoQinCheck();
		public Tunnel_KaoQinCheck()
		{}
		#region  ��Ա����

        /// <summary>
        /// �������²�ѯ�����Ƿ����
        /// </summary>
        /// <param name="year">��</param>
        /// <param name="month">��</param>
        /// <param name="bid">����ID</param>
        /// <returns>0�����ڣ�1����</returns>
        public int ExitsDate(string year, string month,string bid)
        {
            int result = 0;
            Tunnel.DAL.Tunnel_KaoQinCheck kqc = new Tunnel.DAL.Tunnel_KaoQinCheck();
            result = kqc.Exist(year, month,bid);
            return result;
        }

        /// <summary>
        /// ��֤���¿����Ƿ����
        /// </summary>
        /// <param name="year">��</param>
        /// <param name="month">��</param>
        /// <param name="bid">����ID</param>
        /// <returns>0δ��ˣ�1���</returns>
        public int ExitsKaoQin(string year, string month, string bid)
        { 
            int result=0;
            Tunnel.DAL.Tunnel_KaoQinCheck kqc = new Tunnel.DAL.Tunnel_KaoQinCheck();
            result = kqc.Exist(year, month, bid);
            return result;
        }

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
		public bool Exists(int s_id)
		{
			return dal.Exists(s_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_KaoQinCheck model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_KaoQinCheck model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int s_id)
		{
			
			dal.Delete(s_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_KaoQinCheck GetModel(int s_id)
		{
			
			return dal.GetModel(s_id);
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
		public List<Tunnel.Model.Tunnel_KaoQinCheck> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Tunnel.Model.Tunnel_KaoQinCheck> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_KaoQinCheck> modelList = new List<Tunnel.Model.Tunnel_KaoQinCheck>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_KaoQinCheck model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_KaoQinCheck();
					if(dt.Rows[n]["s_id"].ToString()!="")
					{
						model.s_id=int.Parse(dt.Rows[n]["s_id"].ToString());
					}
					if(dt.Rows[n]["s_year"].ToString()!="")
					{
						model.s_year=int.Parse(dt.Rows[n]["s_year"].ToString());
					}
					if(dt.Rows[n]["s_moon"].ToString()!="")
					{
						model.s_moon=int.Parse(dt.Rows[n]["s_moon"].ToString());
					}
					if(dt.Rows[n]["s_bid"].ToString()!="")
					{
						model.s_bid=int.Parse(dt.Rows[n]["s_bid"].ToString());
					}
					model.s_bname=dt.Rows[n]["s_bname"].ToString();
					if(dt.Rows[n]["s_uid"].ToString()!="")
					{
						model.s_uid=int.Parse(dt.Rows[n]["s_uid"].ToString());
					}
					if(dt.Rows[n]["s_date"].ToString()!="")
					{
						model.s_date=DateTime.Parse(dt.Rows[n]["s_date"].ToString());
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

