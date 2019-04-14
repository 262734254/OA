<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskPart.aspx.cs" Inherits="TaskManager_TaskPart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>具体目标进展情况统计</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height:450px;
            background-color:#C6DAF3;
        }
        .style4
        {
            height: 23px;
        }
        .style5
        {
            height: 32px;
        }
        .style6
        {
            height: 23px;
            width: 104px;
        }
        .style7
        {
            height: 32px;
            width: 104px;
        }
        .style8
        {
            width: 104px;
        }
        .style9
        {
            width: 90px;
        }
        .style10
        {
            width: 33px;
        }
        .style11
        {
            width: 99px;
        }
        .style12
        {
            width: 251px;
        }
        .style13
        {
            width: 123px;
        }
        .style16
        {
        }
        .style18
        {
            width: 470px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="../css/6/style.css" />
    <link rel="Stylesheet" type="text/css" href="../css/public.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table class="style1">
            <tr>
                <td  align="center" class="title1">
      <h3>具体目标进展情况</h3>
     </td>
            </tr>
            <tr>
                <td align="center"  valign="top">
        <table style="width: 80%;">
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="BigSelect">
                        <asp:ListItem>2005</asp:ListItem>
                        <asp:ListItem>2006</asp:ListItem>
                        <asp:ListItem>2007</asp:ListItem>
                        <asp:ListItem>2008</asp:ListItem>
                        <asp:ListItem>2009</asp:ListItem>
                        <asp:ListItem>2010</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="BigSelect">
                        <asp:ListItem>一月</asp:ListItem>
                        <asp:ListItem>二月</asp:ListItem>
                        <asp:ListItem>三月</asp:ListItem>
                        <asp:ListItem>四月</asp:ListItem>
                        <asp:ListItem>五月</asp:ListItem>
                        <asp:ListItem>六月</asp:ListItem>
                        <asp:ListItem>七月</asp:ListItem>
                        <asp:ListItem>八月</asp:ListItem>
                        <asp:ListItem>九月</asp:ListItem>
                        <asp:ListItem>十月</asp:ListItem>
                        <asp:ListItem>十一月</asp:ListItem>
                        <asp:ListItem>十二月</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="BigSelect">
                        <asp:ListItem>全部目标</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Button ID="Button3" CssClass="BigButton" runat="server" Text="查询" Width="73px" />
                </td>
            </tr>
        </table>
        <table style="height: 248px; width: 731px;">
            <tr valign="top">
                <td class="style6">
                    <h4>阶段</h4> 
                </td>
                <td class="style4">
                    <h4>目标进展情况</h4>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;
                </td>
                <td class="style5"> 
                2007年
                    <table width="600px">
                        <tr>
                            <td width="60px;">一月</td>
                            <td>二月</td>
                            <td>三月</td>
                            <td>四月</td>
                            <td>五月</td>
                            <td>六月</td>
                            <td>七月</td>
                            <td>八月</td>
                            <td>九月</td>
                            <td>十月</td>
                            <td>十一月</td>
                            <td>十二月</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    第一阶段</td>
                <td class="style4">
                    <table width="600px">
                        <tr>
                            <td class="style9" style="background-color: Blue;">100%</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style8" >
                    第二阶段</td>
                <td>
                    <table width="600px">
                        <tr>
                            <td width="60px;">&nbsp;</td>
                            <td class="style10">&nbsp;</td>
                            <td class="style11" style="background-color: Blue;">100%</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    第三阶段</td>
                <td>
                    <table width="600px">
                        <tr>
                            <td width="60px;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style13">&nbsp;</td>
                            <td class="style12" style="background-color: Blue;">60%</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    第四阶段</td>
                <td>
                    <table width="600px">
                        <tr>
                            <td class="style18">&nbsp;</td>
                            <td class="style16" style="background-color: green;" >0%</td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
         </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
