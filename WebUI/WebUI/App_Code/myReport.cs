using System;
using System.ComponentModel;//注意添加引用
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

public static class Set
{
    public static int num = 0;
}


public class myReport : ReportClass
{

  

    public myReport()
    {
     
    }

    public override String ResourceName
    {
        get
        {

            string str = Set.num == 0 ? "CrystalReportCar.rpt" : "CrystalReport.rpt";

            return str;
        }
        set
        {
            // Do nothing
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section1
    {
        get
        {
            return this.ReportDefinition.Sections[0];
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section2
    {
        get
        {
            return this.ReportDefinition.Sections[1];
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section3
    {
        get
        {
            return this.ReportDefinition.Sections[2];
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section4
    {
        get
        {
            return this.ReportDefinition.Sections[3];
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section5
    {
        get
        {
            return this.ReportDefinition.Sections[4];
        }
    }
}

[System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
public class CachedmyReport : Component, ICachedReport
{
   
    public CachedmyReport()
    {
    }

    public virtual Boolean IsCacheable
    {
        get
        {
            return true;
        }
        set
        {
            // 
        }
    }

    public virtual Boolean ShareDBLogonInfo
    {
        get
        {
            return false;
        }
        set
        {
            // 
        }
    }

    public virtual TimeSpan CacheTimeOut
    {
        get
        {
            return CachedReportConstants.DEFAULT_TIMEOUT;
        }
        set
        {
            // 
        }
    }

    public virtual ReportDocument CreateReport()
    {
        myReport rpt = new myReport();
        rpt.Site = this.Site;
        return rpt;
    }

    public virtual String GetCustomizedCacheKey(RequestContext request)
    {
        String key = null;
        // // The following is the code used to generate the default
        // // cache key for caching report jobs in the ASP.NET Cache.
        // // Feel free to modify this code to suit your needs.
        // // Returning key == null causes the default cache key to
        // // be generated.
        // 
        // key = RequestContext.BuildCompleteCacheKey(
        //     request,
        //     null,       // sReportFilename
        //     this.GetType(),
        //     this.ShareDBLogonInfo );
        return key;
    }
}
