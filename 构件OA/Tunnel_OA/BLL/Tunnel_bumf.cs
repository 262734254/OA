using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// ҵ���߼���Tunnel_bumf ��ժҪ˵����
    /// </summary>
    public class Tunnel_bumf
    {
        private readonly Tunnel.DAL.Tunnel_bumf dal = new Tunnel.DAL.Tunnel_bumf();
        public Tunnel_bumf()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(long b_id)
        {
            return dal.Exists(b_id);
        }

        
        

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_bumf model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_bumf model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(long b_id)
        {

            dal.Delete(b_id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tunnel.Model.Tunnel_bumf GetModel(long b_id)
        {

            return dal.GetModel(b_id);
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
        public List<Tunnel.Model.Tunnel_bumf> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_bumf> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_bumf> modelList = new List<Tunnel.Model.Tunnel_bumf>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_bumf model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_bumf();
                    model.b_id=int.Parse(dt.Rows[n]["b_id"].ToString());
                    if (dt.Rows[n]["b_sort"].ToString() != "")
                    {
                        model.b_sort = int.Parse(dt.Rows[n]["b_sort"].ToString());
                    }
                    if (dt.Rows[n]["b_time"].ToString() != "")
                    {
                        model.b_time = DateTime.Parse(dt.Rows[n]["b_time"].ToString());
                    }
                    model.b_file = dt.Rows[n]["b_file"].ToString();
                    if (dt.Rows[n]["b_state"].ToString() != "")
                    {
                        model.b_state = int.Parse(dt.Rows[n]["b_state"].ToString());
                    }
                    if (dt.Rows[n]["b_user"].ToString() != "")
                    {
                        model.b_user = int.Parse(dt.Rows[n]["b_user"].ToString());
                    }
                    model.b_content = dt.Rows[n]["b_content"].ToString();
                    model.b_datefield = dt.Rows[n]["b_datefield"].ToString();
                    model.b_formcontent = dt.Rows[n]["b_formcontent"].ToString();
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
        public List<Tunnel.Model.Tunnel_bumf> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_bumf> modelList = new List<Tunnel.Model.Tunnel_bumf>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_bumf model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_bumf();
                    model.b_title = dt.Rows[n]["b_title"].ToString();
                    model.b_file = dt.Rows[n]["b_file"].ToString();
                    model.b_id = int.Parse(dt.Rows[n]["b_id"].ToString());
                    if (dt.Rows[n]["b_sort"].ToString() != "")
                    {
                        model.b_sort = int.Parse(dt.Rows[n]["b_sort"].ToString());
                    }
                    if (dt.Rows[n]["b_time"].ToString() != "")
                    {
                        model.b_time = DateTime.Parse(dt.Rows[n]["b_time"].ToString());
                    }
                    model.b_file = dt.Rows[n]["b_file"].ToString();
                    if (dt.Rows[n]["b_state"].ToString() != "")
                    {
                        model.b_state = int.Parse(dt.Rows[n]["b_state"].ToString());
                    }
                    if (dt.Rows[n]["b_user"].ToString() != "")
                    {
                        model.b_user = int.Parse(dt.Rows[n]["b_user"].ToString());
                    }
                    if (dt.Rows[n]["b_stype"].ToString() != "")
                    {
                        model.b_stype = int.Parse(dt.Rows[n]["b_stype"].ToString());
                    }
                    model.b_content = dt.Rows[n]["b_content"].ToString();
                    model.b_datefield = dt.Rows[n]["b_datefield"].ToString();
                    model.b_formcontent = dt.Rows[n]["b_formcontent"].ToString();
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

