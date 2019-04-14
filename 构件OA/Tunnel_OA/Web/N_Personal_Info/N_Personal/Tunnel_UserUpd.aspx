<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_UserUpd.aspx.cs" Inherits="Dachie_UserUpd" %>

<asp:content runat="server" id="content1" contentplaceholderid="Header">
</asp:content>
<asp:content runat="server" id="content2" contentplaceholderid="ContentPlaceHolder1">
    <title>无标题页</title>
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../../javascript/datetimes.js"></script>
    <script src="../../javascript/StrLength.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../javascript/Calendar1.js"></script>
    <script>
        function yjhkk() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtName").value == "") {
                alert('请输入用户名称！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtName").focus();
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtMail").value == "") {
                alert('请输入邮箱！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtMail").focus();
                return false;
            }
        }
    </script>


    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Tunnel_UserUpd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        资料修改</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;border-top:none">
            <tr>
                <td height="25" align="right" style="height: 30px; background-color: #f6f6f6">
                    账号：
                </td>
                <td height="17" align="left" style="background-color:#f6f6f6">
                    <asp:Label ID="txtUserName" runat="server"
                        Width="202px"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="height: 30px; background-color: #ffffff">
                    真实姓名：
                </td>
                <td align="left" height="17" style="background-color:#ffffff">
                    <asp:TextBox ID="txtName" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(50,event,'ctl00_ContentPlaceHolder1_lbl2')"
                        Width="202px"></asp:TextBox>
                    <asp:Label ID="lbl2" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="height: 30px; background-color: #f6f6f6">
                    手机/电话号码：
                </td>
                <td align="left" height="17" style="background-color:#f6f6f6">
                    <asp:TextBox ID="txtTel" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(50,event,'ctl00_ContentPlaceHolder1_lbl4')"
                        Width="202px"></asp:TextBox>
                    <asp:Label ID="lbl4" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="height: 30px; background-color: #ffffff">
                    身份证：
                </td>
                <td align="left" height="17" style="background-color:#ffffff">
                    <asp:TextBox ID="txtIdKard" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(18,event,'ctl00_ContentPlaceHolder1_lbl5')"
                        Width="202px"></asp:TextBox>
                    <asp:Label ID="lbl5" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/18"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="height: 30px; background-color: #f6f6f6">
                    出生年月：
                </td>
                <td align="left" height="17" style="background-color:#f6f6f6">                
                    <asp:TextBox ID="txtBirth" runat="server" onClick="WdatePicker()" class="Wdate"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="height: 30px; background-color: #ffffff">
                    邮箱：
                </td>
                <td align="left" height="17" style="background-color:#ffffff">
                    <asp:TextBox ID="txtMail" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(50,event,'ctl00_ContentPlaceHolder1_lbl7')"
                        Width="202px"></asp:TextBox>
                    <asp:Label ID="lbl7" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 31px" style="background-color: #e6f7ff">
                <asp:ImageButton ID="btnSave" runat="server" CssClass="button" ImageUrl="../../images/save.gif" OnClientClick="return yjhkk()"  OnClick="btnSave_Click" ></asp:ImageButton>
                    
                    
                    &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
            </tr>
        </table>
</asp:content>
