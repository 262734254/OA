using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vote_IndexVote : System.Web.UI.Page
{

    Tunnel.BLL.Tunnel_Votei tv = new Tunnel.BLL.Tunnel_Votei();
    Tunnel.Model.Tunnel_Votei tvv = new Tunnel.Model.Tunnel_Votei();
    List<Tunnel.Model.Tunnel_Votei> tvList = new List<Tunnel.Model.Tunnel_Votei>();

    public static int id = -1;
    public static string voteTitle = string.Empty;
    public static string voteUserName = string.Empty;
    public static string voteDate = string.Empty;
    public static string voteMark = string.Empty;
    public static string voteMax = string.Empty;
    public static string voteType = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                Tunnel.BLL.Tunnel_Vote t = new Tunnel.BLL.Tunnel_Vote();
                Tunnel.Model.Tunnel_Vote tt = new Tunnel.Model.Tunnel_Vote();
                Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
                tt = t.GetModel(id);

                voteTitle = tt.vote_Title;
                voteUserName = tm.GetModel(Convert.ToInt32(tt.vote_userId)).m_name;
                voteDate = Convert.ToDateTime(tt.vote_startDate).ToShortDateString();
                if (!string.IsNullOrEmpty(tt.vote_mark))
                {
                    voteMark = "<img src=../image/info.png width=20px />"+tt.vote_mark;
                }
                voteMax = tt.vote_max.ToString();
                voteType = tt.vote_Type.ToString();
                max.Value = voteMax;

                tvList = tv.GetModelList("ivote_voteId=" + id + "");
                Repeater1.DataSource = tvList;
                Repeater1.DataBind();
                if (voteType == "0")
                    for (int i = 0; i < Repeater1.Items.Count; i++)
                    {
                        ((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Visible = false;
                    }
                else
                    for (int i = 0; i < Repeater1.Items.Count; i++)
                    {
                        ((RadioButton)Repeater1.Items[i].FindControl("RadioButton1")).Visible = false;
                    }
                Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
                bool b = false;
                for (int i = 0; i < tvList.Count; i++)
                {
                    string[] temp = tvList[i].ivote_yesUserId.Split(',');
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (ul.LoginID.ToString() == temp[j])
                            b = true;
                    }
                }
                if (b)
                    Button1.Text = "查看结果";

            }
            else
            {
                Tunnel.BLL.Tunnel_Vote tv = new Tunnel.BLL.Tunnel_Vote();
                List<Tunnel.Model.Tunnel_Vote> tvList = new List<Tunnel.Model.Tunnel_Vote>();
                tvList = tv.GetModelList("(getdate()>vote_startDate and getdate()<vote_endDate) and vote_state=0 and vote_top =1 order by vote_startDate desc");
                if (tvList.Count > 0)
                {
                    Response.Redirect("indexvote.aspx?id=" + tvList[0].vote_Id + "");
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "投票")
        {
            Tunnel.BLL.Tunnel_Votei tvi = new Tunnel.BLL.Tunnel_Votei();
            Tunnel.Model.Tunnel_Votei tvii = new Tunnel.Model.Tunnel_Votei();
            if (voteType == "0")
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    if (((RadioButton)Repeater1.Items[i].FindControl("RadioButton1")).Checked)
                    {
                        tvii.ivote_Id = Convert.ToInt32(((RadioButton)Repeater1.Items[i].FindControl("RadioButton1")).ToolTip.ToString());
                        tvii = tvi.GetModel(tvii.ivote_Id);
                        tvii.ivote_Count++;
                        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
                        tvii.ivote_yesUserId += ul.LoginID + ",";
                        tvi.Update(tvii);
                    }
                }
            else
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                    {
                        tvii.ivote_Id = Convert.ToInt32(((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).ToolTip.ToString());
                        tvii = tvi.GetModel(tvii.ivote_Id);
                        tvii.ivote_Count++;
                        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
                        tvii.ivote_yesUserId += ul.LoginID + ",";
                        tvi.Update(tvii);
                    }
                }
            Tunnel.Common.Message.Show("投票成功!");
        }
        else
        {
            Response.Redirect("indexvoteshow.aspx?id=" + id + "");
        }
    }
}
