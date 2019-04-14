<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_MailSend.aspx.cs" Inherits="N_Exchange_N_ExternalMail_N_MailSend" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>发送邮件</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

<script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function formCheck() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").value == "") {
                alert('请输入标题！');
                document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").focus();
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_tb_content").value == "") {
                alert('请输入内容！');
                document.getElementById("ctl00_ContentPlaceHolder1_tb_content").focus();
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_tb_Email").value == "") {
                alert('请输入接收邮件地址！');
                document.getElementById("ctl00_ContentPlaceHolder1_tb_Email").focus();
                return false;
            }
            else {
                var email = document.getElementById("ctl00_ContentPlaceHolder1_tb_Email").value;
                var pattern = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                chkFlag = pattern.test(email);
                if (chkFlag == false) {
                    alert("邮箱地址的格式不正确！");
                    document.getElementById("ctl00_ContentPlaceHolder1_tb_Email").focus();
                    return false;
                }
            }
        } 
        function ShowDialog() {
            var url = '../../N_SysManage/FlowDesign/Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_id_toValue&to_name=ctl00_ContentPlaceHolder1_tb_Email&titles=0';
            var iWidth = 380; //窗口宽度
            var iHeight = 400; //窗口高度
            var iTop = (window.screen.height - iHeight) / 4.3;
            var iLeft = (window.screen.width - iWidth) / 1.2;
            window.showModalDialog(url, window, "dialogHeight: " + iHeight + "px; dialogWidth: " + iWidth + "px;dialogTop: " + iTop + "; dialogLeft: " + iLeft + "; resizable: no; status: no;scroll:auto");
        }
        function fileupload(str) {
            if (str == 0) {
                document.getElementById("ctl00_ContentPlaceHolder1_fileuploaddiv").style.display = '';
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_fileuploaddiv").style.display = "none";
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr align="left">
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_MailSend.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">发布邮件</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_MailManage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">已发邮件</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
            <td width="63" height="30" align="right" bgcolor="#f6f6f6">
                标题：
            </td>
            <td align="left" bgcolor="#f6f6f6">
                <label>
                    <asp:TextBox runat="server" ID="tb_Title" Width="90%" TextMode="MultiLine" onkeyup="javscrip:checkWord(200,event,'ctl00_ContentPlaceHolder1_lbl1')"
                        Height="55px"></asp:TextBox>
                </label>
                <br />
                <asp:Label ID="lbl1" runat="server" Font-Size="12px" Text="0/200">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td height="75" align="right">
                内容：
            </td>
            <td align="left">
                <span>
                    <input runat="server" id="id_toValue" type="hidden" />
                    <asp:TextBox runat="server" ID="tb_content" TextMode="MultiLine" Rows="8" Width="90%"
                        onkeyup="javascrip:checkWord(1000,event,'ctl00_ContentPlaceHolder1_lbl2')"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbl2" runat="server" Font-Size="12px" Text="0/1000"></asp:Label>
                </span>
            </td>
        </tr>
        <tr bgcolor="#f6f6f6">
            <td height="38" align="right">
                接收人：
            </td>
            <td align="left" bgcolor="#f6f6f6">
                <asp:TextBox runat="server" TextMode="MultiLine" ID="tb_Email" Width="80%" Height="100px"></asp:TextBox>
                <input id="Button4" runat="server" class="button" onclick="ShowDialog();" type="button"
                    value="接收人" />
            </td>
        </tr>
        <tr>
            <td height="30" align="right">
                附件：
            </td>
            <td align="left">
                <input id="file1" type="file" runat="server" />
            </td>
        </tr>
        <tr>
            <td height="30" align="right" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid">
                &nbsp;
            </td>
            <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid">
                <asp:Button ID="Button1" runat="server" Text="发送" CssClass="button" OnClick="Button1_Click"
                    OnClientClick="fileupload(0);return formCheck();" />
                &nbsp;
                <input type="reset" name="Submit2" value="重 置" class="button" />
            </td>
        </tr>
    </table>
    <table style="display: none" width="0%" border="1" align="right" cellpadding="0"
        cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB">
        <tr>
            <td colspan="3" height="30" align="center">
                联系人地址
            </td>
        </tr>
        <tr>
            <td colspan="1">
                <asp:ListBox ID="lbxlinkman" Width="100%" Height="400px" runat="server" Rows="11"
                    AutoPostBack="True" OnSelectedIndexChanged="lbxlinkman_SelectedIndexChanged">
                </asp:ListBox>
            </td>
        </tr>
    </table>
    <div runat="server" id="fileuploaddiv" style="width: 100px; height: 100px; top: 200px;
        left: 330px; position: absolute; display:none ">
        <img src="../../image/img/uploading.gif" style="width: 100px; height: 100px" />
    </div>
</asp:Content>