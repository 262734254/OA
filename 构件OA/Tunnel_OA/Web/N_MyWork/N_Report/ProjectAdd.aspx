<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectAdd.aspx.cs" MasterPageFile="~/MasterPage.master"
    Inherits="SystemManage_KaoHe_Tunnel_ItemsAdd" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">

    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script>
        function yjhkk() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtItems").value == "") {
                alert('请输入工程项目名称！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtItems").focus();
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value == "" || parseInt(document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value) < 1990 || parseInt(document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value) > 2030) {
                alert('请输入正确的年！');
                document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").focus();
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value == "" || parseInt(document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value) < 1 || parseInt(document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value) > 12) {
                alert('请输入正确的月！');
                document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").focus();
                return false;
            } else {
            if (parseInt(document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value) < 10) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value.length < 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value = '0' + document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value;
                    }
                }
            }
        }
    </script>

    <script>
        function cknum() {
            var key = /^\d+$/;
            if (!key.test(document.getElementById("TextBox1").value)) {
                document.getElementById("TextBox1").value = "";
            }
            if (!key.test(document.getElementById("TextBox2").value)) {
                document.getElementById("TextBox2").value = "";
            }
        }

    </script>

    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td runat="server" width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="ExamineAdd.aspx" class="a" id=xinzengkaohe runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增考核</div>
                </a>
            </td>
            <td runat="server" width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="ProjectDel.aspx" class="a" id=guanligongcheng runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理工程</div>
                </a>
            </td>
            <td runat="server" width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="Rate.aspx" class="a" id=kaohedafen runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        考核打分</div>
                </a>
            </td>
            <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="PK_ProjectManager.aspx" class="a" id=kaohepaihang runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        考核排行</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid;
        border-top: none">
        <tr>
            <td align="right" height="25" style="height: 30px; background-color: #f6f6f6">
                工程项目名称：
            </td>
            <td align="left" height="17" style="background-color: #f6f6f6">
                <asp:TextBox ID="txtItems" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(50,event,'lbl')"
                    Width="202px"></asp:TextBox>
                <br />
                <asp:Label ID="lbl" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/50"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="height: 30px; background-color: #ffffff">
                年月：
            </td>
            <td align="left" height="17" style="background-color: #ffffff">
                <asp:TextBox ID="TextBox1" runat="server" onkeyup="return cknum();" CssClass="inputtext"
                    MaxLength="4" Width="56px"></asp:TextBox>
                年<asp:TextBox ID="TextBox2" runat="server" onkeyup="return cknum();" MaxLength="2"
                    Width="51px" CssClass="inputtext"></asp:TextBox>
                月
            </td>
        </tr>
        <tr class="di">
            <td colspan="2" align="center" style="height: 31px">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="提交" OnClientClick="return yjhkk();"
                    OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                    Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>
