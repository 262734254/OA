using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// ҵ���߼���Tunnel_vannewpaper ��ժҪ˵����
    /// </summary>
    public class Tunnel_vannewpaper
    {
        private readonly Tunnel.DAL.Tunnel_vannewpaper dal = new Tunnel.DAL.Tunnel_vannewpaper();
        public Tunnel_vannewpaper()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(long v_id)
        {
            return dal.Exists(v_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_vannewpaper model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_vannewpaper model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(long v_id, int v_user, string v_ip)
        {
            dal.Delete(v_id, v_user, v_ip);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tunnel.Model.Tunnel_vannewpaper GetModel(long v_id)
        {

            return dal.GetModel(v_id);
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
        public List<Tunnel.Model.Tunnel_vannewpaper> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tunnel.Model.Tunnel_vannewpaper> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_vannewpaper> modelList = new List<Tunnel.Model.Tunnel_vannewpaper>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_vannewpaper model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_vannewpaper();
                    model.v_id = Convert.ToInt64(dt.Rows[n]["v_id"].ToString());
                    model.v_title = dt.Rows[n]["v_title"].ToString();
                    model.v_img = dt.Rows[n]["v_img"].ToString();
                    if (dt.Rows[n]["v_file"].ToString() != "")
                    {
                        model.v_file = dt.Rows[n]["v_file"].ToString();
                    }
                    if (dt.Rows[n]["v_user"].ToString() != "")
                    {
                        model.v_user = int.Parse(dt.Rows[n]["v_user"].ToString());
                    }
                    if (dt.Rows[n]["v_sort"].ToString() != "")
                    {
                        model.v_sort = int.Parse(dt.Rows[n]["v_sort"].ToString());
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
        public List<Tunnel.Model.Tunnel_vannewpaper> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_vannewpaper> modelList = new List<Tunnel.Model.Tunnel_vannewpaper>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_vannewpaper model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_vannewpaper();
                    model.v_id = Convert.ToInt64(dt.Rows[n]["v_id"].ToString());
                    model.v_title = dt.Rows[n]["v_title"].ToString();
                    model.v_img = dt.Rows[n]["v_img"].ToString();
                    if (dt.Rows[n]["v_file"].ToString() != "")
                    {
                        model.v_file = dt.Rows[n]["v_file"].ToString();
                    }
                    if (dt.Rows[n]["v_user"].ToString() != "")
                    {
                        model.v_user = int.Parse(dt.Rows[n]["v_user"].ToString());
                    }
                    if (dt.Rows[n]["v_sort"].ToString() != "")
                    {
                        model.v_sort = int.Parse(dt.Rows[n]["v_sort"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion  ��Ա����
    }
}

