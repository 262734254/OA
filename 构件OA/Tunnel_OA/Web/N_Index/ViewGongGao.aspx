<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewGongGao.aspx.cs" Inherits="N_Index_ViewGongGao" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title>无标题页</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF"  style="border-collapse:collapse;border-bottom: 1px #6f97b1 solid;
        border-left: 1px #6f97b1 solid;border-right:1px #6f97b1 solid;border-top: 1px #6f97b1 solid">     

        <tr>
            <td style="border-left:0px;border-right:0px;border-top:0px" height="35" colspan="2" align="center" class="tou">
                <b><span id="Label1" style="font-size: 16px"><%--标题：--%><%=i_title%></span></b>
            </td>
        </tr>
        <tr>
            <td style="border-left:0px;border-right:0px" align="center" colspan="2" height="35">
                发布人：<%=i_user%>
                发布时间：<%=i_time%>
            </td>
        </tr>
        
        <%--<tr style="display: <%=str %>">
            <td style="border-left:0px;border-right:0px" align="center">
                <a href="../upload/UpGongGaoImage/<%=imageName %>">
                    <img src="../upload/UpGongGaoImage/<%=imageName %>" width="160" height="160" border="0" /></a>
            </td>
        </tr>--%>
           
        <tr>
            <td style="border-left:0px;border-right:0px;" id="td_countent" colspan="2" align="left" style="padding: 10px" valign="top"
                height="300">
                <%=i_content%>
                <br />
                <br />
                <%=fujian%>
            </td>
        </tr>       
        <tr>
            <td style="border:0px;" height="25" align="center" colspan="2" class="di">
                <asp:Button ID="Button4" CssClass="button" runat="server" Text="标记已读" OnClick="Button4_Click" />
            </td>
        </tr>
        <tr>
        <td colspan="2" style="height:5px"></td>
        </tr>
    </table>
    
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-left: 1px #6f97b1 solid;border-top: 0px #6f97b1 solid;border-right: 1px #6f97b1 solid;border-bottom:1px #6f97b1 solid">
        <tr>
            <td colspan="2">
                <table style="border-collapse:collapse;" width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td bgcolor="#f6f6f6" colspan="7" height="30" align="center">
                            查看评论信息
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="border:0px;" colspan="2">
                <table width="100%" border="1" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC"
                    bordercolorlight="#c1c1c1" bordercolordark="#FFFFFF" style="border-collapse:collapse;border-top: 1px #6f97b1 solid;
                    border-bottom: 1px #6f97b1 solid;border-right:0px #6f97b1 solid;border-left:0px #6f97b1 solid">
                    <tr height="20">
                        <td  style="border-left:0px;border-top:0px" width="8%" align="center" bgcolor="#e8e8e8">
                            <strong>用户</strong>
                        </td>
                        <td style="border-top:0px" width="55%" align="center" bgcolor="#e8e8e8">
                            <strong>内容</strong>
                        </td>
                        <td style="border-top:0px;border-right:0px" width="17%" align="center" bgcolor="#e8e8e8" height="20">
                            <strong>时间</strong>
                        </td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr height="25" bgcolor="#FFFFFF">
                                <td align="center" style="border-left:0px;" bgcolor="#FFFFFF">
                                    <%#ShowUserName(Eval("UserId").ToString())%>
                                </td>
                                <td bgcolor="#FFFFFF" align="left">
                                    <%#Eval("Content")%>
                                </td>
                                <td align="center" style="border-right:0px;" bgcolor="#FFFFFF">
                                    <%#Eval("SetDate")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr height="30">
                        <td style="border:0px" align="center" class="di" colspan="3">
                            <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                                <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                            </cc1:MTCPager>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td colspan="2" style="height:5px"></td>
        </tr>
        <tr>
            <td align="right">
                评论信息：
            </td>
            <td align="left">
                <asp:TextBox ID="btTitle" runat="server" TextMode="MultiLine" Rows="6" Width="500"
                    onkeyup="javascrip:checkWord(800,event,'lbl1')"></asp:TextBox>
                <div id="lbl1" name="lbl" size="12px" class="lblzifu">
                    0/800</div>
            </td>
        </tr>
        <tr>
            <td align="left" class="">
            </td>
            <td style="height:30px">
                <asp:Button ID="Button3" runat="server" Text="发表评论" CssClass="button" OnClick="Button3_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
