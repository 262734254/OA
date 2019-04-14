using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vote_NewVote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tunnel.BLL.Tunnel_Vote tv = new Tunnel.BLL.Tunnel_Vote();
        Tunnel.Model.Tunnel_Vote tvv = new Tunnel.Model.Tunnel_Vote();
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        tvv.vote_userId = Convert.ToInt32(ul.LoginID.ToString());
        tvv.vote_bumGroup = TextbumId.Value;
        tvv.vote_startDate = TextBox1.Text.Trim().Length > 0 ? Convert.ToDateTime(TextBox1.Text) : DateTime.Now;
        tvv.vote_endDate = TextBox2.Text.Trim().Length > 0 ? Convert.ToDateTime(TextBox2.Text) : Convert.ToDateTime(tvv.vote_startDate).AddYears(1);
        tvv.vote_mark = txtText.Text;
        tvv.vote_state = 0;
        tvv.vote_Title = txtTitle.Text;
        tvv.vote_top = 0;
        tvv.vote_Type = Convert.ToInt32(DropDownList1.SelectedValue);
        tvv.vote_max = 1;
        if (tvv.vote_Type == 1)
        {
            if (TextBox3.Text.Length > 0)
                tvv.vote_max = Convert.ToInt32(TextBox3.Text.Trim());
            else
                tvv.vote_max = 1;
        }
        int relf = tv.Add(tvv);
        if (relf > 0)
        {
            if (CheckBox1.Checked)
            {

                #region 发消息给大家//////////////////////////////////////
                //获得所需参数
                string strToIds = tvv.vote_bumGroup;
                string strTitle = "投票:" + tvv.vote_Title;
                //写入数据库
                if (strToIds != "" && strToIds != "|")
                {
                    strToIds = strToIds.Split('|')[0].ToString();
                    if (strToIds.LastIndexOf(',') > 0)
                    {
                        strToIds = strToIds.Remove(strToIds.LastIndexOf(','), 1);
                    }
                    string[] arr = strToIds.Split(',');
                    List<Tunnel.Model.Tunnel_menber> tmList = new List<Tunnel.Model.Tunnel_menber>();
                    foreach (string item in arr)
                    {
                        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
                        tmList = new List<Tunnel.Model.Tunnel_menber>();
                        tmList = tm.GetModelList("m_bum=" + item + "");
                        for (int j = 0; j < tmList.Count; j++)
                        {
                            call(strTitle, relf.ToString(), DateTime.Now, tmList[j].m_id);
                        }
                    }
                }
                else
                {

                    List<Tunnel.Model.Tunnel_menber> tmList = new List<Tunnel.Model.Tunnel_menber>();
                    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
                    tmList = tm.GetModelList("");

                    foreach (Tunnel.Model.Tunnel_menber item in tmList)
                    {
                        call(strTitle, relf.ToString(), DateTime.Now, item.m_id);
                    }
                }
                #endregion
            }
            Tunnel.Common.Message.Show("添加成功！", "VoteItemsAdd.aspx?id=" + relf + "");
        }
        else
            Tunnel.Common.Message.Show("添加失败！");
    }

    public void call(string title, string id, DateTime calltime,long toId)
    {
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        Tunnel.Model.Tunnel_Remind remindmodel = new Tunnel.Model.Tunnel_Remind();
        remindmodel.m_isread = 0;
        remindmodel.m_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        remindmodel.m_title = " 投票:" + title + "<font color=red>（未读）</font>";
        remindmodel.m_touser = toId;
        remindmodel.m_url = "N_Exchange/N_Vote/Vote.aspx?id=" + id;
        remindmodel.m_callTime = calltime;
        remindmodel.m_type = 4;
        remindmodel.m_typeid = int.Parse(id);
        remindmodel.m_bid = 0;
        Tunnel.BLL.Tunnel_Remind rd = new Tunnel.BLL.Tunnel_Remind();
        rd.Add(remindmodel);
    }
}
