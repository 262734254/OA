<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="aqgl.aspx.cs" Inherits="N_Index_aqgl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title></title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            font-size: 12px;
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
    </style>

    <script type="text/javascript">
        function show(obj, img) {
            var objt = document.getElementById(obj);
            if (objt.style.display == 'none') {
                img.src = '../images/listtableicon-down.gif';
                objt.style.display = '';
            } else {
                img.src = '../images/listtableicon.gif';
                objt.style.display = 'none';
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="50%" align="center" valign="top">
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp; 一周安排
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=42&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=42&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
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
                                        &nbsp;安全管理
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=16&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=16&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
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
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;安全通告
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=17&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource3">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=17&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;从业人员信息
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=18&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater4" runat="server" DataSourceID="SqlDataSource4">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=18&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
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
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;项目管理
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=63&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater7" runat="server" DataSourceID="SqlDataSource7">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=63&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;参考资料
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=43&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater8" runat="server" DataSourceID="SqlDataSource8">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=43&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="42" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="16" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="17" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="18" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="63" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="43" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
