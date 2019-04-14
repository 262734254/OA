<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaderManager.aspx.cs" Inherits="Default2" %>


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
                    部门主管重点任务目标管理</h3>
            </td>
            <td style="text-align: right">
            </td>
        </tr>
    </table>
    <fieldset style="text-align: center; padding-left: 25px; width: 90%">
        <br />
        <div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 阶段划分：<asp:DropDownList 
                            ID="ddlStepStatus" runat="server" 
                CssClass="BigSelect" AutoPostBack="True" onselectedindexchanged="ddlStepStatus_SelectedIndexChanged" 
               >
                <asp:ListItem Value="1">已分阶段</asp:ListItem>
                <asp:ListItem Value="0">未分阶段</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
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
                        <asp:TemplateField HeaderText="划分阶段">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbSend" runat="server" CommandArgument='<%# Eval("id") %>'
                                         CommandName="SE">划分阶段</asp:LinkButton>
                                <asp:HiddenField ID="hidId" runat="server" Value='<%# Eval("id") %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="更新进度">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbBack" runat="server" CommandArgument='<%# Eval("id") %>'
                                    CommandName="UP">更新进度</asp:LinkButton>
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
    <asp:ObjectDataSource ID="objesdd" runat="server" SelectMethod="SelectAllNoStepTask"
        TypeName="BLL.Target.TaskManager">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="1" Name="uid" SessionField="user" 
                Type="Int32" />
            <asp:Parameter DefaultValue="1" Name="s" Type="Int32" />
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
