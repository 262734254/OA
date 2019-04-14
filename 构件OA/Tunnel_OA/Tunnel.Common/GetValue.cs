using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.Caching;
using System.Web;

namespace Tunnel.Common
{
    public abstract class GetValue
    {
        //构造函数
        
        public GetValue() { }

        /// <summary>
        /// 读取数据表单个记录

        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="tab">字段名</param>
        /// <param name="where">条件</param>
        /// <returns>结果</returns>
        public static string getDataValue(string table, string tag, string where)
        {
            DataSet ds = Tunnel.Data.DbHelperSQL.Query("SELECT " + tag + " FROM " + table + " where " + where);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 公共附件信息
        /// </summary>
        /// <param name="fu">附件名路径</param>
        /// <returns>附件名(xxxx.xxx)</returns>
        public static string getfu(string fu)
        {
            if (!"".Equals(fu))
            {
                if (fu.LastIndexOf('/')<0)
                    fu = fu.Substring(fu.LastIndexOf('\\') + 1, fu.Length - fu.LastIndexOf('\\') - 1);
                else
                    fu = fu.Substring(fu.LastIndexOf('/') + 1, fu.Length - fu.LastIndexOf('/') - 1);
                return fu;
            }
            else
            {
                return "无附件";
            }
        }

        /// <summary>
        /// 公共附件信息
        /// </summary>
        /// <param name="fu">附件名路径</param>
        /// <returns>附件名(xxxx.xxx)</returns>
        public static string getfu(string fu, string flag, int i)
        {
            string li = "";

            if (!"".Equals(fu))
            {
                bool no = true;
                string ftype = fu.Substring(fu.IndexOf('.'), fu.Length - fu.IndexOf('.'));
                switch (ftype.ToLower())
                {
                    case ".doc":
                    case ".ppt":
                    case ".xls":
                    case ".txt":
                        no = false;
                        break;
                    default:
                        no = true;
                        break;
                }
                fu = System.Web.HttpUtility.UrlPathEncode(fu);
                if (!no)
                {
                    li = "<li><a href='/EditFujian.aspx?file=" + fu + "&act=edit' target='_blank'>阅读</a></li><li><a href='/DownLoad.aspx?url=" + fu + "'>下载</a></li>";
                }
                else if (flag == "down")
                {
                    li = "<li><a href='/DownLoad.aspx?url=" + fu + "'>下载</a></li>";
                }
                else
                {
                    li = "<li><a href='/DownLoad.aspx?url=" + fu + "'>下载</a></li>";
                }
                fu = System.Web.HttpUtility.UrlDecode(fu);
                if (fu.LastIndexOf('/')<0)
                    fu = fu.Substring(fu.LastIndexOf('\\') + 1, fu.Length - fu.LastIndexOf('\\') - 1);
                else
                    fu = fu.Substring(fu.LastIndexOf('/') + 1, fu.Length - fu.LastIndexOf('/') - 1);
                return "<div style=\"position:relative;cursor:pointer;z-index:1\" onmouseover=\"fshow('fu" + i + "')\" onmouseout=\"fhide('fu" + i + "')\"><img src='/image/atchm.gif'/>" + fu + "<div id='fu" + i + "' onmouseout=\"fhide('fu" + i + "')\" onmouseover=\"fshow('fu" + i + "')\" style=\"display:none;position:absolute; border:1px #CCC solid; background:#9FF; width: 57px;z-index:999;\"><ul>" + li + "</ul></div></div>";
            }
            else
            {
                return "无附件";
            }
        }

        /// <summary>
        /// 用户在线登记
        /// </summary>
        /// <param name="UserId">用户ID</param>
        public static void OnLine(int UserId)
        {
            Tunnel.Data.DbHelperSQL.ExecuteSql("UPDATE TUNNEL_MENBER SET M_ONLINE=1,m_onlinetime=getDate() WHERE M_ID=" + UserId);
        }

        /// <summary>
        /// 用户下线登记
        /// </summary>
        /// <param name="UserID">用户ID</param>
        public static void OffLine(int UserID)
        {
            string piaoju = "";
            HttpCookie cookies = null;  
            if (HttpContext.Current.User.Identity.Name != null)
            {
                piaoju = HttpContext.Current.User.Identity.Name.ToString();
            }
            if (HttpContext.Current.Request.Cookies.Count > 0)
            {
                cookies = HttpContext.Current.Request.Cookies[0];
            }
            string cookieValue = string.Empty;
            if (cookies != null)
            {
                cookieValue = cookies.Value;
            }
            string ontime = getDataValue("Tunnel_menber", "m_onlinetime", "m_id=" + UserID);
            string upTime = getDataValue("Tunnel_menber", "m_counttime", "m_id=" + UserID);
            if (!string.IsNullOrEmpty(ontime))
            {
                DateTime onlinetime = Convert.ToDateTime(ontime);
                DateTime nowtime = DateTime.Now;
                TimeSpan counttime = nowtime - onlinetime;
                int upTime1 = Convert.ToInt32(upTime) + counttime.Minutes;
                //string sql = "UPDATE TUNNEL_MENBER SET M_ONLINE=0,m_counttime=m_counttime+" + counttime.Minutes + " WHERE M_ID=" + UserID;

                string lastoutlogin = DateTime.Now.ToString() + "Cookie:" + cookieValue + "；" + "票据" + piaoju;

                string sql = "UPDATE TUNNEL_MENBER SET M_ONLINE=0,m_counttime=" + upTime1 + ",m_lastoutlogin='" + lastoutlogin + "' WHERE M_ID=" + UserID;
                Tunnel.Data.DbHelperSQL.ExecuteSql(sql);
            }
        }

        /// <summary>
        /// 文件列表
        /// </summary>
        /// <param name="filelist">文件列表</param>
        /// <returns></returns>
        public static string getFile(string filelist)
        {
            int i = 0;
            string filecontent = "";
            if (filelist != "")
            {
                string[] filearr = filelist.Split(',');
                foreach (string file in filearr)
                {
                    if (file != "")
                    {
                        i++;
                        filecontent += Tunnel.Common.GetValue.getfu(file, "", i);
                    }
                }
                return filecontent;
            }
            else
            {
                return "无附件";
            }
        }

        /// <summary>
        /// 取得消息ID
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns>消息ID</returns>
        public static int getmessage(string uid)
        {
            int reResult = 0;
            if (!string.IsNullOrEmpty(uid))
            {
                List<Tunnel.Model.Tunnel_Remind> list = new List<Tunnel.Model.Tunnel_Remind>();
                Tunnel.BLL.Tunnel_Remind tr = new Tunnel.BLL.Tunnel_Remind();
                list = tr.GetModelList("m_isread=0 and m_touser=" + uid);
                if (list.Count > 0)
                {
                    foreach (Tunnel.Model.Tunnel_Remind mr in list)
                    {
                        //不定时提醒,即时提醒
                        if (mr.m_callTime.ToShortDateString().Equals("1800-1-1"))
                        {
                            reResult =Convert.ToInt32(mr.m_id);
                        }
                        else
                        {
                            
                            //全天提醒
                            if (mr.m_callTime.Hour == 0 && mr.m_callTime.Minute == 0 && mr.m_callTime.Second == 0)
                            {
                                reResult = Convert.ToInt32(mr.m_id);
                            }
                            else
                            {
                                //定时提醒
                                if (mr.m_callTime.Year <= DateTime.Now.Year && mr.m_callTime.Month <= DateTime.Now.Month
                                    && mr.m_callTime.Day <= DateTime.Now.Day && mr.m_callTime.Hour <= DateTime.Now.Hour
                                    && mr.m_callTime.Minute <= DateTime.Now.Minute)
                                {
                                    reResult = Convert.ToInt32(mr.m_id);
                                }
                            }
                        }
                    }
                }
                else
                {
                    reResult = -1;
                }
            }
            else
            {
                reResult = -1;
            }

            return reResult;
        }
        /// <summary>
        /// 更新消息状态
        /// </summary>
        /// <param name="mid">消息ID</param>
        /// <returns></returns>
        public static int updatemessage(string mid)
        {
            if (!string.IsNullOrEmpty(mid))
            {
                int num = Tunnel.Data.DbHelperSQL.ExecuteSql("UPDATE Tunnel_Remind SET m_isread WHERE m_id=" + mid);
                return num;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 增加消息
        /// </summary>
        /// <param name="model">消息实体</param>
        /// <returns></returns>
        public static long InsertMessge(Tunnel.Model.Tunnel_Remind model)
        {
            return (new Tunnel.BLL.Tunnel_Remind()).Add(model);
        }

        /// <summary>
        /// 取是聊天列表
        /// </summary>
        /// <returns></returns>
        public static string getChat(string uid)
        {
            string list = "";
            try
            {
                Tunnel.BLL.Tunnel_Chat btc = new Tunnel.BLL.Tunnel_Chat();
                DataSet ds = btc.GetList("CONVERT(datetime, SUBSTRING(CONVERT(varchar, Chat_Date), 0, 11))='" + DateTime.Now.ToShortDateString() + "' order by Chat_date asc");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list += "<div style=\"font-size:14px;" + GetQiao(dr["Chat_State"].ToString(), dr["Chat_UserID"].ToString(), dr["Chat_ToUserID"].ToString(), uid) + "\"><img src=\"images/84.gif\" />&nbsp;" + GetuserName(dr["Chat_UserName"].ToString(), dr["Chat_UserID"].ToString()) + "" + gettoUser(dr["Chat_ToUserID"].ToString(), dr["Chat_state"].ToString()) + "说：" + dr["Chat_content"].ToString() + " <span style=\"color:#999\">[" + dr["Chat_Date"].ToString() + "]</span></div>";
                }
            }
            catch
            {
                list = "";
            }

            return list;
        }

        /// <summary>
        /// 显示对谁说
        /// </summary>
        /// <param name="toid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private static string gettoUser(string toid, string state)
        {
            Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
            ul.UsbnLogin = ul.getUserModel(Convert.ToInt32(toid));
            if (state == "1")
            {
                return " 对 <span style='color:green'>" + ul.UsbnLogin.m_name + "</span> ";
            }
            else if (state == "2")
            {
                if (ul.LoginID.ToString().Equals(toid))
                {
                    return " 对 <span style='color:red'>你</span> 悄悄的";

                }
                else
                {
                    return " 对 <span style='color:red'>" + ul.UsbnLogin.m_name + "</span> 悄悄的";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 显示悄悄话
        /// </summary>
        /// <param name="state">状态</param>
        /// <param name="uid">发布人</param>
        /// <param name="toUid">接收人</param>
        /// <returns></returns>
        private static string GetQiao(string state, string uid, string toUid,string userid)
        {
            string style = "";
            if ("1".Equals(state))
            {
                style = "";
            }
            else if (state == "2")
            {
                if (userid.Equals(uid) || userid.Equals(toUid))
                {
                    style = "";
                }
                else
                {
                    style = "display:none";
                }
            }
            else
            {
                style = "";
            }
            return style;
        }

        /// <summary>
        /// 显示谁说的
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private static string GetuserName(string username, string uid)
        {
            Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
            if (ul.LoginID.ToString().Equals(uid))
            {
                return "<font style=\"color:blue\">你</font>";
            }
            else
            {
                return "<font style=\"color:black\">" + username + "</font>";
            }
        }

        public static string getXiangUser(string p)
        {
            string list = "";
            try
            {
                Tunnel.BLL.Tunnel_menber TmModel = new Tunnel.BLL.Tunnel_menber();
                DataSet ds = TmModel.GetList("m_name like '%" + p + "%'");
                list = "<table>";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list += "<tr><td onclick='showname(" + dr["m_id"].ToString() + ",'" + dr["m_name"].ToString() + "')'>" + dr["m_name"].ToString() + "</td>";
                }
                list += "</table>";
            }
            catch
            {
                list = "";
            }

            return list;
        }
    }
}