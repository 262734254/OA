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
using System.IO;
using ICSharpCode.SharpZipLib.Zip;


public partial class SystemManage_Tunnel_SQLCopy : System.Web.UI.Page
{
    ZipOutputStream zos;
    string strBaseDir = AppDomain.CurrentDomain.BaseDirectory + "bak\\";
    string strBaseDirTmp = AppDomain.CurrentDomain.BaseDirectory + "bak\\bak\\";
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Button5.Attributes.Add("onclick", "return confirm('确定删除吗?')");
        CreatDir(strBaseDirTmp);
        if (!IsPostBack)
        {
            ListBoxBind();
            ClearTemp();
        }

    }

    public void CreatDir(string Dir)
    {
        Directory.CreateDirectory(Dir);
    }

    public void ClearTemp()
    {
        try
        {
            DirectoryInfo di = new DirectoryInfo(strBaseDirTmp);
            di.Delete(true);
        }
        catch (Exception)
        {

        }
        finally
        {
            Directory.CreateDirectory(strBaseDirTmp);
        }

    }
    public void ListBoxBind()
    {
        ListBox1.Items.Clear();

        DirectoryInfo di = new DirectoryInfo(strBaseDir);

        FileInfo[] fi = di.GetFiles("*.bak");
        foreach (FileInfo item in fi)
        {
            ListBox1.Items.Add(item.Name);
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            string fileName = strBaseDir + string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now) + ".bak";
            string SqlStr2 = "backup database SD_OANew_test to disk='" + fileName + "'";
            SqlCommand com = new SqlCommand(SqlStr2, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
            ListBoxBind();
        }
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        string tmpName = string.Empty;
        
        foreach (ListItem item in ListBox2.Items)
        {
            tmpName += item.Text + "|";
        }
        if (tmpName.Length > 0)
        {
            tmpName = tmpName.Substring(0, tmpName.Length - 1);
        }
        string[] temp = tmpName.Split('|');
        foreach (string item in temp)
        {
            try
            {
                File.Copy(strBaseDir + item, strBaseDirTmp + item);
            }
            catch (Exception)
            {
            }
        }
        try
        {
            if (tmpName.Length > 0)
            {
                dlZipDir(strBaseDirTmp);
            }
            else
            {
                Tunnel.Common.Message.Show("还没有文件！");
            }

        }
        catch (Exception e1)
        {
            Response.Write(e1.Message);
        }

    }
    protected void dlZipDir(string strFileName)
    {
        MemoryStream ms = null;
        Response.ContentType = "application/octet-stream";
        strFileName = strFileName.Replace('+', ' ');
        Response.AddHeader("Content-Disposition", "attachment; filename=SQLBenFen.zip");
        ms = new MemoryStream();
        zos = new ZipOutputStream(ms);
        addZipEntry(strFileName);
        zos.Finish();
        zos.Close();
        Response.Clear();
        Response.BinaryWrite(ms.ToArray());
        Response.End();
    }
    protected void addZipEntry(string PathStr)
    {
        DirectoryInfo di = new DirectoryInfo(PathStr);
        foreach (DirectoryInfo item in di.GetDirectories())
        {
            addZipEntry(item.FullName);
        }
        foreach (FileInfo item in di.GetFiles())
        {
            FileStream fs = File.OpenRead(item.FullName);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            string strEntryName = item.FullName.Replace(strBaseDir, "");
            ZipEntry entry = new ZipEntry(strEntryName);
            zos.PutNextEntry(entry);
            zos.Write(buffer, 0, buffer.Length);
            fs.Close();
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        ListItemCollection lc = ListBox1.Items;
        foreach (ListItem item in lc)
        {
            if (item.Selected == true)
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/bak/" + item.Text);
            }
        }
        ListBoxBind();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        ListItemCollection lc = ListBox1.Items;
        foreach (ListItem item in lc)
        {
            if (item.Selected == true)
            {
                if (!ListBox2.Items.Contains(item))
                {
                    ListBox2.Items.Add(item.Text);
                }
            }
        }
        ListBoxBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string tmp = string.Empty;
        foreach (ListItem item in ListBox2.Items)
        {
            if (item.Selected == true)
            {
                tmp += item.Text + "|";
            }
        }

        if (tmp.Length > 0)
        {
            tmp = tmp.Substring(0, tmp.Length - 1);
        }
        try
        {
            string[] temp = tmp.Split('|');
            foreach (string item in temp)
            {
                ListBox2.Items.Remove(item);
            }
        }
        catch (Exception)
        {
        }

        ListBoxBind();
    }
}
