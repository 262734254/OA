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

public partial class _Controls_Pager : System.Web.UI.UserControl
{
    public delegate void MyDele(int pageIndex); //定义一个委托类型
    public event MyDele onLoadPageIndexChaning; //定义一个委托事件

    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnFirst.Enabled = false;
        this.btnPrev.Enabled = false;
    }
    /// <summary>
    /// 当前页索引
    /// </summary>
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
            SetEnabled();//赋值 及控制按钮
        }
    }
    /// <summary>
    /// 总页数
    /// </summary>
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
            SetEnabled();//赋值 及控制按钮
        }
    }


    /// <summary>
    /// 总记录数
    /// </summary>
    public int DataCount
    {
        get
        {
            if (ViewState["DataCount"] == null)
            {
                ViewState["DataCount"] = 0;
            }
            return (int)ViewState["DataCount"];
        }
        set
        {
            ViewState["DataCount"] = value;
            SetEnabled();//赋值 及控制按钮
        }
    }
    /// <summary>
    /// 设置按钮状态
    /// </summary>
    public void SetEnabled()
    {
        btnFirst.Enabled = true;
        btnPrev.Enabled = true;
        btnNext.Enabled = true;
        btnEnd.Enabled = true;
        if (this.PageIndex == 0 )
        {
            btnFirst.Enabled = false;
            btnPrev.Enabled = false;
        }
        if (this.PageIndex == this.PageCount - 1)
        {
            btnNext.Enabled = false;
            btnEnd.Enabled = false;
        }
        this.lblCurrentPage.Text = (this.PageIndex + 1) + "";
        this.lblPageCount.Text = this.PageCount.ToString();
        this.lblDataCount.Text = this.DataCount.ToString();
    }
    /// <summary>
    /// 第一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFirst_Click(object sender, EventArgs e)
    {
        this.PageIndex = 0;
       
        //如果事件不为空..表明实现了这个事件..
        if (onLoadPageIndexChaning != null)
        {
            onLoadPageIndexChaning(this.PageIndex);
        }
      
    }
    /// <summary>
    /// 上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        this.PageIndex --;
       
        //如果事件不为空..表明实现了这个事件..
        if (onLoadPageIndexChaning != null)
        {
            onLoadPageIndexChaning(this.PageIndex);
        }
      
    }
    /// <summary>
    /// 下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        this.PageIndex ++;
       
        //如果事件不为空..表明实现了这个事件..
        if (onLoadPageIndexChaning != null)
        {
            onLoadPageIndexChaning(this.PageIndex);
        }
        
    }
    /// <summary>
    /// 末页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEnd_Click(object sender, EventArgs e)
    {
        this.PageIndex =this.PageCount-1;
       
        //如果事件不为空..表明实现了这个事件..
        if (onLoadPageIndexChaning != null)
        {
            onLoadPageIndexChaning(this.PageIndex);
        }
        
    }
}
