<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="VoteShow.aspx.cs" Inherits="Vote_VoteShow" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:content runat="server" id="content1" contentplaceholderid="Header"> </asp:content>
<asp:content runat="server" id="content2" contentplaceholderid="ContentPlaceHolder1">
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="VoteList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        投票列表</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table width="100%">
            <tr style="background-image: url(../../image/etitle.jpg);background-repeat:no-repeat">
                <td  class="tou">
                    <img src="../../image/reddot.gif" width="12px" />
                    <font color="white">
                    投票结果 --
                    <%=voteTitle %></font>
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
            <tr style="background-image: url(../../image/etitle.jpg);background-repeat:no-repeat">
                <td style="font-size:15px">
                    <img src="../../image/info.png" width="12px" />
                    <font color="white">
                    发表留言</font>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="115px" TextMode="MultiLine" 
                        Width="387px"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="Button1" CssClass="button" runat="server" Text="评论" OnClick="Button1_Click" />
                    &nbsp;</td>
            </tr>
            <tr style="background-image: url(../../image/etitle.jpg);background-repeat:no-repeat">
                <td style="font-size:15px">
                    <img src="../../image/chakan.png" width="12px" />
                    <font color="white">
                    查看留言</font>
                </td>
            </tr>
            <tr>
                <td>
                    <table >
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
                                        <img src="../../image/line.jpg" width="100%" height="1px" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr class=di align="right">
                <td>
                    <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                        <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                    </cc1:MTCPager>
                </td>
            </tr>
        </table>
</asp:content>
