using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.BLL
{
    public class Permission
    {
        /// <summary>
        /// 查看是否有权限
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="XreqestStr">小类</param>
        /// <param name="BreqestStr">大类</param>
        /// <returns>true有权限</returns>
        public static bool IfHasPrimision(string userID, string XreqestStr, string BreqestStr, bool IfRead)
        {
            string tmpUid = string.Empty;
            string tmpBid = string.Empty;
            string tmpDid = string.Empty;
            string tmpJid = string.Empty;

            Tunnel.BLL.Tunnel_menber tm = new Tunnel_menber();
            Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
            List<Tunnel.Model.Tunnel_menber> tmlist = new List<Tunnel.Model.Tunnel_menber>();

            Tunnel.BLL.Tunnel_jiaose tj = new Tunnel_jiaose();
            Tunnel.Model.Tunnel_jiaose tjj = new Tunnel.Model.Tunnel_jiaose();


            Tunnel.BLL.Tunnel_quanxian qx = new Tunnel_quanxian();
            Tunnel.Model.Tunnel_quanxian qxx = new Tunnel.Model.Tunnel_quanxian();
            List<Tunnel.Model.Tunnel_quanxian> qxlist = new List<Tunnel.Model.Tunnel_quanxian>();

            Tunnel.BLL.Tunnel_yingshe tyj = new Tunnel_yingshe();
            Tunnel.Model.Tunnel_yingshe tyjj = new Tunnel.Model.Tunnel_yingshe();
            List<Tunnel.Model.Tunnel_yingshe> tyjlist = new List<Tunnel.Model.Tunnel_yingshe>();

            Tunnel.BLL.Tunnel_uyingshe tyu = new Tunnel_uyingshe();
            Tunnel.Model.Tunnel_uyingshe tyuu = new Tunnel.Model.Tunnel_uyingshe();
            List<Tunnel.Model.Tunnel_uyingshe> tyulist = new List<Tunnel.Model.Tunnel_uyingshe>();

            Tunnel.BLL.Tunnel_byingshe tyb = new Tunnel_byingshe();
            Tunnel.Model.Tunnel_byingshe tybb = new Tunnel.Model.Tunnel_byingshe();
            List<Tunnel.Model.Tunnel_byingshe> tyblist = new List<Tunnel.Model.Tunnel_byingshe>();

            Tunnel.BLL.Tunnel_dyingshe tyd = new Tunnel_dyingshe();
            Tunnel.Model.Tunnel_dyingshe tydd = new Tunnel.Model.Tunnel_dyingshe();
            List<Tunnel.Model.Tunnel_dyingshe> tydlist = new List<Tunnel.Model.Tunnel_dyingshe>();

            UserLogin ul = new UserLogin();
            bool b = false;
            string qxStr = string.Empty;
            tmm = tm.GetModel(Convert.ToInt64(userID));
            tmpBid = tmm.m_bum.ToString();
            tmpJid = tmm.m_jiao.ToString();
            tmpDid = tmm.m_duty.ToString();
            tmpUid = userID;

            tyulist = tyu.GetModelList("uy_uid='" + tmpUid + "'");

            if (tyulist.Count > 0)
                if (tyulist[0].uy_list.Length > 0)
                    qxStr += tyulist[0].uy_list + "|";

            tyjlist = tyj.GetModelList("y_jsid=" + tmpJid + "");

            if (tyjlist.Count > 0)
                if (tyjlist[0].y_qxlist.Length > 0)
                    qxStr += tyjlist[0].y_qxlist + "|";

            tyblist = tyb.GetModelList("by_bid='" + tmpBid + "'");

            if (tyblist.Count > 0)
                if (tyblist[0].by_list.Length > 0)
                    qxStr += tyblist[0].by_list + "|";


            tydlist = tyd.GetModelList("dy_did='" + tmpDid + "'");
            if (tydlist.Count > 0)
                if (tydlist[0].dy_list.Length > 0)
                    qxStr += tydlist[0].dy_list + "|";


            if (qxStr.Length > 0)
                qxStr = qxStr.Substring(0, qxStr.Length - 1);
            if (userID != "1" && ul.JiaoSe(int.Parse(userID)) != "系统管理员")
            {
                if (IfRead)
                    if (tmpJid != "0")
                        if (ul.JiaoSe(int.Parse(userID)) == "总经理")
                            b = true;
                if (!string.IsNullOrEmpty(qxStr))
                {
                    qxlist = qx.GetModelList("q_name='" + XreqestStr + "' and q_mark='" + BreqestStr + "'");
                    if (qxlist.Count > 0)
                        foreach (string item in qxStr.Split('|'))
                        {
                            if (qxlist[0].q_id.ToString().Equals(item.ToString()))
                                b = true;
                        }
                }
            }
            else
            {
                b = true;
            }
            return b;
        }
    }
}
