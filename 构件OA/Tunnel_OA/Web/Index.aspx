<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" MasterPageFile="~/MasterPage.master"
    Inherits="Index" %>

<%@ Register Src="N_UserContrl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="N_UserContrl/Right.ascx" TagName="Right" TagPrefix="uc2" %>
<%@ Register Src="N_UserContrl/Left.ascx" TagName="Left" TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            font-size: 12px;
            background-color: #f2f3f4;
        }
        #listtable
        {
            border: 1px #578daf solid;
        }
        #listtable #listtablemenu
        {
            border-bottom: 1px #578daf solid;
            font-weight: bold;
            color: #0276a5;
        }
        #listtable #listtablebottom
        {
            border-top: 1px #578daf solid;
            font-weight: bold;
            color: #0276a5;
        }
        #daiban
        {
            background: url(images/r_g_01.gif) repeat-x;
        }
    </style>

    <script type="text/javascript">
        var frameheight = 584;
        function tourl(m_id, url) {
            $.get("javascript/updatemessage.ashx?mid=" + m_id, null, null);
            window.location.href = url;
        }
        function show(obj, img) {
            var objt = document.getElementById(obj);
            if (objt.style.display == 'none') {
                img.src = 'images/listtableicon-down.gif';
                objt.style.display = '';
            } else {
                img.src = 'images/listtableicon.gif';
                objt.style.display = 'none';
            }
        }
      
    </script>

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td colspan="2" align="center" valign="middle">
                <table width="99%" id="listtable" style="border-bottom:0px #578daf solid;" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(images/r_bg01.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="2%" align="left">
                                        <img src="images/listtableicon.gif" id="img1" width="20" height="26" onclick="show('daibanmenu',this)"
                                            style="cursor: pointer" />
                                    </td>
                                    <td width="89%" align="left" style="cursor: pointer" onclick="show('daibanmenu',img1)">
                                        待办事项(<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>)
                                    </td>
                                    <td width="9%">
                                        <a style="color: #0276a5; text-decoration: none" href="/MessageList.aspx">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="daibanmenu" style="display: none">
                        <td height="190" valign="top" bgcolor="#FFFFFF">
                            <asp:Repeater ID="Repeater5" runat="server">
                                <ItemTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="daiban">
                                        <tr>
                                            <td width="4%" height="27">
                                                &nbsp;
                                                <img src="images/b_icon02.gif" width="9" height="9" />
                                            </td>
                                            <td width="96%" align="left">
                                                <a href="#" onclick="tourl('<%#Eval("m_id")%>','<%#Eval("m_url")%>')">
                                                    <%#Eval("m_title") %></a>
                                                <%#Eval("m_time") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background: url(images/r_bg02.gif) repeat-x">
                                <tr>
                                    <td height="26" id="listtablemenu" style="background: url(images/r_bg01.gif) repeat-x">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="2%" align="left">
                                                    <img src="images/listtableicon.gif" id="img2" width="20" height="26" onclick="show('xiaoxi',this)"
                                                        style="cursor: pointer" />
                                                </td>
                                                <td width="89%" align="left" onclick="show('xiaoxi',img2)" style="cursor: pointer">
                                                    <!-- -->
                                                    站内消息(<span style="color: red"><%=Count %></span>)
                                                </td>
                                                <td width="9%">
                                                    <a style="color: #0276a5; text-decoration: none" href="/N_Exchange/N_Message/N_MessageReceive.aspx">
                                                        [更多]</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="xiaoxi" style="display: none">
                                    <td align="left">
                                        <table style="border-bottom:1px #578daf solid;" width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="190" valign="top" bgcolor="#FFFFFF">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="daiban">
                                                        <asp:Repeater ID="Repeater1" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td width="4%" height="27">
                                                                        &nbsp;
                                                                        <img src="images/b_icon02.gif" width="9" height="9" />
                                                                    </td>
                                                                    <td width="96%" align="left">
                                                                        <a href="/N_Exchange/N_Message/N_MessageView.aspx?Id=<%#Eval("m_id") %>">新的站内消息，发件人：<%#showusername(Eval("m_from"))%>。时间：<%#Eval("m_time","{0:dd-MM hh:mm:ss}") %>
                                                                            (<span style="color: red">未读</span>) </a>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 6px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="50%" align="center" valign="top">
                <table width="98%" id="listtable" border="0" height="318" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;公司新闻
                                    </td>
                                    <td width="58">
                                        <a style="color: #0276a5; text-decoration: none" href="/N_Index/DataTypeList.aspx?typeId=0">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="289" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater11" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="" align="left">
                                                <a href="/N_Index/ViewGongGao.aspx?Id=<%#Eval("i_id")%>&TypeId=<%#Eval("i_sort")%>&lanmuId=3"
                                                    title="<%#Eval("i_Title")%>">
                                                    <%#title(Eval("i_Title"),36)%>
                                                </a><font color="red">
                                                    <%#shownew(Eval("i_time"))%></font>
                                            </td>
                                            <td width="58">
                                                <%#FormatDate(Eval("i_time").ToString())%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%" align="center" valign="top">
                <table width="98%" id="listtable" border="0" height="318" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;公司公告
                                    </td>
                                    <td width="58">
                                        <a style="color: #0276a5; text-decoration: none" href="/N_Index/DataTypeList.aspx?typeId=-1">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="289" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="" align="left">
                                                <a href="/N_Index/ViewGongGao.aspx?Id=<%#Eval("i_id")%>&TypeId=1&lanmuId=2" title="<%#Eval("i_Title")%>">
                                                    <%#title(Eval("i_Title"),34)%>
                                                </a><font color="red">
                                                    <%#shownew(Eval("i_time"))%></font>
                                            </td>
                                            <td width="58">
                                                <%#FormatDate(Eval("i_time").ToString())%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 6px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="282" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;一周安排
                                    </td>
                                    <td width="58">
                                        <a style="color: #0276a5; text-decoration: none" href="/N_Index/DataTypeList.aspx?typeId=42&lanmuId=0">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="256" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater7" runat="server" DataSourceID="SqlDataSource4">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="" align="left">
                                                <a href="/N_Index/ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=26&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),34)%>
                                                </a><font color="red">
                                                    <%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="58">
                                                <%#Eval("setdate","{0:MM-dd}") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                SelectCommand="SELECT top 10 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="42" Name="typeId" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 6px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="282" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;工作提醒
                                    </td>
                                    <td width="58">
                                        <a style="color: #0276a5; text-decoration: none" href="/N_Index/DataTypeList.aspx?typeId=43&lanmuId=0">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="256" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource1">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="" align="left">
                                                <a href="/N_Index/ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=71&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),34)%>
                                                </a><font color="red">
                                                    <%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="58">
                                                <%#Eval("setdate","{0:MM-dd}") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                SelectCommand="SELECT top 10 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="43" Name="typeId" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
