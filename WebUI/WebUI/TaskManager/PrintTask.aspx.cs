using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using Common;


public partial class Default2 : System.Web.UI.Page
{


    myReport ReportDoc = new myReport();

    protected void Page_Load(object sender, System.EventArgs e)
    {

        ShowCrysView("","");
    }

    private void ShowCrysView(string startTime, string endTime)
    {
        Set.num = 1;
        // 在此处放置用户代码以初始化页面
        string strProvider = CommHelper.GetConnectionString;

        SqlConnection MyConn = new SqlConnection(strProvider);
        MyConn.Open();
        string proName = "Usp_TaskPrint";
        SqlParameter[] pars = new SqlParameter[]
        {
           new SqlParameter("@startdate",startTime),
           new SqlParameter("@finsidate",endTime)
        
        };
        SqlCommand cmd = new SqlCommand(proName, MyConn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddRange(pars);
        SqlDataAdapter MyAdapter = new SqlDataAdapter(cmd);
        TaskDataSet1 ds = new TaskDataSet1();//强类型的数据集
        MyAdapter.Fill(ds, "TaskPrint");//注意fill （dataset，表名） 表名

      
        ReportDoc.SetDataSource(ds);
        CrystalReportViewer1.ReportSourceID = null;
        CrystalReportViewer1.ReportSource = ReportDoc;

    }


    protected void btnSelectValue_Click(object sender, System.EventArgs e)
    {
        ShowCrysView(txFDateFrom.Text.Trim(), txFDateEnd.Text.Trim());
    }
}