<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="MessageAdd.aspx.cs" Inherits="N_Message_N_MessageAdd" %>

<%@ Register assembly="Tunnel.BLL" namespace="OurControl" tagprefix="cc1" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../javascript/Calendarform.js" type="text/javascript"></script>
    <script src="../javascript/utility.js" type="text/javascript"></script>
    <script src="../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/jscript" language="javascript">
        function formCheck() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value=="")
            {
                alert('请输入标题！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").focus();
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtContent").value=="")
            {
                alert('请输入内容！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtContent").focus();
                return false;
            }
        }
    </script>
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
    <tr>
        <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
        <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon">
            <a href="MessageAdd.aspx" class="a">
                <div style="width:73; height:27px; cursor:pointer;">发布留言</div>
            </a>
        </td>
        <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
            <a href="MessageManage.aspx" class="a">
                <div style="width:73; height:27px;cursor:pointer;">管理留言</div>
            </a>
        </td>
        <td bgcolor="#f6f6f6">&nbsp;</td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
                <tr>
                    <td height="30" align="center" bgcolor="#ffffff">标题：</td>
                    <td >
                        <asp:TextBox runat="server" ID="txtTitle" onkeyup="javascrip:checkWord(100,event,'ctl00_ContentPlaceHolder1_lbl1')" Width="328px" ></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="lbl1" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/100"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="75" align="center">内容：</td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Rows="8" Width="90%" onkeyup="javascrip:checkWord(1000,event,'ctl00_ContentPlaceHolder1_lbl2')"></asp:TextBox>
                        <br />
                        <asp:Label ID="lbl2" runat="server" Font-Size="12px" Text="0/1000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
                    <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
                        <asp:Button ID="btnSave" runat="server" Text="发布留言" CssClass="button" 
                            OnClientClick="return formCheck();" onclick="btnSave_Click"/>
                        &nbsp;
                        <input type="reset" name="Submit2" value="重 置" class="button"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>