<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Permission.aspx.cs" Inherits="N_Permission_Permission" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
    <table>
        <tr>
            <td style=" font-weight:bolder; color:#3399CC" align="center">
                所有权限
            </td>
            <td colspan="2" style=" font-weight:bolder; color:#3399CC" align="center">
                设置权限(<%=tempName%>)
            </td>
            <td style=" font-weight:bolder; color:#3399CC" id="tmpSet" runat="server">
             <%= tempName_TypeName%>-拥有权限 
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="ListBox1" runat="server" Height="790px" Width="150px" 
                    SelectionMode="Multiple">
                </asp:ListBox>
            </td>
            <td>
                
                 <asp:Button ID="btnRight" runat="server" CssClass="button" Text="---&gt;&gt;" OnClick="btnRight_Click" />
                 <br /><br /><br />
                 <asp:Button ID="btnLeft" runat="server" CssClass="button" Text="&lt;&lt;---" OnClick="btnLeft_Click" />
            </td>      
            <td>
                <asp:ListBox ID="ListBox2" runat="server" Height="790px" Width="150px" 
                    SelectionMode="Multiple">
                </asp:ListBox>
            </td>
             <td>
                <asp:ListBox ID="ListBox3" runat="server" Height="790px" Width="150px" 
                     SelectionMode="Multiple"  Visible="false">
                </asp:ListBox>
            </td>
        </tr>
        <tr class="di" align="center">
            <td colspan="4">
                <asp:Button ID="Button1" CssClass="button" runat="server" Text="更新" OnClick="Button1_Click" />
                 <asp:Button ID="Button2" CssClass="button" runat="server" Text="返回" OnClick="Button2_Click" />
            </td>
        </tr>
    </table></center>
</asp:Content>