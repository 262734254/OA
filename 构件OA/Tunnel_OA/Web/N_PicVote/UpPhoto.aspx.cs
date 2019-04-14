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

public partial class toupiao_UpPhoto : System.Web.UI.Page
{
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Tunnel.Model.Tunnel_menber menber = ul.GetUserBean(ul.LoginID);
            this.txtAuthor.Text = menber.m_name;           

        }
    }
    //把图片存入数据库
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        int FileLength = upPhoto.PostedFile.ContentLength;

        if (FileLength == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "", "alert('请选择上传的图片!')", true);
        }
        else
        {
            //获得图片名称.
            FileInfo fi = new FileInfo(upPhoto.FileName);
            if (fi.Extension.Equals(".jpg") || fi.Extension.Equals(".JPG") || fi.Extension.Equals(".jpge") || fi.Extension.Equals(".JPEG") || fi.Extension.Equals(".gif") || fi.Extension.Equals(".GIF") || fi.Extension.Equals(".PNG") || fi.Extension.Equals(".png"))
            {
                string type = Path.GetExtension(upPhoto.FileName);
                string filedName = DateTime.Now.ToFileTime().ToString() + type;
                string strpath = Server.MapPath("~/N_PicVote/Pic/");
                string temp = strpath + filedName;
                string _temp = strpath + "_" + filedName;
                string atemp = strpath + "a" + filedName;
                this.upPhoto.SaveAs(temp);
                MakeThumbnail(temp, _temp, 132, 88, "HW");
                MakeThumbnail(temp, atemp, 523, 250, "WH");

                //实例化一个图片实体类信息
                Tunnel.Model.Vote_Info vote_info = new Tunnel.Model.Vote_Info();
                vote_info.v_title = txtPicTitle.Text;
                vote_info.v_Img = filedName;
                vote_info.v_count =0;
                vote_info.v_author=txtAuthor.Text;
                vote_info.v_remark = txtRemark.Text;

                //添加图片实体类
                Tunnel.BLL.Vote_Info vote_InfoBll = new Tunnel.BLL.Vote_Info();
                vote_InfoBll.Add(vote_info);
                Tunnel.Common.Message.Show("图片添加成功");
       
            }
            else
            {
                Tunnel.Common.Message.Show("只能上传图片");
            }
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
            case "WH":
                 if(towidth/toheight>1)
                     toheight = originalImage.Height * width / originalImage.Width;
                else
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
