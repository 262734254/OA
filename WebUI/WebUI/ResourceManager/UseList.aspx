<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UseList.aspx.cs" Inherits="BorrowList" %>

<%@ Register Src="../UserControls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源记录页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 99%;
            background-color: #C6DAF3;
        }
    </style>
    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: #C6DAF3;
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
                        资源使用记录查询</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td>
                                资源名称：<asp:TextBox ID="txtName" class="inputs" runat="server"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 使用类型：&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList
                                    ID="ddlType" class="inputs" runat="server">
                                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                                    <asp:ListItem Value="1">借用</asp:ListItem>
                                    <asp:ListItem Value="2">使用</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server"
                                    class="BigButton" Text="查   询" onclick="btnSearch_Click"   />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnDelete" runat="server" class="BigButton" Text="删   除" 
                                    ToolTip="删除" onclick="btnDelete_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvUseList" runat="server" AutoGenerateColumns="False" Width="100%"
                                    DataSourceID="odsResources">
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
                                        <asp:TemplateField HeaderText="借用编号">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBAID" runat="server" Text='<%# Eval("Borrow.BAID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="资源名称">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRIID" runat="server" Text='<%# Eval("Resource.RIID") %>' 
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="lblRIName" runat="server" Text='<%# Eval("Resource.RIName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="时间">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Borrow.BATime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="员工">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Borrow.User.Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="数量">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="详情">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnSel" runat="server" PostBackUrl='<%# Eval("Resource.RIID", "ResourceDetails.aspx?id={0}") %>'>详情</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsResources" runat="server" SelectMethod="SearchByResourceNameAndBorrowType"
                                    TypeName="BLL.Resource.ApplicationResourceManager">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtName" Name="resourceName" PropertyName="Text"
                                            Type="String" />
                                        <asp:ControlParameter ControlID="ddlType" Name="borrowType" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:Pager ID="ucPager" runat="server" />
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
