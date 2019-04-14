using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vote_VoteUpd : System.Web.UI.Page
{
    public static int tempId = -1;
    Tunnel.BLL.Tunnel_Vote tv = new Tunnel.BLL.Tunnel_Vote();
    static Tunnel.Model.Tunnel_Vote tvv = new Tunnel.Model.Tunnel_Vote();
    List<Tunnel.Model.Tunnel_Vote> tvList = new List<Tunnel.Model.Tunnel_Vote>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                tempId = Convert.ToInt32(Request.QueryString["id"].ToString());
                Pagebind();
            }
        }
    }

    public void Pagebind()
    {
        tvv = tv.GetModel(tempId);
        if (tvv != null)
        {
            if (!string.IsNullOrEmpty(tvv.vote_bumGroup) && tvv.vote_bumGroup != "|")
            {
                TextbumName.Value = tvv.vote_bumGroup.Split('|')[1];
            }
            else
            {
                TextbumName.Value = tvv.vote_bumGroup;
            }
            TextbumId.Value = tvv.vote_bumGroup;
            txtTitle.Text = tvv.vote_Title;
            txtText.Text = tvv.vote_mark;
            TextBox3.Text = tvv.vote_max.ToString();
            DropDownList1.SelectedIndex = Convert.ToInt32(tvv.vote_Type.ToString());
            TextBox1.Text = Convert.ToDateTime(tvv.vote_startDate).ToShortDateString();
            TextBox2.Text =Convert.ToDateTime(tvv.vote_endDate).ToShortDateString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        tvv.vote_bumGroup = TextbumId.Value;
        tvv.vote_startDate = TextBox1.Text.Trim().Length > 0 ? Convert.ToDateTime(TextBox1.Text) : DateTime.Now;
        tvv.vote_endDate = TextBox2.Text.Trim().Length > 0 ? Convert.ToDateTime(TextBox2.Text) : Convert.ToDateTime(tvv.vote_startDate).AddYears(1);
        tvv.vote_mark = txtText.Text;
        tvv.vote_Title = txtTitle.Text;
        tvv.vote_Type = Convert.ToInt32(DropDownList1.SelectedValue);
        tvv.vote_max = 1;
        if (tvv.vote_Type == 1)
        {
            if (TextBox3.Text.Length > 0)
                tvv.vote_max = Convert.ToInt32(TextBox3.Text.Trim());
            else
                tvv.vote_max = 1;
        }
        tv.Update(tvv);
        Tunnel.Common.Message.Show("修改成功!", "votemanagelist.aspx");
    }
}
