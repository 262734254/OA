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

public partial class PicManage_ImgInfo : System.Web.UI.Page
{
    string id = "";
    Tunnel.BLL.Tunnel_Img ti = new Tunnel.BLL.Tunnel_Img();
    public Tunnel.Model.Tunnel_Img tii = new Tunnel.Model.Tunnel_Img();
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            id = Request.QueryString["id"].ToString();
        if (!string.IsNullOrEmpty(Request.QueryString["type"]))
            type = Convert.ToInt32(Request.QueryString["type"]);
        if (!IsPostBack)
        {
            if (!id.Equals("") && !id.Equals("0"))
                tii = ti.GetModel(Convert.ToInt32(id));
        }
    }
    public string ShowName()
    {
        return tii.i_name;
    }
    public string ShowUri()
    {
        return tii.i_uri;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (type == 1)
            Response.Redirect("N_PictureManage.aspx");
        else
            Response.Redirect("../../N_Search/N_PictureManage.aspx");
    }

    private void TurnImg(int num)
    {
        int i_id = 0;
        if (!id.Equals("") && !id.Equals("0"))
        {
            if (num == 0)
            {
                string strsql = "select top 1 i_id from tunnel_img where i_id>" + id + "order by i_id";
                SqlDataReader read = Tunnel.Data.DbHelperSQL.ExecuteReader(strsql);
                if (read.Read())
                {
                    i_id = Convert.ToInt32(read["i_id"]);
                }
                read.Close();
                if (i_id != 0)
                    Response.Redirect("N_PictureView.aspx?id=" + i_id);
                else
                    Response.Redirect("N_PictureView.aspx?id=" + id);
            }
            else
            {
                string strsql = "select top 1 i_id from tunnel_img where i_id<" + id + "order by i_id desc";
                SqlDataReader read = Tunnel.Data.DbHelperSQL.ExecuteReader(strsql);
                if (read.Read())
                {
                    i_id = Convert.ToInt32(read["i_id"]);
                }
                read.Close();
                if (i_id != 0)
                    Response.Redirect("N_PictureView.aspx?id=" + i_id);
                else
                    Response.Redirect("N_PictureView.aspx?id=" + id);
            }
        }
    }



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        TurnImg(0);
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TurnImg(1);
    }
}
