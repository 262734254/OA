using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

public partial class N_Chat_Chat_Bottom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1.Attributes.Add("onchange", "thidselected(this.value)");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Tunnel.Model.Tunnel_Chat tc = new Tunnel.Model.Tunnel_Chat();
            Tunnel.BLL.Tunnel_Chat btc = new Tunnel.BLL.Tunnel_Chat();
            string content = TextBox1.Text;
            string tomen = Request.Form["DropDownList1"];
            int state = 0;
            if (tomen != "0")
            {
                if (CheckBox1.Checked)
                {
                    state = 2;
                    Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
                    Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
                    tr.m_title = "您有一条聊天信息" + "<font color=red>(待读)</font>";
                    tr.m_url = "N_Chat/Default.aspx";
                    tr.m_touser = Convert.ToInt32(tomen);
                    tr.m_time = DateTime.Now;
                    tr.m_type = 2;
                    tr.m_typeid = 2;
                    tr.m_bid = 1;
                    tr.m_callTime = DateTime.Now.AddSeconds(2);
                    tr.m_isread = 0;
                    long messge = br.Add(tr);
                }
                else
                    state = 1;
            }
            Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
            ul.UsbnLogin = ul.getUserModel(ul.LoginID);
            tc.Chat_Content = content;
            tc.Chat_Date = DateTime.Now;
            tc.Chat_State = state;
            tc.Chat_UserID = ul.LoginID;
            tc.Chat_UserName = ul.UsbnLogin.m_name;
            tc.Chat_ToUserID = Convert.ToInt32(tomen);
            btc.Add(tc);
            Response.Redirect("Chat_Bottom.aspx");
        }
        catch
        {
            return;
        }
    }
}