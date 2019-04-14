using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Caching;
using System.Configuration;
using Tunnel.Model;
using System.Data;

namespace Tunnel.BLL
{
    public class UserLogin
    {
        #region 字段

        /// <summary>
        /// 管理员信息缓存
        /// </summary>
        private Cache batmanCache = HttpRuntime.Cache;

        /// <summary>
        /// 获取登陆用户的ID
        /// </summary>
        public int LoginID
        {
            get
            {
                int userid = HttpContext.Current.User.Identity.IsAuthenticated ? Convert.ToInt32(HttpContext.Current.User.Identity.Name) : 0;
                if (userid > 0)
                {
                    string acheKey = string.Format("{0}-CacheKey-{1}", CacheKey, userid);
                    if (batmanCache[acheKey] == null)
                    {
                        userid = 0;
                        RemoveTicket();
                        HttpContext.Current.Response.Redirect("/default.aspx?ReturnUrl=error");
                    }
                    else
                    {

                        string acheKeys = string.Format("{0}-CacheKey-{1}", CacheKey, userid);
                        onRemove = new CacheItemRemovedCallback(this.RemovedCallback);
                        Tunnel.Model.Tunnel_menber ub = new Tunnel.Model.Tunnel_menber();
                        ub = GetUserBean(userid);
                        //batmanCache.Add(acheKey, ub, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 10), CacheItemPriority.Normal, onRemove);
                        batmanCache.Insert(acheKey, ub, null, DateTime.Now.AddMinutes(40), TimeSpan.Zero, CacheItemPriority.Normal, onRemove);
                        //string sql = "UPDATE TUNNEL_MENBER SET M_ONLINE=1";
                        //Tunnel.Data.DbHelperSQL.ExecuteSql(sql);
                    }
                }
                return userid;
            }

        }

        /// <summary>
        /// 用户角色名称
        /// </summary>
        public string JiaoSe(int userId)
        {
            Tunnel.BLL.Tunnel_menber tm = new Tunnel_menber();
            Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
            tmm = tm.GetModel(Convert.ToInt64(userId.ToString()));
            string jiaose = "无角色";
            if (userId == 1)
            {
                jiaose = "系统管理员";
            }
            if (tmm.m_jiao != 0)
            {
                Tunnel_jiaose tj = new Tunnel_jiaose();
                Tunnel.Model.Tunnel_jiaose tjj = new Tunnel.Model.Tunnel_jiaose();
                tjj = tj.GetModel(Convert.ToInt64(tmm.m_jiao.ToString()));
                if (tjj != null)
                {
                    jiaose = tjj.j_name;

                }

            }
            return jiaose;
        }

        #endregion

        #region 属性
        private Tunnel.Model.Tunnel_menber usbnrLogin;
        /// <summary>
        /// 管理员实体类
        /// </summary>
        public Tunnel.Model.Tunnel_menber UsbnLogin
        {
            get { return usbnrLogin; }
            set { usbnrLogin = value; }
        }

