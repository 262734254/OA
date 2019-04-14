using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SystemManage_KaoHe_Tunnel_SpuDFList : System.Web.UI.Page
{
    public string nianyue = string.Empty;
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        IfShow();
        if (!IsPostBack)
        {
            for (int i = 2009; i < 2019; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    if (j > 9)
                        DropDownList1.Items.Add(new ListItem(i.ToString() + j.ToString(), i.ToString() + j.ToString()));
                    else
                        DropDownList1.Items.Add(new ListItem(i.ToString() + "0" + j.ToString(), i.ToString() + "0" + j.ToString()));
                }
            }
            DateTime dt = DateTime.Now.AddMonths(-1);
            DropDownList1.Items.FindByValue(dt.ToString("yyyyMM")).Selected = true;
            nianyue = DropDownList1.SelectedValue;
            ListBind();
        }
    }

    public void ListBind()
    {
        nianyue = DropDownList1.SelectedValue;

        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
        List<Tunnel.Model.Tunnel_menber> tmList = new List<Tunnel.Model.Tunnel_menber>();

        Tunnel.BLL.Tunnel_work tw = new Tunnel.BLL.Tunnel_work();
        Tunnel.Model.Tunnel_work tww = new Tunnel.Model.Tunnel_work();
        List<Tunnel.Model.Tunnel_work> twList = new List<Tunnel.Model.Tunnel_work>();

        Tunnel.BLL.Tunnel_grade tg = new Tunnel.BLL.Tunnel_grade();
        Tunnel.Model.Tunnel_grade tgg = new Tunnel.Model.Tunnel_grade();
        List<Tunnel.Model.Tunnel_grade> tgList = new List<Tunnel.Model.Tunnel_grade>();

        Tunnel.BLL.Tunnel_items ti = new Tunnel.BLL.Tunnel_items();
        Tunnel.Model.Tunnel_items tii = new Tunnel.Model.Tunnel_items();
        List<Tunnel.Model.Tunnel_items> tiList = new List<Tunnel.Model.Tunnel_items>();

        Tunnel.BLL.Tunnel_check tc = new Tunnel.BLL.Tunnel_check();
        Tunnel.Model.Tunnel_check tcc = new Tunnel.Model.Tunnel_check();
        List<Tunnel.Model.Tunnel_check> tcList = new List<Tunnel.Model.Tunnel_check>();

        List<Tunnel.Model.Tunnel_ReadCheckList> trList = new List<Tunnel.Model.Tunnel_ReadCheckList>();

        tcList = tc.GetModelList("c_date='" + nianyue + "'");

        foreach (Tunnel.Model.Tunnel_check itemCheck in tcList)
        {
            Tunnel.Model.Tunnel_ReadCheckList tr = new Tunnel.Model.Tunnel_ReadCheckList();
            List<Tunnel.Model.Tunnel_check> clist = new List<Tunnel.Model.Tunnel_check>();

            tr.ItemsID = Convert.ToInt32(itemCheck.c_itemsId);
            tr.ItemsName = ti.GetModel(Convert.ToInt32(itemCheck.c_itemsId)).i_name;
            tr.UserId = Convert.ToInt32(itemCheck.c_userId);
            tr.UserName = tm.GetModel(Convert.ToInt64(itemCheck.c_userId.ToString())).m_name;
            tgList = tg.GetModelList("g_checkid=" + itemCheck.c_id + "");
            tr.AqscCent = 0;
            tr.CbkzCent = 0;
            tr.ClglCent = 0;
            tr.DzbgzCent = 0;
            tr.GbgzCent = 0;
            tr.GczlCent = 0;
            tr.SbglCent = 0;
            tr.ScjhCent = 0;
            tr.WmsgCent = 0;
            tr.XcgzCent = 0;
            tr.XnzhCent = 0;
            tr.XxgzCent = 0;
            tr.ZhzlCent = 0;
            if (tgList.Count > 0)
            {
                foreach (Tunnel.Model.Tunnel_grade item in tgList)
                {
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "成本控制")
                    {
                        tr.CbkzCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "虚拟账户")
                    {
                        tr.XnzhCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "生产计划")
                    {
                        tr.ScjhCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "文明施工")
                    {
                        tr.WmsgCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "安全生产")
                    {
                        tr.AqscCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "工程质量")
                    {
                        tr.GczlCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "设备管理")
                    {
                        tr.SbglCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "材料管理")
                    {
                        tr.ClglCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "综合治理")
                    {
                        tr.ZhzlCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "贯标工作")
                    {
                        tr.GbgzCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "宣传工作")
                    {
                        tr.XcgzCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "党支部工作")
                    {
                        tr.DzbgzCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                    if (tw.GetModel(Convert.ToInt32(item.g_workId)).w_workName == "信息工作")
                    {
                        tr.XxgzCent = Convert.ToSingle(item.g_cent.ToString());
                    }
                }
            }

            tr.AllCent = tr.AqscCent +
            tr.CbkzCent +
            tr.ClglCent +
            tr.DzbgzCent +
            tr.GbgzCent +
            tr.GczlCent +
            tr.SbglCent +
            tr.ScjhCent +
            tr.WmsgCent +
            tr.XcgzCent +
            tr.XnzhCent +
            tr.XxgzCent +
            tr.ZhzlCent;
            trList.Add(tr);
        }
        GridView1.DataSource = trList;
        GridView1.DataBind();

    }
    public void IfShow()
    {
        if (!Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核管理", "统计报表", false))
        {
            xinzengkaohe.Disabled = true;
            xinzengkaohe.HRef = "";
            guanligongcheng.Disabled = true;
            guanligongcheng.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核打分", "统计报表", false))
        {
            kaohedafen.Disabled = true;
            kaohedafen.HRef = "";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        nianyue = DropDownList1.SelectedValue;
        ListBind();
    }
}
