using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class N_Project_Re_add : System.Web.UI.Page
{
     private readonly  Tunnel.BLL.Tunnel_ModelType reportManage = new Tunnel.BLL.Tunnel_ModelType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lt = new ListItem();
                lt.Text = "顶级分类";
                lt.Value = "0";
                ddlType.Items.Add(lt);
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




        /// <summary>
        ///绑定下拉列表
        /// </summary>
        void BindTv()
        {
           string str =  "      |";
            //查询所有模板数据
            IList<Tunnel.Model.Tunnel_ModelType> sList = reportManage.GetAllParent();

            foreach (Tunnel.Model.Tunnel_ModelType r in sList)
            {
                ListItem lt = new ListItem();
                
                    lt.Text =str+"─"+ r.Re_Name;
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
                    BindNode(ref ddlType,item.Re_Id, str);
                }

        }


        /// <summary>
        /// 新增模板类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Tunnel.Model.Tunnel_ModelType r = new Tunnel.Model.Tunnel_ModelType();
                r.Re_Name = txtName.Text;
                r.Re_Num = Convert.ToInt32(txtNum.Text);
                r.Re_ParentId = Convert.ToInt32(ddlType.SelectedValue);
                if (reportManage.AddReport(r) != 0)
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('新增成功');location.herf='Re_add.aspx'</script>");
                    Response.Write("新增成功!");
                    Response.Redirect("Re_add.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('新增失败')</script>");
                    return;
                }
            }
        }
    
}
