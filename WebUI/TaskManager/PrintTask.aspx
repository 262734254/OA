<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintTask.aspx.cs" Inherits="Default2" %>



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
            width: 105px;
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
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPrint" runat="server" CssClass="BigButton" Text="打印" />
        </div>
    </fieldset>
    <table align="center" cellpadding="0" cellspacing="0" 
        style="width: 676px; height: 216px">
        <tr align="center" class="TableHeader">
            <td class="style15">
                &nbsp;序号</td>
            <td class="style16">
                <p class="p0" 
                    style="margin-bottom:7.8000pt; margin-top:7.8000pt; text-align:center; line-height:90%; ">
                    <span>重点工作名称</span></p>
            </td>
            <td class="style17">
                主要工作任务</td>
            <td class="style18">
                牵头领导</td>
            <td class="style19">
                当前工作节点</td>
            <td class="style20">
                已完成比例</td>
        </tr>
        <tr align="center" class="TableContent">
            <td class="style14">
                数据绑定
            </td>
            <td class="style10">
                数据绑定
            </td>
            <td class="style12">
                数据绑定
            </td>
            <td class="style8">
                数据绑定
            </td>
            <td class="style2">
                数据绑定</td>
            <td>
                10%</td>
        </tr>
        <tr align="center" class="TableContent">
            <td class="style14">
                数据绑定
            </td>
            <td class="style10">
                数据绑定
            </td>
            <td class="style12">
                数据绑定
            </td>
            <td class="style8">
                数据绑定
            </td>
            <td class="style2">
                数据绑定</td>
            <td>
                99%</td>
        </tr>
        <tr align="center" class="TableContent">
            <td class="style14">
                数据绑定
            </td>
            <td class="style10">
                数据绑定
            </td>
            <td class="style12">
                数据绑定
            </td>
            <td class="style8">
                数据绑定
            </td>
            <td class="style2">
                数据绑定</td>
            <td>
                22%</td>
        </tr>
        <tr align="center" class="TableContent">
            <td class="style14">
                数据绑定
            </td>
            <td class="style10">
                数据绑定
            </td>
            <td class="style12">
                数据绑定
            </td>
            <td class="style8">
                数据绑定
            </td>
            <td class="style2">
                数据绑定</td>
            <td>
                90%</td>
        </tr>
    </table>
    </form>
</body>
</html>
