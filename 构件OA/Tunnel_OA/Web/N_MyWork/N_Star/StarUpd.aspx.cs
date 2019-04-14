using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

public partial class SystemManage_Tunnel_MxUpd : System.Web.UI.Page
{
    public static string id = string.Empty;

    public static Tunnel.BLL.Tunnel_MingXing tmx = new Tunnel.BLL.Tunnel_MingXing();
    public static Tunnel.Model.Tunnel_MingXing tmxx = new Tunnel.Model.Tunnel_MingXing();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                id = Request["id"].ToString();
                PageBind();
            }
        }
    }

    public void PageBind()
    {
        string tmpUid = string.Empty;
        tmxx = tmx.GetModel(Convert.ToInt32(id));
        if (tmxx != null)
        {
            txtTitle.Text = tmxx.Title.ToString();
            tmpUid = tmxx.m_uid.ToString();
            Label2.Text = tmxx.m_year.ToString();
            Label3.Text = tmxx.m_moon.ToString();
            FreeTextBox1.Value = tmxx.m_content;
        }

        //Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        //Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
        //tmm = tm.GetModel(Convert.ToInt64(tmpUid));
        //if (tmm != null)
        //{
        //    Label1.Text = tmm.m_name;
        //}

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        #region 动态添加图片
        //if (FileUpload1.HasFile)
        //{
        //string strsql = "select * from Tunnel_MingXing where m_id=" + tmxx.m_id + "";
        //SqlDataReader reader = Tunnel.Data.DbHelperSQL.ExecuteReader(strsql);
        //if (reader.Read())
        //{
        //    if (!reader["m_img"].ToString().Trim().Equals(""))
        //    {
        //        File.Delete(Server.MapPath(reader["m_img"].ToString().Trim()));
        //    }
        //}
        //string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
        //ext = ext.ToLower();
        //if (ext == ".jpg" || ext == ".bmp" || ext == ".gif")
        //{
        //    string date = DateTime.Now.ToFileTime().ToString();
        //    if (!Directory.Exists(Server.MapPath("mx")))
        //    {
        //        Directory.CreateDirectory(Server.MapPath("mx"));
        //    }
        //    FileUpload1.SaveAs(Server.MapPath("mx/" + date + ".jpg"));
        //    tmxx.m_img = "mx/" + date + ".jpg";
        //  ;
        //}
        //reader.Close();
        //} 
        #endregion
        tmxx.m_content = FreeTextBox1.Value;
        tmxx.Title = txtTitle.Text;
        tmx.Update(tmxx);
        Tunnel.Common.Message.Show("更新成功！", "StarManage.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("StarManage.aspx");
    }
}
