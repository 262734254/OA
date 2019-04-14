using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class N_Calendar_CalendarAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["day"]))
            {
                text1.Value = Request.QueryString["day"].ToString() + " 00:00:00";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(TextBox1.Text.Trim()))
        {
            if (Tunnel.Common.RegexComm.IsValidTime(text1.Value, 1))
            {
                Tunnel.BLL.Tunnel_workplan tw = new Tunnel.BLL.Tunnel_workplan();
                Tunnel.Model.Tunnel_workplan tww = new Tunnel.Model.Tunnel_workplan();
                Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
                tww.w_user = ul.LoginID;
                tww.w_title = TextBox1.Text;
                tww.w_starttime = Convert.ToDateTime(text1.Value);
                switch (DropDownList1.SelectedValue)
                {
                    case "0":
                        tww.w_endtime = Convert.ToDateTime("1800-01-01");
                        break;
                    case "1":
                        tww.w_endtime = tww.w_starttime.AddMinutes(-10);
                        break;
                    case "2":
                        tww.w_endtime = tww.w_starttime.AddMinutes(-30);
                        break;
                    case "3":
                        tww.w_endtime = tww.w_starttime.AddMinutes(-60);
                        break;
                    case "4":
                        tww.w_endtime = tww.w_starttime.Date;
                        break;
                    case "5":
                        tww.w_endtime = tww.w_starttime;
                        break;
                    default:
                        break;
                }
                tww.w_content = TextBox2.Text;
                int id = tw.Add(tww);
                //添加消息机制
                call(tww.w_title, id.ToString(), tww.w_endtime);
                //
                Tunnel.Common.Message.Show("添加成功!");
            }
            else
            {
                Tunnel.Common.Message.Show("日期格式不正确!");
            }
        }
        else
        {
            Tunnel.Common.Message.Show("请填写标题!");
        }

    }

    public void call(string title, string id, DateTime calltime)
    {
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        Tunnel.Model.Tunnel_Remind remindmodel = new Tunnel.Model.Tunnel_Remind();
        remindmodel.m_isread = 0;
        remindmodel.m_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        remindmodel.m_title = "日程提示:" + title + "<font color=red>（未读）</font>";
        remindmodel.m_touser = ul.LoginID;
        remindmodel.m_url = "N_Calendar/CalendarInfo.aspx?id=" + id;
        remindmodel.m_callTime = calltime;
        remindmodel.m_typeid = int.Parse(id);
        remindmodel.m_type = 3;
        Tunnel.BLL.Tunnel_Remind rd = new Tunnel.BLL.Tunnel_Remind();
        if (calltime != Convert.ToDateTime("1800-01-01"))
            rd.Add(remindmodel);
    }
}
