using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SystemManage_BaseData_Flow_SelectLeft : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.createDataSet();
        this.InitTree(TreeView1.Nodes, "0");
    }
    private DataSet createDataSet()//返回数据库表
    {
        Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
        ds = new DataSet();
        ds =tb.GetList("");
        return ds;
    }
    protected void InitTree(TreeNodeCollection Nds, string parentId)//用递归方法动态生成节点

    {
        DataView dv = new DataView();
        TreeNode tmpNode;
        dv.Table = ds.Tables[0];
        dv.RowFilter = "b_hid=" + "'" + parentId + "'";
        foreach (DataRowView drv in dv)
        {
            tmpNode = new TreeNode();
            tmpNode.Value = drv["b_id"].ToString();
            tmpNode.Text = "<a href='Flow_SelectRight.aspx?act=bum&idh=" + drv["b_id"].ToString() + "&to_id=" + Request.Params["to_id"] + "&to_name=" + Request.Params["to_name"] + "&type=" + Request.Params["type"] + "&Competence=" + Request.Params["Competence"] + "' target='rightFrame'>" + drv["b_NAME"].ToString() + "<a> ";
            //tmpNode.NavigateUrl = "#";//设置超链接

            tmpNode.SelectAction = TreeNodeSelectAction.None;//禁用超链接属性

            tmpNode.ExpandAll();//展开所有子节点
            Nds.Add(tmpNode);
            this.InitTree(tmpNode.ChildNodes, tmpNode.Value);
        }
    }
}
