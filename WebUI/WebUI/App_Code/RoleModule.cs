using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL.Power;
using System.Collections.Generic;
/// <summary>
/// RoleModuleTest 的摘要说明
/// </summary>
public class RoleModule : IHttpModule
{
    RolePowerManager rolePowerManager = new RolePowerManager();

    public RoleModule()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region IHttpModule 成员

    public void Dispose()
    {

    }

    public void Init(HttpApplication context)
    {
        //开始执行事件处理程序
        context.PreRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
    }

    void context_PostRequestHandlerExecute(object sender, EventArgs e)
    {
        HttpApplication app = (HttpApplication)sender;

        if (app.Context.Request.Url.ToString().ToLower().Contains(".aspx"))
        {
            //不是登录页面
            if (!app.Context.Request.Url.ToString().ToLower().Contains("login.aspx"))
            {
                //不是首页 再控制访问权限
                if (!app.Context.Request.Url.ToString().ToLower().Contains("indexs.aspx"))
                {
                    if (app.Context.Session != null && app.Context.Session["user"] != null)
                    {


                        Model.UserInfo user = (Model.UserInfo)app.Context.Session["user"];
                        //根据角色ID获取权限
                        IList<Model.Power> list = rolePowerManager.selectAllPowersByUserId(user.UID);
                        bool flag = false;
                        foreach (Model.Power power in list)
                        {
                            if (app.Context.Request.Url.ToString().ToLower().Contains(power.URL.ToString().ToLower()))
                            {
                                flag = true;
                                break;
                            }

                        }
                        if (!flag)
                        {
                            app.Context.Response.Redirect("~/login.aspx");

                        }
                    }
                }
            }
            if (app.Context.CurrentHandler is Page)//如果是源请求为页面
            {
                System.Web.UI.Page page = (System.Web.UI.Page)app.Context.CurrentHandler;
                if (page != null)
                    page.PreRender += new EventHandler(page_PreRender);//在页面加载后呈现之前发生的事件 控制按钮的可用不可用
            }

        }



    }



    void page_PreRender(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session != null && HttpContext.Current.Session["user"] != null)
        {
            //查询用户的角色所拥有的增删改查操作
            Model.UserInfo user = (Model.UserInfo)HttpContext.Current.Session["user"];
            IList<Model.Role> list = rolePowerManager.SelectAllRolesByUserID(user.UID);

            //遍历用户的所有角色
            foreach (Model.Role role in list)
            {
                IList<Model.Hidden> list2 = rolePowerManager.selectRoleByHiddenContol(role.roleId);
                foreach (Model.Hidden h in list2)
                {

                    HtmlForm form = ((Page)sender).Form;
                    foreach (Control ctl in form.Controls)
                    {
                        if (ctl.GetType().ToString() == "System.Web.UI.WebControls.Button")
                        {

                            Button bt = ctl as Button;
                            if (bt != null)
                            {
                                if (bt.ToolTip.Contains("删除") && h.Delete == 0)
                                {
                                    bt.Enabled = false;
                                }
                                 if (bt.ToolTip.Contains("添加") && h.Add == 0)
                                {
                                    bt.Enabled = false;
                                }
                                //else if (bt.ToolTip.Contains("查询") && h.Select == 0)
                                //{
                                //    bt.Enabled = false;
                                //}
                                 if (bt.ToolTip .Contains("更新") && h.Update == 0)
                                {
                                    bt.Enabled = false;
                                }
                                 if (bt.ToolTip.Contains("审核") && h.Checke == 0)
                                {
                                    bt.Enabled = false;
                                }
                                 if (bt.ToolTip.Contains("出车") && h.Send == 0)
                                {
                                    bt.Enabled = false;
                                }
                                 if (bt.ToolTip.Contains("回车") && h.Back == 0)
                                {
                                    bt.Enabled = false;
                                }
                                 if (bt.ToolTip.Contains("新车入库") && h.Comein == 0)
                                {
                                    bt.Enabled = false;
                                }
                            }
                        }


                        if (ctl.GetType().ToString() == "System.Web.UI.WebControls.LinkButton")
                        {

                            LinkButton bt = ctl as LinkButton;
                            if (bt != null)
                            {
                                if (bt.ToolTip.Contains("删除") && h.Delete == 0)
                                {
                                    bt.Enabled = false;
                                }
                                 if (bt.ToolTip.Contains("添加") && h.Add == 0)
                                {
                                    bt.Enabled = false;
                                }
                                //else if (bt.ToolTip.Contains("查询") && h.Select == 0)
                                //{
                                //    bt.Enabled = false;
                                //}
                                if (bt.ToolTip.Contains("更新") && h.Update == 0)
                                {
                                    bt.Enabled = false;
                                }
                                 if (bt.ToolTip.Contains("审核") && h.Checke == 0)
                                {
                                    bt.Enabled = false;
                                }
                                if (bt.ToolTip.Contains("出车") && h.Send == 0)
                                {
                                    bt.Enabled = false;
                                }
                                if (bt.ToolTip.Contains("回车") && h.Back == 0)
                                {
                                    bt.Enabled = false;
                                }
                                 if (bt.ToolTip.Contains("新车入库") && h.Comein == 0)
                                {
                                    bt.Enabled = false;
                                }
                            }

                        }


                        //gridview中的不可用
                        if (ctl.GetType().ToString() == "System.Web.UI.WebControls.GridView")
                        {
                            GridView bt = ctl as GridView;
                            for (int i = 0; i < bt.Rows.Count; i++)
                            {
                                LinkButton lbDel = bt.Rows[i].FindControl("lbDel") as LinkButton;
                                LinkButton lbDetail = (LinkButton)bt.Rows[i].FindControl("lbDetail");
                                LinkButton lbUp = (LinkButton)bt.Rows[i].FindControl("lbUp");
                                LinkButton lbSend = (LinkButton)bt.Rows[i].FindControl("lbSend");
                                LinkButton lbBack = (LinkButton)bt.Rows[i].FindControl("lbBack");

                                if (lbDel != null && h.Delete == 0)
                                {
                                    lbDel.Enabled = false;
                                }
                                 if (lbUp != null && h.Update == 0)
                                {
                                    lbUp.Enabled = false;
                                }
                                if (lbDetail != null && h.Select == 0)
                                {
                                    lbDetail.Enabled = false;
                                }
                                if (lbSend != null && h.Send == 0)
                                {
                                    lbSend.Enabled = false;
                                }
                               if (lbBack != null && h.Back == 0)
                                {
                                    lbBack.Enabled = false;
                                }

                            }


                            //找到DropdownList控件
                            if (ctl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                            {
                                DropDownList droplist = (DropDownList)bt.FindControl("ddlType");
                                if (droplist != null)
                                {
                                    droplist.Items.Clear();
                                    if (role.RoleName == "会议部主管")
                                    {
                                        droplist.Items.Add(new ListItem("会议申请", "会议申请"));
                                    }
                                     if (role.RoleName == "资源部领导")
                                    {
                                        droplist.Items.Add(new ListItem("资源采购", "资源采购"));
                                        droplist.Items.Add(new ListItem("资源借用", "资源借用"));
                                    }
                                     if (role.RoleName == "车库管理员")
                                    {
                                        droplist.Items.Add(new ListItem("用车申请", "用车申请"));

                                    }
                                     if (role.RoleName == "任务审核领导")
                                    {
                                        droplist.Items.Add(new ListItem("任务申请", "任务申请"));

                                    }


                                }
                            }




                        }
                    }
                }
            }
        }
    }

    #endregion
}

