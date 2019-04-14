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
using System.Data.SqlClient;
//using MyOkFlow.BLL;
//using MyOkFlow.Model;
using System.Collections.Generic;
public partial class UserWork_MailSend : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        //当页面加载时，将所有部门都加载
    //        IList<DepartInfo> list = DepartInfoManage.GetDepartInfoAll();
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            DepartInfo depart = list[i];
    //            ListUser.Items.Add(depart.DepartName);
    //        }
    //    }
    //}
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ListUser.Items.Clear();
    //    int Dutyid =Convert.ToInt32(DropDepart.SelectedItem.Value);
    //    if (Dutyid ==100)//当选择所有部门时，将所有部门信息显示出来
    //    {
    //       IList<DepartInfo> de = DepartInfoManage.GetDepartInfoAll();
    //        for (int i = 0; i < de.Count; i++)
    //        {
    //            DepartInfo depart = de[i];
    //            ListUser.Items.Add(depart.DepartName);
    //        }
    //    }
    //    else
    //    {
    //        List<UserInfo> list = UserInfoManage.GetUserInfoByDepartId(Dutyid);
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            UserInfo user = list[i];
    //            if (Dutyid.Equals(user.DepartId))
    //            {
    //                ListUser.Items.Add(user.UserName);
    //            }
    //        }
    //    }
    //}
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (ListUser.SelectedItem == null)
    //    {
    //        Response.Write("<script>alert('请选择要添加的一项数据.');</script>");
    //    }
    //    else
    //    {
    //        bool exist = false;
    //        foreach (ListItem li in this.ListBox2.Items)
    //        {
    //            if (li.Value == this.ListUser.SelectedItem.Value)
    //            {
    //                exist = true;
    //            }
    //        }
    //        if (exist == false)
    //        {
    //            this.ListBox2.Items.Add(new ListItem(this.ListUser.SelectedItem.Text, this.ListUser.SelectedItem.Value));
    //        }
    //    }        
    //}
    //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    //{
    //    for (int i = 0; i < ListBox2.Items.Count; i++)
    //    {
    //        if (this.ListBox2.Items[i].Selected == true)
    //        {
    //            ListBox2.Items.Remove(this.ListBox2.Items[i]);

    //        }
    //        // ListBox2.Items[i].Text
    //    }
    //}
    //protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    //{

    //    foreach (ListItem li in ListUser.Items)
    //    {
    //        bool exist = false;
    //        foreach (ListItem lised in ListBox2.Items)
    //            if (lised.Value == li.Value)
    //                exist = true;
    //        if (exist == false)
    //            ListBox2.Items.Add(new ListItem(li.Text, li.Value));
    //    }


    //    //for (int i = 0; i < ListBox1.Items.Count; i++)
    //    //{
    //    //    for (int j = 0; j< ListBox2.Items.Count; j++)
    //    //    {
    //    //        if (ListBox2.Items[j].Text.ToString() == ListBox1.SelectedItem.Text.ToString())
    //    //        {
    //    //            Response.Write("<script>alert('不能添家相同员工!')</script>");
    //    //            return;
    //    //        }
    //    //    }


    //    //    ListBox2.Items.Add(ListBox1.Items[i].Text.ToString());
    //    //}
    //}
    //protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    //{

    //    for (int i = 0; i < ListBox2.Items.Count; )
    //    {
    //        ListBox2.Items.Remove(ListBox2.Items[i]);
    //    }
    //}
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    Response.Write("<script>window.close();</script>");
    //}
    //public string pass()
    //{
    //    string txt = "";
    //    for (int j = 0; j < this.ListBox2.Items.Count; j++)
    //    {
    //        txt += this.ListBox2.Items[j];
    //        txt += ";";

    //    }
    //    return txt;

    //}
}
