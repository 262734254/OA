<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_PictureAdd.aspx.cs" Inherits="PicManage_ImgAdd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title>无标题页</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

 

    <script>
        function check() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtname").value == "") {
                alert('请输入图片名称！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtname").focus();
                return false;
            }
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
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_PictureAdd.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">新增图片</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_PictureManage.aspx" onclick="resize()" class="a">
    <div style="width:73; height:27px;cursor:pointer;">图片管理</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
            <tr>
                <td bgcolor="#f6f6f6" align="center" height="30">
                    名称：
                </td>
                <td bgcolor="#f6f6f6" align="left">
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td align="center">
                   年份：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="ddlYear" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td  height="30" align="center"  bgcolor="#f6f6f6">
                部门：
                </td>
                <td bgcolor="#f6f6f6" align="left">
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem>工地</asp:ListItem>
                        <asp:ListItem>会议</asp:ListItem>
                        <asp:ListItem>企业文化</asp:ListItem>                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td height="30" width="80" align="center">
                    上传图片：
                </td>
                <td align="left">
                    <asp:FileUpload ID="FileUpload1" onkeydown="event.returnValue=false; " onpaste="return   false "
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid">
                    &nbsp;
                </td>
                <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="提交" OnClientClick="return check();fileupload(0);"
                        OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
            <div runat="server" id="fileuploaddiv" style="width: 100px; height: 100px; top:0px;
        left: 330px; position: absolute; display: none">
        <img src="../../image/img/uploading.gif" style="width: 100px; height: 100px" />
    </div>
    </div>
</asp:Content>