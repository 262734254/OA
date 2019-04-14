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
        .style5
        {
            height: 32px;
        }
        .style6
        {
        }
        .style7
        {
            height: 32px;
            width: 134px;
        }
        .style19
        {
            width: 100%;
        }
        .style23
        {
            width: 81px;
        }
        .style24
        {
            height: 33px;
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
                    <asp:DropDownList ID="ddlYears" runat="server" CssClass="BigSelect" >
                        <asp:ListItem Value="">请选择</asp:ListItem>
                        <asp:ListItem>2010</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                         <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;年&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                    <asp:DropDownList ID="ddlMonths" runat="server" CssClass="BigSelect">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                    月&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="BigSelect">
                        <asp:ListItem Value="">全部目标</asp:ListItem>
                        <asp:ListItem Value="计划性任务">计划性任务</asp:ListItem>
                        <asp:ListItem>紧急性任务</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Button ID="btnSelect" CssClass="BigButton" runat="server" Text="查询" 
                        Width="73px" onclick="btnSelect_Click" />
                </td>
            </tr>
        </table>
        <table style="height: 248px; width: 731px;">
            <tr valign="top">
                <td class="style24">
                    <h4 style="height: 16px; width: 121px">阶段</h4> 
                </td>
                <td class="style24">
                    <h4>目标进展情况</h4>
                    <h4> 
                    <asp:Label ID="lblYear" runat="server"></asp:Label>
                    </h4>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;
                </td>
                <td class="style5"> 
&nbsp;<table width="600px">
                        <tr>
                            <td width="60px;">&nbsp;</td>
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
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style6" colspan="2">
                        <asp:DataList ID="dlistShow" runat="server" DataSourceID="objes" Height="351px" 
                            Width="732px" onitemdatabound="dlistShow_ItemDataBound">
                            <HeaderTemplate>
                                <table class="style19">
                                    <tr>
                                        <td class="style22">
                                            &nbsp;</td>
                                        <td>
                                            <table width="600px" >
                                                <tr>
                                                    <td width="60px;" style="color:Green">
                                                        一月</td>
                                                    <td style="color:Green">
                                                        二月</td>
                                                    <td style="color:Green">
                                                        三月</td>
                                                    <td style="color:Green">
                                                        四月</td>
                                                    <td style="color:Green">
                                                        五月</td>
                                                    <td style="color:Green">
                                                        六月</td>
                                                    <td style="color:Green">
                                                        七月</td>
                                                    <td style="color:Green">
                                                        八月</td>
                                                    <td style="color:Green">
                                                        九月</td>
                                                    <td style="color:Green">
                                                        十月</td>
                                                    <td style="color:Green">
                                                        十一月</td>
                                                    <td style="color:Green">
                                                        十二月</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table class="style19"  width="731px">
                                    <tr>
                                        <td class="style23">
                                            <asp:Label ID="StepNameLabel" runat="server" Text='<%# Eval("StepName") %>' />
                                            <asp:HiddenField ID="hidSId" runat="server" Value='<%# Eval("SId") %>' />
                                             <asp:HiddenField ID="hidStart" runat="server"  Value='<%# Eval("StartMonth") %>'  />
                                             <asp:HiddenField ID="hidEnd" runat="server"  Value='<%# Eval("EndMonth") %>' />
                                              <asp:HiddenField ID="hidRate" runat="server"  Value='<%# Eval("FilishRate") %>' />
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLeft" style="  background-color:Transparent ; border:0" runat="server" Height="0"></asp:TextBox>
                                            <asp:TextBox ID="txtShowColor" runat="server"    style="  background-color:Blue ; color:Red; border:0"></asp:TextBox>
                                            
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        </td>
            </tr>
            </table>
                        <br />
                        <asp:ObjectDataSource ID="objes" runat="server" 
                            SelectMethod="SelectStageAllProcByTaskId" TypeName="BLL.Target.TaskManager">
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="10" Name="taskId" 
                                    QueryStringField="taskId" Type="Int32" />
                                <asp:ControlParameter ControlID="ddlYears" Name="year" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddlMonths" DefaultValue="" Name="month" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddlType" Name="type" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
         </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
