<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MingXing.aspx.cs" Inherits="MingXing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 155px;
        }
        .style2
        {
        	height: 47px;
        }
        .style3
        {
            height: 47px;
        }
        .f
        {
            font-family: 微软雅黑;
            font-size: 12px;
        }
        .style4
        {
            height: 229px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <table background="../image/card11.gif"  border="0" cellpadding="0" cellspacing="0"  style="width: 548px; height: 501px" class="f">
        <tr>
            <td colspan="2" height="47" style="padding-left: 100px">
                <font color="red">
                    <%=year %></font><font color="black">年</font><font color="red"><%=moon %></font><font
                        color="black">月</font>
            </td>
            
        </tr>
        <tr>
            <td class="style1" height="41">
                <img style="margin-left: 26px; margin-top: 27px" width="110px" height="118px" src="../systemmanage/<%=img %>" />
            </td>
            <td class="style2" align="left">
                <table width=340px  border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td class="style2">
                            发布人：<%=name %>                 </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            标 题：<%=title%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr height="55px">
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="top" style="padding-left: 20px" class="style4">
            <asp:Panel runat="server" Width="99%" ID="panel1" ScrollBars="Vertical">
            <asp:Label runat="server" ID="lblcontent"  Width="96%" 
                    Style="word-break:break-all;word-wrap:break-word" 
                    Height="214px" ></asp:Label>
                </asp:Panel>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>                
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
