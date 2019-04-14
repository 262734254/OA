using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class N_Project_Project_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.Params["DeleteId"]))
            {
                Tunnel.BLL.Tunnel_ProJectMent TPBll = new Tunnel.BLL.Tunnel_ProJectMent();
                TPBll.Delete(int.Parse(Request.Params["DeleteId"]));
                //Tunnel.Data.DbHelperSQL.ExecuteSql("Update Tunnel_ProJectMent Set Pro_Status=-1 Where Pro_id=" + int.Parse(Request.Params["DeleteId"]));
                Tunnel.BLL.Tunnel_bum TbBll = new Tunnel.BLL.Tunnel_bum();
                Tunnel.Common.Message.Show("删除成功!");
            }
            if (!string.IsNullOrEmpty(Request.Params["PauseId"]))
            {
                Tunnel.Data.DbHelperSQL.ExecuteSql("Update Tunnel_ProJectMent Set Pro_Status=1 Where Pro_id=" + int.Parse(Request.Params["PauseId"]));
                Tunnel.Common.Message.Show("操作成功!");
            }
            if (!string.IsNullOrEmpty(Request.Params["CloseId"]))
            {
                Tunnel.Data.DbHelperSQL.ExecuteSql("Update Tunnel_ProJectMent Set Pro_Status=2 Where Pro_id=" + int.Parse(Request.Params["CloseId"]));
                Tunnel.Common.Message.Show("操作成功!");
            }
            if (!string.IsNullOrEmpty(Request.Params["OpenId"]))
            {
                Tunnel.Data.DbHelperSQL.ExecuteSql("Update Tunnel_ProJectMent Set Pro_Status=0 Where Pro_id=" + int.Parse(Request.Params["OpenId"]));
                Tunnel.Common.Message.Show("操作成功!");
            }
            this.Bind();
        }
    }

    private void Bind()
    {
        DataSet ds = (new Tunnel.BLL.Tunnel_ProJectMent()).GetList("1=1 order by Pro_StartDate Desc");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables[0].DefaultView;//设置数据源(DataTable类型)
        pds.AllowPaging = true;
        //每页显示的行数
        //pds.PageSize = 12;
        AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {

    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        this.Bind();
    }

    public string GetStatus(string state)
    {
        switch (state)
        {
            case "0":
                return "<font color=green>开启</font>";
            case "1":
                return "<font color=Orange>暂停</font>";
            case "2":
                return "<font color=red>关闭</font>";
            default:
                return "";
        }
    }

    public string GetMenu(string state, string id)
    {
        switch (state)
        {
            case "0":
                return "<a href='?PauseId=" + id + "'>暂停</a> <a href='?CloseId=" + id + "'onclick='return confirm(\"关闭后所有表单将停止填写！确认关闭本项经部？\")'>关闭</a>";
            case "1":
                return "<a href='?OpenId=" + id + "'>开启</a> <a href='?CloseId=" + id + "' onclick='return confirm(\"关闭后所有表单将停止填写！确认关闭本项经部？\")'>关闭</a>";
            default:
                return "";
        }
    }
}
