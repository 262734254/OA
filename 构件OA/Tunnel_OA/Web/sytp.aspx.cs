using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class sytp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tunnel.BLL.Tunnel_PageMessage vi = new Tunnel.BLL.Tunnel_PageMessage();
        Tunnel.Model.Tunnel_PageMessage vii = new Tunnel.Model.Tunnel_PageMessage();
        List<Tunnel.Model.Tunnel_PageMessage> viList = vi.GetModelList("1=1");
        if (new Tunnel.BLL.Vote_Info().GetModelList("1=1").Count > 0)
        {
            Bitmap img = new Bitmap(Server.MapPath("~/image/sytp.jpg"));
            Graphics g = Graphics.FromImage(img);
            //g.DrawString(viList[0].pic_TopicName, new Font("微软雅黑", 10f,FontStyle.Bold), Brushes.Black, new PointF(0, 0));
            this.DrawToImage(g, img);//输出图像
            g.Dispose();
            img.Dispose();
        }
    }
    /// <summary>
    /// 输出图片
    /// </summary>
    /// <param name="g">画板</param>
    /// <param name="img">图片对象</param>
    private void DrawToImage(Graphics g, Bitmap img)
    {
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        Response.ClearContent();
        Response.ContentType = "image/Jpeg";
        Response.BinaryWrite(ms.ToArray());
    }
}
