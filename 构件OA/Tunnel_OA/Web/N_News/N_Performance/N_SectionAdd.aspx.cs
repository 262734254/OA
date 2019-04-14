using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using Tunnel.Model;
using Tunnel.BLL;
public partial class N_News_N_Performance_N_SectionAdd : System.Web.UI.Page
{
    #region 申明变量
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.BLL.Tunnel_Performance btb = new Tunnel.BLL.Tunnel_Performance();
    Tunnel.Model.Tunnel_Performance mtb = new Tunnel.Model.Tunnel_Performance(); 
    #endregion

    #region 加载事件
    protected void Page_Load(object sender, EventArgs e)
    {

    } 
    #endregion

    #region 添加事件
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
      
        if (tb_Title.Text == "")
        {
            Tunnel.Common.Message.back("请输入标题");
            return;
        }
        else if ("".Equals(HiddenField1.Value.Trim()))
        {
            Tunnel.Common.Message.back("请选择附件");
            return;
        }
        try
        {
            System.Web.HttpFileCollection uploadFiles = Request.Files;
            System.Web.HttpPostedFile theFile;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                theFile = uploadFiles[i];
                if (Convert.ToDouble(theFile.ContentLength) / 1024 / 1024 > 10)
                {
                    Tunnel.Common.Message.back("附件大小不能大于10MB");
                    return;
                }
                else
                    continue;
            }

            //将当前步骤存入数据库表:Tunnel_Performance
            if (sava() >= 1)
            {
                Tunnel.Common.Message.Show("提交成功!", "N_ManagementSection.aspx");
                
            }
            else
            {
                Tunnel.Common.Message.back("提交失败!");
            }



        }
        catch
        {
            Tunnel.Common.Message.back("流程错误,请与管理员联系!");
        }
    }
    
    #endregion

    #region 添加方法
    private int sava()
    {
        ArrayList list = new ArrayList();
        
        if (!"".Equals(this.SaveFiles()))
        {
            if (null != Request.Form["hfile"] && !"".Equals(Request.Form["hfile"]))
            {
                mtb.File = Request.Form["hfile"] + "," + this.SaveFiles();//批量附件上传
            }
            else
            {
                mtb.File = this.SaveFiles();//批量附件上传
            }
        }
        else
        {
            if (null != Request.Form["hfile"] && !"".Equals(Request.Form["hfile"]))
            {
                mtb.File = Request.Form["hfile"];
            }
            else
            {
                mtb.File = "";
            }
        }
        mtb.Type = 0;                                          //0是科室考核1是分厂考核
        mtb.Title = tb_Title.Text.Trim();                     //标题
        mtb.Name = "";                          //文件名
        mtb.CreateDate = DateTime.Now;                         //创建时间
        mtb.CreateUser = ul.LoginID;                  //发布用户的ID

        return Tunnel.BLL.Tunnel_Performance.Add(mtb);
    } 
    #endregion

    #region 批量附件上传的方法
    /// <summary>
    /// 批量附件上传
    /// </summary>
    /// <returns></returns>
    private string SaveFiles()
    {
        string filelist = "";
        string uploadpath = Server.MapPath("../../upload/Performance");
        System.Web.HttpFileCollection uploadFiles = Request.Files;
        System.Web.HttpPostedFile theFile;
        for (int i = 0; i < uploadFiles.Count; i++)
        {
            theFile = uploadFiles[i];
            string filename = theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
            string dataname = "upload/Performance/" + filename;
            if (filename != "")
            {
                theFile.SaveAs(uploadpath + "/" + filename);
                filelist += dataname + ",";
            }
        }
        if (filelist.Length > 0)
        {
            filelist = filelist.Substring(0, filelist.Length - 1);//去掉最后的的','
        }
        return filelist;


    } 
    #endregion

}





