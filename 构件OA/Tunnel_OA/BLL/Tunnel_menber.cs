using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// 业务逻辑类Tunnel_menber 的摘要说明。
    /// </summary>
    public class Tunnel_menber
    {
        private readonly Tunnel.DAL.Tunnel_menber dal = new Tunnel.DAL.Tunnel_menber();
        public Tunnel_menber()
        { }
        #region  成员方法
        public bool Exists(int userid)
        {
            return dal.Exists(userid);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string userName, string userPass, string m_ip, ref int m_id)
        {
            return dal.Exists(userName, userPass, m_ip, ref m_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_menber model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_menber model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long m_id)
        {

            dal.Delete(m_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_menber GetModel(long m_id)
        {

            return dal.GetModel(m_id);
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
        public DataSet GetList(int Top, string strWhere,string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_menber> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_menber> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_menber> modelList = new List<Tunnel.Model.Tunnel_menber>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 )
            {
                Tunnel.Model.Tunnel_menber model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_menber();
                    model.m_id = Convert.ToInt64(dt.Rows[n]["m_id"].ToString());
                    model.m_login = dt.Rows[n]["m_login"].ToString();
                    model.m_name = dt.Rows[n]["m_name"].ToString();
                    model.m_password = dt.Rows[n]["m_password"].ToString();
                    model.m_mobile = dt.Rows[n]["m_mobile"].ToString();
                    if (dt.Rows[n]["m_mail"].ToString() != "")
                    {
                        model.m_mail = dt.Rows[n]["m_mail"].ToString();
                    }
                    model.m_idcard = dt.Rows[n]["m_idcard"].ToString();
                    model.m_spassword = dt.Rows[n]["m_spassword"].ToString();
                    if (dt.Rows[n]["m_jiao"].ToString() != "")
                    {
                        model.m_jiao = int.Parse(dt.Rows[n]["m_jiao"].ToString());
                    }
                    if (dt.Rows[n]["m_bum"].ToString() != "")
                    {
                        model.m_bum = Convert.ToInt32(dt.Rows[n]["m_bum"].ToString());
                    }
                    if (dt.Rows[n]["m_duty"].ToString() != "")
                    {
                        model.m_duty = Convert.ToInt32(dt.Rows[n]["m_duty"].ToString());
                    }
                    if (dt.Rows[n]["m_xjb"].ToString() != "")
                    {
                        model.m_xjb = dt.Rows[n]["m_xjb"].ToString();
                    }
                    if (dt.Rows[n]["m_state"].ToString() != "")
                    {
                        model.m_state = int.Parse(dt.Rows[n]["m_state"].ToString());
                    }
                    model.m_flag = dt.Rows[n]["m_flag"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[n]["m_birth"].ToString()))
                    {
                        model.m_birth = Convert.ToDateTime(dt.Rows[n]["m_birth"].ToString());
                        
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public List<Tunnel.Model.Tunnel_menber> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_menber> modelList = new List<Tunnel.Model.Tunnel_menber>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_menber model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_menber();
                    model.m_id = Convert.ToInt64(dt.Rows[n]["m_id"].ToString());
                    model.m_login = dt.Rows[n]["m_login"].ToString();
                    model.m_name = dt.Rows[n]["m_name"].ToString();
                    model.m_password = dt.Rows[n]["m_password"].ToString();
                    model.m_mobile = dt.Rows[n]["m_mobile"].ToString();
                    if (dt.Rows[n]["m_mail"].ToString() != "")
                    {
                        model.m_mail = dt.Rows[n]["m_mail"].ToString();
                    }
                    model.m_idcard = dt.Rows[n]["m_idcard"].ToString();
                    model.m_spassword = dt.Rows[n]["m_spassword"].ToString();
                    if (dt.Rows[n]["m_jiao"].ToString() != "")
                    {
                        model.m_jiao = int.Parse(dt.Rows[n]["m_jiao"].ToString());
                    }
                    if (dt.Rows[n]["m_bum"].ToString() != "")
                    {
                        model.m_bum = Convert.ToInt32(dt.Rows[n]["m_bum"].ToString());
                    }
                    if (dt.Rows[n]["m_duty"].ToString() != "")
                    {
                        model.m_duty = Convert.ToInt32(dt.Rows[n]["m_duty"].ToString());
                    }
                    if (dt.Rows[n]["m_xjb"].ToString() != "")
                    {
                        model.m_xjb = dt.Rows[n]["m_xjb"].ToString();
                    }
                    if (dt.Rows[n]["m_state"].ToString() != "")
                    {
                        model.m_state = int.Parse(dt.Rows[n]["m_state"].ToString());
                    }
                    model.m_flag = dt.Rows[n]["m_flag"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[n]["m_birth"].ToString()))
                    {
                        model.m_birth = Convert.ToDateTime(dt.Rows[n]["m_birth"].ToString());
                        
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[n]["m_online"].ToString()))
                    {
                        model.m_online = dt.Rows[n]["m_online"].ToString();

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[n]["m_onlinetime"].ToString()))
                    {
                        model.m_onlinetime = dt.Rows[n]["m_onlinetime"].ToString();

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[n]["m_counttime"].ToString()))
                    {
                        model.m_counttime = dt.Rows[n]["m_counttime"].ToString();

                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public List<Tunnel.Model.Tunnel_menber> GetList_up(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList_up(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_menber> modelList = new List<Tunnel.Model.Tunnel_menber>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_menber model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_menber();
                    model.m_id = Convert.ToInt64(dt.Rows[n]["m_id"].ToString());
                    model.m_login = dt.Rows[n]["m_login"].ToString();
                    model.m_name = dt.Rows[n]["m_name"].ToString();
                    model.m_password = dt.Rows[n]["m_password"].ToString();
                    model.m_mobile = dt.Rows[n]["m_mobile"].ToString();
                    if (dt.Rows[n]["m_mail"].ToString() != "")
                    {
                        model.m_mail = dt.Rows[n]["m_mail"].ToString();
                    }
                    model.m_idcard = dt.Rows[n]["m_idcard"].ToString();
                    model.m_spassword = dt.Rows[n]["m_spassword"].ToString();
                    if (dt.Rows[n]["m_jiao"].ToString() != "")
                    {
                        model.m_jiao = int.Parse(dt.Rows[n]["m_jiao"].ToString());
                    }
                    if (dt.Rows[n]["m_bum"].ToString() != "")
                    {
                        model.m_bum = Convert.ToInt32(dt.Rows[n]["m_bum"].ToString());
                    }
                    if (dt.Rows[n]["m_duty"].ToString() != "")
                    {
                        model.m_duty = Convert.ToInt32(dt.Rows[n]["m_duty"].ToString());
                    }
                    if (dt.Rows[n]["m_xjb"].ToString() != "")
                    {
                        model.m_xjb = dt.Rows[n]["m_xjb"].ToString();
                    }
                    if (dt.Rows[n]["m_state"].ToString() != "")
                    {
                        model.m_state = int.Parse(dt.Rows[n]["m_state"].ToString());
                    }
                    model.m_flag = dt.Rows[n]["m_flag"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[n]["m_birth"].ToString()))
                    {
                        model.m_birth = Convert.ToDateTime(dt.Rows[n]["m_birth"].ToString());

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[n]["m_online"].ToString()))
                    {
                        model.m_online = dt.Rows[n]["m_online"].ToString();

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[n]["m_onlinetime"].ToString()))
                    {
                        model.m_onlinetime = dt.Rows[n]["m_onlinetime"].ToString();

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[n]["m_counttime"].ToString()))
                    {
                        model.m_counttime = dt.Rows[n]["m_counttime"].ToString();

                    }
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

