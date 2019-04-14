using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class SystemManage_Tunnel_MxAdd : System.Web.UI.Page
{
    List<Tunnel.Model.Tunnel_MingXing> tmxxList = new List<Tunnel.Model.Tunnel_MingXing>();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (FileUpload1.HasFile)
        //{
          
        //    string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
        //    ext = ext.ToLower();
        //    if (ext == ".jpg" || ext == ".bmp" || ext == ".gif")
        //    {
                if (FreeTextBox1.Value.Length > 0)
                {
                    string tempdel = string.Empty;
                    Tunnel.BLL.Tunnel_MingXing tmx = new Tunnel.BLL.Tunnel_MingXing();
                    Tunnel.Model.Tunnel_MingXing tmxx = new Tunnel.Model.Tunnel_MingXing();
                    //if (tmx.GetModelList("m_year=" + text1.Value.Split('-')[0] + " and m_moon=" + text1.Value.Split('-')[1] + "").Count > 0)
                    //{
                    //    tempdel = tmx.GetModelList("m_year=" + text1.Value.Split('-')[0] + " and m_moon=" + text1.Value.Split('-')[1] + "")[0].m_id.ToString();
                    //}

                    tmxx.Title = txtUser.Text.Trim();
                    tmxx.m_year = Convert.ToInt32(text1.Value.Split('-')[0]);
                    tmxx.m_moon = Convert.ToInt32(text1.Value.Split('-')[1]);
                    tmxx.m_content = FreeTextBox1.Value;
                    tmxx.m_uid = ul.LoginID;
                    string date = DateTime.Now.ToFileTime().ToString();
                    //if (!Directory.Exists(Server.MapPath("mx")))
                    //{
                    //    Directory.CreateDirectory(Server.MapPath("mx"));
                    //}
                    //FileUpload1.SaveAs(Server.MapPath("mx/" + date + ".jpg"));
                    tmxx.m_img = "";   //"mx/" + date + ".jpg";
                    try
                    {
                        if (tmx.Add(tmxx) > 0)
                        {
                            Tunnel.Common.Message.Show("添加成功!", "StarManage.aspx");
                        }
                    }
                    catch (Exception)
                    {

                    }
                    //if (tempdel.Length > 0)
                    //{
                    //    Del(Convert.ToInt32(tempdel));
                    //}

                }
                //else
                //{
                //    Tunnel.Common.Message.Show("请输入内容!", "StarAdd.aspx");
                //}
            //}
            //else
            //{
            //    Tunnel.Common.Message.Show("请上传JPG、BMP、GIF图片!", "StarAdd.aspx");
            //}
        //}





    }

    public void Del(int d)
    {
        try
        {
            Tunnel.BLL.Tunnel_MingXing tmx = new Tunnel.BLL.Tunnel_MingXing();
            if (File.Exists(Server.MapPath(tmx.GetModel(d).m_img)))
            {
                File.Delete(Server.MapPath(tmx.GetModel(d).m_img));
            }
            tmx.Delete(d);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
