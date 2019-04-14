<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="VoteList.aspx.cs" Inherits="Vote_VoteList" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
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
             <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a class="a" href="../../N_PicVote/Vote_ShowAllPic.aspx" target="_blank"> 
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        图片投票</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
        style="border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid;">
        <tr style="background-color: #f6f6f6; font-weight: bold" height="30px">
            <td align="center" width="5%">
                序号
            </td>
            <td align="center" width="65%">
                标题
            </td>
            <td align="center" width="10%">
                发布日期
            </td>
            <td align="center" width="10%">
                发布人
            </td>
            <td align="center" width="10%">
                操作
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr height="30px" align="center" bgcolor="#ffffff">
                    <td width="5%">
                        <%#Eval("Vote_Id") %>
                    </td>
                    <td width="65%">
                        <a href="vote.aspx?id=<%#Eval("vote_Id") %>" title="点击投票">
                            <%#Eval("vote_Title") %></a>
                    </td>
                    <td width="10%">
                        <%#Eval("vote_startDate","{0:d}")%>
                    </td>
                    <td width="10%">
                        <%#GetName(Eval("vote_userId"))%>
                    </td>
                    <td width="10%">
                        <a href="VoteShow.aspx?id=<%#Eval("vote_Id") %>">查看结果</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr align="right">
            <td height="30" colspan="5" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid">
                <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                    <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                </cc1:MTCPager>
            </td>
        </tr>
    </table>
</asp:Content>