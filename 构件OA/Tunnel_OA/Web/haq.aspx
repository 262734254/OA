<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="haq.aspx.cs" Inherits="haq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script>
        function checkSearch(obj) {
            if (obj.value == '登录名或真实姓名') {
                obj.value = '';
            }
        }
        function checkText1() {
            if (document.getElementById("<%=TextBox1.ClientID %>").value == '') {
                alert('登录密码不能为空');
                return false;
            }
        }
        function checkText2() {
            if (document.getElementById("<%=TextBox2.ClientID %>").value == '') {
                alert('审批密码不能为空');
                return false;
            }
        }
    </script>

    <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF">
        <tr align="center">
            <td colspan="5">
                <asp:TextBox ID="searchtext" runat="server" Text="登录名或真实姓名" onclick="checkSearch(this)"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Button
                    ID="Button3" runat="server" Text="" CssClass="searchbutton" OnClick="Button3_Click" />
            </td>
        </tr>
        <tr style="font-weight: bold" height="35px" bgcolor="#f6f6f6" align="center">
            <td>
                选择
            </td>
            <td>
                登录名
            </td>
            <td>
                真实姓名
            </td>
            <td>
                密码
            </td>
            <td>
                审批密码
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr height="25px" align="center">
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" ToolTip='<%#Eval("m_id") %>' />
                    </td>
                    <td>
                        &nbsp;
                        <%#Eval("m_login") %>
                    </td>
                    <td>
                        &nbsp;
                        <%#Eval("m_name") %>
                    </td>
                    <td>
                        &nbsp;
                        <%#jm(Eval("m_password"))%>
                    </td>
                    <td>
                        &nbsp;
                        <%#jm(Eval("m_spassword"))%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr class="di">
            <td colspan="5">
                <asp:Button ID="Button1" runat="server" Text="登录密码" CssClass="button" OnClick="Button1_Click"
                    OnClientClick="return checkText1();" /><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="di">
            <td colspan="5">
                <asp:Button ID="Button2" runat="server" Text="审批密码" CssClass="button" OnClick="Button2_Click"
                    OnClientClick="return checkText2();" /><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="di" align="right">
            <td colspan="5">
                <font align="right" color="red">* 批量重置密码、审批密码页面</font>
            </td>
        </tr>
    </table>
</asp:Content>
