<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Matter.aspx.cs" Inherits="OfficeHelp_LeaveMessage_ShowMessage" %>

<%@ Register Src="../UserControls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>待办事宜列表</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" type="text/javascript">

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #C6DAF3">
        <!---留言消息-->
        <div class="title1">
            <h3>
                待办事宜</h3>
        </div>
        <fieldset style="border: 1px solid #CCCCCC; text-align: center; padding-left: 25px;
            width: 90%">
            <br />
            <div style="height: 31px; width: 745px;">
                按办理状态：<asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="0">全部</asp:ListItem>
                    <asp:ListItem>待办</asp:ListItem>
                    <asp:ListItem>已办</asp:ListItem>
                    <asp:ListItem>受理中</asp:ListItem>
                </asp:DropDownList>
                按申请类型：<asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem Selected="True">会议申请</asp:ListItem>
                    <asp:ListItem>用车申请</asp:ListItem>
                    <asp:ListItem>资源借用</asp:ListItem>
                    <asp:ListItem>资源采购</asp:ListItem>
                    <asp:ListItem>任务申请</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="BigButton" OnClick="btnSearch_Click" />
                &nbsp;
            </div>
        </fieldset>
        <table style="width: 752px; height: 449px;">
            <tr>
                <td valign="top">
                    <asp:GridView ID="gvPending" runat="server" AutoGenerateColumns="False" DataSourceID="odsPeding"
                        Height="76px" Width="744px" onrowcommand="gvPending_RowCommand" 
                        onrowdatabound="gvPending_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="主题">
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="申请人">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplicationMan" runat="server" Text='<%# Eval("ResponseMan") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="申请时间">
                                <ItemTemplate>
                                    <asp:Label ID="lblTime" runat="server" Text='<%# Eval("Timer") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="申请类型">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("ApplicationType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblState" CommandName="State" CommandArgument='<%# Eval("Id") %>'
                                        runat="server" Text='<%# Eval("States") %>'></asp:LinkButton>
                                    /<asp:LinkButton ID="lblEnd" CommandName="End" CommandArgument='<%# Eval("Id") %>'
                                        runat="server" Text="终结"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="TableHeader" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsPeding" SelectMethod="SearchPending" TypeName="BLL.Matter.ExamineManager"
                        runat="server">
                        <SelectParameters>
                            <asp:Parameter Name="state" Type="String" DefaultValue="0" />
                            <asp:Parameter Name="type" Type="String" DefaultValue="会议申请" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <br />
                    <uc1:Pager ID="Pager1" runat="server" />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
