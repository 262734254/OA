<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Tunnel_UserUpd.aspx.cs" Inherits="Dachie_UserUpd" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

    <script src="../../javascript/Calendar1.js" type="text/javascript"></script>

    <script>
        function yjhkk() {
            if (document.getElementById("<%=txtName.ClientID %>").value == "") {
                alert('请输入用户名称！');
                document.getElementById("<%=txtName.ClientID %>").focus();
                return false;
            }
            if (document.getElementById("<%=txtPwd.ClientID %>").value == "") {
                alert('请输入密码！');
                document.getElementById("<%=txtPwd.ClientID %>").focus();
                return false;
            }
            if (document.getElementById("<%=txtMail.ClientID %>").value == "") {
                alert('请输入邮箱！');
                document.getElementById("<%=txtMail.ClientID %>").focus();
                return false;
            }

            var a = /(1[35]\d{9})/;
            var t1 = document.getElementById("<%=txtTel.ClientID %>").value;
            if (!a.test(t1)) {
                if (t1 != "") {
                    alert("请输入正确的手机号码");
                    return false;
                }
            }
        }
    </script>

    <style type="text/css">
        .style1
        {
            height: 19px;
        }
        .style2
        {
            height: 30px;
            width: 212px;
        }
        .style3
        {
            height: 19px;
            width: 212px;
        }
    </style>
    <table width="100%" border="1" align="center" cellpadding="0" cellspacing="1" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF">
        <tr>
            <td height="25" align="right" style="background-color: #f6f6f6" class="style2">
                账号：
            </td>
            <td height="25" align="left" style="background-color: #f6f6f6">
                &nbsp;<asp:TextBox ID="txtUserName" runat="server" CssClass="inputtext" ReadOnly="True"
                    onkeyup="javascrip:checkWord(50,event,'lbl')" Width="202px"></asp:TextBox>
                <asp:Label ID="lbl" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" class="style2">
                真实姓名：
            </td>
            <td align="left" height="25">
                <asp:TextBox ID="txtName" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(50,event,'lbl0')"
                    Width="202px"></asp:TextBox>
                <asp:Label ID="lbl0" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="background-color: #f6f6f6" class="style3">
                密码：
            </td>
            <td align="left" class="style1" style="background-color: #f6f6f6">
                &nbsp;<asp:TextBox ID="txtPwd" runat="server" CssClass="inputtext" TextMode="Password"
                    onkeyup="javascrip:checkWord(50,event,'lbl1')" Width="202px"></asp:TextBox>
                <asp:Label ID="lbl1" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" class="style2">
                手机/电话号码：
            </td>
            <td align="left" height="25">
                <asp:TextBox ID="txtTel" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(50,event,'lbl2')"
                    Width="202px"></asp:TextBox>
                <asp:Label ID="lbl2" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="background-color: #f6f6f6" class="style2">
                身份证：
            </td>
            <td align="left" height="25" style="background-color: #f6f6f6">
                <asp:TextBox ID="txtIdKard" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(18,event,'lbl3')"
                    Width="202px"></asp:TextBox>
                <asp:Label ID="lbl3" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/18"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" class="style2">
                审批密码：
            </td>
            <td align="left" height="25">
                <asp:TextBox ID="txtsPwd" runat="server" TextMode="Password" onkeyup="javascrip:checkWord(50,event,'lbl5')"
                    Width="202px"></asp:TextBox>
                <asp:Label ID="lbl5" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="background-color: #f6f6f6" class="style2">
                出生年月：
            </td>

            <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>

            <td align="left" height="25" style="background-color: #f6f6f6">
                <asp:TextBox ID="txtBirth" runat="server" CssClass="Wdate" onClick="WdatePicker()"
                    Width="201px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" class="style2">
                角色：
            </td>
            <td align="left" height="25">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="198px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="background-color: #f6f6f6" class="style2">
                部门：
            </td>
            <td align="left" height="25" style="background-color: #f6f6f6">
                <asp:DropDownList ID="ddlBum" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" class="style2">
                职务：
            </td>
            <td align="left" height="25">
                <asp:DropDownList ID="ddlDuty" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="background-color: #f6f6f6" class="style2">
                项经部：
            </td>
            <td align="left" height="25" style="background-color: #f6f6f6">
                <asp:CheckBoxList ID="CheckBoxList3" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="background-color: #f6f6f6" class="style2">
                科室：
            </td>
            <td align="left" height="25" style="background-color: #f6f6f6">
                <asp:CheckBoxList ID="cbListKS" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="background-color: #f6f6f6" class="style2">
                用户状态：
            </td>
            <td align="left" height="25" style="background-color: #f6f6f6">
                <asp:RadioButtonList ID="rbState" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">锁定</asp:ListItem>
                    <asp:ListItem Value="0">开启</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" class="style2">
                邮箱：
            </td>
            <td align="left" height="25">
                <asp:TextBox ID="txtMail" runat="server" Width="230px" onkeyup="javascrip:checkWord(50,event,'lbl4')"></asp:TextBox>
                <asp:Label ID="lbl4" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 31px" class="di">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="提交" OnClientClick="return yjhkk()"
                    OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                    Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>
