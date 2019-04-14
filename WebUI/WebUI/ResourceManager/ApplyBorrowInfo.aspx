<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyBorrowInfo.aspx.cs"
    Inherits="ResourceManager_ApplyBorrowInfo" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源借用申请详情</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: #C6DAF3;
        }
        .style2
        {
            height: 90px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td align="center" class="title1">
                                <h3>
                                    资源借用申请详情</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table style="width: 545px">
                                    <tr align="left">
                                        <td>
                                            申请单号：<asp:TextBox ID="txtApplyNum" class="inputs" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            申请时间：<input type="text" id="txtBATime" runat="server" style="border-right: #99ccff 1px solid;
                                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;
                                                width: 120px;" readonly="readonly" />
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            紧急程度：<asp:TextBox ID="txtExigentGrade" class="inputs" runat="server" Width="120px"
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            借 用 人 ：<asp:TextBox ID="txtUser" class="inputs" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            是否审批：<asp:TextBox ID="txtExamine" class="inputs" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="2" class="style2" align="center">
                                            备&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtMark" class="inputs" runat="server" Height="59px"
                                                TextMode="MultiLine" Width="330px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <h5>
                                                借用资源列表</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="gvBorrowResource" runat="server" AutoGenerateColumns="False" DataSourceID="odsBorrowResource"
                                                Style="margin-right: 0px" Width="100%">
                                                <RowStyle CssClass="TableContent" Height="32px" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="资源编号">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Resource.RIID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="资源名称">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Resource.RIName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="资源类型">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Resource.Type.RTName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Number" HeaderText="借用数量" SortExpression="Number" />
                                                    <asp:TemplateField HeaderText="资源规格">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Resource.RISpec") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px" />
                                            </asp:GridView>
                                            <uc1:Pager ID="ucPager" runat="server" />
                                            <asp:ObjectDataSource ID="odsBorrowResource" runat="server" SelectMethod="GetAllApplicationResource"
                                                TypeName="BLL.Resource.ApplicationResourceManager">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="1" Name="type" Type="Int32" />
                                                    <asp:QueryStringParameter DefaultValue="" Name="id" QueryStringField="id" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnAuditing" runat="server" class="BigButton" OnClick="btnAuditing_Click"
                                                Text="审   批" ToolTip="审核" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" OnClick="btnReset_Click" />
                                        </td>
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
