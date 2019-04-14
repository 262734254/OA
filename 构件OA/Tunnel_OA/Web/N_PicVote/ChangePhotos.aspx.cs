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
using System.Drawing;
using System.Collections.Generic;

public partial class n_picvote_changephotos : System.Web.UI.Page
{
    public string ImgURL = "";
    string filedName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Tunnel.BLL.Tunnel_PageMessage pmBLL = new Tunnel.BLL.Tunnel_PageMessage();
            List<Tunnel.Model.Tunnel_PageMessage> list = pmBLL.GetModelList(" 1=1  order by pic_ID desc");
            if (list.Count > 0)
            {
                //绑定上一次的页面标题
                txttitle.Text = list[0].pic_TitleName;
                //绑定上一次的页面主题
                txttopic.Text = list[0].pic_TopicName;
                //绑定上一次的顶部图片链接
                ImgURL = "../N_PicVote/Pic/" + list[0].pic_TopImgURL;
                //绑定上一次的底部颜色
                txtcolor.Text = list[0].pic_BgColor;
            }
        }

    }
    protected void btnok_click(object sender, EventArgs e)
    {

        int TitleLength = this.uptitilepic.PostedFile.ContentLength;
        if (TitleLength != 0)
        {
            //获得图片名称.
            FileInfo fi = new FileInfo(uptitilepic.FileName);
            if (fi.Extension.Equals(".jpg") || fi.Extension.Equals(".JPG") || fi.Extension.Equals(".jpge") || fi.Extension.Equals(".JPEG") || fi.Extension.Equals(".gif") || fi.Extension.Equals(".GIF") || fi.Extension.Equals(".PNG") || fi.Extension.Equals(".png"))
            {
                string type = Path.GetExtension(uptitilepic.FileName);
                filedName = DateTime.Now.ToFileTime().ToString() + type;
                string strpath = Server.MapPath("~/N_PicVote/Pic/");
                string temp = strpath + filedName;
                string _temp = strpath + "_" + filedName;
                this.uptitilepic.SaveAs(temp);
            }
            else
            {
                Tunnel.Common.Message.Show("只能上传图片类型的文件!");
            }
        }
        else
        {
            filedName = ImgURL;

        }

        Tunnel.Model.Tunnel_PageMessage pageMessageModel = new Tunnel.Model.Tunnel_PageMessage();
        pageMessageModel.pic_AspxName = "Vote_ShowAllPic.aspx";
        pageMessageModel.pic_TitleName = this.txttitle.Text.Trim().ToString();
        pageMessageModel.pic_TopicName = this.txttopic.Text.Trim().ToString();
        pageMessageModel.pic_TopImgURL = filedName;
        pageMessageModel.pic_BgColor = this.txtcolor.Text.Trim();
        Tunnel.BLL.Tunnel_PageMessage pageMessBLL = new Tunnel.BLL.Tunnel_PageMessage();
        pageMessBLL.Add(pageMessageModel);
        Tunnel.Common.Message.Show("上传成功!");

    }
}