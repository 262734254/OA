<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="haq.aspx.cs" Inherits="haq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script>
        function checkSearch(obj) {
            if (obj.value == '��¼������ʵ����') {
                obj.value = '';
            }
        }
        function checkText1() {
            if (document.getElementById("<%=TextBox1.ClientID %>").value == '') {
                alert('��¼���벻��Ϊ��');
                return false;
            }
        }
        function checkText2() {
            if (document.getElementById("<%=TextBox2.ClientID %>").value == '') {
                alert('�������벻��Ϊ��');
                return false;
            }
        }
    </script>

    <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF">
        <tr align="center">
            <td colspan="5">
                <asp:TextBox ID="searchtext" runat="server" Text="��¼������ʵ����" onclick="checkSearch(this)"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Button
                    ID="Button3" runat="server" Text="" CssClass="searchbutton" OnClick="Button3_Click" />
            </td>
        </tr>
        <tr style="font-weight: bold" height="35px" bgcolor="#f6f6f6" align="center">
            <td>
                ѡ��
            </td>
            <td>
                ��¼��
            </td>
            <td>
                ��ʵ����
            </td>
            <td>
                ����
            </td>
            <td>
                ��������
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
                <asp:Button ID="Button1" runat="server" Text="��¼����" CssClass="button" OnClick="Button1_Click"
                    OnClientClick="return checkText1();" /><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="di">
            <td colspan="5">
                <asp:Button ID="Button2" runat="server" Text="��������" CssClass="button" OnClick="Button2_Click"
                    OnClientClick="return checkText2();" /><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="di" align="right">
            <td colspan="5">
                <font align="right" color="red">* �����������롢��������ҳ��</font>
            </td>
        </tr>
    </table>
</asp:Content>
