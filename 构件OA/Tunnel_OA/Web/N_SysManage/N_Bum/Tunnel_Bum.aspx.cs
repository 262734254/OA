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
using System.Collections.Generic;

public partial class SystemManage_Tunnel_Bum : System.Web.UI.Page
{
    public static Tunnel.BLL.Tunnel_bum bm = new Tunnel.BLL.Tunnel_bum();
    public static Tunnel.Model.Tunnel_bum bmm = new Tunnel.Model.Tunnel_bum();
    public static List<Tunnel.Model.Tunnel_bum> bmmlist = new List<Tunnel.Model.Tunnel_bum>();
    public static List<Tunnel.Model.Tunnel_bum> blist = new List<Tunnel.Model.Tunnel_bum>();
    public static string state = string.Empty;
    public static string bid = "0";
    public static Tunnel.BLL.Tunnel_byingshe tb = new Tunnel.BLL.Tunnel_byingshe();
    public static Tunnel.Model.Tunnel_byingshe tbb = new Tunnel.Model.Tunnel_byingshe();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.InitTree(TreeView1.Nodes, "0");
            BindDrop();
            if (!string.IsNullOrEmpty(Request.QueryString["act"]))
            {
                state = Request.QueryString["act"].ToString();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    bid = Request.QueryString["id"].ToString();
                    DropDownList1.Items.FindByValue(bm.GetModel(Convert.ToInt32(bid)).b_hid.ToString()).Selected = true;
                    txtname.Text = bm.GetModel(Convert.ToInt32(bid)).b_name;
                    txtname2.Text = bm.GetModel(Convert.ToInt32(bid)).b_depict;
                }
                else
                    bid = "0";
                if (state == "upd")
                    DropDownList1.Enabled = false;
                else if (state == "del")
                {
                    if (DelBum())
                        Tunnel.Common.Message.Show("删除成功", "Tunnel_Bum.aspx");
                    else
                        Tunnel.Common.Message.Show("存在下级机构", "Tunnel_Bum.aspx");
                }
                else
                    Tunnel.Common.Message.Show("非法访问", "../../default.aspx");
            }
            else
            {
                state = string.Empty;
                DropDownList1.Enabled = true;
            }

        }
    }

    protected void InitTree(TreeNodeCollection Nds, string parentId)//用递归方法动态生成节点
    {
        DataSet ds = new DataSet();
        ds = bm.GetAllList();
        DataView dv = new DataView();
        TreeNode tmpNode;
        dv.Table = ds.Tables[0];
        dv.RowFilter = "b_hid=" + "'" + parentId + "'";
        foreach (DataRowView drv in dv)
        {
            tmpNode = new TreeNode();
            tmpNode.Value = drv["b_id"].ToString();
            tmpNode.Text = drv["b_name"].ToString() + "<a href='?act=upd&id=" + drv["b_id"].ToString() + "'><font color=red>[改]</font></a> <a href=?act=del&id=" + drv["b_id"].ToString() + " onClick=\"return confirm('是否删除此条记录？')\"><font color=red>[删]</font></a><a href=../../N_Permission/Permission.aspx?bid=" + drv["b_id"].ToString() + ">[权限]</a>";
            //tmpNode.NavigateUrl = "#";//设置超链接

            tmpNode.SelectAction = TreeNodeSelectAction.None;//禁用超链接属性

            tmpNode.ExpandAll();//展开所有子节点
            Nds.Add(tmpNode);
            this.InitTree(tmpNode.ChildNodes, tmpNode.Value);

        }
    }

    public void BindDrop()
    {
        bmmlist = bm.GetModelList("1=1");
        foreach (Tunnel.Model.Tunnel_bum item in bmmlist)
        {
            if (item.b_hid == 0)
            {
                DropDownList1.Items.Add(new ListItem("顶级机构" + "-->>" + item.b_name, item.b_id.ToString()));
            }
            else
            {
                if (bm.GetModel(item.b_id) != null)
                    if (bm.GetModel(bm.GetModel(item.b_id).b_hid) != null)
                        if (item != null)
                            DropDownList1.Items.Add(new ListItem(bm.GetModel(bm.GetModel(item.b_id).b_hid).b_name + "-->>" + item.b_name, item.b_id.ToString()));
            }
        }
    }

    public bool AddBum()
    {
        bool b = true;
        blist = bm.GetModelList("b_hid=" + DropDownList1.SelectedValue + "");

        foreach (Tunnel.Model.Tunnel_bum item in blist)
        {
            if (item.b_name == txtname.Text.Trim())
            {
                b = false; //同级存在同名
            }
        }
        if (b)
        {
            bmm.b_name = txtname.Text.Trim();
            bmm.b_hid = Convert.ToInt32(DropDownList1.SelectedValue);
            bmm.b_depict = txtname2.Text;
            int i = bm.Add(bmm);
            tbb.by_bid = i.ToString();
            tb.Add(tbb);
        }
        return b;

    }
    public bool UpdBum()
    {
        bmm = bm.GetModel(Convert.ToInt64(bid));
        bmm.b_name = txtname.Text.Trim();
        bmm.b_depict = txtname2.Text.Trim();
        bm.Update(bmm);
        return true;
    }
    public bool DelBum()
    {
        bool b = true;
        blist = bm.GetModelList("b_hid=" + bid + "");
        if (blist.Count > 0)
        {
            b = false; //存在下级目录
        }
        else
        {
            bm.Delete(Convert.ToInt64(bid));
            if (tb.GetModelList("by_bid='" + bid + "'").Count != 0)
            {
                tb.Delete(Convert.ToInt32(tb.GetModelList("by_bid='" + bid + "'")[0].by_id));
            }
        }
        return b;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (state == "upd")
        {
            UpdBum();
            Tunnel.Common.Message.Show("更新成功", "Tunnel_Bum.aspx");
        }
        else
        {
            if (AddBum())
            {
                Tunnel.Common.Message.Show("添加成功", "Tunnel_Bum.aspx");
            }
            else
            {
                Tunnel.Common.Message.Show("同机构存在同名部门", "Tunnel_Bum.aspx");
            }
        }
    }
}

