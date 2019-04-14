using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Model;
using BLL.Car;
using Common;
public partial class CarManager_DisobeyRecordlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Pager1.onLoadPageIndexChaning += new _Controls_Pager.MyDele(Pager1_onLoadPageIndexChaning);
        if (!IsPostBack)
        {
         
            Pager1.onLoadPageIndexChaning += new _Controls_Pager.MyDele(Pager1_onLoadPageIndexChaning);
            DataBind(0);
        }
    }

    void Pager1_onLoadPageIndexChaning(int pageIndex)
    {
        DataBind(pageIndex);
    }
    /// <summary>
    /// 利用PagedDataSource做数据源绑定数据分页
    /// </summary>
    /// <param name="pageIndex"></param>
    private void DataBind(int pageIndex)
    {
        string statime = txtStatime.Value;
        string endtime = txtEndtime.Value;
        string carType = ddlCharType.SelectedValue;
        string carMark = ddlCarMark.SelectedValue;
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = CommHelper.GetPageCount;
        IList<DisobeyRecord> list = null;
        if (statime == "" && endtime == "" && carType == "全部" && carMark == "全部")
        {
            list = DisobeyRecordManager.getAllDisobeyRecord("", "", "全部", "全部");
        }
        else
        {
            list = DisobeyRecordManager.getAllDisobeyRecord(statime, endtime, carType, carMark);
        }
        if (list.Count == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "无相应的记录";
        }
        else
        {
            lblMessage.Visible = false;
        }
        pds.DataSource = list;
        pds.CurrentPageIndex = pageIndex;  //取得当前页索引
        Pager1.DataCount = list.Count;//获取记录数 并赋值  
        Pager1.PageCount = pds.PageCount;
        dvDisobeyRecord.DataSourceID = null;
        dvDisobeyRecord.DataSource = pds;
        dvDisobeyRecord.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
         DataBind(0);
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < dvDisobeyRecord.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)dvDisobeyRecord.Rows[i].FindControl("input") as CheckBox;
                if (cb.Checked == true)
                {

                    HiddenField lfCarID = dvDisobeyRecord.Rows[i].FindControl("lblDR_Id") as HiddenField;
                    int id = Convert.ToInt32(lfCarID.Value);
                    DisobeyRecordManager.delDisobeyRecordById(id);
                }

            }

            Response.Redirect("~/CarManager/DisobeyRecordlist.aspx");
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);

            return;
        }
    }
    protected void lbtnSel_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Sel")
        {
            int DR_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/DisobeyRecord.aspx?DR_Id=" + DR_Id + "&&DR_name=" + name);
        }
    }
    protected void lbtnUp_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Up")
        {
            int DR_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/DisobeyRecord.aspx?DR_Id=" + DR_Id + " &&DR_name=" + name);
        }
    }
}
