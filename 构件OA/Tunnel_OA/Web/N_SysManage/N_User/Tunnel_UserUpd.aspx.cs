using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tunnel.Model;
using System.Collections.Generic;


public partial class Dachie_UserUpd : System.Web.UI.Page
{
    public static Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    public Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
    public static Tunnel.BLL.Tunnel_uyingshe tu = new Tunnel.BLL.Tunnel_uyingshe();
    public static Tunnel.Model.Tunnel_uyingshe tuu = new Tunnel.Model.Tunnel_uyingshe();
    Tunnel.BLL.SelType st = new Tunnel.BLL.SelType();

    public static Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
    public static Tunnel.Model.Tunnel_jiaose tjj = new Tunnel_jiaose();
    public static List<Tunnel_bum> blist = new List<Tunnel_bum>();
    public static Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    public static Tunnel.Model.Tunnel_bum tbb = new Tunnel_bum();
    public static List<Tunnel_duty> dlist = new List<Tunnel_duty>();
    public static Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
    public static Tunnel.Model.Tunnel_duty tdd = new Tunnel_duty();
    public static List<Tunnel_jiaose> jlist = new List<Tunnel_jiaose>();
    private Tunnel.BLL.Tunnel_xjbType xjbTypeBLL;
    private Tunnel.BLL.Tunnel_xjbType m_xjbTypeBLL
    {
        get
        {
            if (null == xjbTypeBLL)
                xjbTypeBLL = new Tunnel.BLL.Tunnel_xjbType();
            return xjbTypeBLL;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            DropBind();
            if (!string.IsNullOrEmpty(Request.QueryString["updid"]))
            {
                tmm = tm.GetModel(Convert.ToInt64(Request.QueryString["updid"].ToString()));
                bind();
            }
            else
            {
                Tunnel.Common.Message.Show("用户不存在");
            }
        }
    }

    public void DropBind()
    {
        jlist = tj.GetModelList("1=1");
        for (int i = 0; i < jlist.Count; i++)
        {
            DropDownList1.Items.Add(new ListItem(jlist[i].j_name, jlist[i].j_id.ToString()));
        } 
        DropDownList1.Items.Insert(0, new ListItem("请选择", "0"));

        blist = tb.GetModelList("1=1");
        for (int i = 0; i < blist.Count; i++)
        {
            ddlBum.Items.Add(new ListItem(blist[i].b_name, blist[i].b_id.ToString()));
        }
        ddlBum.Items.Insert(0, new ListItem("请选择", "0"));

        dlist = td.GetModelList("1=1");
        for (int i = 0; i < dlist.Count; i++)
        {
            ddlDuty.Items.Add(new ListItem(dlist[i].d_name, dlist[i].d_id.ToString()));
        }
        ddlDuty.Items.Insert(0, new ListItem("请选择", "0"));

        List<Tunnel.Model.Tunnel_xjbType> xjbList = m_xjbTypeBLL.GetModelList("1=1");
        foreach (Tunnel.Model.Tunnel_xjbType x_item in xjbList)
        {
            CheckBoxList3.Items.Add(new ListItem(x_item.Typename, x_item.Id.ToString()));
        }
        List<Tunnel.Model.Tunnel_SelType> newsType = st.GetModelList("KSID<>0 ORDER BY KSID");
        string sid = "";
        for (int i = 0; i < newsType.Count; i++)
        {
            if (sid == newsType[i].KSID.ToString().Trim())
            {
                continue;
            }
            else
            {
                cbListKS.Items.Add(new ListItem(newsType[i].BumName, newsType[i].KSID.ToString()));
                sid = newsType[i].KSID.ToString();
            }
        }
    }

