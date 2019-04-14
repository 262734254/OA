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

public partial class GongWen_upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            this.SaveImages();
    }

    private void SaveImages()
    {
        string uploadpath = Server.MapPath("");
        System.Web.HttpFileCollection uploadFiles = Request.Files;
        System.Web.HttpPostedFile theFile;
        for (int i = 0; i < uploadFiles.Count; i++)
        {
            theFile = uploadFiles[i];
            if (uploadFiles.GetKey(i).ToUpper() == "EDITFILE")
            {
                string filename = theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
                theFile.SaveAs(uploadpath + "/" + filename);
            }
        }
    }
}
