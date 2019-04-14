<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stockreport.aspx.cs" Inherits="ReportManager_Stockreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>采购单报表页面</title>
 <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
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
                    <h3>资源采购报表管理</h3></td>
            </tr>
            <tr>
                <td align="center">
    
        <table>
            <tr>
                <td style="height:50px;">
                    采购日期：<asp:TextBox ID="TextBox1" class="inputs" runat="server"></asp:TextBox>
                    至<asp:TextBox ID="TextBox2" class="inputs" runat="server"></asp:TextBox>
                    &nbsp;资源类型：<asp:DropDownList ID="DropDownList1" class="inputs" runat="server">
                        <asp:ListItem>易耗品</asp:ListItem>
                        <asp:ListItem>贵重品</asp:ListItem>
                    </asp:DropDownList>
&nbsp;<asp:Button ID="Button1" runat="server" class="BigButton" Text="查   询" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" class="BigButton" OnClientClick="confirm('您确认要打印吗！');" Text="打   印" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width:750px; height:300px; text-align:center;" cellpadding="0" cellspacing="0">
                        <tr class="TableHeader">
                            <td>
                                序号</td>
                            <td>
                                资源名称</td>
                            <td>
                                资源规格</td>
                            <td>
                                资源数量</td>
                            <td>
                                单价</td>
                            <td>
                                采购日期</td>
                            <td>
                                备注</td>
                            
                        </tr>
                        <tr class="TableContent">
                            <td>
                                1</td>
                            <td>
                                电脑</td>
                            <td>
                                手提</td>
                            <td>
                                1</td>
                            <td>
                                4000.00</td>
                            <td>
                                2010-04-20</td>
                            
                            <td>
                                不能超资</td>
                            
                        </tr>
                          <tr class="TableContent">
                            <td>
                                1</td>
                            <td>
                                电脑</td>
                            <td>
                                手提</td>
                            <td>
                                1</td>
                            <td>
                                4000.00</td>
                            <td>
                                2010-04-20</td>
                            
                            <td>
                                不能超资</td>
                            
                        </tr>
                          <tr class="TableContent">
                            <td>
                                1</td>
                            <td>
                                电脑</td>
                            <td>
                                手提</td>
                            <td>
                                1</td>
                            <td>
                                4000.00</td>
                            <td>
                                2010-04-20</td>
                            
                            <td>
                                不能超资</td>
                            
                        </tr>
                          <tr class="TableContent">
                            <td>
                                1</td>
                            <td>
                                电脑</td>
                            <td>
                                手提</td>
                            <td>
                                1</td>
                            <td>
                                4000.00</td>
                            <td>
                                2010-04-20</td>
                            
                            <td>
                                不能超资</td>
                            
                        </tr>
                          <tr class="TableContent">
                            <td>
                                1</td>
                            <td>
                                电脑</td>
                            <td>
                                手提</td>
                            <td>
                                1</td>
                            <td>
                                4000.00</td>
                            <td>
                                2010-04-20</td>
                            
                            <td>
                                不能超资</td>
                            
                        </tr>
                          <tr class="TableContent">
                            <td>
                                1</td>
                            <td>
                                电脑</td>
                            <td>
                                手提</td>
                            <td>
                                1</td>
                            <td>
                                4000.00</td>
                            <td>
                                2010-04-20</td>
                            
                            <td>
                                不能超资</td>
                            
                        </tr>
                       <tr class="TableContent">
                            <td>
                                1</td>
                            <td>
                                电脑</td>
                            <td>
                                手提</td>
                            <td>
                                2</td>
                            <td>
                                4000.00</td>
                            <td>
                                2010-04-20</td>
                            
                            <td>
                                不能超资</td>
                            
                        </tr>
                       <tr class="TableContent">
                            <td>
                                1</td>
                            <td>
                                电脑</td>
                            <td>
                                手提</td>
                            <td>
                                2</td>
                            <td>
                                4000.00</td>
                            <td>
                                2010-04-20</td>
                            
                            <td>
                                不能超资</td>
                            
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    共有<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    记录&nbsp;&nbsp; |&nbsp;&nbsp; 共有<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    页&nbsp; |&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkfirst" runat="server">首页</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnkprev" runat="server">上一页</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnknext" runat="server">下一页</asp:LinkButton>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="lnklast" runat="server">尾页</asp:LinkButton>
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