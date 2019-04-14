<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalenderDetails.aspx.cs" Inherits="Calendar_MattersCalender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>日程详情</title>
<script language="javascript" src="../js/calendar.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../css/6/style.css" />
    <link rel="Stylesheet" type="text/css" href="../js/calendar.js" />
<script language="javascript" type="text/javascript">
function RepeatIs(){
	document.getElementById("repeat").style.display="block";
}
function RepeatNo(){
	document.getElementById("repeat").style.display="none";
}
</script>
 <style type="text/css">
         .style4
        {
            width: 100%; background-color:#C6DAF3;
            height: 511px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center" class="style4">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
    <tr>
    <td colspan="2" class="title1">
        <h3>日程详情</h3>
    </td>
    </tr>
    <tr>
    <td align="center">
        <table border="0" cellpadding="2" cellspacing="1" style="font: menu"
            width="80%">
            <tr>
                <td align="right" style="width: 93px; height: 14px">
        时间：</td>
                <td align="left" style="height: 14px">
                    <asp:TextBox ID="txFDate" runat="server" ReadOnly="True" Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" onClick="showcalendar(event, this);">2012-12-12</asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="width: 93px; height: 24px">
                    提醒时间：</td>
                <td align="left" style="height: 24px">
                    <asp:TextBox ID="txtRemind" runat="server" ReadOnly="True" Style="border-right: #99ccff 1px solid;
                       border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                        onClick="showcalendar(event, this);">2012-12-11</asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="width: 93px; height: 2px">
                    是否重复：</td>
                <td align="left" style="height: 2px">
                    <asp:RadioButtonList ID="rdoRepeat" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 93px; height: 2px">
                    类型：</td>
                <td align="left" style="height: 2px">
                    <asp:DropDownList ID="dropType" runat="server" Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" Enabled="False">
                        <asp:ListItem>工作</asp:ListItem>
                        <asp:ListItem>私人</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 93px">
        概要：</td>
                <td align="left">
                    <input id="txName" runat="server" class="TxCss" name="txName" style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; width: 450px;
                        border-bottom: #99ccff 1px solid; height: 18px" type="text" 
                        readonly="readOnly" value="你好" />
                    <span id="RequiredFieldValidator1" style="display: none; color: red"></span>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="width: 93px">
        详细：</td>
                <td align="left">
                    <textarea id="txDes" runat="server" class="TxCss" cols="20" name="txDes" rows="2"
                        style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                        width: 450px; border-bottom: #99ccff 1px solid; height: 100px" 
                        readonly="readonly">海潮</textarea></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 25px">
                    &nbsp; &nbsp;&nbsp;&nbsp;
                                <input id="btnExit" type="button" class="BigButton" value="返　回" onclick="history.go(-1);" /></td>
            </tr>
        </table>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>