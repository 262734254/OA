using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// ҵ���߼���Tunnel_mail ��ժҪ˵����
    /// </summary>
    public class Tunnel_mail
    {
        private readonly Tunnel.DAL.Tunnel_mail dal = new Tunnel.DAL.Tunnel_mail();
        public Tunnel_mail()
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
        public int Add(Tunnel.Model.Tunnel_mail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_mail model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(long m_id, int m_user, string m_ip, ref int num)
        {
            dal.Delete(m_id, m_user, m_ip, ref num);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tunnel.Model.Tunnel_mail GetModel(long m_id)
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
        public DataSet GetList(int Top, string strWhere,string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_mail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_mail> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_mail> modelList = new List<Tunnel.Model.Tunnel_mail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_mail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_mail();
                    //model.m_id=dt.Rows[n]["m_id"].ToString();
                    model.m_title = dt.Rows[n]["m_title"].ToString();
                    model.m_content = dt.Rows[n]["m_content"].ToString();
                    if (dt.Rows[n]["m_from"].ToString() != "")
                    {
                        model.m_from = int.Parse(dt.Rows[n]["m_from"].ToString());
                    }
                    if (dt.Rows[n]["m_to"].ToString() != "")
                    {
                        model.m_to = Convert.ToInt32(dt.Rows[n]["m_to"].ToString());
                    }
                    model.m_file = dt.Rows[n]["m_file"].ToString();
                    if (dt.Rows[n]["m_time"].ToString() != "")
                    {
                        model.m_time = DateTime.Parse(dt.Rows[n]["m_time"].ToString());
                    }
                    if (dt.Rows[n]["m_sort"].ToString() != "")
                    {
                        model.m_sort = int.Parse(dt.Rows[n]["m_sort"].ToString());
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
        public List<Tunnel.Model.Tunnel_mail> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_mail> modelList = new List<Tunnel.Model.Tunnel_mail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_mail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_mail();
                    model.m_id = Convert.ToInt64(dt.Rows[n]["m_id"].ToString());
                    model.m_title = dt.Rows[n]["m_title"].ToString();
                    model.m_content = dt.Rows[n]["m_content"].ToString();
                    if (dt.Rows[n]["m_from"].ToString() != "")
                    {
                        model.m_from = int.Parse(dt.Rows[n]["m_from"].ToString());
                    }
                    if (dt.Rows[n]["m_to"].ToString() != "")
                    {
                        model.m_to = Convert.ToInt32(dt.Rows[n]["m_to"].ToString());
                    }
                    model.m_file = dt.Rows[n]["m_file"].ToString();
                    if (dt.Rows[n]["m_time"].ToString() != "")
                    {
                        model.m_time = DateTime.Parse(dt.Rows[n]["m_time"].ToString());
                    }
                    if (dt.Rows[n]["m_sort"].ToString() != "")
                    {
                        model.m_sort = int.Parse(dt.Rows[n]["m_sort"].ToString());
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

