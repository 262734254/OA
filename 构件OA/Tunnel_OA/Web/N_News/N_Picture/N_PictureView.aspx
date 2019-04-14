<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_PictureView.aspx.cs" Inherits="PicManage_ImgInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">

    <title>无标题页</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script >
        $(document).ready(function() {
            if ($("#imgsr img").width() > 690) {
                $("#imgsr img").width(690);
            }
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_PictureAdd.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">新增图片</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_PictureManage.aspx" onclick="resize()" class="a">
    <div style="width:73; height:27px;cursor:pointer;">图片管理</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
        <div>
            <table width="100%" border="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid;border-top:0px #6f97b1 solid;border-bottom:0px #6f97b1 solid;" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="7" bgcolor="#f6f6f6"  style="font-size:14px;border-bottom:1px #6f97b1 solid;"  height="25" align="center">
                        图片浏览</td>
                </tr>
                <tr>
                <td align="center">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">上一张</asp:LinkButton>
                    /<asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">下一张</asp:LinkButton></td>
                </tr>
            </table>
            <table style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid;border-top:0px #6f97b1 solid;border-bottom:1px #6f97b1 solid;text-align:center;"  width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="center" id="imgsr">
                        <img src="image/<%=ShowUri() %> " alt="" />
                        <div>
                    《<%=ShowName() %>》</div></td>
                </tr>
                
                <tr>
                <td  bgcolor="#e6f7ff" height="30" align="center">   

            <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="返回" />

                </td>
                </tr>
            </table>
            
         </div>
</asp:Content>