        /// <summary>
        /// Cache关键字
        /// </summary>
        private string CacheKey
        {
            get { return "TunnelLogin"; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="userId">管理员ID</param>
        /// <returns>返回管理员信息</returns>
        public Tunnel.Model.Tunnel_menber GetUserBean(int userId)
        {
            Tunnel.Model.Tunnel_menber tempModel = new Tunnel.Model.Tunnel_menber();
            if (userId > 0)
            {
                string acheKey = string.Format("{0}-CacheKey-{1}", CacheKey, userId);
                if (batmanCache[acheKey] != null)
                    tempModel = (Tunnel.Model.Tunnel_menber)batmanCache[acheKey];
                else
                    tempModel = getUserModel(Convert.ToInt64(userId));
            }
            else
            {
                if (HttpContext.Current != null && userId == 0)
                {
                    HttpCookie newCookie = HttpContext.Current.Request.Cookies["userId"];
                    userId = Convert.ToInt32(newCookie.Value);
                }
                tempModel = getUserModel(Convert.ToInt64(userId));
            }
            return tempModel;
        }

        public Tunnel.Model.Tunnel_menber getUserModel(long userId)
        {
            Tunnel.BLL.Tunnel_menber mbll = new Tunnel_menber();
            return mbll.GetModel(userId);
        }
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userName">用户信息</param>
        /// <param name="userPass">用户密码</param>
        /// <param name="userId">返回用户Id</param>
        /// <returns>返回登陆成功或失败</returns>
        public int UserLoginCheck(string userName, string userPass, string m_ip, ref int userId)
        {
            try
            {
                Tunnel.BLL.Tunnel_menber tBll = new Tunnel.BLL.Tunnel_menber();
                tBll.Exists(userName, userPass, m_ip, ref userId);
                if (userId > 0)
                {
                    HttpCookie newCookie = new HttpCookie("userId");
                    newCookie.Value = userId.ToString();
                    Tunnel.Model.Tunnel_menber model = new Tunnel.Model.Tunnel_menber();
                    model = getUserModel(userId);
                    UsbnLogin = model;
                    if (model != null)
                        CreateCache(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userId;
        }

        /// <summary>
        /// 管理员登陆或注册后地址转向
        /// </summary>
        /// <param name="relt">操作是否成功</param>
        public void UserRedirect(int relt)
        {
            //返回首页
            if (relt > 0)
            {
                string url = ConfigurationManager.AppSettings["UserLoginSucceed"];
                HttpContext.Current.Response.Redirect(url);
            }
        }

        /// <summary>
        /// 创建票证
        /// </summary>
        /// <param name="userId">登陆用户ID</param>
        /// <param name="userTypeId">角色名称</param>
        public void CreateTicket(int userId, int userTypeId)
        {
            FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, userId.ToString(), DateTime.Now, DateTime.Now.AddMinutes(40), true, JiaoSe(userId), System.Web.Security.FormsAuthentication.FormsCookiePath);
            string key = System.Web.Security.FormsAuthentication.Encrypt(fat);
            HttpCookie cookies = new HttpCookie(FormsAuthentication.FormsCookieName, key);
            cookies.Expires.AddMinutes(40);
            HttpContext.Current.Response.Cookies.Add(cookies);
        }

        /// <summary>
        /// 移除票证
        /// </summary>
        private void RemoveTicket()
        {
            FormsAuthentication.SignOut();

        }

        private CacheItemRemovedCallback onRemove = null;

        /// <summary>
        /// 创建缓存
        /// </summary>
        /// <param name="ub">管理员信息</param>
        public void CreateCache(Tunnel.Model.Tunnel_menber ub)
        {
            string acheKey = string.Format("{0}-CacheKey-{1}", CacheKey, ub.m_id);
            onRemove = new CacheItemRemovedCallback(this.RemovedCallback);
            //batmanCache.Add(acheKey, ub, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 10), CacheItemPriority.Normal, onRemove);
            batmanCache.Insert(acheKey, ub, null, DateTime.Now.AddMinutes(40), TimeSpan.Zero, CacheItemPriority.High, onRemove);
            CreateTicket(Convert.ToInt32(ub.m_id), ub.m_jiao);
        }

        public void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            string acheKey = string.Format("{0}-CacheKey-{1}", CacheKey, ((Tunnel.Model.Tunnel_menber)v).m_id);
            if (batmanCache[acheKey] == null)
                OffLine(Convert.ToInt32(Convert.ToInt32(k.Substring(k.LastIndexOf('-') + 1))));
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="userId">管理员登陆ID</param>
        public void RemoveCache(int userId)
        {
            RemoveTicket();
            string acheKey = string.Format("{0}-CacheKey-{1}", CacheKey, userId);
            if (batmanCache[acheKey] != null && userId == LoginID)
                batmanCache.Remove(acheKey);
            HttpContext.Current.Response.Redirect("/default.aspx");
            
        }

        /// <summary>
        /// 获取用户登录状态
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns>true已登录，false未登录</returns>
        public bool ValidateCache(string userid)
        {
            bool result = false;
            string acheKey = string.Format("{0}-CacheKey-{1}", CacheKey, userid);
            if (batmanCache[acheKey] != null)
                result = true;
            return result;
        }

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
        public void OffLine(int UserID)
        {
            string piaoju = "";
            HttpCookie cookies = null;
            if (HttpContext.Current != null)
            {
                piaoju = HttpContext.Current.User.Identity.Name.ToString();
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
                int upTime1 = Convert.ToInt32(upTime) + counttime.Minutes + counttime.Hours * 60;
                string lastoutlogin = DateTime.Now.ToString() + " |Cookie:" + cookieValue + " |票据" + piaoju;
                string sql = "UPDATE TUNNEL_MENBER SET M_ONLINE=0,m_onlinetime=getdate(),m_counttime=" + upTime1 + ",m_lastoutlogin='" + lastoutlogin + "' WHERE M_ID=" + UserID;
                Tunnel.Data.DbHelperSQL.ExecuteSql(sql);
            }
        }
        #endregion
    }
}
