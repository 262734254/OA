<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Center.aspx.cs" Inherits="N_Center_Center" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        <!
        -- body
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
            background: url(../images/r_g_01.gif) repeat-x;
        }
        .STYLE1
        {
            color: #FF0000;
            font-weight: normal;
        }
        -- ></style>
    <title>无标题页</title>

    <script src="../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        var frameheight = 584;
        function tourl(m_id, url) {
            $.get("../javascript/updatemessage.ashx?mid=" + m_id, null, null);
            window.location.href = "../" + url;
        }
        function show(obj, img) {
            var objt = document.getElementById(obj);
            if (objt.style.display == 'none') {
                img.src = '../images/listtableicon-down.gif';
                objt.style.display = '';
                frameheight += 175;
            } else {
                img.src = '../images/listtableicon.gif';
                objt.style.display = 'none';
                frameheight -= 175;
            }
            window.parent.document.getElementById("mainFrame").style.height = frameheight;
        }
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="50%" align="center" valign="top">
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;公司公告
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5; text-decoration: none" href="../N_Index/DataTypeList.aspx?typeId=-1">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="84%" align="left">
                                                <a href="../N_Index/ViewGongGao.aspx?Id=<%#Eval("i_id")%>&TypeId=1&lanmuId=2" title="<%#Eval("i_Title")%>">
                                                    <%#title(Eval("i_Title"),36)%>
                                                </a><font color="red">
                                                    <%#shownew(Eval("i_time"))%></font>
                                            </td>
                                            <td width="12%">
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
            <td width="50%" align="center">
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;公司新闻
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5; text-decoration: none" href="../N_Index/DataTypeList.aspx?typeId=0">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater11" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="84%" align="left">
                                                <a href="../N_Index/ViewGongGao.aspx?Id=<%#Eval("i_id")%>&TypeId=<%#Eval("i_sort")%>&lanmuId=3"
                                                    title="<%#Eval("i_Title")%>">
                                                    <%#title(Eval("i_Title"),36)%>
                                                </a><font color="red">
                                                    <%#shownew(Eval("i_time"))%></font>
                                            </td>
                                            <td width="12%">
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
            </td>
            <td align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="192" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;工程警示
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5; text-decoration: none" href="../N_Index/DataTypeList.aspx?typeId=71&lanmuId=0">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="156" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource1">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="84%" align="left">
                                                <a href="../N_Index/ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=71&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%>
                                                </a><font color="red">
                                                    <%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="12%">
                                                <%#Eval("setdate","{0:MM-dd}") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                SelectCommand="SELECT top 6 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) ORDER BY [setDate] DESC">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="71" Name="typeId" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;工程投标和中标
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="../N_Index/DataTypeList.aspx?typeId=22&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater6" runat="server" DataSourceID="SqlDataSource3">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="84%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=22&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="12%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                    SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) ORDER BY [setDate] DESC">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="22" Name="typeId" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" valign="middle">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="192" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;先锋视野
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5; text-decoration: none" href="../N_Index/DataTypeList.aspx?typeId=3&lanmuId=0">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="35%" height="156" align="center" valign="middle" id="imgsr" bgcolor="#FFFFFF">
                            &nbsp;<img src="../images/tmp_img01.gif" width="120" height="150" />
                        </td>
                        <td width="65%" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater4" runat="server" DataSourceID="SqlDataSource2">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="8%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="68%" align="left">
                                                <a href="../N_Index/ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=3&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),20)%>
                                                </a><font color="red">
                                                    <%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="14%">
                                                <%#Eval("setdate","{0:MM-dd}") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                SelectCommand="SELECT top 6 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) ORDER BY [setDate] DESC">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="3" Name="typeId" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" valign="middle">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="99%" id="listtable" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_bg01.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="2%" align="left">
                                        <img src="../images/listtableicon.gif" id="img1" width="20" height="26" onclick="show('daiban',this)"
                                            style="cursor: pointer" />
                                    </td>
                                    <td width="89%" align="left" style="cursor: pointer" onclick="show('daibanmenu',img1)">
                                        待办事项(<span class="STYLE1"><asp:Label ID="Label1" runat="server"></asp:Label></span>)
                                    </td>
                                    <td width="9%">
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
                                                <img src="../images/b_icon02.gif" width="9" height="9" />
                                            </td>
                                            <td width="96%" align="left">
                                                <a href="#" onclick="tourl('<%#Eval("m_id")%>','<%#Eval("m_url")%>')">
                                                    <%#Eval("m_title") %></a>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background: url(../images/r_bg02.gif) repeat-x">
                                <tr>
                                    <td height="26" id="listtablemenu" style="background: url(../images/r_bg01.gif) repeat-x">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="2%" align="left">
                                                    <img src="../images/listtableicon.gif" id="img2" width="20" height="26" onclick="show('xiaoxi',this)"
                                                        style="cursor: pointer" />
                                                </td>
                                                <td width="89%" align="left" onclick="show('xiaoxi',img2)" style="cursor: pointer">
                                                    <!-- -->
                                                    站内消息(<span class="STYLE1"><%=Count %></span>)
                                                </td>
                                                <td width="9%">
                                                    <a style="color: #0276a5; text-decoration: none" href="../N_Exchange/N_Message/N_MessageReceive.aspx">
                                                        [更多]</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="xiaoxi" style="display: none">
                                    <td align="left">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="190" valign="top" bgcolor="#FFFFFF">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="daiban">
                                                        <asp:Repeater ID="Repeater1" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td width="4%" height="27">
                                                                        &nbsp;
                                                                        <img src="../images/b_icon02.gif" width="9" height="9" />
                                                                    </td>
                                                                    <td width="96%" align="left">
                                                                        <a href="../N_Exchange/N_Message/N_MessageView.aspx?Id=<%#Eval("m_id") %>">您有新短消息(2010-04-01
                                                                            12:30:33) (<span class="STYLE1">未读</span>) </a>
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
            </td>
        </tr>
    </table>
</asp:Content>
