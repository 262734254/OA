<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintTask.aspx.cs" Inherits="Default2" %>



<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>目标任务查看</title>
     <link href="../css/public.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-size: 12px;
        }
        .style2
        {
            width: 101px;
        }
        
p.p0{
margin:0pt;
margin-bottom:0.0001pt;
margin-bottom:0pt;
margin-top:0pt;
text-align:justify;
font-size:10.5000pt; font-family:'Times New Roman'; }
        .style8
        {
            width: 100px;
        }
        .style10
        {
            width: 169px;
        }
        .style12
        {
            width: 117px;
        }
        .style14
        {
        }
        .style15
        {
            width: 105px;
            height: 9px;
        }
        .style16
        {
            width: 169px;
            height: 9px;
        }
        .style17
        {
            width: 117px;
            height: 9px;
        }
        .style18
        {
            width: 100px;
            height: 9px;
        }
        .style19
        {
            width: 101px;
            height: 9px;
        }
        .style20
        {
            height: 9px;
        }
    </style>
</head>
<body style="text-align: left;background-color:#C6DAF3;">
    <form id="Form1" runat="server" method="post" name="form1">
    <table class="title1" width="750px;">
        <tr>
            <td>
                <h3>
                    任务报表信息打印</h3>
            </td>
            <td style="text-align: right"></td>
        </tr>
    </table>
    <fieldset style="text-align: center; padding-left: 25px;
        width: 90%">
        <br />
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp; 从<asp:TextBox ID="txFDateFrom" runat="server" 
                                        Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                        onClick="showcalendar(event, this);"></asp:TextBox>
                                    &nbsp;<asp:CompareValidator ID="CompareValidator1" 
                runat="server" ControlToValidate="txFDateFrom" ErrorMessage="日期格式不对" 
                Operator="DataTypeCheck" SetFocusOnError="True" Type="Date"></asp:CompareValidator>
            到<asp:TextBox ID="txFDateEnd" runat="server" 
                                        Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                        onClick="showcalendar(event, this);"></asp:TextBox>
                                    &nbsp;<asp:CompareValidator ID="CompareValidator2" 
                runat="server" ControlToValidate="txFDateEnd" ErrorMessage="日期格式不对" 
                Operator="DataTypeCheck" SetFocusOnError="True" Type="Date"></asp:CompareValidator>
&nbsp;<asp:CompareValidator ID="CompareValidator3" runat="server" 
                ControlToCompare="txFDateFrom" ControlToValidate="txFDateEnd" 
                ErrorMessage="开始日期要大于结束日期" Operator="GreaterThan" SetFocusOnError="True" 
                Type="Date"></asp:CompareValidator>
            <asp:Button ID="btnSelectValue" runat="server" CssClass="BigButton" Text="查询" onclick="btnSelectValue_Click" 
               />
        </div>
    </fieldset>
    <table align="center" cellpadding="0" cellspacing="0" 
        style="width: 676px; height: 216px">
        <tr align="center" class="TableHeader">
            <td class="style15">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td class="style17">
                &nbsp;</td>
            <td class="style18">
                &nbsp;</td>
            <td class="style19">
                &nbsp;</td>
            <td class="style20">
                &nbsp;</td>
        </tr>
        <tr align="center" class="TableContent">
            <td class="style14" colspan="6">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true" ReportSourceID="CrystalReportSource1" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="TaskManager\CrystalReport.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
