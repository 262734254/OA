using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SystemManage_KaoHe_Tunnel_CheckAdd : System.Web.UI.Page
{
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        IfShow();
        if (!IsPostBack)
        {
            ListBind();
        }
    }
    public void IfShow()
    {
        if (!Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核管理", "统计报表", false))
        {
            xinzengkaohe.Disabled = true;
            xinzengkaohe.HRef = "";
            guanligongcheng.Disabled = true;
            guanligongcheng.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核打分", "统计报表", false))
        {
            kaohedafen.Disabled = true;
            kaohedafen.HRef = "";
        }
    }
    public void ListBind()
    {
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList3.Items.Clear();
        Tunnel.BLL.Tunnel_items ti = new Tunnel.BLL.Tunnel_items();
        Tunnel.Model.Tunnel_items tii = new Tunnel.Model.Tunnel_items();
        List<Tunnel.Model.Tunnel_items> ilist = new List<Tunnel.Model.Tunnel_items>();
        for (int i = 2009; i < 2019; i++)
        {
            DropDownList2.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        for (int i = 1; i < 13; i++)
        {
            if (i.ToString().Length == 2)
                DropDownList3.Items.Add(new ListItem(i.ToString(), i.ToString()));
            else
                DropDownList3.Items.Add(new ListItem("0" + i.ToString(), "0" + i.ToString()));

        }
        DateTime dt = DateTime.Now.AddMonths(-1);
        DropDownList2.Items.FindByValue(dt.Year.ToString()).Selected = true;
        DropDownList3.Items.FindByValue(dt.Month.ToString().Length > 1 ? dt.Month.ToString() : "0" + dt.Month.ToString()).Selected = true;

        ilist = ti.GetModelList(" year='" + DropDownList2.SelectedValue + "' and  moon='" + DropDownList3.SelectedValue + "'");
        foreach (Tunnel.Model.Tunnel_items item in ilist)
        {
            DropDownList1.Items.Add(new ListItem(item.i_name, item.i_id.ToString()));
        }
        DropDownList1.Items.Insert(0, new ListItem("请选择", "0"));


    }

    public void ListBind2()
    {
        Tunnel.BLL.Tunnel_items ti = new Tunnel.BLL.Tunnel_items();
        Tunnel.Model.Tunnel_items tii = new Tunnel.Model.Tunnel_items();
        List<Tunnel.Model.Tunnel_items> ilist = new List<Tunnel.Model.Tunnel_items>();

        DropDownList1.Items.Clear();
        ilist = ti.GetModelList(" year='" + DropDownList2.SelectedValue + "' and  moon='" + DropDownList3.SelectedValue + "'");
        foreach (Tunnel.Model.Tunnel_items item in ilist)
        {
            DropDownList1.Items.Add(new ListItem(item.i_name, item.i_id.ToString()));
        }
        DropDownList1.Items.Insert(0, new ListItem("请选择", "0"));


    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            Tunnel.BLL.Tunnel_check tc = new Tunnel.BLL.Tunnel_check();
            Tunnel.Model.Tunnel_check tcc = new Tunnel.Model.Tunnel_check();
            foreach (string item in HiddenField1.Value.Split(','))
            {
                tcc.c_userId = Convert.ToInt32(item.Trim().ToString());
                tcc.c_itemsId = Convert.ToInt32(DropDownList1.SelectedValue);
                tcc.c_date = DropDownList2.SelectedValue + DropDownList3.SelectedValue;
                tcc.c_income = "0";
                tcc.c_score = 0;
                tc.Add(tcc);
                count++;
            }
            Tunnel.Common.Message.Show("成功增加" + count + "条记录");
        }
        catch (Exception)
        {
            Tunnel.Common.Message.Show("请填写完整!", "ExamineAdd.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectAdd.aspx");
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBind2();
    }
}
