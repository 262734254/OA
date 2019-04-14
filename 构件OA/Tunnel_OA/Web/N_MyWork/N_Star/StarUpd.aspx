<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    ValidateRequest="false" CodeFile="StarUpd.aspx.cs" Inherits="SystemManage_Tunnel_MxUpd" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script>
    function yjhkk() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_Text1").value == "") {
                alert("请选择日期!");
                return false;
            }
           if (document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value == "")
             {
            alert('请输入标题！');
            document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").focus();
            fileupload(1);
            return false;

            }
  
        }
        function SelectUserWeb() {
            window.open('SelectUser.aspx', '选择用户', 'height=400, width=300,toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no')
        }
    </script>
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="StarAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        发布喜报</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="StarManage.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理喜报</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid;">
        <tr height="30px">
            <td align="right" style="background-color: #f6f6f6" onkeyup="javascrip:checkWord(200,event,'ctl00_ContentPlaceHolder1_lbl1')" class="style1">
                标题：
            </td>
            <td align="left" bgcolor="#f6f6f6">
                <asp:TextBox ID="txtTitle" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
<%--        <tr height="30px">
            <td align="right" style="background-color: #ffffff" class="style1">
                照片：
            </td>
            <td align="left" bgcolor="#ffffff">
                <asp:FileUpload ID="FileUpload1" runat="server" 
                    onpaste="return   false " />
            </td>
        </tr>--%>
        <tr height="300px">
            <td align="right" style="background-color: #f6f6f6" class="style1">
                事迹：
            </td>
            <td align="left" style="background-color: #f6f6f6">
                <FCKeditorV2:FCKeditor ID="FreeTextBox1" runat="server" BasePath="~/Vfckeditor/"
                    Height="100%">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr height="30px">
            <td align="right" style="background-color: #ffffff" class="style1">
                年月：
            </td>
            <td align="left" bgcolor="#ffffff">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                年<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                月
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 30px" bgcolor="#e6f7ff">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="提交" OnClientClick="return yjhkk();"
                    OnClick="btnSave_Click" />
                <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                    Text="返回列表" />
            </td>
        </tr>
    </table>
</asp:Content>
