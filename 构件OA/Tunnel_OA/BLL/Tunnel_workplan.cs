using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// �����ƻ� ҵ���߼���
    /// </summary>
    public class Tunnel_workplan
    {
        private readonly Tunnel.DAL.Tunnel_workplan dal = new Tunnel.DAL.Tunnel_workplan();
        public Tunnel_workplan()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(long w_id)
        {
            return dal.Exists(w_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_workplan model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_workplan model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int w_id, int w_user, string w_ip)
        {
            return dal.Delete(w_id, w_user, w_ip);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tunnel.Model.Tunnel_workplan GetModel(int w_id)
        {
            return dal.GetModel(w_id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_workplan> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_workplan> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_workplan> modelList = new List<Tunnel.Model.Tunnel_workplan>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_workplan model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_workplan();
                    model.w_id = Convert.ToInt64(dt.Rows[n]["w_id"].ToString());
                    model.w_title = dt.Rows[n]["w_title"].ToString();
                    model.w_content = dt.Rows[n]["w_content"].ToString();
                    model.w_depict = dt.Rows[n]["w_depict"].ToString();
                    model.w_endtime = Convert.ToDateTime(dt.Rows[n]["w_endtime"].ToString());
                    model.w_starttime = Convert.ToDateTime(dt.Rows[n]["w_starttime"].ToString());
                    model.w_user = Convert.ToInt32(dt.Rows[n]["w_user"].ToString());
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        /// <param name="pb">��ҳ������Ϣ</param>
        /// <param name="count">��������</param>
        /// <returns></returns>
        public List<Tunnel.Model.Tunnel_workplan> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_workplan> modelList = new List<Tunnel.Model.Tunnel_workplan>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_workplan model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_workplan();
                    model.w_id = Convert.ToInt64(dt.Rows[n]["w_id"].ToString());
                    model.w_title = dt.Rows[n]["w_title"].ToString();
                    model.w_content = dt.Rows[n]["w_content"].ToString();
                    if (dt.Rows[n]["w_starttime"].ToString() != "")
                    {
                        model.w_starttime = DateTime.Parse(dt.Rows[n]["w_starttime"].ToString());
                    }
                    if (dt.Rows[n]["w_endtime"].ToString() != "")
                    {
                        model.w_endtime = DateTime.Parse(dt.Rows[n]["w_endtime"].ToString());
                    }
                    model.w_depict = dt.Rows[n]["w_depict"].ToString();
                    if (dt.Rows[n]["w_user"].ToString() != "")
                    {
                        model.w_user = int.Parse(dt.Rows[n]["w_user"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  ��Ա����
    }
}

