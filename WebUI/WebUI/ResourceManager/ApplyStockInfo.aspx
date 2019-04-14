<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyStockInfo.aspx.cs" Inherits="ResourceManager_ApplyStockInfo" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>采购申请详情页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 450px;
            background-color: #C6DAF3;
        }
        .style2
        {
            width: 500px;
        }
        .style3
        {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="background-color: #C6DAF3">
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        采购申请详情</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table class="style2">
                        <tr>
                            <td align="left">
                                申&nbsp; 请&nbsp; 单&nbsp; 号：<asp:TextBox ID="txtSAID" class="inputs" runat="server"
                                    ReadOnly="True" Width="120px"></asp:TextBox>
                            </td>
                            <td align="left">
                                申 请 人 ：<asp:TextBox ID="txtUser" class="inputs" runat="server" ReadOnly="True" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                采&nbsp; 购&nbsp; 时&nbsp; 间：<input id="txtTime" name="txFDate" type="text" style="border: 1px solid #99ccff;
                                    width: 120px; height: 17px;" runat="server" readonly="readonly" />
                            </td>
                            <td align="left">
                                所需费用：<asp:TextBox ID="txtNeedCharge" runat="server" class="inputs" ReadOnly="True"
                                    Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                是否通过审批：<asp:TextBox ID="txtIsExamine" runat="server" class="inputs" ReadOnly="True"
                                    Width="120px"></asp:TextBox>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                采购原因：<asp:TextBox ID="txtCause" runat="server" class="inputs" Height="90px" TextMode="MultiLine"
                                    Width="333px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs" runat="server"
                                    Height="90px" TextMode="MultiLine" Width="333px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left">
                                采购资源
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <asp:GridView ID="gvBorrowResource" runat="server" AutoGenerateColumns="False" DataSourceID="odsStockResource"
                                    Style="margin-right: 0px; margin-bottom: 0px;" Width="100%">
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
                                        <asp:BoundField DataField="Number" HeaderText="采购数量" SortExpression="Number" />
                                        <asp:TemplateField HeaderText="资源规格">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Resource.RISpec") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px" />
                                </asp:GridView>
                                <uc1:Pager ID="ucPager" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnAuditing" runat="server" class="BigButton" Text="审   批" 
                                    OnClick="btnAuditing_Click" ToolTip="审核" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" OnClick="btnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
                                <asp:ObjectDataSource ID="odsStockResource" runat="server" SelectMethod="GetAllApplicationResource"
                                    TypeName="BLL.Resource.ApplicationResourceManager">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="2" Name="type" Type="Int32" />
                                        <asp:QueryStringParameter DefaultValue="" Name="id" QueryStringField="id" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
    </form>
</body>
</html>