    public void bind()
    {
        tmm = tm.GetModel(Convert.ToInt64(Request.QueryString["updid"]));
        ddlBum.SelectedIndex = -1;
        ddlBum.Items.FindByValue(tmm.m_bum.ToString()).Selected = true;
        ddlDuty.SelectedIndex = -1;
        ddlDuty.Items.FindByValue(tmm.m_duty.ToString()).Selected = true;

        foreach (string item in tmm.m_xjb.ToString().Split('|'))
        {
            foreach (ListItem item1 in CheckBoxList3.Items)
            {
                if (item1.Value == item)
                    item1.Selected = true;
            }
        }
        foreach (string item in tmm.m_KSID.ToString().Trim().Split(','))
        {
            foreach (ListItem item1 in cbListKS.Items)
            {
                if (item1.Value == item)
                    item1.Selected = true;
            }
        }

        if (tj.GetModelList("j_id=" + tmm.m_jiao + "").Count != 0)
        {
            DropDownList1.Items.FindByValue(tmm.m_jiao.ToString()).Selected = true;
        }


        txtPwd.Attributes["value"] = tmm.m_password;
        txtsPwd.Attributes["value"] = tmm.m_spassword;

        txtIdKard.Text = tmm.m_idcard;
        txtUserName.Text = tmm.m_login;
        txtMail.Text = tmm.m_mail;
        txtTel.Text = tmm.m_mobile;
        txtName.Text = tmm.m_name;
        rbState.Items.FindByValue(tmm.m_state.ToString()).Selected = true;
        txtBirth.Text = tmm.m_birth.ToShortDateString() == "1800-1-1" ? "" : tmm.m_birth.ToShortDateString();

    }

    public bool Save()
    {
        bool b = false;
        try
        {
            tmm.m_id = Convert.ToInt64(Request.QueryString["updid"].ToString());
            tmm.m_idcard = txtIdKard.Text.Trim();
            if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {
                tmm.m_jiao = Convert.ToInt32(DropDownList1.SelectedValue);
            }
            tmm.m_bum = int.Parse(ddlBum.SelectedValue.Trim());
            tmm.m_duty = int.Parse(ddlDuty.SelectedValue.Trim());
            string xjb = string.Empty;
            foreach (ListItem item in CheckBoxList3.Items)
            {
                if (item.Selected)
                    xjb += item.Value + "|";
            }
            if (xjb.Length > 0)
            {
                xjb = xjb.Substring(0, xjb.Length - 1);
            }
            if (!string.IsNullOrEmpty(xjb))
                tmm.m_xjb = xjb;
            else
                tmm.m_xjb = "";

            tmm.m_mail = txtMail.Text.Trim();
            tmm.m_name = txtName.Text.Trim();
            if (txtPwd.Attributes["value"] != txtPwd.Text)
            {
                tmm.m_password = Tunnel.Data.DESEncrypt.Encrypt(txtPwd.Text.Trim());
            }
            else
            {
                tmm.m_password = txtPwd.Attributes["value"];
            }

            if (txtsPwd.Attributes["value"] != txtsPwd.Text)
            {
                tmm.m_spassword = Tunnel.Data.DESEncrypt.Encrypt(txtsPwd.Text.Trim());
            }
            else
            {
                tmm.m_spassword = txtsPwd.Attributes["value"];
            }
            tmm.m_state = Convert.ToInt32(rbState.SelectedValue);
            tmm.m_mobile = txtTel.Text.Trim();
            tmm.m_login = txtUserName.Text.Trim();
            if (!string.IsNullOrEmpty(txtBirth.Text))
            {
                tmm.m_birth = Convert.ToDateTime(txtBirth.Text);
            }
            string ksid = string.Empty;
            foreach (ListItem item in cbListKS.Items)
            {
                if (item.Selected)
                    ksid += item.Value + ",";
            }
            if (ksid.Length > 0)
            {
                ksid = ksid.Substring(0, ksid.Length - 1);
            }
            if (!string.IsNullOrEmpty(ksid))
                tmm.m_KSID = ksid;
            else
                tmm.m_KSID = "";

            tm.Update(tmm);
            b = true;
        }
        catch (Exception ex)
        {
            Tunnel.Common.Message.Show(ex.Message);
        }
        return b;

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Save())
        {
            Tunnel.Common.Message.Show("更新成功", "tunnel_userlist.aspx");
        }
        else
        {
            Tunnel.Common.Message.Show("更新失败");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("tunnel_userlist.aspx");
    }
}
