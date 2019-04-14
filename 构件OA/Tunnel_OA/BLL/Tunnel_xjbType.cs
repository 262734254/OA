using System;
using System.Collections.Generic;
using System.Text;
using Tunnel.Model;
using System.Data;
namespace Tunnel.BLL
{
    public class Tunnel_xjbType
    {
        Tunnel.DAL.Tunnel_xjbType xjb = new Tunnel.DAL.Tunnel_xjbType();
        public List<Tunnel.Model.Tunnel_xjbType> GetModelList(string where)
        {

            List<Tunnel.Model.Tunnel_xjbType> list = new List<Tunnel.Model.Tunnel_xjbType>();
            DataSet das = xjb.GetList(where);
            if (das != null)
            {
                if (das.Tables.Count > 0)
                    list = GetModelList(das.Tables[0]);
            }
            return list;

        }

        private List<Tunnel.Model.Tunnel_xjbType> GetModelList(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                List<Tunnel.Model.Tunnel_xjbType> list = new List<Tunnel.Model.Tunnel_xjbType>();
                foreach (DataRow rows in table.Rows)
                {
                    Tunnel.Model.Tunnel_xjbType model = new Tunnel.Model.Tunnel_xjbType();
                    model.Id = Convert.ToInt32(rows["id"]);
                    model.Typename = rows["typename"].ToString();
                    model.Typeid = Convert.ToInt32(rows["typeid"].ToString());
                    model.IsStop = rows["IsStop"].ToString().Trim();
                    model.UserID = int.Parse(rows["UserID"].ToString().Trim());
                    list.Add(model);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        #region 添加数据
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="xjbInfo">项经部类型实体</param>
        /// <returns>添加的行数</returns>
        public int Add(Tunnel.Model.Tunnel_xjbType xjbType)
        {
            //throw new NotImplementedException().Message();
            return xjb.Add(xjbType);
        }
        #endregion

        #region 更新数据
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="xjbInfo">项经部类型实体</param>
        /// <returns>更新的行数</returns>
        public int Update(Tunnel.Model.Tunnel_xjbType xjbType)
        {
            //throw new NotImplementedException().Message();
            return xjb.Update(xjbType);
        }
        #endregion

        public Tunnel.Model.Tunnel_xjbType GetModel(int p)
        {
            string where = " id=" + p.ToString(); ;
            Tunnel.Model.Tunnel_xjbType model = new Tunnel.Model.Tunnel_xjbType();
            DataSet das = xjb.GetList(where);
            if (das != null)
            {
                if (das.Tables.Count > 0)
                {
                    if (das.Tables[0].Rows.Count > 0)
                    {
                        model.Id = Convert.ToInt32(das.Tables[0].Rows[0]["id"]);
                        model.Typeid = Convert.ToInt32(das.Tables[0].Rows[0]["typeid"]);
                        model.Typename = das.Tables[0].Rows[0]["typename"].ToString();
                        model.Parentid = Convert.ToInt32(das.Tables[0].Rows[0]["Parentid"]);
                        model.Url = das.Tables[0].Rows[0]["Url"].ToString();
                        model.IsStop = das.Tables[0].Rows[0]["IsStop"].ToString().Trim();
                        model.UserID = int.Parse(das.Tables[0].Rows[0]["UserID"].ToString().Trim());
                    }
                    else
                        model = null;
                }
                else
                    model = null;
            }
            else
                model = null;
            return model;
        }

        #region 获取项经部信息类型数据集
        /// <summary>
        /// 获取项经部信息类型数据集
        /// </summary>
        /// <param name="where"></param>
        /// <returns>项经部数据集</returns>
        public DataSet GetList(string where)
        {
            Tunnel.DAL.Tunnel_xjbType xjb = new Tunnel.DAL.Tunnel_xjbType();
            return xjb.GetList(where);
        }
        #endregion

        #region 获得分页集合
        /// <summary>
        /// 获得分页集合
        /// </summary>
        /// <param name="pb">页类</param>
        /// <param name="count">总数</param>
        /// <returns>集合</returns>
        public List<Tunnel.Model.Tunnel_xjbType> GetList(PageBase pb, ref int count)
        {
            Tunnel.DAL.Tunnel_xjbType xjb = new Tunnel.DAL.Tunnel_xjbType();
            DataTable dt = xjb.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_xjbType> modelList = new List<Tunnel.Model.Tunnel_xjbType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_xjbType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_xjbType();
                    model.Id = Convert.ToInt32(dt.Rows[n]["id"].ToString());
                    model.Typename = dt.Rows[n]["typename"].ToString().Trim();
                    model.Typeid = Convert.ToInt32(dt.Rows[n]["typeid"].ToString());
                    model.Parentid = Convert.ToInt32(dt.Rows[n]["parentid"].ToString());
                    model.Url = dt.Rows[n]["url"].ToString().Trim();
                    model.IsStop = dt.Rows[n]["IsStop"].ToString().Trim();
                    model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString().Trim());
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
    }
}
