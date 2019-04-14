using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// ҵ���߼���Tunnel_project ��ժҪ˵����
    /// </summary>
    public class Tunnel_project
    {
        private readonly Tunnel.DAL.Tunnel_project dal = new Tunnel.DAL.Tunnel_project();
        public Tunnel_project()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(long p_id)
        {
            return dal.Exists(p_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_project model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_project model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(long p_id, int p_user, string p_ip)
        {
            dal.Delete(p_id, p_user, p_ip);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tunnel.Model.Tunnel_project GetModel(long p_id)
        {

            return dal.GetModel(p_id);
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
        public List<Tunnel.Model.Tunnel_project> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_project> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_project> modelList = new List<Tunnel.Model.Tunnel_project>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_project model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_project();
                    model.p_id = Convert.ToInt64(dt.Rows[n]["p_id"].ToString());
                    model.p_name = dt.Rows[n]["p_name"].ToString();
                    model.p_yname = dt.Rows[n]["p_yname"].ToString();
                    model.p_jname = dt.Rows[n]["p_jname"].ToString();
                    model.p_xfile = dt.Rows[n]["p_xfile"].ToString();
                    model.p_zfile = dt.Rows[n]["p_zfile"].ToString();
                    if (dt.Rows[n]["p_user"].ToString() != "")
                    {
                        model.p_user = int.Parse(dt.Rows[n]["p_user"].ToString());
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
        public List<Tunnel.Model.Tunnel_project> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_project> modelList = new List<Tunnel.Model.Tunnel_project>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_project model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_project();
                    model.p_id = Convert.ToInt64(dt.Rows[n]["p_id"].ToString());
                    model.p_name = dt.Rows[n]["p_name"].ToString();
                    model.p_yname = dt.Rows[n]["p_yname"].ToString();
                    model.p_jname = dt.Rows[n]["p_jname"].ToString();
                    model.p_xfile = dt.Rows[n]["p_xfile"].ToString();
                    model.p_zfile = dt.Rows[n]["p_zfile"].ToString();
                    if (dt.Rows[n]["p_user"].ToString() != "")
                    {
                        model.p_user = int.Parse(dt.Rows[n]["p_user"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  ��Ա����
    }
}

