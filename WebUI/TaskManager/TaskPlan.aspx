<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskPlan.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>目标进展情况统计</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height:450px;
            background-color:#C6DAF3;
        }
        .style11
        {
            height: 20px;
            width: 709px;
        }
        .style12
        {
            width: 51px;
        }
        .style13
        {
            width: 586px;
        }
        .style14
        {
            height: 17px;
            width: 42px;
        }
        .style17
        {
            height: 17px;
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
      <h3>任务目标计划<table style="width: 80%;">
            <tr>
                <td>
                    &nbsp;<asp:DropDownList ID="ddlYear" runat="server" CssClass="BigSelect" 
                       >
                        <asp:ListItem Value="">请选择</asp:ListItem>
                        <asp:ListItem>2010</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                    </asp:DropDownList>
                    年&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="BigSelect">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                        <asp:ListItem Value="1">一月</asp:ListItem>
                        <asp:ListItem Value="2">二月</asp:ListItem>
                        <asp:ListItem Value="3">三月</asp:ListItem>
                        <asp:ListItem Value="4">四月</asp:ListItem>
                        <asp:ListItem Value="5">五月</asp:ListItem>
                        <asp:ListItem Value="6">六月</asp:ListItem>
                        <asp:ListItem Value="7">七月</asp:ListItem>
                        <asp:ListItem Value="8">八月</asp:ListItem>
                        <asp:ListItem Value="9">九月</asp:ListItem>
                        <asp:ListItem Value="10">十月</asp:ListItem>
                        <asp:ListItem Value="11">十一月</asp:ListItem>
                        <asp:ListItem Value="12">十二月</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="BigSelect">
                        <asp:ListItem Value="">全部目标</asp:ListItem>
                        <asp:ListItem>计划性任务</asp:ListItem>
                        <asp:ListItem>紧急性任务</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Button ID="btnSubmit" CssClass="BigButton" runat="server" Text="查询" 
                        Width="73px" onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
                        </h3>
     </td>
            </tr>
            <tr>
                <td align="center"  valign="top">
        <table style=" width: 683px; height: 21px;">
            <tr valign="top">
                <td class="style14">
                    <h4>任务</h4> 
                </td>
                <td class="style17">
                    <h4 style="width: 97px; height: 6px; margin-bottom: 19px">进度</h4>
                </td>
            </tr>
                        
        </table>
                        <br />
                        <asp:DataList ID="ddlistShow" runat="server" DataSourceID="objessss" 
                            style="margin-left: 0px; margin-bottom: 91px" 
                            onitemdatabound="ddlistShow_ItemDataBound" 
                            onitemcommand="ddlistShow_ItemCommand"  >
                            <HeaderTemplate>
                                <table style="width: 631px; margin-left: 26px">
                                    <tr>
                                        <td width="60px;" style=" color:Green">
                                            10%</td>
                                        <td style=" color:Green">
                                            20%</td>
                                        <td style=" color:Green">
                                            30%</td>
                                        <td style=" color:Green">
                                            40%</td>
                                        <td style=" color:Green">
                                            50%</td>
                                        <td style=" color:Green">
                                            60%</td>
                                        <td style=" color:Green">
                                            70%</td>
                                        <td style=" color:Green">
                                            80%</td>
                                        <td style=" color:Green">
                                            90%</td>
                                        <td style=" color:Green">
                                            100%</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <br />
                                <br />
                                <table class="style11">
                                    <tr>
                                        <td class="style12">
                                            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                                        </td>
                                        <td class="style13" align="left"  >
                                        
                                            <asp:TextBox ID="txtRateNow" style="border:0 ; text-align:right; color:Red "     BackColor="blue" runat="server"  ></asp:TextBox>
                                            &nbsp;</td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton1" runat="server" 
                                                CommandArgument='<%# Eval("Id") %>' CommandName="Detail">详细</asp:LinkButton>
                                            <asp:HiddenField ID="hidFilishTime" runat="server"  Value='<%# Eval("FinishRate") %>'  />
                                            <asp:HiddenField ID="hidId" runat="server" Value='<%# Eval("id") %>' />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:ObjectDataSource ID="objessss" runat="server" 
                            SelectMethod="GetAllTaskFinishRate" TypeName="BLL.Target.TaskManager">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlType" Name="year" 
                                    PropertyName="SelectedValue" Type="String" DefaultValue="" />
                                <asp:ControlParameter ControlID="ddlMonth" Name="month" 
                                    PropertyName="SelectedValue" Type="String" DefaultValue="" />
                                <asp:ControlParameter ControlID="ddlYear" Name="type" 
                                    PropertyName="SelectedValue" Type="String" DefaultValue="" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
         </td>
            </tr>
           
            <tr>
                <td>
                    <br />
                </td>
            </tr>
           
        </table>
        
    </div>
    </form>
</body>
</html>
