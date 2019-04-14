<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleList.aspx.cs" Inherits="Default8" %>

<%@ Register src="../../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>角色管理</title>
   <link href="../../css/6/style.css" type="text/css" rel="stylesheet" />
    <link href="../../css/public.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .style2
        {
            width: 100%; background-color:#C6DAF3;
            height:450px;
        }
        </style>
    <script type="text/javascript">
        function selAll(obj)
        {
            var items=document.getElementsByTagName("input");
            for(var i=0;i<items.length;i++)
            {
                if(items[i]!=null&&items[i].type=="checkbox")
                {
                    items[i].checked=obj.checked;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style2">
            <tr>
                <td align="center" class="title1">
                <h3>角色管理</h3>
                   </td>
            </tr>
            <tr>
                <td align="center" valign="top">
             
        <table>
        <tr><td style="height:50px"> 角色名称：<asp:TextBox ID="txtRoleName" class="inputs" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSelect" class="BigButton" 
                runat="server" Text="查   询" onclick="btnSelect_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hkAddRole" runat="server" 
                NavigateUrl="~/PowerManager/Role/AddRole.aspx">新增角色</asp:HyperLink>
                                </td></tr>
            <tr>
                <td style="text-align:left">
&nbsp;<asp:Button ID="Button2" class="BigButton" runat="server" Text="删  除" 
                        onclick="btnDelte" onclientclick="return confirm('确定要删除？')" />
                </td>
            </tr>
            <tr>
                <td valign="top" style="padding-top:10px">
                   
                    <asp:GridView ID="gvShowData" runat="server" AutoGenerateColumns="False" CellPadding="6" 
                                        DataSourceID="objes1" ForeColor="#333333" GridLines="None" 
                                        Width="742px" style="margin-left: 0px" 
                        onrowcommand="gvShowData_RowCommand">
                        <RowStyle BackColor="#EFF3FB" CssClass="TableContent" />
                        <EmptyDataRowStyle CssClass="TableContent" />
                        <Columns>
                            <asp:TemplateField HeaderText="角色编号" SortExpression="roleId">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("roleId") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <input id="ckControls" type="checkbox" />全选
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckCheck" runat="server"   ToolTip='<%# Eval("roleId") %>' />
                                    <asp:HiddenField ID="hiddenRoleId" runat="server" Value='<%# Eval("roleId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RoleName" HeaderText="角色名称" 
                                SortExpression="RoleName" />
                            <asp:BoundField DataField="Description" HeaderText="备注" 
                                SortExpression="Description" />
                            <asp:TemplateField HeaderText="授权">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lknbtnAthori" runat="server" 
                                        CommandArgument='<%#  Eval("roleId")%>' CommandName="AU">授权</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkModify" runat="server" 
                                        CommandArgument='<%# Eval("roleId") %>' CommandName="MO">修改</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnDel" runat="server" 
                                        CommandArgument='<%# Eval("roleId") %>' CommandName="DE" OnClientClick="return confirm('确定要删除？')" > 删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" CssClass="TableContent" Font-Bold="True" 
                            ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" CssClass="TableHeader" Font-Bold="True" 
                            ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" CssClass="TableContent" />
                        <AlternatingRowStyle BackColor="White" CssClass="TableContent" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:Pager ID="Pager5" runat="server" />
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