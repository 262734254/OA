using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class N_Project_Project_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.Params["ProJectId"]))
            {
                Tunnel.Model.Tunnel_ProJectMent TPModel = new Tunnel.Model.Tunnel_ProJectMent();
                Tunnel.BLL.Tunnel_ProJectMent TPBll = new Tunnel.BLL.Tunnel_ProJectMent();
                TPModel = TPBll.GetModel(int.Parse(Request.Params["ProJectId"]));
                Label1.Text = Page.Title = TPModel.Pro_Name;
                IsSubmit(Label2, TPModel.Pro_ManEndDate, HyperLink1, HyperLink7);
                IsSubmit(Label3, TPModel.Pro_ContractEndDate, HyperLink2, HyperLink8);
                IsSubmit(Label4, TPModel.Pro_EquipmentEndDate, HyperLink3, HyperLink9);
                IsSubmit(Label5, TPModel.Pro_MaterialEndDate, HyperLink4, HyperLink10);
                IsSubmit(Label6, TPModel.Pro_PlanEndDate, HyperLink5, HyperLink11);
                IsSubmit(Label7, TPModel.Pro_SecurityEndDate, HyperLink6, HyperLink12);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lb">显示Label</param>
    /// <param name="time">提交时间</param>
    /// <param name="lk">查看链接</param>
    /// <param name="tlk">提醒链接</param>
    private void IsSubmit(Label lb, DateTime time,HyperLink lk,HyperLink tlk)
    {
        if (!string.IsNullOrEmpty(time.ToString()) && !"0001-1-1 0:00:00".Equals(time.ToString()))
        {
            lb.Text = "<font color='green'>" + time.ToString() + "</font>";
            lk.Enabled = true;
            tlk.Visible = false;
            lk.NavigateUrl = "#";
        }
        else
        {
            lb.Text = "<font color='red'>未提交</font>";
            tlk.Visible = true;
            lk.Enabled = false;
        }
    }
}
