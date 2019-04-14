<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="rlzyb.aspx.cs" Inherits="N_Index_rlzyb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
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
            background: url(../../images/r_g_01.gif) repeat-x;
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
                img.src = '../../images/listtableicon-down.gif';
                objt.style.display = '';
            } else {
                img.src = '../../images/listtableicon.gif';
                objt.style.display = 'none';
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" valign="middle">
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;科室动态&nbsp;
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=41&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" colspan="2" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater12" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td align="left" colspan="2">
                                                <a href="DataTypeList.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=0">
                                                    <%#Eval("typename") %></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="Repeater6" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <%#GetLink(Eval("Id"),"41","0",Eval("Title"),Eval("userId"),Eval("readUser")) %>
                                                &nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" valign="middle">
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;人力资源管理&nbsp;
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=159&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" colspan="2" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater13" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td align="left" colspan="2">
                                                <a href="DataTypeList.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=0">
                                                    <%#Eval("typename") %></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="Repeater14" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <%#GetLink(Eval("Id"),"40","0",Eval("Title"),Eval("userId"),Eval("readUser")) %>
                                                &nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
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
            <td width="50%" align="center" valign="middle">
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
                                        &nbsp;人力资源信息&nbsp;
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=36&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater7" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td align="left" colspan="2">
                                                <a href="DataTypeList.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=0">
                                                    <%#Eval("typename") %></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <%#GetLink(Eval("Id"),"36","0",Eval("Title"),Eval("userId"),Eval("readUser")) %>
                                                &nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
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
                                        &nbsp;教育培训
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=37&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater8" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td align="left" colspan="2">
                                                <a href="DataTypeList.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=0">
                                                    <%#Eval("typename") %></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <%#GetLink(Eval("Id"),"37","0",Eval("Title"),Eval("userId"),Eval("readUser")) %>
                                                &nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
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
            <td align="center" valign="middle">        <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                        &nbsp;综合治理
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=38&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater9" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td align="left" colspan="2">
                                                <a href="DataTypeList.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=0">
                                                    <%#Eval("typename") %></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="Repeater3" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <%#GetLink(Eval("Id"),"38","0",Eval("Title"),Eval("userId"),Eval("readUser")) %>
                                                &nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" valign="middle">        <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                        &nbsp;后勤保障
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=39&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" colspan="2" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater10" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td align="left" colspan="2">
                                                <a href="DataTypeList.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=0">
                                                    <%#Eval("typename") %></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="Repeater4" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <%#GetLink(Eval("Id"),"39","0",Eval("Title"),Eval("userId"),Eval("readUser")) %>
                                                &nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
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
                        <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;合同管理&nbsp;
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=160&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" colspan="2" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater15" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td align="left" colspan="2">
                                                <a href="DataTypeList.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=0">
                                                    <%#Eval("typename") %></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="Repeater16" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <%#GetLink(Eval("Id"),"41","0",Eval("Title"),Eval("userId"),Eval("readUser")) %>
                                                &nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
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
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;参考资料&nbsp;
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=40&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" colspan="2" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater11" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td align="left" colspan="2">
                                                <a href="DataTypeList.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=0">
                                                    <%#Eval("typename") %></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="Repeater5" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <%#GetLink(Eval("Id"),"40","0",Eval("Title"),Eval("userId"),Eval("readUser")) %>
                                                &nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
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
            <asp:Parameter DefaultValue="33" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="6" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="7" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="8" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="SELECT top 18 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="32" Name="typeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
