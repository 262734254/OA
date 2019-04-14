<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommentPhotos.aspx.cs" Inherits="CommentPhotos" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=TitleName %></title>
    <link href="Css/font.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function disImage(image) {
            image.src = "validate.aspx?id=" + Math.random();
        }
        function Isnull() {
            var Yourword = document.getElementById("txtYourword").value;
            Yourword = Yourword.replace(/(^\s*)|(\s*$)/g, " ");
            Yourword = Yourword.replace(/(^\s*)|(\s*$)/g, "");
            if (Yourword.length > 0) {
                return true;
            } else {
                alert("评论内容不能为空或者空格!");
                return false;
            }
        }
    </script>
<script language="JavaScript">
    function correctPNG() // correctly handle PNG transparency in Win IE 5.5 & 6.
    {
        var arVersion = navigator.appVersion.split("MSIE")
        var version = parseFloat(arVersion[1])
        if ((version >= 5.5) && (document.body.filters)) {
            for (var j = 0; j < document.images.length; j++) {
                var img = document.images[j]
                var imgName = img.src.toUpperCase()
                if (imgName.substring(imgName.length - 3, imgName.length) == "PNG") {
                    var imgID = (img.id) ? "id='" + img.id + "' " : ""
                    var imgClass = (img.className) ? "class='" + img.className + "' " : ""
                    var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' "
                    var imgStyle = "display:inline-block;" + img.style.cssText
                    if (img.align == "left") imgStyle = "float:left;" + imgStyle
                    if (img.align == "right") imgStyle = "float:right;" + imgStyle
                    if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle
                    var strNewHTML = "<span " + imgID + imgClass + imgTitle
             + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
             + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
             + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>"
                    img.outerHTML = strNewHTML
                    j = j - 1
                }
            }
        }
    }
    window.attachEvent("onload", correctPNG);
</script>
</head>
<body bgcolor="#e6e6e6">
    <form id="form1" runat="server">
    <center>
        <table cellspacing="0" cellpadding="0" width="1024px" height="195px" border="0">
            <tr align="left" valign="top">
                <td id="img_top" runat="server">
                    <img src="../image/LOGO-ZI.png" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </center>
    <center>
        <table width="1024px" bgcolor="#ffffff">
            <tr>
                <td>
                    <br />
                    <table width="90%">
                        <tr align="center">
                            <td>
                                <table cellpadding="0" style="text-align: center; background-color: White; font-size: 12px;
                                    color: Gray;">
                                    <tr align="center">
                                        <td colspan="2" bgcolor="#cccccc">
                                            <table width="536px" cellspacing="1" cellpadding="0" border="0">
                                                <tr>
                                                    <td bgcolor="#ffffff">
                                                        <table width="535px" cellspacing="1" cellpadding="0" border="0">
                                                            <tr align="center" valign="bottom">
                                                                <td>
                                                                    <asp:Image ImageUrl="" ID="imgPic" runat="server" Width="535px" /></td></tr></table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            标题：<asp:Label ID="lblTitle" runat="server" Text="标题"></asp:Label>&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; 作者：<asp:Label
                                                ID="lblAuthor" runat="server" Text="作者"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="btnup" Text="上一张" runat="server" OnClick="lbUp_Click" BorderStyle="NotSet"></asp:LinkButton>
                                            <asp:Label ID="lbltopid" runat="server" Text="" Style="display: none"></asp:Label>
                                            &nbsp;&nbsp;<asp:LinkButton ID="btndown" Text="下一张" runat="server" OnClick="lbDown_Click"></asp:LinkButton>
                                            <asp:Label ID="lbldownid" runat="server" Text="" Style="display: none"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblRemark" runat="server" Text="备注"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0" leftmargin="0" topmargin="0">
                                    <tr align="left">
                                        <td height="30">
                                            <hr />
                                            <b>评论</b>
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rptShow" runat="server">
                                        <ItemTemplate>
                                            <tr valign="top">
                                                <td height="30px">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td width="1">
                                                                    <img src="../image/tx.gif" alt="" />&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblUser" runat="server" Text='<%#Eval("m_name")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDate" runat="server" Text=' <%#Eval("lw_SetDate")%>'>
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="lblWord" runat="server" Text=' <%# Eval("lw_Content")%>'></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td>
                                            <hr />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <webdiyer:AspNetPager ID="ANPBYPage" runat="server" FirstPageText="首页" LastPageText="尾页"
                                    NextPageText="下一页" OnPageChanged="ANPBYPage_PageChanged" PrevPageText="上一页" ShowPageIndexBox="Always"
                                    SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" AlwaysShow="True"
                                    PageIndexBoxType="TextBox">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                <table width="90%">
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="Label3" Text="您的评论：" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:TextBox ID="txtYourword" Text="" runat="server" Width="619px" TextMode="MultiLine"
                                                Height="120px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td height="53">
                                            <asp:Button ID="button" runat="server" Text="发送" CssClass="LinkButton" OnClientClick="return Isnull()"
                                                OnClick="button_Click" Width="112px" Height="20px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="1024px" style="margin-bottom: 0; padding-bottom: 0">
            <tr align="center" id="divBottom" runat="server" valign="bottom" height="55px">
                <td>
                    <center>
                        <span style="color: black">沪ICP备09099347号 版权所有:上海隧道股份盾构工程公司 Copyright ©2010 www.stec-oa.com
                            All Rights Reserved.&nbsp;
                            <br />
                            技术支持:上海玉喜科技信息公司</span>
                    </center>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
