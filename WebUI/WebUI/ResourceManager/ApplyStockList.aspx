<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyStockList.aspx.cs" Inherits="ResourceManager_ApplyStockList" %>

<%@ Register Src="../UserControls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源借用申请列表</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: #C6DAF3;
        }
        .style4
        {
            height: 32px;
        }
    </style>

    <script type="text/javascript">
        function CheckAll(obj)
        {
            var item=document.getElementsByTagName("input");
            for(var i=0;i<item.length;i++)
            {
                if(item[i].type=="checkbox")
                {
                    item[i].checked=obj.checked;
                }
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        资源采购申请列表</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="right">
                                <asp:HiddenField ID="hfLoginId" runat="server" />
                                <asp:Button ID="btnNewApplyStock" runat="server" class="BigButton" Text="新增资源申请"
                                    OnClick="btnNewApplyStock_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                采购单号：<asp:TextBox ID="txtSAID" class="inputs" runat="server"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 申请时间：<input type="text" onclick="showcalendar(event, this);"
                                    id="txtSATime" runat="server" style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; width: 120px; border-bottom: #99ccff 1px solid" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" class="BigButton"
                                    Text="查   询" OnClick="btnSearch_Click" />
                                &nbsp;<asp:Button ID="btnDelete" runat="server" class="BigButton" Text="删   除" 
                                    OnClick="btnDelete_Click" ToolTip="删除" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvStockApplicationList" runat="server" AutoGenerateColumns="False"
                                    DataSourceID="odsStockApplication" Width="100%" OnRowCommand="gvStockApplicationList_RowCommand"
                                    OnRowDataBound="gvStockApplicationList_RowDataBound">
                                    <RowStyle CssClass="TableContent" Height="32px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="cbALL" runat="server" Text="全选" OnClick="CheckAll(this)" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbCheck" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SAID" HeaderText="申请单号" SortExpression="SAID" />
                                        <asp:TemplateField HeaderText="借用人">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("User.Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NeedCharge" HeaderText="所需金额" SortExpression="NeedCharge" />
                                        <asp:BoundField DataField="SATime" HeaderText="采购时间" SortExpression="SATime" />
<%--                                        <asp:HyperLinkField DataNavigateUrlFields="SAID" Text="修改" HeaderText="修改" DataNavigateUrlFormatString="UpdateApplyStock.aspx?id={0}" />
--%>                                        
                                        <asp:TemplateField HeaderText="详情">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbDetail" runat="server" PostBackUrl='<%# Eval("SAID", "ApplyStockInfo.aspx?id={0}") %>'>详情</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="删除">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbDel" runat="server" CommandArgument='<%# Eval("SAID") %>'
                                                    CommandName="Del">删除</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsStockApplication" runat="server" SelectMethod="SearchStockApplication"
                                    TypeName="BLL.Resource.StockApplicationManager">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtSAID" Name="said" PropertyName="Text" Type="Int32" />
                                        <asp:ControlParameter ControlID="txtSATime" Name="time" PropertyName="Value" DefaultValue=" "
                                            Type="String" />
                                        <asp:ControlParameter ControlID="hfLoginId" Name="uid" PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:Pager ID="ucpage" runat="server" />
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
