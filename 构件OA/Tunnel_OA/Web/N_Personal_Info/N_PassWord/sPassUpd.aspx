<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="sPassUpd.aspx.cs" Inherits="Dachie_UserUpd" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../css/group.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../javascript/datetimes.js"></script>

    <script src="../javascript/StrLength.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" src="../javascript/Calendar1.js"></script>

    <script>
        function yjhkk() {
            var b = true;
            if (document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value != document.getElementById("ctl00_ContentPlaceHolder1_TextBox3").value) {

                alert('�����������벻һ�£�');
                document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").focus();
                b = false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_TextBox3").value == "") {

                alert('�������벻��Ϊ�գ�');
                document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").focus();
                b = false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value != document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value) {
                alert("ԭʼ���벻��ȷ,����������!");
                b = false;
            }
            return b;
        }
    </script>

    <style type="text/css">
        .button
        {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            background: url('../../images/buttom_imgbg.gif') no-repeat;
            width: 69px;
            height: 23px;
        }
    </style>
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="PassUpd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        ��½����</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="sPassUpd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        ��������</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table id="content" border="0" cellpadding="0" cellspacing="0" class="tabler" style="border-bottom: 1px #6f97b1 solid;
        border-left: 1px #6f97b1 solid" width="100%">
        <tr style="background-color: #f6f6f6;">
            <td align="right" height="30" width="101">
                �û����� &nbsp;
            </td>
            <td height="30">
                <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="16px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" height="30" width="101">
                ԭ�������룺 &nbsp;
            </td>
            <td height="30">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
                <font color="Blue" >��ʼ��������Ϊ��123456</font> </td>
        </tr>
        <tr style="background-color: #f6f6f6;">
            <td align="right" height="30" width="101">
                ���������룺 &nbsp;
            </td>
            <td height="30">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" height="30" width="101">
                ȷ���������룺&nbsp;
            </td>
            <td height="30">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" height="20" style="background-color: #e6f7ff;">
                &nbsp;
            </td>
            <td align="left" height="20" style="background-color: #e6f7ff;">
                <asp:ImageButton ID="btnSave" runat="server" CssClass="button" ImageUrl="../../images/save.gif"
                    OnClientClick="return yjhkk() ;" OnClick="btnSave_Click"></asp:ImageButton>
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>