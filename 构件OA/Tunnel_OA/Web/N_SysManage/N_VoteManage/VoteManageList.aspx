<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="VoteManageList.aspx.cs" Inherits="Vote_VoteManageList" %>

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
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="NewVote.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增投票</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="VoteManageList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        投票管理</div>
                </a>
            </td>
            <td width="74" id="Td1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="../../N_PicVote/ChangePhotos.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        整体风格</div>
                </a>
            </td>
            <td width="74" id="Td2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="../../N_PicVote/UpPhoto.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        上传票项</div>
                </a>
            </td>
                            <td width="74" id="Td5" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
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
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
        style="border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr style="background-color: #f6f6f6; font-weight: bold" height="30px">
            <td align="center">
                选择
            </td>
            <td align="center">
                发布人
            </td>
            <td align="center">
                发布范围
            </td>
            <td align="center" width="200">
                标题
            </td>
            <td align="center">
                类型
            </td>
            <td align="center">
                生效日期
            </td>
            <td align="center">
                终止日期
            </td>
            <td align="center">
                状态
            </td>
            <td align="center">
                操作
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center" height="30px" bgcolor="#ffffff">
                        <asp:CheckBox ID="CheckBox1" runat="server" ToolTip='<%#Eval("vote_Id") %>' />
                    </td>
                    <td align="center" height="30px" bgcolor="#ffffff">
                        <%#GetName(Eval("vote_userId")) %>
                    </td>
                    <td align="center" height="30px" bgcolor="#ffffff" title=<%#GetBum(Eval("vote_bumGroup")) %>>
                        <%#GetBum(Eval("vote_bumGroup")).Length > 15 ? GetBum(Eval("vote_bumGroup")).Substring(0, 12) + "..." : GetBum(Eval("vote_bumGroup"))%>
                    </td>
                    <td align="center" height="30px" bgcolor="#ffffff">
                        <a href="VoteShow.aspx?id=<%#Eval("vote_Id") %>" title="查看结果">
                            <%#Eval("vote_Title") %></a>
                    </td>
                    <td align="center" height="30px" bgcolor="#ffffff">
                        <%#Eval("vote_type").ToString()=="0"?"单选":"多选" %>
                    </td>
                    <td align="center" height="30px" bgcolor="#ffffff">
                        <%#Eval("vote_startDate","{0:d}") %>
                    </td>
                    <td align="center" height="30px" bgcolor="#ffffff">
                        <%#Eval("vote_endDate","{0:d}") %>
                    </td>
                    <td align="center" height="30px" bgcolor="#ffffff">
                        <%#Eval("vote_state").ToString() == "0"?"开启":"关闭" %>
                    </td>
                    <td align="center" height="30px" bgcolor="#ffffff">
                        <a href="?state=<%#Eval("vote_state")%>&id=<%#Eval("vote_Id") %>">
                            <%#Eval("vote_state").ToString() == "0" ? "关闭" : "开启"%>
                        </a><a href="VoteItemsAdd.aspx?id=<%#Eval("vote_Id") %>">修改候选项 </a><a href="VoteUpd.aspx?id=<%#Eval("vote_Id") %>">
                            修改主题 </a><%--<a href="?top=<%#Eval("vote_top")%>&id=<%#Eval("vote_Id") %>">
                                <%#Eval("vote_top").ToString() == "0" ? "首页显示" : "取消首页显示"%>
                            </a>--%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC"
        style="border: 1px #6f97b1 solid; border-top: none">
        <tr class="di">
            <td align="left" height="30">
                <asp:Button ID="Button1" runat="server" Text="批量删除" CssClass="button" OnClick="Button1_Click"
                    OnClientClick="return confirm('是否删除此条记录？')" />
            </td>
            <td align="right">
                <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                    <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                </cc1:MTCPager>
            </td>
        </tr>
    </table>
</asp:Content>