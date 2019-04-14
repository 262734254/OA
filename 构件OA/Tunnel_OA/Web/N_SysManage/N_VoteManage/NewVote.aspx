<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="NewVote.aspx.cs" Inherits="Vote_NewVote" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script>
        function yjhkk() {
            var b = true;
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value == "") {
                alert('请输入投票主题！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").focus();
                b = false;
            }
            var d1 = document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value;
            var d2 = document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value;
            if (d1 != "" && d2 != "") {
                d1Arr = d1.split('-');
                d2Arr = d2.split('-');
                v1 = new Date(d1Arr[0], d1Arr[1], d1Arr[2]);
                v2 = new Date(d2Arr[0], d2Arr[1], d2Arr[2]);
                if (v1 >= v2) {
                    alert("结束日期不能小于等于开始日期!")
                    b = false;
                }
                return b;
            } 
        }
        function SelectUserWeb() {
            window.open('SelectUser.aspx', '选择部门', 'height=400, width=300,toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no')
        }
        function Clear() {
            document.getElementById("ctl00_ContentPlaceHolder1_TextbumName").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_TextbumId").value = "";
        }
        
    </script>

    <style type="text/css">
        #TextbumName
        {
            height: 94px;
            width: 342px;
        }
    </style>
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="NewVote.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增投票</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="VoteManageList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        投票管理</div>
                </a>
            </td>
                <td width="74" id="Td1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../../N_PicVote/ChangePhotos.aspx"class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        整体风格</div>
                </a>
            </td>
                <td width="74" id="Td2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../../N_PicVote/UpPhoto.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        上传票项</div>
                </a>
            </td>
                            <td width="74" id="Td3" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../../N_PicVote/Manage_VotePic.aspx" class="a"  target=_blank>
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理票项</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="1" align="center" cellpadding="0" cellspacing="1" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF" style="background-image: ..image/tpg_bg.jpg">
        <tr>
            <td height="25" align="right" style="height: 30px; background-color: #ffffff">
                发布范围（部门）：
            </td>
            <td height="17" align="left">
                <textarea id="TextbumName" readonly="readonly" runat="server"></textarea>
                <input id="Button1" type="button" class="button" value="添加" onclick="SelectUserWeb();" />
                <input id="Button2" type="button" value="清空" class="button" onclick="Clear();" />
                <input id="TextbumId" type="hidden" runat="server">
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="height: 30px; background-color: #ffffff">
                投票主题：
            </td>
            <td height="17" align="left">
                &nbsp;<asp:TextBox ID="txtTitle" runat="server" Width="341px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="height: 30px; background-color: #ffffff">
                投票详细说明：
            </td>
            <td height="17" align="left">
                &nbsp;<asp:TextBox ID="txtText" runat="server" TextMode="MultiLine" Width="342px"
                    Height="54px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="height: 30px; background-color: #ffffff">
                类型：
            </td>
            <td align="left">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Text="单选" Value="0">单选</asp:ListItem>
                    <asp:ListItem Text="多选" Value="1">多选</asp:ListItem>
                </asp:DropDownList>
                可选最多候选项数：<asp:TextBox ID="TextBox3" runat="server" Text="1" Width="49px">1</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="height: 30px; background-color: #ffffff">
                有效期：
            </td>
            <td align="left" height="25">

                <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>

                生效日期：<asp:TextBox ID="TextBox1" class="Wdate" runat="server" onClick="WdatePicker()"></asp:TextBox>
                为空则立即生效
                <br />
                终止日期：<asp:TextBox ID="TextBox2" class="Wdate" runat="server" onClick="WdatePicker()"></asp:TextBox>
                为空则手动终止
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="height: 30px; background-color: #ffffff">
                是否发送通知:
            </td>
            <td align="left" height="25">
                <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" />
            </td>
        </tr>
        <tr class="di">
            <td colspan="2" align="center" style="height: 31px">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClientClick="return yjhkk();"
                    CssClass="button" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>