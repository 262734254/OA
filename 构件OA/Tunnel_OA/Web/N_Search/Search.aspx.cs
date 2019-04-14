using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tunnel.Model;
using System.Data;
using System.Data.SqlClient;

public partial class N_Search_Search : System.Web.UI.Page
{

    public int cuttentPage;

    private int pageSize = 28;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCom();
            MTCPager1.Visible = false;
        }
    }


    public void PageBind()
    {

        //System.Web.UI.HtmlControls.HtmlTable imgview = (System.Web.UI.HtmlControls.HtmlTable)this.FindControl("imgview");


        // System.Web.UI.HtmlControls.HtmlTable tableview = (System.Web.UI.HtmlControls.HtmlTable)this.FindControl("tableview");

        string where = " 1=1 ";
        Tunnel.Model.PageBase pb = new PageBase();
        if (DropDownList1.SelectedItem.Text.Trim().Equals("新闻"))
            where += " and i_sort = 0 and i_hit=1 ";
        if (DropDownList1.SelectedItem.Text.Trim().Equals("公告"))
        {
            pb.TblName = "Tunnel_information";
            where += " and i_sort = 1 ";
        }
        else
            pb.TblName = DropDownList1.SelectedItem.Value.Trim();
        pb.ProcedureName = "SearchAll";
        pb.FldName = "id";
        pb.OrderType = 1;
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        pb.DoCount = 1;
        where += " and (Title like '%" + text1.Text.Trim() + "%' or content like '%" + text1.Text.Trim() + "%')";
        pb.StrWhere = where + " and del=0";
        SqlParameter[] parameters = GetParameter(pb);
        DataSet das = Tunnel.Data.DbHelperSQL.RunProcedure(pb.ProcedureName, parameters, "ds");
        if (pb.DoCount == 1)
        {
            if (das.Tables.Count == 1)
                count = Convert.ToInt32(das.Tables[0].Rows[0][0].ToString());
        }
        das.Clear();
        pb.DoCount = 0;
        SqlParameter[] parameters2 = GetParameter(pb);
        DataSet das2 = Tunnel.Data.DbHelperSQL.RunProcedure(pb.ProcedureName, parameters2, "ds");
        if (!(das2.Tables[0].Rows.Count > 0))
           Tunnel.Common.Message.Show("没有相关匹配的信息");

        //数据绑定
        if (DropDownList1.SelectedItem.Text.Trim().Equals("图片"))
        {
            imgview.Style.Add(HtmlTextWriterStyle.Display, "''");
            tableview.Style.Add(HtmlTextWriterStyle.Display, "none");
            DataList1.DataSource = das2.Tables[0];
            DataList1.DataBind();
        }
        else
        {
            imgview.Style.Add(HtmlTextWriterStyle.Display, "none");
            tableview.Style.Add(HtmlTextWriterStyle.Display, "''");
            Repeater1.DataSource = das2.Tables[0];
            Repeater1.DataBind();
        }

        //数据分页
        MTCPager1.PageSize = pageSize;
        MTCPager1.RecordCount = count;
        MTCPager1.PageIndex = cuttentPage;
        if (count <= pb.PageSize)
            MTCPager1.Visible = false;
        else
            MTCPager1.Visible = true;
    }

    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        PageBind();
    }
    private void BindCom()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("新闻", "Tunnel_information");
        dic.Add("公告", "Tunnel_informations");
        dic.Add("科室信息", "Tunnel_Index");
        dic.Add("公文", "Tunnel_bumf");
        //dic.Add("档案", "Tunnel_Profile");
        //dic.Add("图片", "Tunnel_Img");
        foreach (KeyValuePair<string, string> value in dic)
        {
            DropDownList1.Items.Add(new ListItem(value.Key, value.Value));
        }
    }
    protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
    {
        PageBind();
    }
    private SqlParameter[] GetParameter(PageBase pb)
    {
        SqlParameter[] parameters = 
            {
                new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                new SqlParameter("@strGetFields", SqlDbType.VarChar, 255),
                new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@doCount", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
            };
        parameters[0].Value = pb.TblName;
        parameters[1].Value = pb.StrGetFields;
        parameters[2].Value = pb.FldName;
        parameters[3].Value = pb.PageSize;
        parameters[4].Value = pb.PageIndex;
        parameters[5].Value = pb.DoCount;
        parameters[6].Value = pb.OrderType;
        parameters[7].Value = pb.StrWhere;
        return parameters;
    }
    /// <summary>
    /// 显示用户真实姓名
    /// </summary>
    /// <param name="Id">用户Id</param>
    /// <returns></returns>
    public string ShowUserName(string UserId)
    {
        Tunnel.BLL.Tunnel_menber mbll = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber model = new Tunnel.Model.Tunnel_menber();
        model = mbll.GetModel(Convert.ToInt64(UserId));
        string strTemp = string.Empty;
        if (model != null)
            strTemp = model.m_name;
        return strTemp;
    }
    public string TitleHerfUrl(int id, string title)
    {
        string type = DropDownList1.SelectedItem.Text.Trim();
        string url = "";
        switch (type)
        {
            case "新闻":
                url = "<a href='../N_News/N_News/N_NewView.aspx?Id=" + id + "&TypeId=0'>" + title + "</a>";
                break;
            case "公告":
                url = "<a href='../N_News/N_Bulletin/N_GonggaoView.aspx?Id=" + id + "&TypeId=1'>" + title + "</a>";
                break;
            case "科室信息":
                Tunnel.BLL.Tunnel_Index ix = new Tunnel.BLL.Tunnel_Index();
                Tunnel_index model = new Tunnel_index();
                model = ix.GetModel(id);
                url = "<a href='ViewIndex.aspx?Id=" + id + "&TypeId=" + model.TypeId + "&lanmuId=1'>" + title + "</a>";
                break;
            case "公文":
                url = "<a href='../N_WorkFlow/ODocument/Document_View.aspx?lid=" + Tunnel.Data.DESEncrypt.Encrypt(id.ToString()) + "'>" + title + "</a>";
                break;
            case "档案":
                url = title;
                break;
            case "图片":
                url = "<a href='../N_WorkFlow/ODocument/Document_View.aspx?lid=" + Tunnel.Data.DESEncrypt.Encrypt(id.ToString()) + "'>" + title + "</a>";
                break;
        }
        return url;
    }
}
