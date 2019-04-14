<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_VotePic.aspx.cs" Inherits="N_PicVote_Manage_VotePic" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理投票信息</title>
    <link href="Css/font.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .font1
        {
            font-weight: 800;
            font-size: 14px;
            color: #a55f3c;
        }
    </style>

    <script language="JavaScript">
function correctPNG() // correctly handle PNG transparency in Win IE 5.5 & 6.
{
     var arVersion = navigator.appVersion.split("MSIE")
     var version = parseFloat(arVersion[1])
     if ((version >= 5.5) && (document.body.filters)) 
     {
       for(var j=0; j<document.images.length; j++)
       {
           var img = document.images[j]
           var imgName = img.src.toUpperCase()
           if (imgName.substring(imgName.length-3, imgName.length) == "PNG")
           {
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
             j = j-1
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
        <table cellpadding="0" cellspacing="0" border="0" width="1024px" height="975px">
            <tr valign="top" align="left">
                <td id="img_top" runat="server" height="195px">
                    <img src="../image/LOGO-ZI.png" />
                </td>
            </tr>
            <tr valign="middle" align="center" height="43px" bgcolor="#ffffff">
                <td>
                    <center>
                        <asp:Label runat="server" ID="lblTopicName" CssClass="font1"></asp:Label>
                    </center>
                </td>
            </tr>
            <tr align="center" valign="top" height="600px" bgcolor="#ffffff">
                <td>
                    <asp:DataList ID="dt_VotePic" runat="server" RepeatColumns="6" Width="935px" BorderWidth="0px"
                        OnItemCommand="dt_VotePic_ItemCommand" DataKeyField="v_id" BorderStyle="None">
                        <ItemTemplate>
                            <table cellspacing="0" cellpadding="0" width="152" align="center" border="0">
                                <tbody>
                                    <tr>
                                        <td bgcolor="#cccccc">
                                            <table cellspacing="1" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td bgcolor="#ffffff">
                                                            <table cellspacing="4" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td width="142" height="92">
                                                                            <div align="center">
                                                                                <a href="CommentPhotos.aspx?v_id=<%#Eval("v_id") %>" target="_blank">
                                                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("v_Img","../N_PicVote/Pic/_{0}") %>' 
                                                                                        Height="88px" Border="0" /></a></div>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" height="20">
                                            <div style="text-align: center">
                                                &nbsp;<asp:TextBox ID="txtName" runat="server" Text='<%# Eval("v_title") %>' Height="21px"
                                                    Width="89px"></asp:TextBox></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="1">
                                            <table width="90%">
                                                <tr style="text-align: justify">
                                                    <td>
                                                        <asp:Button runat="server" CommandName="UP" CssClass="LinkButton" CommandArgument='<%#Eval("v_id") %>'
                                                            ID="btnReName" Text="重命名" Height="20px" />
                                                    </td>
                                                    <td>
                                                        <asp:Button runat="server" CommandName="DEL" CssClass="LinkButton" CommandArgument='<%#Eval("v_id") %>'
                                                            ID="btn_DeleteVote" Text="删除" Height="20px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr align="center" valign="bottom" height="85px" bgcolor="#ffffff">
                <td>
                    <webdiyer:AspNetPager ID="ANPBYPage" runat="server" FirstPageText="首页" LastPageText="尾页"
                        NextPageText="下一页" OnPageChanged="ANPBYPage_PageChanged" PrevPageText="上一页" ShowPageIndexBox="Always"
                        SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" AlwaysShow="True"
                        PageIndexBoxType="TextBox">
                    </webdiyer:AspNetPager>
                    <br />
                </td>
            </tr>
            <tr align="center" id="divBottom" runat="server" valign="bottom" height="55px" width="1024px">
                <td align="center">
                    <center>
                        <span style="color: White">沪ICP备09099347号 版权所有:上海隧道股份盾构工程公司 Copyright ©2010 www.stec-oa.com
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
