<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceInfoList.aspx.cs"
    Inherits="ResourceManager_ResourceList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源信息列表</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
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
                        资源信息查询</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnNewApplyBrrow" runat="server" class="BigButton" Text="新增资源" OnClick="btnNewApplyBrrow_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                资源名称：<asp:TextBox ID="txtName" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                &nbsp; 资源类型：<asp:DropDownList ID="ddlType" class="inputs" runat="server" AppendDataBoundItems="True"
                                    DataSourceID="odsType" DataTextField="RTName" DataValueField="RTID">
                                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                                </asp:DropDownList>
                                资源状态：&nbsp;<asp:DropDownList ID="ddlState" class="inputs" runat="server">
                                    <asp:ListItem Selected="True" Value="0">--请选择--</asp:ListItem>
                                    <asp:ListItem Value="1">可用</asp:ListItem>
                                    <asp:ListItem Value="2">禁用</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" class="BigButton" Text="查   询"
                                    OnClick="btnSearch_Click" />
                                &nbsp;<asp:Button ID="btnDelete" runat="server" class="BigButton" Text="删   除" 
                                    onclick="btnDelete_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvResourceList" runat="server" AutoGenerateColumns="False" DataSourceID="odsResourceList"
                                    Width="100%" onrowcommand="gvResourceList_RowCommand" 
                                    onrowdatabound="gvResourceList_RowDataBound">
                                    <RowStyle Height="32px" CssClass="TableContent" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="cbALL" runat="server" Text="全选" OnClick="CheckAll(this)" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbCheck" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="序号" SortExpression="RIID">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("RIID") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("RIID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="资源名称" SortExpression="RIName">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("RIName") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("RIName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="资源类型">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Type.RTName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="资源数量" SortExpression="Number">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Number") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="购买时间" SortExpression="InTime">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("InTime") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("InTime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="资源状态" SortExpression="RIState">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("RIState") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("RIState") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="资源规格" SortExpression="RISpec">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("RISpec") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("RISpec") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:HyperLinkField DataNavigateUrlFields="RIID" Text="详情" HeaderText="详情" DataNavigateUrlFormatString="ResourceInfo.aspx?id={0}" />
                                        <asp:HyperLinkField DataNavigateUrlFields="RIID" Text="修改" HeaderText="修改" DataNavigateUrlFormatString="UpdateResource.aspx?id={0}" />
                                        <asp:TemplateField HeaderText="删除">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" 
                                                    CommandArgument='<%# Eval("RIID") %>' CommandName="Del">删除</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsResourceList" runat="server" SelectMethod="GetAllResourceInfo"
                                    TypeName="BLL.Resource.ResourceInfoManager"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="odsType" runat="server" SelectMethod="GetAllResourceType"
                                    TypeName="BLL.Resource.ResourceTypeManager"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                共有<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                记录&nbsp;&nbsp; |&nbsp;&nbsp; 共有<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                页&nbsp; |&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkfirst" runat="server">首页</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lnkprev" runat="server">上一页</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lnknext" runat="server">下一页</asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="lnklast" runat="server">尾页</asp:LinkButton>
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
