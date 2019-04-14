<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Driverreport.aspx.cs" Inherits="ReportManager_Driverreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>驾驶员出车记录报表</title>
      <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
  
  <%-- <script src ="../js/report.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .style4
        {
             width: 100%; background-color:#C6DAF3;
            height: 450px;
        }
         .style1
        {
            width: 750px;
            height:300px;
           
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style4">
            <tr>
                <td align="center" class="title1">
                   <h3>驾驶员出车管理</h3></td>
            </tr>
            <tr>
                <td align="center">
    
        <table>
            <tr>
                <td style="height:50px">
                    驾驶员名称：<asp:DropDownList ID="DropDownList1" class="inputs" runat="server">
                        <asp:ListItem>张三</asp:ListItem>
                        <asp:ListItem>李四</asp:ListItem>
                        <asp:ListItem>王五</asp:ListItem>
                        <asp:ListItem>赵六</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp; 出车日期：<asp:TextBox ID="TextBox1" class="inputs" runat="server"></asp:TextBox>
                    至<asp:TextBox ID="TextBox2" class="inputs" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" class="BigButton" runat="server" Text="查   询" />
                </td>
                <td>
                    <asp:Button ID="excel" runat="server" OnClientClick="confirm('您确定要删除吗！');" class="BigButton" Text="打   印" />
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table id="content" style="width:100%; height:300px;" cellpadding="0" cellspacing="0">
                        <tr align="center" class="TableHeader">
                            <td>
                                驾驶员名称</td>
                            <td>
                                实际公里数</td>
                            <td>
                                出车用时(小时数)</td>
                            <td>
                                用车次数</td>
                            <td>
                                节假日出车数</td>
                            <td>
                                午餐补贴</td>
                            <td>
                                其它补贴</td>
                            <td>
                                国家规定节假日加班时间</td>
                            <td class="style2">
                                周六日加班时间</td>
                            <td>
                                平时加班时间</td>
                        </tr>
                        <tr align="center" class="TableContent">
                            <td>
                                李程</td>
                            <td >
                                30</td>
                            <td class="">
                                5</td>
                            <td >
                                1</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                        </tr>
                        <tr align="center" class="TableContent">
                          <td>
                                李程</td>
                            <td>
                                30</td>
                            <td>
                                5</td>
                            <td>
                                1</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td >
                                0</td>
                            <td>
                                0</td>
                        </tr>
                         <tr align="center" class="TableContent">
                            <td>
                                李程</td>
                            <td >
                                30</td>
                            <td class="">
                                5</td>
                            <td >
                                1</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                        </tr>
                        <tr align="center" class="TableContent">
                          <td>
                                李程</td>
                            <td>
                                30</td>
                            <td>
                                5</td>
                            <td>
                                1</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td >
                                0</td>
                            <td>
                                0</td>
                        </tr>
                         <tr align="center" class="TableContent">
                            <td>
                                李程</td>
                            <td >
                                30</td>
                            <td class="">
                                5</td>
                            <td >
                                1</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                            <td >
                                0</td>
                        </tr>
                        <tr align="center" class="TableContent">
                          <td>
                                李程</td>
                            <td>
                                30</td>
                            <td>
                                5</td>
                            <td>
                                1</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td >
                                0</td>
                            <td>
                                0</td>
                        </tr>
                        <tr align="center" class="TableContent">
                           <td>
                                李程</td>
                            <td>
                                30</td>
                            <td>
                                5</td>
                            <td>
                                1</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td >
                                0</td>
                            <td>
                                0</td>
                        </tr>
                        <tr align="center" class="TableContent">
                           <td>
                                李程</td>
                            <td>
                                30</td>
                            <td>
                                5</td>
                            <td>
                                1</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td>
                                0</td>
                            <td >
                                0</td>
                            <td>
                                0</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
            <td colspan="2">共有Label记录   |   共有Label页  |   首页首页首页  上一页上一页上一页  下一页下一页下一页   尾页尾页尾页</td>
            </tr>
        </table>
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
