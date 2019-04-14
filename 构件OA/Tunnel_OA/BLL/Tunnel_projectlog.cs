using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// ҵ���߼���Tunnel_projectlog ��ժҪ˵����
    /// </summary>
    public class Tunnel_projectlog
    {
        private readonly Tunnel.DAL.Tunnel_projectlog dal = new Tunnel.DAL.Tunnel_projectlog();
        public Tunnel_projectlog()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(long pl_id)
        {
            return dal.Exists(pl_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_projectlog model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_projectlog model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(long pl_id, int pl_user, string pl_ip)
        {
            return dal.Delete(pl_id, pl_user, pl_ip);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tunnel.Model.Tunnel_projectlog GetModel(long pl_id)
        {

            return dal.GetModel(pl_id);
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
        public List<Tunnel.Model.Tunnel_projectlog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_projectlog> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_projectlog> modelList = new List<Tunnel.Model.Tunnel_projectlog>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_projectlog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_projectlog();
                    model.pl_id = Convert.ToInt64(dt.Rows[n]["pl_id"].ToString());
                    model.pl_title = dt.Rows[n]["pl_title"].ToString();
                    model.pl_content = dt.Rows[n]["pl_content"].ToString();
                    if (dt.Rows[n]["pl_time"].ToString() != "")
                    {
                        model.pl_time = DateTime.Parse(dt.Rows[n]["pl_time"].ToString());
                    }
                    if (dt.Rows[n]["pl_user"].ToString() != "")
                    {
                        model.pl_user = int.Parse(dt.Rows[n]["pl_user"].ToString());
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
        public List<Tunnel.Model.Tunnel_projectlog> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_projectlog> modelList = new List<Tunnel.Model.Tunnel_projectlog>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_projectlog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_projectlog();
                    model.pl_id = Convert.ToInt64(dt.Rows[n]["pl_id"].ToString());
                    model.pl_title = dt.Rows[n]["pl_title"].ToString();
                    model.pl_content = dt.Rows[n]["pl_content"].ToString();
                    if (dt.Rows[n]["pl_time"].ToString() != "")
                    {
                        model.pl_time = DateTime.Parse(dt.Rows[n]["pl_time"].ToString());
                    }
                    if (dt.Rows[n]["pl_user"].ToString() != "")
                    {
                        model.pl_user = int.Parse(dt.Rows[n]["pl_user"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  ��Ա����
    }
}

