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
        <div>
            <table width="100%" border="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid;border-top:1px #6f97b1 solid;border-bottom:0px #6f97b1 solid;" cellspacing="0" cellpadding="0">
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
                        <img src="../N_News/N_Picture/image/<%=ShowUri() %> " alt="" />
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