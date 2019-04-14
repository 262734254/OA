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
using System.Drawing;
using System.IO;

public partial class PicManage_ImgAdd : System.Web.UI.Page
{
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            ListBindYear();
        }
    }
    /// <summary>
    /// 绑定年份下拉列表(2005-2015)
    /// </summary>
    public void ListBindYear()
    {
        ddlYear.Items.Clear();
        for (int i = -5; i <= -1; i++)
        {
            ddlYear.Items.Add(new ListItem(DateTime.Now.AddYears(i).Year.ToString(), DateTime.Now.AddYears(i).Year.ToString()));
        }
        ddlYear.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
        for (int i = 1; i <= 5; i++)
        {
            ddlYear.Items.Add(new ListItem(DateTime.Now.AddYears(i).Year.ToString(), DateTime.Now.AddYears(i).Year.ToString()));

        }
        ddlYear.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fileContentType = FileUpload1.PostedFile.ContentType;
            if (fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/pjpeg")
            {
                string name = txtname.Text.Trim() + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'), FileUpload1.FileName.Length - FileUpload1.FileName.LastIndexOf('.'));
                string temp = Server.MapPath("image") + "\\" + txtname.Text.Trim() + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'), FileUpload1.FileName.Length - FileUpload1.FileName.LastIndexOf('.'));
                string _temp = Server.MapPath("image") + "\\_" + txtname.Text.Trim() + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'), FileUpload1.FileName.Length - FileUpload1.FileName.LastIndexOf('.'));

                Tunnel.BLL.Tunnel_Img ti = new Tunnel.BLL.Tunnel_Img();
                Tunnel.Model.Tunnel_Img tii = new Tunnel.Model.Tunnel_Img();

                if (ti.GetModelList("i_name='" + txtname.Text.Trim() + "'").Count == 0)
                {
                    tii.i_date = DateTime.Now;
                    tii.i_name = txtname.Text.Trim();
                    tii.i_uri = name;
                    tii.i_user = ul.LoginID;
                    tii.i_type = ddlType.SelectedValue;
                    tii.i_year = ddlYear.SelectedValue;
                    ti.Add(tii);
                    if (File.Exists(temp))
                    {
                        File.Delete(temp);
                    }
                    if (File.Exists(_temp))
                    {
                        File.Delete(_temp);
                    }
                    FileUpload1.SaveAs(temp);
                    MakeThumbnail(temp, _temp, 133, 100, "Cut");
                    Tunnel.Common.Message.Show("添加成功！");
                    string strsql = "";
                    strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + ul.LoginID + ",'" + DateTime.Now + "','信息发布>>图片管理>>新增图片。标题：" + tii.i_name + "','" + Tunnel.Common.Common.GetIp() + "',1)";
                    Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
                }
                else
                {
                    Tunnel.Common.Message.Show("此图片已经存在！");
                }

            }
            else
            {
                Tunnel.Common.Message.Show("图片格式不支持。支持的类型有：jpg，gif，bmp");
            }
        }
        else
        {
            Tunnel.Common.Message.Show("请选择图片！");
        }
    }
    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param>    
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板

        Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充

        g.Clear(Color.White);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图

            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
}
