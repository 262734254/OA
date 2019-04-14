using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class CarManager_MyPage : System.Web.UI.UserControl
{
    public delegate void myDele(int pageIndex);
    public event myDele onPageIndexChanging;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkFirst_Click(object sender, EventArgs e)
    {
        this.PageIndex = 0;

        if (onPageIndexChanging != null)
            onPageIndexChanging(this.PageIndex);

        SetButtonEnable();
    }
    protected void lnkPrev_Click(object sender, EventArgs e)
    {
        this.PageIndex--;

        if (onPageIndexChanging != null)
            onPageIndexChanging(this.PageIndex);

        SetButtonEnable();
    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {
        this.PageIndex++;

        if (onPageIndexChanging != null)
            onPageIndexChanging(this.PageIndex);

        SetButtonEnable();
    }
    protected void lnkLast_Click(object sender, EventArgs e)
    {
        this.PageIndex = this.PageCount - 1;

        if (onPageIndexChanging != null)
            onPageIndexChanging(this.PageIndex);

        SetButtonEnable();
    }
      public int PageIndex
    {
        get
        {
            if (ViewState["PageIndex"] == null)
            {
                ViewState["PageIndex"] = 0;
            }

            return (int)ViewState["PageIndex"];
        }
        set
        {
            ViewState["PageIndex"] = value;
        }
    }

    public int PageCount
    {
        get
        {
            if (ViewState["PageCount"] == null)
            {
                ViewState["PageCount"] = 0;
            }

            return (int)ViewState["PageCount"];
        }
        set
        {
            ViewState["PageCount"] = value;
        }
    }
    public void SetButtonEnable()
    {
        lnkFirst.Enabled = true;
        lnkLast.Enabled = true;
        lnkNext.Enabled = true;
        lnkPrev.Enabled = true;
        if (this.PageIndex == 0)
        {
            lnkPrev.Enabled = false;
            lnkFirst.Enabled = false;
        }

        if (this.PageIndex == this.PageCount - 1)
        {
            lnkLast.Enabled = false;
            lnkNext.Enabled = false;
        }
        if (this.PageCount == 1)
        {
            lnkPrev.Enabled = false;
            lnkFirst.Enabled = false;
            lnkLast.Enabled = false;
            lnkNext.Enabled = false;
        }
        lblCurrentPage.Text = (this.PageIndex + 1) + "";
        lblTotalPages.Text = this.PageCount.ToString();
    }

}
