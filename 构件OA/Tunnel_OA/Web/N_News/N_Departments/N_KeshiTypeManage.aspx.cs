using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using Tunnel.Model;

public partial class N_News_N_Departments_N_KeshiTypeManage : System.Web.UI.Page
{
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    Tunnel.BLL.SelType st = new Tunnel.BLL.SelType();
    Tunnel.Model.Tunnel_SelType most = new Tunnel.Model.Tunnel_SelType();
    List<Tunnel.Model.Tunnel_SelType> mostList = new List<Tunnel.Model.Tunnel_SelType>();
    List<Tunnel.Model.Tunnel_menber> meb = new List<Tunnel.Model.Tunnel_menber>();

    public string key = string.Empty;

    public static string where = string.Empty;
    public int cuttentPage;
    private int pageSize = 30;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["STATE"] = "N";
            BindDownList();
            BindList();
        }
    }

    private void BindDownList()
    {
        string strSQL = "";
        string strOR = "";
        string strBum = tm.GetModel(ul.LoginID).m_bum.ToString().Trim();
        List<Tunnel.Model.Tunnel_SelType> newsType = st.GetModelList("ParentID=0 and IsDel=0");
        string sBum = "";
        for (int i = 0; i < newsType.Count; i++)
        {
            if (sBum == newsType[i].BumID)
                continue;
            else
            {
                string[] bums = newsType[i].BumID.Trim().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < bums.Length; j++)
                {
                    if (strBum == bums[j])
                    {
                        strOR += " BumID='" + newsType[i].BumID + "' OR";
                        break;
                    }
                }
                sBum = newsType[i].BumID;
            }
        }
        
        if (strOR != "")
            strOR = strOR.Substring(0, strOR.Length - 2);
        ddlType.Items.Clear();
        ddlType1.Items.Clear();
        List<Tunnel.Model.Tunnel_SelType> headList = new List<Tunnel.Model.Tunnel_SelType>();
        if ("系统管理员" == ul.JiaoSe(ul.LoginID))
        {
            strSQL = "ParentID=0 and IsDel=0 order by bumname desc";
        }
        else
        {
            if (strOR != "")
                strSQL = string.Format("ParentID=0 and IsDel=0 AND ({0}) ORDER BY bumname desc", strOR);
            else
                strSQL = "1=2";
        }
        //else if (tm.GetModel(ul.LoginID).m_bum == 131)
        //{
        //    strSQL = string.Format("ParentID=0 and (BumID='{0}' or BumID=0) order by bumname desc", tm.GetModel(ul.LoginID).m_bum);
        //}
        //else if (tm.GetModel(ul.LoginID).m_bum == 134)
        //{
        //    strSQL = string.Format("ParentID=0 and (BumID='{0}' or BumID=132 or BumID=0) order by bumname desc", tm.GetModel(ul.LoginID).m_bum);
        //}
        //else
        //{
        //    strSQL = string.Format("ParentID=0 and BumID='{0}' order by bumname desc", tm.GetModel(ul.LoginID).m_bum);
        //}
        headList = st.GetModelList(strSQL);
        for (int i = 0; i < headList.Count; i++)
        {
            ddlType.Items.Add(new ListItem("(" + headList[i].BumName + ") " + headList[i].TypeName, headList[i].TypeID.ToString()));
            ddlType1.Items.Add(new ListItem("(" + headList[i].BumName + ") " + headList[i].TypeName, headList[i].TypeID.ToString()));

            //List<Tunnel.Model.Tunnel_SelType> itemList = new List<Tunnel.Model.Tunnel_SelType>();
            //itemList = st.GetModelList(string.Format("ParentID={0} order by bumname desc", headList[i].TypeID));
            //for (int j = 0; j < itemList.Count; j++)
            //{
            //    DropDownList1.Items.Add(new ListItem("|-> " + itemList[j].TypeName, itemList[j].TypeID.ToString()));
            //    List<Tunnel.Model.Tunnel_SelType> list = new List<Tunnel.Model.Tunnel_SelType>();
            //    list = st.GetModelList(string.Format("ParentID={0} order by bumname desc", itemList[j].TypeID));
            //    for (int k = 0; k < list.Count; k++)
            //    {
            //        DropDownList1.Items.Add(new ListItem("|->-> " + list[k].TypeName, list[k].TypeID.ToString()));
            //    }
            //}
        }
        ddlType1.Items.Insert(0, new ListItem("全部","0"));
    }

    private void BindList()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_NewsType";
        pb.FldName = "TypeID";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        pb.DoCount = 1;
        key = "";
        where = "";
        if (ddlType1.SelectedIndex > 0)
            key = " ParentID=" + ddlType1.SelectedItem.Value.Trim();
        else
        {
            string pid="";
            for(int i=1;i<ddlType.Items.Count;i++)
            {
                pid += ddlType.Items[i].Value.Trim() + ",";
            }
            if (pid != "")
                key += string.Format(" ParentID in ({0})", pid.Substring(0,pid.Length-1));
            else
                key += "1=2";
        }
        if (txtTitle.Text.Trim() != "")
            key += " AND TypeName LIKE '%" + txtTitle.Text.Trim() + "%'";

        if ("系统管理员" == ul.JiaoSe(ul.LoginID))
        {
            key += " AND ParentID<>0 AND IsDel=0";
        }
        else
        {
            key += " AND ParentID<>0 AND IsDel=0 AND BumID='" + tm.GetModel(ul.LoginID).m_bum + "'";
        }
        where = key;
        //where += key + " AND ParentID<>0 AND BumID=0";
        pb.StrWhere = where;

        st.GetList(pb, ref count); //获取总条数
        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_SelType> modelList = new List<Tunnel.Model.Tunnel_SelType>();
        modelList = st.GetList(pb, ref count);//获取分页结果


        //数据绑定
        dgdType.DataSource = modelList;
        dgdType.DataBind();

        //数据分页
        MTCPager1.PageSize = pageSize;
        MTCPager1.RecordCount = count;
        MTCPager1.PageIndex = cuttentPage;
        if (count <= pb.PageSize)
            MTCPager1.Visible = false;
        else
            MTCPager1.Visible = true;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        BindList();
    }

    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        BindList();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtname.Text.Trim() == "")
        {
            Tunnel.Common.Message.back("请输入科室子类型");
            return;
        }

        if (ViewState["STATE"].ToString().Trim() == "N")
        {
            most.TypeName = txtname.Text.Trim();
            most.BumID = tm.GetModel(ul.LoginID).m_bum.ToString().Trim();
            most.BumName = st.GetModelList("TypeID=" + ddlType.SelectedItem.Value.Trim())[0].TypeName.Trim();
            most.Url = "N_Index/dszc.aspx";
            most.ParentID = int.Parse(ddlType.SelectedItem.Value.Trim());
            most.IsDel = 0;

            if (st.Add(most) > 0)
            {
                Tunnel.Common.Message.Show("保存成功！", "N_KeshiTypeManage.aspx");
            }
            else
            {
                Tunnel.Common.Message.back("保存失败");
                return;
            }
        }
        else
        {
            //Tunnel.Model.Tunnel_SelType mosts = st.GetModel(int.Parse(hidValue.Value.Trim()));
            most.TypeID = int.Parse(hidValue.Value.Trim());
            most.TypeName = txtname.Text.Trim();
            most.BumID = tm.GetModel(ul.LoginID).m_bum.ToString().Trim();
            most.BumName = st.GetModelList("TypeID=" + ddlType.SelectedItem.Value.Trim())[0].TypeName.Trim();
            most.Url = "N_Index/dszc.aspx";
            most.ParentID = int.Parse(ddlType.SelectedItem.Value.Trim());
            most.IsDel = 0;
            if (st.Update(most) > 0)
            {
                Tunnel.Common.Message.Show("保存成功！", "N_KeshiTypeManage.aspx");
            }
            else
            {
                Tunnel.Common.Message.back("保存失败");
                return;
            }
        }
    }
    protected void dgdType_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.SelectedItem || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.CommandName.Trim() == "Select")
            {
                hidValue.Value = e.Item.Cells[0].Text.Trim();
                ddlType.SelectedIndex = -1;
                ddlType.Items.FindByValue(e.Item.Cells[3].Text.Trim()).Selected = true;
                txtname.Text = e.Item.Cells[1].Text.Trim();
                ViewState["STATE"] = "U";
            }
            if (e.CommandName.Trim() == "Delete")
            {
                st.Delete(int.Parse(e.Item.Cells[0].Text.Trim()));
                Tunnel.Common.Message.Show("删除成功！", "N_KeshiTypeManage.aspx");
            }
        }
    }
    protected void btnCanel_Click(object sender, EventArgs e)
    {
        ddlType.SelectedIndex = -1;
        ddlType1.SelectedIndex = -1;
        txtname.Text = "";
        ViewState["STATE"] = "N";
    }
    public string GetTypeName(string typeID)
    {
        List < Tunnel.Model.Tunnel_SelType> list = st.GetModelList("TypeID=" + typeID);
        return "(" + list[0].BumName.Trim() + ") " + list[0].TypeName.Trim();
    }
}
