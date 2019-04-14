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


public partial class N_UserContrl_TreeView : System.Web.UI.UserControl
{
    private readonly  Tunnel.BLL.Tunnel_ModelType reportManage = new Tunnel.BLL.Tunnel_ModelType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTv();
            }
        }

        /// <summary>
        ///绑定树控件
        /// </summary>
        void BindTv()
        {
            IList<Tunnel.Model.Tunnel_ModelType> pList = reportManage.GetAllParent();
            foreach (Tunnel.Model.Tunnel_ModelType r in pList)
            {
                TreeNode pNode = new TreeNode();
                pNode.Text = r.Re_Name;
                pNode.Value = r.Re_Id.ToString();
                pNode.CollapseAll();
                pNode.NavigateUrl = "~/N_Project/Re_add.aspx?id=" + r.Re_Id.ToString();

                //根据父节点获取所有子节点
                BindNode(ref pNode, r.Re_Id);

                tvReportModel.Nodes.Add(pNode);
            }
            tvReportModel.DataBind();
        }
        void BindNode(ref TreeNode node, int id)
        {
            //根据父节点获取所有子节点
            IList<Tunnel.Model.Tunnel_ModelType> sList = reportManage.GetAllNode(id);
            
                foreach (Tunnel.Model.Tunnel_ModelType sR in sList)
                {
                    TreeNode sNode = new TreeNode();
                    sNode.Text = sR.Re_Name;
                    sNode.Value = sR.Re_Id.ToString();
                    sNode.NavigateUrl = "~/N_Project/Re_add.aspx?id=" + sR.Re_Id.ToString();
                    node.ChildNodes.Add(sNode);

                    BindNode(ref sNode, sR.Re_Id);
                }
            
            
        }
}
