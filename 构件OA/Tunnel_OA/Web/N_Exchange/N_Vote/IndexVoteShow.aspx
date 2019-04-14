<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndexVoteShow.aspx.cs" Inherits="Vote_IndexVoteShow" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>投票结果</title>
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="547px">
            <tr style="background-image: url(../../image/etitle.jpg)">
                <td class="tou3" align="center">
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
                <table width=500px style="font-size:15px">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td width=200px>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("iVote_Title") %>
                                </td>
                                <td>
                                        <img width="<%#GetBai(Eval("ivote_Count"),200)%>" height="10px" src="../../image/vote_bg.gif" /><%#GetBai(Eval("ivote_Count"),100)%>%
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
            <tr style="background-image: url(../../image/etitle.jpg)">
                <td style="font-size:15px">
                    <img src="../../image/info.png" width="12px" />
                    发表留言
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="95px" TextMode="MultiLine" 
                        Width="298px"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="Button1" CssClass="button" runat="server" Text="评论" OnClick="Button1_Click" />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input onclick="window.close();" class="button" type="button" value="关闭" />
                </td>
            </tr>
            <tr style="background-image: url(../../image/etitle.jpg)">
                <td style="font-size:15px">
                    <img src="../../image/chakan.png" width="12px" />
                    查看留言
                </td>
            </tr>
            <tr>
                <td>
                    <table width="500px">
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
                                        <img src="../image/line.jpg" width="547" height="1px" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                        <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                    </cc1:MTCPager>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <table>
    </table>
    </form>
</body>
</html>
