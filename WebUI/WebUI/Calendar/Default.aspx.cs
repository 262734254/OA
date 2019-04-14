using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL.WorkHelper;
using DAL;
using Common;


public partial class _Default : System.Web.UI.Page
{

    static string str = "";
    static int id;
    static string strYes = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                if (Request.QueryString["Id"] != null && Request.QueryString["title"] != null && Request.QueryString["Is"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["Id"]);
                    str = Request.QueryString["title"];
                    strYes = Request.QueryString["Is"];
                    if (strYes.Equals("是"))
                    {
                        int num = CalendarManager.UpdateTime(id);
                        //if (num > 0)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('设置成功');", true);
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('设置失败！');", true);
                        //}

                    }


                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('我明天不提醒你了！');", true);


            }
            this.TextMe.Value = str;
        }
    }
}
