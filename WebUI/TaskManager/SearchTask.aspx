<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTask.aspx.cs" Inherits="Default2" %>


<%@ Register Src="../UserControls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
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
        .style4
        {
            height: 3px;
        }
    </style>
</head>
<body style="text-align: left; background-color: #C6DAF3;">
    <form id="Form1" runat="server" method="post" name="form1">
    <table class="title1" width="750px;">
        <tr>
            <td>
                <h3>
                    任务目标信息</h3>
            </td>
            <td style="text-align: right">
            </td>
        </tr>
    </table>
    <fieldset style="text-align: center; padding-left: 25px; width: 90%">
        <br />
        <div>
            &nbsp;&nbsp; 任务时间<asp:DropDownList ID="ddlYear" runat="server" CssClass="BigSelect">
                <asp:ListItem Value=" ">请选择</asp:ListItem>
                <asp:ListItem>2010</asp:ListItem>
                <asp:ListItem>2011</asp:ListItem>
                <asp:ListItem>2012</asp:ListItem>
                <asp:ListItem>2013</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
            </asp:DropDownList>
            年<asp:DropDownList ID="ddlMonth" runat="server" CssClass="BigSelect">
                <asp:ListItem Value=" ">请选择</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
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
            月&nbsp;&nbsp;&nbsp;&nbsp; 完成状态：<asp:DropDownList ID="ddlStatus" runat="server" CssClass="BigSelect">
                <asp:ListItem Value=" ">请选择</asp:ListItem>
                <asp:ListItem Value="已完成">已完成</asp:ListItem>
                <asp:ListItem Value="执行中">执行中</asp:ListItem>
                <asp:ListItem Value="存在困难">存在困难</asp:ListItem>
                <asp:ListItem Value="未执行">未执行</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp; 任务领域：<asp:DropDownList ID="ddlFile" runat="server" CssClass="BigSelect"
                Width="71px">
                <asp:ListItem Value=" ">请选择</asp:ListItem>
                <asp:ListItem>市场拓展</asp:ListItem>
                <asp:ListItem>资源开采</asp:ListItem>
                <asp:ListItem>能源开发</asp:ListItem>
                <asp:ListItem>地产环保</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSelect" runat="server" CssClass="BigButton" Text="查询" OnClick="btnSelect_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TaskManager/PrintTask.aspx">打印报表</asp:HyperLink>
        </div>
    </fieldset>
    <table align="center" cellpadding="0" cellspacing="0" style="width: 661px; height: 226px">
        <tr align="center">
            <td valign="top" style="padding-top: 50px">
                <asp:GridView ID="GVShowTask" runat="server" AutoGenerateColumns="False" DataSourceID="objesdd"
                    Width="641px" DataKeyNames="Id" OnRowCommand="GVShowTask_RowCommand" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="TableContent"
                    OnRowDataBound="gv_RowDataBound">
                    <RowStyle CssClass="TableContent" ForeColor="#000066" />
                    <EmptyDataRowStyle CssClass="TableContent" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                        <asp:BoundField DataField="Tasktype" HeaderText="类别" SortExpression="Tasktype" />
                        <asp:BoundField DataField="Work" HeaderText="重点工作" SortExpression="Work" />
                        <asp:BoundField DataField="Tasktype" HeaderText="目标级别" SortExpression="Tasktype" />
                        <asp:BoundField DataField="targetTask" HeaderText="目标任务" SortExpression="targetTask" />
                        <asp:BoundField DataField="dutyDepart" HeaderText="负重部门" SortExpression="dutyDepart" />
                        <asp:BoundField DataField="Principal" HeaderText="部门负责人" SortExpression="Principal" />
                        <asp:BoundField DataField="Extrleader" HeaderText="分管领导" SortExpression="Extrleader" />
                        <asp:TemplateField HeaderText="详细">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbtnDetails" runat="server" CommandArgument='<%# Eval("id") %>'
                                    CommandName="SE">详细</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="更新">
                            <ItemTemplate>
                                <asp:LinkButton ID="lknbtnUpdate" runat="server" CommandArgument='<%# Eval("id") %>'
                                    CommandName="UP">更新</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" CssClass="TableContent" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" CssClass="TableHeader" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle CssClass="TableContent" />
                    <AlternatingRowStyle CssClass="TableContent" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="objesdd" runat="server" SelectMethod="SelectTaskByConditions"
        TypeName="BLL.Target.TaskManager">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlYear" DefaultValue="" Name="year" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="ddlMonth" Name="month" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="ddlStatus" Name="status" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="ddlFile" Name="field" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <table align="center">
        <tr align="center">
            <td class="style4">
                <uc1:Pager ID="Pager2" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
