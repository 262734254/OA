<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarRateReport.aspx.cs" Inherits="ReportManager_CarRateReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车辆费用报表</title>
      <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
     <%--<script src ="../js/report.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .style1
        {
             width: 100%; background-color:#C6DAF3;
            height: 450px;
        }
          </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                   <h3>公司车辆费用汇总表</h3></td>
            </tr>
            <tr>
                <td align="center" class="title1">
                    汇总时间：<asp:DropDownList ID="ddlYear" runat="server">
                        <asp:ListItem>2010</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2020</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="0">上半年</asp:ListItem>
                        <asp:ListItem Value="1">下半年</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnSave" runat="server"  Text="查询" onclick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td align="center">
    
 
            
    <CR:CrystalReportViewer ID="crviewCarCost" runat="server" AutoDataBind="True" 
        Height="50px" ReportSourceID="crsCarCost" Width="350px" />
            <CR:CrystalReportSource ID="crsCarCost" runat="server">
                <report filename="ReportManager\CrystalReportCar.rpt">
                </report>
            </CR:CrystalReportSource>
 
    
                </td>
            </tr>
        </table>
    
    </div>
 
    
    </form>
</body>
</html>
