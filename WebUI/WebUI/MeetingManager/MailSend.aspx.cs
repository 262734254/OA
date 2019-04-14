using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using BLL.Power;
using BLL.Meeting;
using Model;
public partial class UserWork_MailSend : System.Web.UI.Page
{

    protected override void OnPreRender(EventArgs e)
    {


        base.OnPreRender(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    public string returnAll()
    {
        string str = "";
        for (int i = 0; i < txtRight.Items.Count; i++)
        {
            str+=txtRight.Items[i]+",";
        }
        return str;
    }

    //根据部门动态加载员工
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDepartment.SelectedItem.Text=="请选择")
        {
            txtLeft.Items.Clear();
            return;
        }
        else
        {
            txtLeft.Items.Clear();
            //根据部门ID查询所有员工
            IList<UserInfo> list = UserInfoManager.GetAllUsersByDepartmentId(Convert.ToInt32(ddlDepartment.SelectedValue));
            for (int i = 0; i < list.Count; i++)
            {
                UserInfo userInfo=list[i];
                txtLeft.Items.Add(new ListItem(userInfo.Name,userInfo.Name)) ;
            }
            txtLeft.DataBind();
        }
    }
    /// <summary>
    /// 将选中员工添加到列表中
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibRight_Click(object sender, ImageClickEventArgs e)
    {

        if (txtLeft.SelectedItem == null)
        {

            Response.Write("<script>alert('请选择要添加的一项数据.');</script>");
        }
        else
        {
            //添加员工，如果选项中存在，则不添加
            bool exist=false;
            foreach (ListItem item in txtRight.Items)
	        {
                if (item.Value==this.txtLeft.SelectedValue)
	            {
                    exist = true;
	            }
	        }
            if (exist==false)
            {
                txtRight.Items.Add(new ListItem(this.txtLeft.SelectedItem.Text, this.txtLeft.SelectedValue));
            }
            txtRight.DataBind();
        }

        }
       
    

    /// <summary>
    /// 将添加的员工移除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibLeft_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < txtRight.Items.Count; i++)
        {
            if (txtRight.Items[i].Selected==true)
            {
                txtRight.Items.Remove(txtRight.Items[i]);;
            }
        }
    }
    /// <summary>
    /// 添加所有项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgTo_Click(object sender, ImageClickEventArgs e)
    {
        //循环编历两个ListItem，判断选中项中是否存在有要添加的项，存在不重复添加，不则在添加
        //foreach (ListItem item in txtLeft.Items)
        //{
        //    bool flag = false;
        //    foreach (ListItem li in txtRight.Items)
        //    {
        //        if (item.Value==li.Value)
        //        {
        //            flag = true;
        //        }
        //        if (flag==false)
        //        {
        //            txtRight.Items.Add(new ListItem(li.Text,li.Value));
        //        }
        //    }
        //}
        //循环编历两个ListItem，判断选中项中是否存在有要添加的项，存在提示不能重复添加，不则在添加
        for (int i = 0; i < txtLeft.Items.Count; i++)
        {
            for (int j = 0; j < txtRight.Items.Count; j++)
            {
                if (txtRight.Items[j].Text.ToString()==txtLeft.Items[i].Text.ToString())
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(),"","<script>alert('该员工已添加!请不要重复添加')</script>");
                    return;
                }
            }
            txtRight.Items.Add(new ListItem(txtLeft.Items[i].Text.ToString(), txtLeft.Items[i].Value.ToString()));

        }


    }
    /// <summary>
    /// 移除所有选中项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgReturn_Click(object sender, ImageClickEventArgs e)
    {
        //循环遍历选中项中的员工，将所有选中项员工移除
        for (int i = 0; i < txtRight.Items.Count; i++)
        {
            txtRight.Items.Clear();
           // txtRight.Items.Remove(txtRight.Items[i]);
        }
    }


}
