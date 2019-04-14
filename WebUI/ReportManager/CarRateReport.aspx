<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarRateReport.aspx.cs" Inherits="ReportManager_CarRateReport" %>

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
                   <h3>车辆费用报表管理</h3></td>
            </tr>
            <tr>
                <td align="center">
    
        <table>
            <tr>
                <td style="height:50px" align="left">
                    车牌号：<asp:DropDownList ID="DropDownList2" runat="server" Height="16px" 
                        Width="99px">
                        <asp:ListItem>粤A/K7122</asp:ListItem>
                        <asp:ListItem>苏A/33733</asp:ListItem>
                    </asp:DropDownList>
                    车辆类型：<asp:DropDownList ID="DropDownList1" runat="server" class="inputs">
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:DropDownList>
                    出车日期：<asp:TextBox ID="TextBox1" runat="server" class="inputs" Width="105px">2010-05-12</asp:TextBox>
                    至<asp:TextBox ID="TextBox2" runat="server" class="inputs" Width="100px">2010-05-12</asp:TextBox>
                    <asp:Button ID="Button1" runat="server" class="BigButton" Text="查   询" />
                    <asp:Button ID="Button2" runat="server" class="BigButton" 
                        OnClientClick="confirm('您确认要打印吗！');" Text="打   印" />
                </td>
            </tr>
            <tr>
                <td>
                    <table style="text-align:center;width:100%; height:300px" cellpadding="0" cellspacing="0">
                        <tr class="TableHeader">
                            <td>
                                车牌号               <td>
                                月保费</td>
                            <td>
                                路桥费</td>
                            <td>
                                临时保管费</td>
                            <td>
                                加油费</td>
                            <td>
                                维修费</td>
                            <td>
                                洗车费</td>
                            <td>
                                购车税费</td>
                            <td>
                                税费</td>
                            <td>
                                保险费</td>
                            <td>
                                养路费</td>
                            <td>
                                年票费</td>
                            <td>
                                年审费</td>
                            <td>
                                上牌费</td>
                            <td>
                                其它杂费</td>
                            <td>
                                定损事故处理费</td>
                            <td>
                                合计</td>
                        </tr>
                        <tr class="TableContent">
                            <td>
                               皖A/k7122</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                192.64</td>
                            <td>
                                670.38</td>
                            <td>
                                530.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                1200.38&nbsp;</td>
                        </tr>
                        <tr class="TableContent">
                            <td>
                               皖A/69335</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                192.64</td>
                            <td>
                                670.38</td>
                            <td>
                                530.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                1200.38</td>
                        </tr>
                        <tr class="TableContent">
                            <td>
                               皖A/k7122</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                192.64</td>
                            <td>
                                670.38</td>
                            <td>
                                530.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                1200.38&nbsp;</td>
                        </tr>
                        <tr class="TableContent">
                            <td>
                               皖A/69335</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                192.64</td>
                            <td>
                                670.38</td>
                            <td>
                                530.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                1200.38</td>
                        </tr>
                        <tr class="TableContent">
                            <td>
                               皖A/k7122</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                192.64</td>
                            <td>
                                670.38</td>
                            <td>
                                530.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                1200.38&nbsp;</td>
                        </tr>
                        <tr class="TableContent">
                            <td>
                               皖A/69335</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                192.64</td>
                            <td>
                                670.38</td>
                            <td>
                                530.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                1200.38</td>
                        </tr>
                         <tr class="TableContent">
                            <td>
                               皖A/28578</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                192.64</td>
                            <td>
                                670.38</td>
                            <td>
                                530.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                1200.38</td>
                        </tr>
                         <tr class="TableContent">
                            <td>
                               皖A/53283</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                192.64</td>
                            <td>
                                670.38</td>
                            <td>
                                530.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                               0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                0.00</td>
                            <td>
                                1200.38</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
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
