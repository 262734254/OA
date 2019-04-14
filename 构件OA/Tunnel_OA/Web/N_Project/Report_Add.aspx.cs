using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class N_Project_Report_Add : System.Web.UI.Page
{
    private readonly Tunnel.BLL.Tunnel_ModelType reportManage = new Tunnel.BLL.Tunnel_ModelType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            BindTv();

            //判断模板ID是否为否，不为空则显示该对象
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                //根据模板ID获取模板对象
                Tunnel.Model.Tunnel_ModelType report = reportManage.GetReportById(id);
                //绑定数据
                txtNum.Text = report.Re_Num.ToString();
                txtName.Text = report.Re_Name;
                ddlType.SelectedValue = report.Re_ParentId.ToString();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Tunnel.BLL.UserLogin ul=new Tunnel.BLL.UserLogin();
        Tunnel.Model.Tunnel_ProjectReport TpRModel = new Tunnel.Model.Tunnel_ProjectReport();
        TpRModel.Report_Order = Convert.ToInt32(txtNum.Text.Trim());
        TpRModel.Report_Name = txtName.Text;
        TpRModel.Report_Class = Convert.ToInt32(ddlType.SelectedValue);
        TpRModel.Report_Sort = Convert.ToInt32(RadioButtonList1.SelectedValue);
        TpRModel.Report_State = Convert.ToInt32(RadioButtonList3.SelectedValue);
        TpRModel.Report_UserID=ul.LoginID;
        TpRModel.Report_Shen = Convert.ToInt32(RadioButtonList2.SelectedValue);
        Tunnel.BLL.Tunnel_ProjectReport TpRBll = new Tunnel.BLL.Tunnel_ProjectReport();
        TpRBll.Add(TpRModel);
        Tunnel.Common.Message.Show("添加成功！");
    }

    /// <summary>
    ///绑定下拉列表
    /// </summary>
    void BindTv()
    {
        string str = "      |";
        //查询所有模板数据
        IList<Tunnel.Model.Tunnel_ModelType> sList = reportManage.GetAllParent();

        foreach (Tunnel.Model.Tunnel_ModelType r in sList)
        {
            ListItem lt = new ListItem();

            lt.Text = str + "─" + r.Re_Name;
            lt.Value = r.Re_Id.ToString();
            ddlType.DataTextField = "Re_Name";
            ddlType.DataValueField = "Re_ParentId";

            ddlType.Items.Add(lt);
            //根据父节点获取所有子节点
            BindNode(ref  ddlType, r.Re_Id, str);
        }

    }
    void BindNode(ref DropDownList ddlType, int id, string str)
    {
        str = str + "      |";
        //根据父节点获取所有子节点
        IList<Tunnel.Model.Tunnel_ModelType> sList = reportManage.GetAllNode(id);

        foreach (Tunnel.Model.Tunnel_ModelType sR in sList)
        {
            ListItem lt = new ListItem();
            lt.Text = str + "─" + sR.Re_Name;
            lt.Value = sR.Re_Id.ToString();

            ddlType.Items.Add(lt);

            //BindNode(ref ddlType, sR.Re_Id, str);
        }
        //将循环放到外面，排序
        foreach (Tunnel.Model.Tunnel_ModelType item in sList)
        {
            BindNode(ref ddlType, item.Re_Id, str);
        }

    }
}
