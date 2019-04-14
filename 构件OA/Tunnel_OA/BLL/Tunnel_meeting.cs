using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// ҵ���߼���Tunnel_meeting ��ժҪ˵����
    /// </summary>
    public class Tunnel_meeting
    {
        private readonly Tunnel.DAL.Tunnel_meeting dal = new Tunnel.DAL.Tunnel_meeting();
        public Tunnel_meeting()
        { }
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
        public int Add(Tunnel.Model.Tunnel_meeting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_meeting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(long m_id, int m_user, string m_ip)
        {
            return dal.Delete(m_id, m_user, m_ip);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tunnel.Model.Tunnel_meeting GetModel(long m_id)
        {

            return dal.GetModel(m_id);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_meeting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_meeting> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_meeting> modelList = new List<Tunnel.Model.Tunnel_meeting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_meeting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_meeting();
                    model.m_id = Convert.ToInt64(dt.Rows[n]["m_id"].ToString());
                    model.m_title = dt.Rows[n]["m_title"].ToString();
                    model.m_content = dt.Rows[n]["m_content"].ToString();
                    model.m_menber = dt.Rows[n]["m_menber"].ToString();
                    if (dt.Rows[n]["m_startime"].ToString() != "")
                    {
                        model.m_startime = DateTime.Parse(dt.Rows[n]["m_startime"].ToString());
                    }
                    if (dt.Rows[n]["m_endtime"].ToString() != "")
                    {
                        model.m_endtime = DateTime.Parse(dt.Rows[n]["m_endtime"].ToString());
                    }
                    if (dt.Rows[n]["m_user"].ToString() != "")
                    {
                        model.m_user = int.Parse(dt.Rows[n]["m_user"].ToString());
                    }
                    if (dt.Rows[n]["m_state"].ToString() != "")
                    {
                        model.m_state = int.Parse(dt.Rows[n]["m_state"].ToString());
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
        /// <param name="pb">��ҳ������Ϣ</param>
        /// <param name="count">��������</param>
        /// <returns></returns>
        public List<Tunnel.Model.Tunnel_meeting> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_meeting> modelList = new List<Tunnel.Model.Tunnel_meeting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_meeting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_meeting();
                    model.m_id = Convert.ToInt64(dt.Rows[n]["m_id"].ToString());
                    model.m_title = dt.Rows[n]["m_title"].ToString();
                    model.m_content = dt.Rows[n]["m_content"].ToString();
                    model.m_menber = dt.Rows[n]["m_menber"].ToString();
                    if (dt.Rows[n]["m_startime"].ToString() != "")
                    {
                        model.m_startime = DateTime.Parse(dt.Rows[n]["m_startime"].ToString());
                    }
                    if (dt.Rows[n]["m_endtime"].ToString() != "")
                    {
                        model.m_endtime = DateTime.Parse(dt.Rows[n]["m_endtime"].ToString());
                    }
                    if (dt.Rows[n]["m_user"].ToString() != "")
                    {
                        model.m_user = int.Parse(dt.Rows[n]["m_user"].ToString());
                    }
                    if (dt.Rows[n]["m_state"].ToString() != "")
                    {
                        model.m_state = int.Parse(dt.Rows[n]["m_state"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  ��Ա����
    }
}

