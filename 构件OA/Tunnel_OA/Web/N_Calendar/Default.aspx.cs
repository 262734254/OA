using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class N_Calendar_Default : System.Web.UI.Page
{
    static int imgCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        imgCount = 0;
        if (!IsPostBack)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Del();
                Response.Redirect("default.aspx");
            }
        }
    }
    public void Del()
    {
        Tunnel.BLL.Tunnel_workplan tw = new Tunnel.BLL.Tunnel_workplan();
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        tw.Delete(int.Parse(Request.QueryString["id"].ToString()), ul.LoginID, Tunnel.Common.Common.GetIp());
        Tunnel.BLL.Tunnel_Remind tr = new Tunnel.BLL.Tunnel_Remind();
        Tunnel.Model.Tunnel_Remind trr = new Tunnel.Model.Tunnel_Remind();

        List<Tunnel.Model.Tunnel_Remind> trList = new List<Tunnel.Model.Tunnel_Remind>();
        trList = tr.GetModelList("m_type=3 and m_typeid=" + Request.QueryString["id"].ToString() + "");
        if (trList.Count > 0)
            tr.Delete(trList[0].m_typeid);
    }
    protected void calSchedule_DayRender(object sender, DayRenderEventArgs e)
    {
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber user = tm.GetModel(Convert.ToInt64(ul.LoginID.ToString()));
        //自定义显示内容 
        CalendarDay calDay = e.Day;
        //获取表示呈现在空间中的单元格
        TableCell tc = e.Cell;
        if (calDay.IsOtherMonth)
        {
            tc.Controls.Clear();
        }
        else
        {
            try
            {
                HtmlAnchor ahyperLink = new HtmlAnchor();
                ahyperLink.InnerHtml = calDay.Date.Day > 9 ? "<img src='../image/notify_new.gif' />" : "&nbsp;&nbsp;<img src='../image/notify_new.gif' />";
                ahyperLink.Title = "新增个人日程";
                ahyperLink.HRef = "CalendarAdd.aspx?day=" + calDay.Date.ToShortDateString();
                ahyperLink.ID = "ServerA";
                tc.Controls.Add(new LiteralControl("&nbsp;" + "&nbsp;" + "&nbsp;"));
                tc.Controls.Add(ahyperLink);
                Tunnel.BLL.Tunnel_workplan tw = new Tunnel.BLL.Tunnel_workplan();
                List<Tunnel.Model.Tunnel_workplan> wkList =
                tw.GetModelList("w_user=" + ul.LoginID + " and w_starttime>='" + calDay.Date.ToShortDateString() + "' and  w_starttime<'" + calDay.Date.AddDays(1).ToShortDateString() + "'");

                if (wkList.Count > 0)
                {
                    string str = null;
                    foreach (Tunnel.Model.Tunnel_workplan schedule in wkList)
                    {
                       int tmpCount = imgCount++;
                        HtmlAnchor ha = new HtmlAnchor();
                        ha.Attributes.Add("onmouseover", "javascript:show('img" + tmpCount + "')");
                        ha.HRef = "CalendarInfo.aspx?id=" + schedule.w_id + "&day=" + calDay.Date.ToShortDateString();
                        //try
                        //{
                        //    str = schedule.w_title.Substring(0, 3);
                        //}
                        //catch
                        //{
                        //    str = schedule.w_title.ToString();
                        //}
                        ha.InnerHtml = "<img src='../image/atchm.gif' border=0 />" + schedule.w_starttime.Hour.ToString() +
                            ":" + schedule.w_starttime.Minute.ToString() + "&nbsp;" + str + "..." +
                             "<a  href='?id=" + schedule.w_id + "' onClick=\"return confirm('是否删除此条记录？')\">" +
                             "<img alt='删除日程' id=img" + tmpCount + " name=remove src='../image/remove.png' border=0 style='display:none'/></a>";

                        tc.Controls.Add(new LiteralControl("&nbsp;" + "&nbsp;" + "&nbsp;"));
                        tc.Controls.Add(new LiteralControl("<br>"));
                        tc.Controls.Add(ha);
                    }
                }

            }
            catch (Exception)
            {
                //Response.Write(ex.ToString());
            }
            e.Cell.Attributes["onmouseover"] = "javascript:this.style.backgroundColor='#fff7ce';cursor='hand';";
            e.Cell.Attributes["onmouseout"] = "javascript:this.style.backgroundColor='#ffffff'";
        }
    }
}
