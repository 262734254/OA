<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_UserAdd.aspx.cs" Inherits="Dachie_UserAdd" %>

<asp:Content runat="server" ID="contetn1" ContentPlaceHolderID="Header"></asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">

  <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

    <script src="../../javascript/JScript.js"></script>

    <script>
        function copy() {
            document.getElementById("ctl00_ContentPlaceHolder1_txtName").value = document.getElementById("txtUserName").value;
        }
        function yjhkk() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtUserName").value == "") {
                alert('请输入用户名称！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtUserName").focus();
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtPwd").value == "") {
                alert('请输入密码！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtPwd").focus();
                return false;
            }
//            if (document.getElementById("ctl00_ContentPlaceHolder1_txtMail").value == "") {
//                alert('请输入邮箱！');
//                document.getElementById("ctl00_ContentPlaceHolder1_txtMail").focus();
//                return false;
//            }
        }
    </script>

    <style type="text/css">
        #txtUserName
        {
            width: 198px;
        }
    </style>
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Tunnel_UserAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增用户</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="Tunnel_UserList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理用户</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table width="100%" border="1" align="center" cellpadding="0" cellspacing="1" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF">
            <tr>
                <td height="25" align="right" style="height: 30px; background-color: #f6f6f6">
                    账号：
                </td>
                <td height="17" align="left" bgcolor="#f6f6f6">
                    <input id="txtUserName" onkeyup="StartRequest();copy();javascrip:checkWord(50,event,'lbl')"
                        value="" /><img src="../../image/st.gif" alt="" id="show" />
                    <asp:Label ID="lbl" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" style="height: 30px; " bgcolor="#FFFFFF">
                    密码：
                </td  >
                <td height="17" align="left">
                    <asp:TextBox ID="txtPwd" runat="server" CssClass="inputtext" TextMode="Password"
                        onkeyup="javascrip:checkWord(50,event,'lbl0')" Width="202px"></asp:TextBox>
                    <asp:Label ID="lbl0" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right" height="25" style="height: 30px; background-color: #f6f6f6">
                    邮箱：
                </td>
                <td align="left" height="17"  bgcolor="#f6f6f6">
                    <asp:TextBox ID="txtMail" runat="server" CssClass="inputtext" Width="256px" onkeyup="javascrip:checkWord(50,event,'lbl1')"></asp:TextBox>
                    <asp:Label ID="lbl1" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 31px" class="di">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="提交" OnClientClick="return yjhkk();"
                        OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>

    <asp:HiddenField ID="txtName" runat="server" Value="" />
 

</asp:Content>
    
  