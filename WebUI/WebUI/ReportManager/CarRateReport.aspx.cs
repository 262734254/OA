using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Data;
public partial class ReportManager_CarRateReport : System.Web.UI.Page
{
    myReport ReportDoc = new myReport();

    protected void Page_Load(object sender, EventArgs e)
    {
       ShowCrysView("2010",0);
    }

    private void ShowCrysView(string year,int status)
    {
        //改变水晶报表的值
        Set.num = 0;

        // 在此处放置用户代码以初始化页面
        string strProvider = "server=192.168.1.53;uid=sa;pwd=sa;database=OA_DB;MultipleActiveResultSets=true";

        SqlConnection MyConn = new SqlConnection(strProvider);
        MyConn.Open();

        SqlCommand cmd = new SqlCommand("usp_SelectAllCarCost", MyConn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] parms = new SqlParameter[]    
        {
           new SqlParameter("@year",year),
            new SqlParameter("@status",status)
        };
        cmd.Parameters.AddRange(parms);
        DataSetCar ds = new DataSetCar();
        SqlDataAdapter MyAdapter = new SqlDataAdapter(cmd);


        MyAdapter.Fill(ds, "CarCost");//注意fill （dataset，表名） 表名
       
        ReportDoc.SetDataSource(ds);
        crviewCarCost.ReportSourceID = null;
        crviewCarCost.ReportSource = ReportDoc;
        
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string year = ddlYear.SelectedValue;
        int status = Convert.ToInt32(ddlStatus.SelectedValue);
        ShowCrysView(year,status);
    }
}