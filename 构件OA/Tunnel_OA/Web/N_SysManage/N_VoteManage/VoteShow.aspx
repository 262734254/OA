<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="VoteShow.aspx.cs" Inherits="Vote_VoteShow" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
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
    <table width="100%">
        <tr style="background-image: url(../../image/etitle.jpg); background-repeat: no-repeat">
            <td class="tou">
                <img src="../../image/reddot.gif" width="12px" />
                投票结果 --
                <%=voteTitle %>
            </td>
        </tr>
        <tr>
            <td>
                <%=voteMark %>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("iVote_Title") %>
                                </td>
                                <td>
                                    <img width="<%#GetBai(Eval("ivote_Count"),400)%>" height="10px" src="../../image/vote_bg.gif" /><%#GetBai(Eval("ivote_Count"),100)%>%
                                </td>
                                <td>
                                    <%#Eval("ivote_Count")%>票
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr style="background-image: url(../../image/etitle.jpg); background-repeat: no-repeat">
            <td style="font-size: 15px">
                <img src="../../image/info.png" width="12px" />
                发表留言
            </td>
        </tr>
        <tr align="center">
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="115px" TextMode="MultiLine" Width="387px"></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td>
                <asp:Button ID="Button1" CssClass="button" runat="server" Text="评论" OnClick="Button1_Click" />
                &nbsp;
            </td>
        </tr>
        <tr style="background-image: url(../../image/etitle.jpg); background-repeat: no-repeat">
            <td style="font-size: 15px">
                <img src="../../image/chakan.png" width="12px" />
                查看留言
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="left">
                                    <img src="../../image/liuyan.gif" width="12px" />
                                    <%#GetName(Eval("vate_userId"))%>
                                </td>
                                <td align="right">
                                    <%#Eval("vate_Date")%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <%#Eval("vote_Message")%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <img src="../../image/line.jpg" width="700" height="1px" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td class="di" align="right">
                <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                    <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                </cc1:MTCPager>
            </td>
        </tr>
    </table>
</asp:Content>